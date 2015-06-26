using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CSGO_Theme_Control.Form_Classes.HelpUserForm
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();

            txtUserThemePath.Text    = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Microsoft\Windows\Themes\";
            txtDefaultThemePath.Text = @"C:\Windows\Resources";

            txtUserThemePath.ScrollBars = RichTextBoxScrollBars.ForcedHorizontal;

            txtHelpBox.Lines = new string[]
            {
                "If you have encountered a bug please report it at the Github linked at the top of this page.\n",
                "Please make sure your program is up to date and your bug has not already been fixed before reporting bugs."  
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
