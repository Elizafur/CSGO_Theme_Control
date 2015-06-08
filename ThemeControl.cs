//    This file is part of CSGO Theme Control.
//    Copyright (C) 2015  Elijah Furland      
//
//    CSGO Theme Control is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    CSGO Theme Control is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with CSGO Theme Control.  If not, see <http://www.gnu.org/licenses/>.

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
        private bool DebugMode;
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
        private const string VERSION_NUM    = "1.0.0.5";
        private Thread t_IsCSGORunning;
        private RegistryKey rk_StartupKey   = Registry.CurrentUser.OpenSubKey(
            "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        //The String in this dictionary should be the path to the theme to change to.
        private Dictionary<HotKey, String> HotKeys = new Dictionary<HotKey, String>();

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

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(
            IntPtr      hWnd, 
            int         id, 
            int         fsModifiers, 
            int         vk
        );

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(
            IntPtr      hWnd, 
            int         id
        );

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
            
            //TODO: <- dont remove this.
            //Set DebugMode to false before release.
            this.DebugMode = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //rundll32.exe %SystemRoot%\system32\shell32.dll,Control_RunDLL %SystemRoot%\system32\desk.cpl desk,@Themes /Action:OpenTheme /file:"C:\Windows\Resources\Themes\aero.theme"
            //rundll32.exe %SystemRoot%\system32\shell32.dll,Control_RunDLL %SystemRoot%\system32\desk.cpl desk,@Themes /Action:OpenTheme /file:"C:\Windows\Resources\Ease of Access Themes\hcwhite.theme"
            this.ReadConfig();

            //Register hotkeys.
            if (this.HotKeys != null || this.HotKeys.Count > 0)
                foreach(KeyValuePair<HotKey, String> entry in this.HotKeys)
                    RegisterHotKey(this.Handle, entry.Key.id, entry.Key.keyModifier, entry.Key.keyHashCode);

            //Check appropriate boxes on forms that correlate with user settings.
            chkEnabled.Checked = this.IsEnabled;
            if (rk_StartupKey.GetValue(ThemeControl.APP_NAME) == null) 
                this.registryBootWritten = false;
            else 
                this.registryBootWritten = true;

            this.BootOnStart            = registryBootWritten;
            this.chkStartOnBoot.Checked = registryBootWritten;

            //If CSGO is running when the program is started we should switch themes.
            this.shouldChangeDeskTheme  = this.csgoIsRunning();
            if (this.shouldChangeDeskTheme)
            {
                if (this.GameThemePath != null)
                    this.changeTheme(this.GameThemePath);
                else
                    this.changeTheme(true);
            }
            this.shouldChangeGameTheme  = !this.shouldChangeDeskTheme;

            //Create new thread to determine if CSGO is ever started.
            t_IsCSGORunning = new Thread(CheckIfRunningForever) { IsBackground = true };
            t_IsCSGORunning.Start();
        }

        private void ThemeControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DebugMode)
            {
                DBGRunTests();
            }

            if (t_IsCSGORunning != null)
            {
                if (t_IsCSGORunning.IsAlive)
                {
                    t_IsCSGORunning.Interrupt();
                    t_IsCSGORunning.Abort();
                }
            }

            this.WriteConfig();
            if (this.BootOnStart)
            {
                if (!registryBootWritten)
                    this.createBootStartup();
            }

            if (this.HotKeys != null || this.HotKeys.Count > 0)
                foreach (KeyValuePair<HotKey, String> entry in this.HotKeys)
                    UnregisterHotKey(this.Handle, entry.Key.id);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
 
            if (m.Msg == Constants.WIN_MSG_HOTKEY_DOWN && this.IsEnabled)
            {
                //Credit to http://www.fluxbytes.com/csharp/how-to-register-a-global-hotkey-for-your-application-in-c/
                /* Note that the three lines below are not needed if you only want to register one hotkey.
                 * The below lines are useful in case you want to register multiple keys, which you can use a switch with the id as argument, or if you want to know which key/modifier was pressed for some particular reason. */
 
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);                                      // The key of the hotkey that was pressed.
                Constants.KeyModifier modifier = (Constants.KeyModifier)((int)m.LParam & 0xFFFF);       // The modifier of the hotkey that was pressed.
                int id = m.WParam.ToInt32();                                                            // The id of the hotkey that was pressed.

                HotKey local = new HotKey(id, (int)modifier, key);

                try
                {
                    String pathToTheme = this.HotKeys[local];
                    execCMDThemeChange(pathToTheme);
                }
                catch (Exception e)
                {
                    //TODO:
                    //Path does not exist. Make this better later by narrowing Exception to a specific few.
                    createCrashDump(e.Message);
                }
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
                "Version:"       + HelperFunc.CreateWhiteSpace(7) + ThemeControl.VERSION_NUM,
                "Is Enabled:"    + HelperFunc.CreateWhiteSpace(4) + this.IsEnabled,
                "Boot on start:" + HelperFunc.CreateWhiteSpace(1) + this.BootOnStart,
                "Desktop theme:" + HelperFunc.CreateWhiteSpace(1) + desktopT,
                "In-game theme:" + HelperFunc.CreateWhiteSpace(1) + gameT
            );

            this.log("Hotkeys<Key, Theme>:" + HelperFunc.CreateWhiteSpace(4) + "{");
            if (this.HotKeys != null || this.HotKeys.Count > 0)
            {
                foreach (KeyValuePair<HotKey, String> entry in this.HotKeys)
                {
                    this.log(HelperFunc.CreateWhiteSpace(4) + "[" + entry.Key.ToString() + ", " + HelperFunc.CreateShortHandTheme(entry.Value.ToString()) + "]");
                }
            }
            this.log("}");
            
        }

        private void createCrashDump(string context)
        {
            string programExePathFolder = this.getExeDirectory();

            String Date = (DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.TimeOfDay.ToString()).Replace(":", "-");
            Date = Date.Remove(Date.LastIndexOf("."));
            Date += DateTime.Now.ToString("tt");

            StreamWriter sw = new StreamWriter(programExePathFolder + "CSGO_THEME_CONTROL_" + Date + ".crashdumplog");
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
                throw new Exception("A second exception occured while trying to create a log of a prior exception.\nThis means that something incredibly wrong has happened and the program must terminate. Context follows:\n" + e.Message);
            }
            finally
            {
                sw.Close();
            }
        }

        private void createBootStartup()
        {
            rk_StartupKey.SetValue(ThemeControl.APP_NAME, Application.ExecutablePath.ToString());
        }

        private void deleteBootStartup()
        {
            rk_StartupKey.DeleteValue(ThemeControl.APP_NAME, false); 
        }

        private void ReadConfig()
        {
            string programExePathFolder = this.getExeDirectory();

            StreamReader f = new StreamReader(programExePathFolder + Constants.APP_CONFIG_LOCATION);
            try
            {
                while (!f.EndOfStream)
                {
                    string line = f.ReadLine();
                    if (!line.StartsWith("//"))
                    {
                        //Looking back at this I don't know what this does other than the fact that we somehow end up with a split String.
                        //But I assume it is splitting at the quotations and at the whitespace.
                        //It works is what's important. (I feel awful writing that).
                        List<string> split = line.Split('"')
                                                 .Select((element, index) => index % 2 == 0                                     // If even index
                                                       ? element.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)    // Split the item
                                                       : new string[] { element })                                              // Keep the entire item
                                                 .SelectMany(element => element).ToList();

                        for (int i = 0; i < split.Count; i++)
                        {
                            if (i != split.Count - 1)
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
                                    this.DesktopThemeName = HelperFunc.UpperCaseFirstChar(splitTheme[splitTheme.Length - 1].Replace(".theme", ""));
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
                                    this.GameThemeName = HelperFunc.UpperCaseFirstChar(splitTheme[splitTheme.Length - 1].Replace(".theme", ""));
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    log("ERROR: CFG is in an invalid format and cannot be read.");
                                }
                            }
                            else if (word.StartsWith("hotkey{"))
                            {
                                try
                                {
                                    //using the split line stored in the variable 'split':
                                    //index 0 should be "Hotkey{" which is our identifier
                                    //index 1 should be the id of the key to assign.
                                    //index 2 should be the modifier of the key.
                                    //index 3 should be the key itself as a string.
                                    //index 4 should be the string path to the theme which will be activated.

                                    try 
                                    {
                                        //Add hotkey to global hotkey list.
                                        this.HotKeys.Add(new HotKey(
                                            Convert.ToInt32(split[1]),
                                            Convert.ToInt32(split[2]),
                                            (Keys)Enum.Parse(typeof(Keys), split[3], false)
                                        ), split[4]);
                                    }
                                    catch (Exception e)
                                    {
                                        if (e is ArgumentNullException || e is ArgumentException || e is OverflowException)
                                        {
                                            log("ERROR: CFG is in an invalid format and cannot be read.");
                                        }
                                        else
                                        {
                                            throw;
                                        }
                                    }
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

            StreamWriter sw = new StreamWriter(programExePathFolder + Constants.APP_CONFIG_LOCATION);
            try
            {
                sw.WriteLine("//Note to those reading:\n//Modifying this file could result in the breaking of your config.\n");
                sw.WriteLine("IsEnabled " + HelperFunc.CreateWhiteSpace(8) + "\"" + this.IsEnabled.ToString() + "\"");

                if (this.DesktopThemePath != null)
                {
                    sw.WriteLine("DesktopThemePath " + HelperFunc.CreateWhiteSpace(4) + "\"" + this.DesktopThemePath + "\"");
                }
                if (this.GameThemePath != null)
                {
                    sw.WriteLine("GameThemePath " + HelperFunc.CreateWhiteSpace(8) + "\"" + this.GameThemePath + "\"");
                }

                if (this.HotKeys != null)
                    foreach (KeyValuePair<HotKey, String> entry in this.HotKeys)
                    {
                        sw.Write("Hotkey{ ");
                        sw.Write(entry.Key.id + " " + entry.Key.keyModifier + " " + entry.Key.key);
                        sw.Write(" " + entry.Value);
                        sw.Write(" }\n");
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
                if (t_IsCSGORunning != null)
                {
                    t_IsCSGORunning.Abort();
                }
            }
            else
            {
                if (t_IsCSGORunning != null)
                {
                    if (!t_IsCSGORunning.IsAlive)
                    {
                        t_IsCSGORunning = new Thread(CheckIfRunningForever) { IsBackground = true };
                        t_IsCSGORunning.Start();
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
                
                if (name.Equals(Constants.CSGO_PROC_NAME))
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
            startInfo.Arguments = String.Format(Constants.CMD_CHANGE_THEME, PathToFile);
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();

            System.Threading.Thread.Sleep(500); //Sleep program until the dialog is actually open, so that we can close it.
            int iHandle = FindWindow("CabinetWClass", "Personalization");
            if (iHandle > 0)
            {
                SendMessage(iHandle, Constants.WIN_MSG_WM_SYSCOMMAND, Constants.WIN_MSG_SC_CLOSE, 0);
            }

            //Do a second check to make sure we didn't close it too early in the event of a slow computer etc.
            System.Threading.Thread.Sleep(500);
            iHandle = FindWindow("CabinetWClass", "Personalization");
            if (iHandle > 0)
            {
                SendMessage(iHandle, Constants.WIN_MSG_WM_SYSCOMMAND, Constants.WIN_MSG_SC_CLOSE, 0);
            }
        }

        private void changeTheme(bool useClassic)
        {
            try
            {
                string PATH;
                if (useClassic)
                    PATH = Constants.WIN_CLASSIC_THEME;
                else
                    PATH = Constants.WIN_AERO_THEME;

                execCMDThemeChange(PATH);
            }
            catch (Exception e)
            {
                //TODO:
                //Path does not exist. Make this better later by narrowing Exception to a specific few.
                createCrashDump(e.Message);
            }
        }

        //Used for custom themes.
        private void changeTheme(string themePath)
        {
            try
            {
                string PATH = themePath;

                execCMDThemeChange(PATH);
            }
            catch (Exception e)
            {
                //TODO:
                //Path does not exist. Make this better later by narrowing Exception to a specific few.
                createCrashDump(e.Message);
            }
        }

        private void altTabIntoCSGO()
        {
            if (Process.GetCurrentProcess().ProcessName.Equals("csgo")) return;

            IntPtr activeWindow = Process.GetCurrentProcess().MainWindowHandle;

            foreach (Process proc in Process.GetProcesses())
            {
                if (activeWindow == proc.MainWindowHandle)
                {
                    if (proc.ProcessName.Equals(Constants.CSGO_PROC_NAME)) return;
                    else
                    {
                        IntPtr csgohWnd = this.getCSGOhWnd();
                        if (csgohWnd == IntPtr.Zero)
                            return;

                        SetForegroundWindow(csgohWnd);
                    }
                }
            }
            
        }

        private IntPtr getCSGOhWnd()
        {
            foreach (Process proc in Process.GetProcesses())
            {
                if (proc.ProcessName.Equals(Constants.CSGO_PROC_NAME)) return proc.MainWindowHandle;
            }

            return IntPtr.Zero;
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
                this.DesktopThemeName = HelperFunc.UpperCaseFirstChar(split[split.Length - 1].Replace(".theme", ""));
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
                this.GameThemeName = HelperFunc.UpperCaseFirstChar(split[split.Length - 1].Replace(".theme", ""));
            }
            this.logStatus();
        }

        private void btnClearThemes_Click(object sender, EventArgs e)
        {
            this.GameThemePath      = null;
            this.DesktopThemePath   = null;
            this.logStatus();
        }

        private void btnPickHotkeys_Click(object sender, EventArgs e)
        {
            unsafe
            {
                HotKeyDataHolder hkdh;
                ThemeDataHolder tdh;
                HotKeyPickerForm hkpf = new HotKeyPickerForm(&hkdh, &tdh, this.HotKeys);
                Form casted = (Form)hkpf;
                HelperFunc.CreateFormStartPosition(ref casted, this);
                hkpf = (HotKeyPickerForm)casted;

                DialogResult result = hkpf.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string themePathFromCSTR = new string(tdh.ThemePath);
                    //After the form is closed we can make a new KeyValuePair for our dictionary and register the key.
                    RegisterHotKey(this.Handle, hkdh.id, hkdh.keyModifier, hkdh.keyHashCode);
                    this.HotKeys.Add(
                        HotKey.FormNewHotKey(hkdh),
                        themePathFromCSTR
                    );
                }
            }

            this.logStatus();
        }

        private void btnRemoveHotkey_Click(object sender, EventArgs e)
        {
            unsafe
            {
                HotKeyDataHolder hkdh;
                HotKeyRemovalForm hkrf = new HotKeyRemovalForm(&hkdh, this.HotKeys);
                Form casted = (Form)hkrf;
                HelperFunc.CreateFormStartPosition(ref casted, (Form)this);
                hkrf = (HotKeyRemovalForm)casted;

                DialogResult result = hkrf.ShowDialog();
                if (result == DialogResult.OK)
                {
                    HotKey hk = new HotKey(hkdh.id, hkdh.keyModifier, hkdh.key);
                    this.HotKeys.Remove(hk);
                    UnregisterHotKey(this.Handle, hk.id);
                }
                else if (result == DialogResult.Yes)
                {
                    this.HotKeys = new Dictionary<HotKey, String>();
                }
            }

            this.logStatus();
        }

        //Debug method
        private void DBGRunTests()
        {
            createCrashDump("This is just a test crash dump. You should not be seeing this!");
            //TODO: Some other stuff should be here.
        }
    }
}
