using System;
using System.Windows.Forms;

namespace CSGO_Theme_Control.Form_Classes.AdvancedSettingsForm
{
    public partial class AdvancedUserSettingsForm : Form
    {
        public bool CleanLogs;
        //TODO(Medium): Expand settings.

        public AdvancedUserSettingsForm(bool preExistingCleanLogsSetting)
        {
            InitializeComponent();

            CleanLogs = preExistingCleanLogsSetting;
            chkCleanLogsFolder.Checked = CleanLogs;
        }

        private void chkCleanLogsFolder_CheckedChanged(object sender, EventArgs e)
        {
            CleanLogs = chkCleanLogsFolder.Checked;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
