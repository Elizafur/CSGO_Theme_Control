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

namespace CSGO_Theme_Control.Form_Classes.ThemeControlForm
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
            this.NotificationIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.GitHubItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnChooseDesktop = new System.Windows.Forms.Button();
            this.btnChooseIngame = new System.Windows.Forms.Button();
            this.btnClearThemes = new System.Windows.Forms.Button();
            this.btnPickHotkeys = new System.Windows.Forms.Button();
            this.btnRemoveHotkey = new System.Windows.Forms.Button();
            this.btnOpenAdvanced = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
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
            this.txtStatus.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(6, 19);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(324, 208);
            this.txtStatus.TabIndex = 2;
            this.txtStatus.Text = "";
            this.txtStatus.WordWrap = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtStatus);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 233);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Program Status";
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
            this.GitHubItemToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("GitHubItemToolStripMenuItem.Image")));
            this.GitHubItemToolStripMenuItem.Name = "GitHubItemToolStripMenuItem";
            this.GitHubItemToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.GitHubItemToolStripMenuItem.Text = "Goto Github";
            this.GitHubItemToolStripMenuItem.Click += new System.EventHandler(this.GitHubItemToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
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
            this.btnChooseDesktop.Location = new System.Drawing.Point(12, 298);
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
            this.btnChooseIngame.Size = new System.Drawing.Size(136, 23);
            this.btnChooseIngame.TabIndex = 6;
            this.btnChooseIngame.Text = "Choose ingame theme";
            this.btnChooseIngame.UseVisualStyleBackColor = true;
            this.btnChooseIngame.Click += new System.EventHandler(this.btnChooseIngame_Click);
            // 
            // btnClearThemes
            // 
            this.btnClearThemes.Location = new System.Drawing.Point(12, 377);
            this.btnClearThemes.Name = "btnClearThemes";
            this.btnClearThemes.Size = new System.Drawing.Size(136, 23);
            this.btnClearThemes.TabIndex = 7;
            this.btnClearThemes.Text = "Clear themes";
            this.btnClearThemes.UseVisualStyleBackColor = true;
            this.btnClearThemes.Click += new System.EventHandler(this.btnClearThemes_Click);
            // 
            // btnPickHotkeys
            // 
            this.btnPickHotkeys.Location = new System.Drawing.Point(233, 251);
            this.btnPickHotkeys.Name = "btnPickHotkeys";
            this.btnPickHotkeys.Size = new System.Drawing.Size(102, 23);
            this.btnPickHotkeys.TabIndex = 8;
            this.btnPickHotkeys.Text = "New Hotkey";
            this.btnPickHotkeys.UseVisualStyleBackColor = true;
            this.btnPickHotkeys.Click += new System.EventHandler(this.btnPickHotkeys_Click);
            // 
            // btnRemoveHotkey
            // 
            this.btnRemoveHotkey.Location = new System.Drawing.Point(233, 280);
            this.btnRemoveHotkey.Name = "btnRemoveHotkey";
            this.btnRemoveHotkey.Size = new System.Drawing.Size(102, 23);
            this.btnRemoveHotkey.TabIndex = 9;
            this.btnRemoveHotkey.Text = "Remove Hotkey";
            this.btnRemoveHotkey.UseVisualStyleBackColor = true;
            this.btnRemoveHotkey.Click += new System.EventHandler(this.btnRemoveHotkey_Click);
            // 
            // btnOpenAdvanced
            // 
            this.btnOpenAdvanced.Location = new System.Drawing.Point(233, 441);
            this.btnOpenAdvanced.Name = "btnOpenAdvanced";
            this.btnOpenAdvanced.Size = new System.Drawing.Size(115, 23);
            this.btnOpenAdvanced.TabIndex = 10;
            this.btnOpenAdvanced.Text = "Advanced Options";
            this.btnOpenAdvanced.UseVisualStyleBackColor = true;
            this.btnOpenAdvanced.Click += new System.EventHandler(this.btnOpenAdvanced_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(12, 441);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(66, 23);
            this.btnHelp.TabIndex = 11;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // ThemeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 468);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnOpenAdvanced);
            this.Controls.Add(this.btnRemoveHotkey);
            this.Controls.Add(this.btnPickHotkeys);
            this.Controls.Add(this.btnClearThemes);
            this.Controls.Add(this.btnChooseIngame);
            this.Controls.Add(this.btnChooseDesktop);
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
        private System.Windows.Forms.NotifyIcon NotificationIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem GitHubItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnChooseDesktop;
        private System.Windows.Forms.Button btnChooseIngame;
        private System.Windows.Forms.Button btnClearThemes;
        private System.Windows.Forms.Button btnPickHotkeys;
        private System.Windows.Forms.Button btnRemoveHotkey;
        private System.Windows.Forms.Button btnOpenAdvanced;
        private System.Windows.Forms.Button btnHelp;
    }
}

