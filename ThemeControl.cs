using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Threading;
using System.Globalization;

namespace CSGO_Theme_Control
{
    public partial class ThemeControl : Form
    {

        private bool IsEnabled              = true;
        private bool BootOnStart            = false;
        private bool shouldChangeDeskTheme  = false;
        private bool shouldChangeGameTheme  = false;
        private bool registryBootWritten    = false;
        private string DesktopThemePath     = null;
        private string GameThemePath        = null;
        private string DesktopThemeName     = null;
        private string GameThemeName        = null;
        private const string EXE_NAME       = "CSGO_Theme_Control.exe";
        private const string APP_NAME       = "CSGO_THEME_CONTROL";
        private const string VERSION_NUM    = "0.9.0.0";
        private Thread t;
        private RegistryKey rk              = Registry.CurrentUser.OpenSubKey(
            "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        [DllImport("user32.dll")]
        private static extern int FindWindow(
            string      lpClassName,
            string      lpWindowName
        );

        [DllImport("user32.dll")]
        private static extern int SendMessage(
            int         hWnd,
            int         Msg,
            int         wParam,
            int         lParam
        );

        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_CLOSE      = 0xF060;

        //Used to alt-tab back into the CSGO process after changing themes.
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd); 

        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        private static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        public ThemeControl()
        {
            InitializeComponent();
            this.NotificationIcon.Icon = new System.Drawing.Icon(this.getExeDirectory() + "resources\\Gaben_santa.ico");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //rundll32.exe %SystemRoot%\system32\shell32.dll,Control_RunDLL %SystemRoot%\system32\desk.cpl desk,@Themes /Action:OpenTheme /file:"C:\Windows\Resources\Themes\aero.theme"
            //rundll32.exe %SystemRoot%\system32\shell32.dll,Control_RunDLL %SystemRoot%\system32\desk.cpl desk,@Themes /Action:OpenTheme /file:"C:\Windows\Resources\Ease of Access Themes\hcwhite.theme"
            this.ReadConfig();
            chkEnabled.Checked = this.IsEnabled;

            if (rk.GetValue(ThemeControl.APP_NAME) == null) 
                this.registryBootWritten = false;
            else 
                this.registryBootWritten = true;

            this.BootOnStart            = registryBootWritten;
            this.chkStartOnBoot.Checked = registryBootWritten;

            this.shouldChangeDeskTheme  = this.csgoIsRunning();

            if (this.shouldChangeDeskTheme)
            {
                if (this.GameThemePath != null)
                    this.changeTheme(this.GameThemePath);
                else
                    this.changeTheme(true);
            }

            this.shouldChangeGameTheme  = !this.shouldChangeDeskTheme;

            t = new Thread(CheckIfRunningForever){ IsBackground = true };
            t.Start();

        }

        private void ThemeControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.t != null)
            {
                if (this.t.IsAlive)
                {
                    this.t.Interrupt();
                    this.t.Abort();
                }
            }

