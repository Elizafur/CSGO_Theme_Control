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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemeControl));
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.chkStartOnBoot = new System.Windows.Forms.CheckBox();
            this.txtStatus = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NotificationIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.GitHubItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnChooseDesktop = new System.Windows.Forms.Button();
            this.btnChooseIngame = new System.Windows.Forms.Button();
            this.btnClearThemes = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.contextMenu.SuspendLayout();
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
            this.label1.Size = new System.Drawing.Size(194, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Head over to Eli45.github.io for updates";
            // 
            // NotificationIcon
            // 
            this.NotificationIcon.BalloonTipText = "CSGO Theme Control is minimized!";
            this.NotificationIcon.BalloonTipTitle = "CSGO Theme Control";
            this.NotificationIcon.Visible = true;
            this.NotificationIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotificationIcon_MouseClick);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GitHubItemToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(140, 48);
            // 
            // GitHubItemToolStripMenuItem
            // 
            this.GitHubItemToolStripMenuItem.Name = "GitHubItemToolStripMenuItem";
            this.GitHubItemToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.GitHubItemToolStripMenuItem.Text = "Goto Github";
            this.GitHubItemToolStripMenuItem.Click += new System.EventHandler(this.GitHubItemToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "File Dialog";
            this.openFileDialog.Filter = "Theme Files|*.theme";
            this.openFileDialog.InitialDirectory = "C:\\Windows\\Resources";
            // 
            // btnChooseDesktop
            // 
            this.btnChooseDesktop.Location = new System.Drawing.Point(13, 298);
            this.btnChooseDesktop.Name = "btnChooseDesktop";
            this.btnChooseDesktop.Size = new System.Drawing.Size(136, 23);
            this.btnChooseDesktop.TabIndex = 5;
            this.btnChooseDesktop.Text = "Choose desktop theme";
            this.btnChooseDesktop.UseVisualStyleBackColor = true;
            this.btnChooseDesktop.Click += new System.EventHandler(this.btnChooseDesktop_Click);
            // 
            // btnChooseIngame
            // 
            this.btnChooseIngame.Location = new System.Drawing.Point(12, 327);
            this.btnChooseIngame.Name = "btnChooseIngame";
            this.btnChooseIngame.Size = new System.Drawing.Size(137, 23);
            this.btnChooseIngame.TabIndex = 6;
            this.btnChooseIngame.Text = "Choose ingame theme";
            this.btnChooseIngame.UseVisualStyleBackColor = true;
            this.btnChooseIngame.Click += new System.EventHandler(this.btnChooseIngame_Click);
            // 
            // btnClearThemes
            // 
            this.btnClearThemes.Location = new System.Drawing.Point(13, 378);
            this.btnClearThemes.Name = "btnClearThemes";
            this.btnClearThemes.Size = new System.Drawing.Size(136, 23);
            this.btnClearThemes.TabIndex = 7;
            this.btnClearThemes.Text = "Clear themes";
            this.btnClearThemes.UseVisualStyleBackColor = true;
            this.btnClearThemes.Click += new System.EventHandler(this.btnClearThemes_Click);
            // 
            // ThemeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 468);
            this.Controls.Add(this.btnClearThemes);
            this.Controls.Add(this.btnChooseIngame);
            this.Controls.Add(this.btnChooseDesktop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkStartOnBoot);
            this.Controls.Add(this.chkEnabled);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ThemeControl";
            this.Text = "Theme Control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThemeControl_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.ThemeControl_Resize);
            this.groupBox1.ResumeLayout(false);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.CheckBox chkStartOnBoot;
        private System.Windows.Forms.RichTextBox txtStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon NotificationIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem GitHubItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnChooseDesktop;
        private System.Windows.Forms.Button btnChooseIngame;
        private System.Windows.Forms.Button btnClearThemes;
    }
}

