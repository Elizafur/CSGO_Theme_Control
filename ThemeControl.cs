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

namespace CSGO_Theme_Control
{
    public partial class ThemeControl : Form
    {

        private bool IsEnabled          = true;
        private bool BootOnStart        = false;
        private bool shouldChangeTheme  = false;
        private Thread t;
        private string EXE_NAME         = "CSGO_Theme_Control.exe";

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


        public ThemeControl()
        {
            InitializeComponent();
            //this.ReadConfig();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //rundll32.exe %SystemRoot%\system32\shell32.dll,Control_RunDLL %SystemRoot%\system32\desk.cpl desk,@Themes /Action:OpenTheme /file:"C:\Windows\Resources\Themes\aero.theme"
            //rundll32.exe %SystemRoot%\system32\shell32.dll,Control_RunDLL %SystemRoot%\system32\desk.cpl desk,@Themes /Action:OpenTheme /file:"C:\Windows\Resources\Ease of Access Themes\hcwhite.theme"
            this.ReadConfig();
            chkEnabled.Checked      = this.IsEnabled;
            chkStartOnBoot.Checked  = this.BootOnStart;

            t = new Thread(CheckIfRunningForever){ IsBackground = true };
            t.Start();
        }

        private void ThemeControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.t.IsAlive)
            {
                this.t.Interrupt();
                this.t.Abort();
            }

            this.WriteConfig();
            if (this.BootOnStart)
            {
                //TODO: Make this actually work.
                this.createStartupShortcut();
            }
        }

        private void log(string s)
        {
            this.txtStatus.Text += s+"\n";
        }

        private void createStartupShortcut()
        {
            string user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string PATH = "C:\\users\\" + user + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup";
            string ProgramExePath = System.Reflection.Assembly.GetEntryAssembly().Location;

            Type t = Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")); //Windows Script Host Shell Object
            dynamic shell = Activator.CreateInstance(t);
            try
            {
                var lnk = shell.CreateShortcut("CSGOThemeControl.lnk");
                try
                {
                    lnk.TargetPath = ProgramExePath;
                    lnk.IconLocation = "shell32.dll, 1";
                    lnk.Save();
                }
                finally
                {
                    Marshal.FinalReleaseComObject(lnk);
                }
            }
            finally
            {
                Marshal.FinalReleaseComObject(shell);
            }
        }

        private void ReadConfig()
        {
            string[] programExePath_split = System.Reflection.Assembly.GetEntryAssembly().Location.Split('\\');
            for (int i = 0; i < programExePath_split.Length; i++)
            {
                if (programExePath_split[i].Equals(this.EXE_NAME))
                {
                    programExePath_split[i] = "";
                }
            }

            string programExePathFolder = String.Join("\\", programExePath_split);

            StreamReader f = new StreamReader(programExePathFolder + "cfg\\Config.ThemeControlCfg");
            try
            {
                while (!f.EndOfStream)
                {
                    string line = f.ReadLine();
                    string[] split = line.Split(' ');
                    for (int i = 0; i < split.Length; i++)
                    {
                        if (split[i].ToLower().Equals("IsEnabled"))
                        {
                            try
                            {
                                this.IsEnabled = Convert.ToBoolean(split[i + 1].ToLower());
                            }
                            catch (Exception) //TODO: Replace with arrayoutofbounds exception
                            {
                                log("ERROR: CFG is in an invalid format and cannot be read.");
                                this.IsEnabled = false;
                            }
                        }
                        else if (split[i].ToLower().Equals("bootonstart"))
                        {
                            try
                            {
                                this.BootOnStart = Convert.ToBoolean(split[i + 1].ToLower());
                            }
                            catch (Exception)
                            {
                                log("CFG is in an invalid format and cannot be read.");
                                this.BootOnStart = false;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                //TODO: Log error in a crash dump file.
            }
            finally
            {
                f.Close();
            }
        }

        private void WriteConfig()
        {
            string[] programExePath_split = System.Reflection.Assembly.GetEntryAssembly().Location.Split('\\');
            for (int i = 0; i < programExePath_split.Length; i++)
            {
                if (programExePath_split[i].Equals(this.EXE_NAME))
                {
                    programExePath_split[i] = "";
                }
            }

            string programExePathFolder = String.Join("\\", programExePath_split);

            StreamWriter sw = new StreamWriter(programExePathFolder + "cfg\\Config.ThemeControlCfg");
            try
            {
                sw.WriteLine("IsEnabled" + this.IsEnabled.ToString());
                sw.WriteLine("BootOnStart" + this.BootOnStart.ToString());
            }
            catch (Exception e)
            {
                //TODO: Log error in a crash dump file.
            }
            finally
            {
                sw.Close();
            }
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
                        this.changeTheme(true);
                        this.shouldChangeTheme = true;
                    }
                    else
                    {
                        if (this.shouldChangeTheme)
                        {
                            this.changeTheme(false);
                            this.shouldChangeTheme = false;
                        }
                    }
                
                }
                try
                {
                    System.Threading.Thread.Sleep(5000);
                }
                catch (System.Threading.ThreadInterruptedException)
                {
                    //TODO: log
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
        }

        private void chkStartOnBoot_CheckedChanged(object sender, EventArgs e)
        {
            this.BootOnStart = chkEnabled.Checked;
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

        private void changeTheme(bool useClassic)
        {
            string PATH;
            if (useClassic) 
                PATH = "\\Ease of Access Themes\\hcwhite";
            else
                PATH = "\\Themes\\aero";

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C rundll32.exe %SystemRoot%\\system32\\shell32.dll,Control_RunDLL %SystemRoot%\\system32\\desk.cpl desk,@Themes /Action:OpenTheme /file:\"C:\\Windows\\Resources" + PATH + ".theme\"";
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();

            System.Threading.Thread.Sleep(500); //Sleep program until the dialog is actually open, so that we can close it.
            int iHandle = FindWindow("CabinetWClass", "Personalization");
            if (iHandle > 0)
            {
                SendMessage(iHandle, WM_SYSCOMMAND, SC_CLOSE, 0);
            }

        }

    }
}