            this.WriteConfig();
            if (this.BootOnStart)
            {
                //TODO: Check if this is even really required as theoretically this key should always already be created if the checkbox is checked.
                if (!registryBootWritten)
                    this.createBootStartup();
            }
        }

        private void log(string s)
        {
            this.txtStatus.Text += s + "\n";
        }

        private void log(params string[] s)
        {
            foreach (string cur in s)
            {
                this.txtStatus.Text += cur + "\n";
            }
        }

        private void logStatus()
        {
            this.txtStatus.Text = "";
            string desktopT = (this.DesktopThemePath == null) ? "Aero" : this.DesktopThemeName;
            string gameT    = (this.GameThemePath == null) ? "High Contrast White" : this.GameThemeName;

            this.log(
                "Version:\t\t" + ThemeControl.VERSION_NUM,
                "Is Enabled:\t" + this.IsEnabled,
                "Boot on start:\t" + this.BootOnStart,
                "Desktop theme:\t" + desktopT,
                "In-game theme:\t" + gameT
            );
        }

        private void createCrashDump(string context)
        {
            StreamWriter sw = new StreamWriter(this.getExeDirectory() + "CSGO_THEME_CONTROL_" + DateTime.Now.ToString() + ".crashdumplog");
            try
            {
                sw.WriteLine("[CRASH DUMP LOG]");
                sw.WriteLine("[DATE]{" + DateTime.Now + "}");
                sw.WriteLine("[VERSION]{" + ThemeControl.VERSION_NUM + "}");
                sw.WriteLine("[CONTEXT]{");
                sw.Write(context + "\n}");
            }
            catch (Exception e)
            {
                throw new Exception("Something incredibly wrong has happened and the program must terminate. Context follows:\n" + e.Message);
            }
            finally
            {
                sw.Close();
            }
        }

        private void createBootStartup()
        {
            this.rk.SetValue(ThemeControl.APP_NAME, Application.ExecutablePath.ToString());
        }

        private void deleteBootStartup()
        {
            this.rk.DeleteValue(ThemeControl.APP_NAME, false); 
        }

        private void ReadConfig()
        {
            string programExePathFolder = this.getExeDirectory();

            StreamReader f = new StreamReader(programExePathFolder + "cfg\\Config.ThemeControlCfg");
            try
            {
                while (!f.EndOfStream)
                {
                    string line = f.ReadLine();
                    if (!line.StartsWith("//"))
                    {
                        List<string> split = line.Split('"')
                                                 .Select((element, index) => index % 2 == 0  // If even index
                                                       ? element.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)  // Split the item
                                                       : new string[] { element })  // Keep the entire item
                                                 .SelectMany(element => element).ToList();

                        for (int i = 0; i < split.Count; i++)
                        {
                            if (i != split.Count - 1)   //Must not be the last element in the list
                            {
                                if (split[i].StartsWith("\t"))
                                {
                                    split[i] = split[i + 1];
                                    split.Remove(split[i + 1]);
                                }
                            }
                        }


                        for (int i = 0; i < split.Count; i++)
                        {
                            var word = split[i].ToLower();
                            if (word.Equals("isenabled"))
                            {
                                try
                                {
                                    this.IsEnabled = Convert.ToBoolean(split[i + 1].ToLower());
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    log("ERROR: CFG is in an invalid format and cannot be read.");
                                    this.IsEnabled = false;
                                }
                            }
                            else if (word.Equals("desktopthemepath"))
                            {
                                try
                                {
                                    this.DesktopThemePath = split[i + 1].ToLower();
                                    string[] splitTheme = this.DesktopThemePath.Split('\\');
                                    this.DesktopThemeName = this.UpperCaseFirstChar(splitTheme[splitTheme.Length - 1].Replace(".theme", ""));
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    log("ERROR: CFG is in an invalid format and cannot be read.");
                                }
                            }
                            else if (word.Equals("gamethemepath"))
                            {
                                try
                                {
                                    this.GameThemePath = split[i + 1].ToLower();
                                    string[] splitTheme = this.GameThemePath.Split('\\');
                                    this.GameThemeName = this.UpperCaseFirstChar(splitTheme[splitTheme.Length - 1].Replace(".theme", ""));
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    log("ERROR: CFG is in an invalid format and cannot be read.");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                this.createCrashDump(e.Message);
            }
            finally
            {
                f.Close();
            }

            this.logStatus();
        }

        private void WriteConfig()
        {
            string programExePathFolder = this.getExeDirectory();

            StreamWriter sw = new StreamWriter(programExePathFolder + "cfg\\Config.ThemeControlCfg");
            try
            {
                sw.WriteLine("//Note to those reading:\n//Modifying this file could result in the breaking of your config.");
                sw.WriteLine("IsEnabled \t\t\t\"" + this.IsEnabled.ToString() + "\"");


                if (this.DesktopThemePath != null)
                {
                    sw.WriteLine("DesktopThemePath \t\"" + this.DesktopThemePath + "\"");
                }
                if (this.GameThemePath != null)
                {
                    sw.WriteLine("GameThemePath \t\t\"" + this.GameThemePath + "\"");
                }
            }
            catch (Exception e)
            {
                createCrashDump(e.Message);
            }
            finally
            {
                sw.Close();
            }
        }

        private string getExeDirectory()
        {
            string[] programExePath_split = System.Reflection.Assembly.GetEntryAssembly().Location.Split('\\');
            for (int i = 0; i < programExePath_split.Length; i++)
            {
                if (programExePath_split[i].Equals(ThemeControl.EXE_NAME))
                {
                    programExePath_split[i] = "";
                }
            }

            return String.Join("\\", programExePath_split);
        }

        private void CheckIfRunningForever()
        {
            for (;;)
            {
                if (IsEnabled)
                {
                    bool running = this.csgoIsRunning();
                    if (running)
                    {
                        if (this.shouldChangeGameTheme)
                        {
                            if (this.GameThemePath == null)
                            {
                                this.changeTheme(true);
                            }
                            else
                            {
                                this.changeTheme(this.GameThemePath);
                            }
                            this.shouldChangeGameTheme = false;
                            this.shouldChangeDeskTheme = true;

                            System.Threading.Thread.Sleep(500); //Wait so we don't alt tab to fast.
                            altTabIntoCSGO();
                        }
                    }
                    else
                    {
                        if (this.shouldChangeDeskTheme)
                        {
                            if (this.DesktopThemePath == null)
                            {
                                this.changeTheme(false);
                            }
                            else
                            {
                                this.changeTheme(this.DesktopThemePath);
                            }
                            this.shouldChangeGameTheme = true;
                            this.shouldChangeDeskTheme = false;
                        }
                    }
                
                }
                try
                {
                    System.Threading.Thread.Sleep(5000);
                }
                catch (System.Threading.ThreadInterruptedException)
                {
                    //Do nothing, only a first chance exception and the program closes immediately after catching this anyway.
                }
            }
        }

        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            this.IsEnabled = chkEnabled.Checked;
            if (!this.IsEnabled)
            {
                if (t != null)
                {
                    t.Abort();
                }
            }
            else
            {
                if (t != null)
                {
                    if (!t.IsAlive)
                    {
                        t = new Thread(CheckIfRunningForever) { IsBackground = true };
                        t.Start();
                    }
                }
            
            }
            this.logStatus();
        }

        private void chkStartOnBoot_CheckedChanged(object sender, EventArgs e)
        {
            this.BootOnStart = chkStartOnBoot.Checked;
            if (BootOnStart)
                this.createBootStartup();
            else
            {
                this.deleteBootStartup();
            }

            this.logStatus();
        }

        private bool csgoIsRunning()
        {
            Process[] Processes = Process.GetProcesses();
            foreach (Process proc in Processes)
            {
                string name = proc.ProcessName;
                
                if (name.Equals("csgo"))
                {
                    return true;
                }
            }

            return false;
        }

        private void execCMDThemeChange(string PathToFile)
        {
            //PathToFile should be a full path from the C: directory to the .theme file.
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C rundll32.exe %SystemRoot%\\system32\\shell32.dll,Control_RunDLL %SystemRoot%\\system32\\desk.cpl desk,@Themes /Action:OpenTheme /file:\"" + PathToFile + "\"";
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();

            System.Threading.Thread.Sleep(500); //Sleep program until the dialog is actually open, so that we can close it.
            int iHandle = FindWindow("CabinetWClass", "Personalization");
            if (iHandle > 0)
            {
                SendMessage(iHandle, WM_SYSCOMMAND, SC_CLOSE, 0);
            }

            //Do a second check to make sure we didn't close it too early in the event of a slow computer etc.
            System.Threading.Thread.Sleep(500);
            iHandle = FindWindow("CabinetWClass", "Personalization");
            if (iHandle > 0)
            {
                SendMessage(iHandle, WM_SYSCOMMAND, SC_CLOSE, 0);
            }
        }

        private void changeTheme(bool useClassic)
        {
            string PATH;
            if (useClassic)
                PATH = "C:\\Windows\\Resources\\Ease of Access Themes\\hcwhite.theme";
            else
                PATH = "C:\\Windows\\Resources\\Themes\\aero.theme";

            execCMDThemeChange(PATH);
        }

        //Used for custom themes.
        private void changeTheme(string themePath)
        {
            string PATH = themePath;

            execCMDThemeChange(PATH);
        }

        private void altTabIntoCSGO()
        {
            if (Process.GetCurrentProcess().ProcessName.Equals("csgo")) return;

            IntPtr activeWindow = Process.GetCurrentProcess().MainWindowHandle;

            foreach (Process proc in Process.GetProcesses())
            {
                if (activeWindow == proc.MainWindowHandle)
                {
                    if (proc.ProcessName.Equals("csgo")) return;
                    else
                    {
                        IntPtr csgohWnd = this.getCSGOhWnd();
                        SetForegroundWindow(csgohWnd);
                    }
                }
            }
            
        }

        private IntPtr getCSGOhWnd()
        {
            foreach (Process proc in Process.GetProcesses())
            {
                if (proc.ProcessName.Equals("csgo")) return proc.MainWindowHandle;
            }

            return IntPtr.Zero;
        }

        private string UpperCaseFirstChar(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return String.Empty;
            }

            return char.ToUpper(s[0]) + s.Substring(1);
        }

        private void ThemeControl_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                NotificationIcon.ShowBalloonTip(500);
                this.Hide();
            }
        }

        private void NotificationIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.contextMenu.Show(Control.MousePosition);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void GitHubItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Eli45/CSGO_Theme_Control");
        }

        private void btnChooseDesktop_Click(object sender, EventArgs e)
        {
            DialogResult result = this.openFileDialog.ShowDialog();
            if (result == DialogResult.OK)  //User selected a file and clicked ok
            {
                string filepath = openFileDialog.FileName;
                this.DesktopThemePath = filepath;
                string[] split = filepath.Split('\\');
                this.DesktopThemeName = this.UpperCaseFirstChar(split[split.Length - 1].Replace(".theme", ""));
            }
            this.logStatus();
        }

        private void btnChooseIngame_Click(object sender, EventArgs e)
        {
            DialogResult result = this.openFileDialog.ShowDialog();
            if (result == DialogResult.OK)  //User selected a file and clicked ok
            {
                string filepath = openFileDialog.FileName;
                this.GameThemePath = filepath;
                string[] split = filepath.Split('\\');
                this.GameThemeName = this.UpperCaseFirstChar(split[split.Length - 1].Replace(".theme", ""));
            }
            this.logStatus();
        }

        private void btnClearThemes_Click(object sender, EventArgs e)
        {
            this.GameThemePath      = null;
            this.DesktopThemePath   = null;
            this.logStatus();
        }

    }
}
