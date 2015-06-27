using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using CSGO_Theme_Control.Base_Classes.Constants;
using CSGO_Theme_Control.Base_Classes.Helper;

namespace CSGO_Theme_Control.Form_Classes.HelpUserForm
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();

            txtUserThemePath.Text    = Path.GetPathRoot(Environment.SystemDirectory) + @"Users\" + Environment.UserName + @"\AppData\Local\Microsoft\Windows\Themes\";
            txtDefaultThemePath.Text = Path.GetPathRoot(Environment.SystemDirectory) + @"Windows\Resources";

            txtUserThemePath.ScrollBars = RichTextBoxScrollBars.ForcedHorizontal;

            txtHelpBox.Lines = new string[]
            {
                "If you have encountered a bug please report it at the Github linked at the top of this page.\n",
                "Please make sure your program is up to date and your bug has not already been fixed before reporting bugs.\n"
            };

            const string TAB = "    ";
            txtTroubleShoot.Lines = new string[]
            {
                "Other trouble shooting tips include:",
                $"{TAB}\u2022Deleting your config file located at: " + ThemeControlForm.ThemeControl.GetExeDirectory() + Constants.APP_CONFIG_LOCATION,
                $"{TAB}\u2022Making sure your .NET Framework is atleast version 4.6",
                $"{TAB}\u2022Deleting and reinstalling the program.",
                $"{TAB}\u2022Repairing your User32.dll (see https://support.microsoft.com/en-us/kb/142676)"
            };
        }

        private void lblLinkToGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Eli45/CSGO_Theme_Control");
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
