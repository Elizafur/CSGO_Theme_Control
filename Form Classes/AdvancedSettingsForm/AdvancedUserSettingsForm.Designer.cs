namespace CSGO_Theme_Control.Form_Classes.AdvancedSettingsForm
{
    partial class AdvancedUserSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvancedUserSettingsForm));
            this.chkCleanLogsFolder = new System.Windows.Forms.CheckBox();
            this.btnFinish = new System.Windows.Forms.Button();
            this.chkCleanOldLogsOnly = new System.Windows.Forms.CheckBox();
            this.chkCleanThrownLogs = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkCleanLogsFolder
            // 
            this.chkCleanLogsFolder.AutoSize = true;
            this.chkCleanLogsFolder.Location = new System.Drawing.Point(13, 13);
            this.chkCleanLogsFolder.Name = "chkCleanLogsFolder";
            this.chkCleanLogsFolder.Size = new System.Drawing.Size(104, 17);
            this.chkCleanLogsFolder.TabIndex = 0;
            this.chkCleanLogsFolder.Text = "Clean logs folder";
            this.chkCleanLogsFolder.UseVisualStyleBackColor = true;
            this.chkCleanLogsFolder.CheckedChanged += new System.EventHandler(this.chkCleanLogsFolder_CheckedChanged);
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(161, 203);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(111, 47);
            this.btnFinish.TabIndex = 1;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // chkCleanOldLogsOnly
            // 
            this.chkCleanOldLogsOnly.AutoSize = true;
            this.chkCleanOldLogsOnly.Location = new System.Drawing.Point(13, 37);
            this.chkCleanOldLogsOnly.Name = "chkCleanOldLogsOnly";
            this.chkCleanOldLogsOnly.Size = new System.Drawing.Size(159, 17);
            this.chkCleanOldLogsOnly.TabIndex = 2;
            this.chkCleanOldLogsOnly.Text = "Clean logs only before today";
            this.chkCleanOldLogsOnly.UseVisualStyleBackColor = true;
            this.chkCleanOldLogsOnly.CheckedChanged += new System.EventHandler(this.chkCleanOldLogsOnly_CheckedChanged);
            // 
            // chkCleanThrownLogs
            // 
            this.chkCleanThrownLogs.AutoSize = true;
            this.chkCleanThrownLogs.Location = new System.Drawing.Point(13, 61);
            this.chkCleanThrownLogs.Name = "chkCleanThrownLogs";
            this.chkCleanThrownLogs.Size = new System.Drawing.Size(110, 17);
            this.chkCleanThrownLogs.TabIndex = 3;
            this.chkCleanThrownLogs.Text = "Clean thrown logs";
            this.chkCleanThrownLogs.UseVisualStyleBackColor = true;
            this.chkCleanThrownLogs.CheckedChanged += new System.EventHandler(this.chkCleanThrownLogs_CheckedChanged);
            // 
            // AdvancedUserSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.chkCleanThrownLogs);
            this.Controls.Add(this.chkCleanOldLogsOnly);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.chkCleanLogsFolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdvancedUserSettingsForm";
            this.Text = "Advanced Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkCleanLogsFolder;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.CheckBox chkCleanOldLogsOnly;
        private System.Windows.Forms.CheckBox chkCleanThrownLogs;
    }
}