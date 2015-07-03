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
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using CSGO_Theme_Control.Base_Classes.Constants;

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

            const string TAB    = "    ";
            const string BULLET = "\u2022";
            txtTroubleShoot.Lines = new string[]
            {
                "Other trouble shooting tips include:",
                $"{TAB}{BULLET}Deleting your config file located at: {ThemeControlForm.ThemeControl.GetExeDirectory() + Constants.APP_CONFIG_LOCATION}",
                $"{TAB}{BULLET}Making sure your .NET Framework is atleast version 4.6",
                $"{TAB}{BULLET}Deleting and reinstalling the program.",
                $"{TAB}{BULLET}Repairing your User32.dll (Only do this if there is an explicit error saying there was a problem with it, also see https://support.microsoft.com/en-us/kb/142676)"
            };
        }

        private void lblLinkToGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Eli45/CSGO_Theme_Control");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
