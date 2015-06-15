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
            this.SuspendLayout();
            // 
            // chkCleanLogsFolder
            // 
            this.chkCleanLogsFolder.AutoSize = true;
            this.chkCleanLogsFolder.Location = new System.Drawing.Point(13, 13);
            this.chkCleanLogsFolder.Name = "chkCleanLogsFolder";
            this.chkCleanLogsFolder.Size = new System.Drawing.Size(111, 17);
            this.chkCleanLogsFolder.TabIndex = 0;
            this.chkCleanLogsFolder.Text = "Clean Logs Folder";
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
            // AdvancedUserSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
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
    }
}