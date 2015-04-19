namespace CSGO_Theme_Control
{
    partial class ThemeControl
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
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.chkStartOnBoot = new System.Windows.Forms.CheckBox();
            this.txtStatus = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(13, 251);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(65, 17);
            this.chkEnabled.TabIndex = 0;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            this.chkEnabled.CheckedChanged += new System.EventHandler(this.chkEnabled_CheckedChanged);
            // 
            // chkStartOnBoot
            // 
            this.chkStartOnBoot.AutoSize = true;
            this.chkStartOnBoot.Location = new System.Drawing.Point(13, 275);
            this.chkStartOnBoot.Name = "chkStartOnBoot";
            this.chkStartOnBoot.Size = new System.Drawing.Size(87, 17);
            this.chkStartOnBoot.TabIndex = 1;
            this.chkStartOnBoot.Text = "Start on boot";
            this.chkStartOnBoot.UseVisualStyleBackColor = true;
            this.chkStartOnBoot.CheckedChanged += new System.EventHandler(this.chkStartOnBoot_CheckedChanged);
            // 
            // txtStatus
            // 
            this.txtStatus.Enabled = false;
            this.txtStatus.Location = new System.Drawing.Point(6, 19);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(311, 208);
            this.txtStatus.TabIndex = 2;
            this.txtStatus.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtStatus);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 233);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Program Status";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 446);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "PLACEHOLDERGo to Github.com/Eli45/CSGOThemControl to get new updates";
            // 
            // ThemeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 468);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkStartOnBoot);
            this.Controls.Add(this.chkEnabled);
            this.Name = "ThemeControl";
            this.Text = "Theme Control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThemeControl_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.CheckBox chkStartOnBoot;
        private System.Windows.Forms.RichTextBox txtStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
    }
}

