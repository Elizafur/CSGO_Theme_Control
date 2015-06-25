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
using System.Windows.Forms;
using System.Linq;
using CSGO_Theme_Control.Base_Classes.UserSettings;

namespace CSGO_Theme_Control.Form_Classes.AdvancedSettingsForm
{
    public partial class AdvancedUserSettingsForm : Form
    {
        public readonly UserSettingsContainer USettingsOptions;

        public AdvancedUserSettingsForm(params UserSettingsEnum.Options[] uOptions)
        {
            InitializeComponent();

            USettingsOptions = new UserSettingsContainer(uOptions);

            chkCleanLogsFolder.Checked = USettingsOptions.GetOptions().Contains(UserSettingsEnum.Options.CLEAN_LOGS);
            DisableChecksBasedOnOptions();

        }

        private void chkCleanLogsFolder_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCleanLogsFolder.Checked)
            {
                USettingsOptions.Add(UserSettingsEnum.Options.CLEAN_LOGS);
            }
            else
            {
                USettingsOptions.Remove(UserSettingsEnum.Options.CLEAN_LOGS);
            }

            DisableChecksBasedOnOptions();
        }

        private void DisableChecksBasedOnOptions()  //Come up with a better name?
        {
            if (chkCleanLogsFolder.Checked)
            {
                chkCleanOldLogsOnly.Enabled = true;
                chkCleanThrownLogs.Enabled = true;

                chkCleanOldLogsOnly.Checked =
                    USettingsOptions.GetOptions().Contains(UserSettingsEnum.Options.CLEAN_LOGS_ONLY_BEFORE_TODAY);
                chkCleanThrownLogs.Checked  =
                    USettingsOptions.GetOptions().Contains(UserSettingsEnum.Options.CLEAN_FATAL_LOGS);

            }
            else
            {
                chkCleanOldLogsOnly.Checked = false;
                chkCleanThrownLogs.Checked = false;
                chkCleanOldLogsOnly.Enabled = false;
                chkCleanThrownLogs.Enabled = false;
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void chkCleanOldLogsOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCleanOldLogsOnly.Checked)
                USettingsOptions.Add(UserSettingsEnum.Options.CLEAN_LOGS_ONLY_BEFORE_TODAY);
            else
                USettingsOptions.Remove(UserSettingsEnum.Options.CLEAN_LOGS_ONLY_BEFORE_TODAY);
        }

        private void chkCleanThrownLogs_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCleanThrownLogs.Checked)
                USettingsOptions.Add(UserSettingsEnum.Options.CLEAN_FATAL_LOGS);
            else
                USettingsOptions.Remove(UserSettingsEnum.Options.CLEAN_FATAL_LOGS);
        }
    }
}
