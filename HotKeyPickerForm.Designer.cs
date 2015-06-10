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

namespace CSGO_Theme_Control
{
    partial class HotKeyPickerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HotKeyPickerForm));
            this.label1 = new System.Windows.Forms.Label();
            this.lblHKID = new System.Windows.Forms.Label();
            this.fileFirstTheme = new System.Windows.Forms.OpenFileDialog();
            this.btnThemeTriggerDialog = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnPickHotKey = new System.Windows.Forms.Button();
            this.lblKeyOK = new System.Windows.Forms.Label();
            this.lblThemeOK = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.chkToggle = new System.Windows.Forms.CheckBox();
            this.btnSecondTheme = new System.Windows.Forms.Button();
            this.lblTheme2OK = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(96, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Hotkey";
            // 
            // lblHKID
            // 
            this.lblHKID.AutoSize = true;
            this.lblHKID.Location = new System.Drawing.Point(13, 74);
            this.lblHKID.Name = "lblHKID";
            this.lblHKID.Size = new System.Drawing.Size(61, 13);
            this.lblHKID.TabIndex = 1;
            this.lblHKID.Text = "Hotkey ID: ";
            // 
            // fileFirstTheme
            // 
            this.fileFirstTheme.FileName = "Pick Theme";
            this.fileFirstTheme.Filter = "Theme Files|*.theme";
            this.fileFirstTheme.InitialDirectory = "C:\\Windows\\Resources";
            // 
            // btnThemeTriggerDialog
            // 
            this.btnThemeTriggerDialog.Location = new System.Drawing.Point(15, 133);
            this.btnThemeTriggerDialog.Name = "btnThemeTriggerDialog";
            this.btnThemeTriggerDialog.Size = new System.Drawing.Size(153, 23);
            this.btnThemeTriggerDialog.TabIndex = 3;
            this.btnThemeTriggerDialog.Text = "Select Theme To Trigger";
            this.btnThemeTriggerDialog.UseVisualStyleBackColor = true;
            this.btnThemeTriggerDialog.Click += new System.EventHandler(this.btnThemeTriggerDialog_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(200, 277);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(122, 44);
            this.btnFinish.TabIndex = 4;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnPickHotKey
            // 
            this.btnPickHotKey.Location = new System.Drawing.Point(16, 104);
            this.btnPickHotKey.Name = "btnPickHotKey";
            this.btnPickHotKey.Size = new System.Drawing.Size(152, 23);
            this.btnPickHotKey.TabIndex = 5;
            this.btnPickHotKey.Text = "Select Key To Trigger";
            this.btnPickHotKey.UseVisualStyleBackColor = true;
            this.btnPickHotKey.Click += new System.EventHandler(this.btnPickHotKey_Click);
            // 
            // lblKeyOK
            // 
            this.lblKeyOK.AutoSize = true;
            this.lblKeyOK.ForeColor = System.Drawing.Color.Red;
            this.lblKeyOK.Location = new System.Drawing.Point(174, 109);
            this.lblKeyOK.Name = "lblKeyOK";
            this.lblKeyOK.Size = new System.Drawing.Size(66, 13);
            this.lblKeyOK.TabIndex = 6;
            this.lblKeyOK.Text = "Not Finished";
            // 
            // lblThemeOK
            // 
            this.lblThemeOK.AutoSize = true;
            this.lblThemeOK.ForeColor = System.Drawing.Color.Red;
            this.lblThemeOK.Location = new System.Drawing.Point(174, 138);
            this.lblThemeOK.Name = "lblThemeOK";
            this.lblThemeOK.Size = new System.Drawing.Size(66, 13);
            this.lblThemeOK.TabIndex = 7;
            this.lblThemeOK.Text = "Not Finished";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(16, 288);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 8;
            // 
            // chkToggle
            // 
            this.chkToggle.AutoSize = true;
            this.chkToggle.Location = new System.Drawing.Point(16, 162);
            this.chkToggle.Name = "chkToggle";
            this.chkToggle.Size = new System.Drawing.Size(91, 17);
            this.chkToggle.TabIndex = 9;
            this.chkToggle.Text = "Theme toggle";
            this.chkToggle.UseVisualStyleBackColor = true;
            this.chkToggle.CheckedChanged += new System.EventHandler(this.chkToggle_CheckedChanged);
            // 
            // btnSecondTheme
            // 
            this.btnSecondTheme.Location = new System.Drawing.Point(16, 186);
            this.btnSecondTheme.Name = "btnSecondTheme";
            this.btnSecondTheme.Size = new System.Drawing.Size(152, 23);
            this.btnSecondTheme.TabIndex = 10;
            this.btnSecondTheme.Text = "Select Second Theme";
            this.btnSecondTheme.UseVisualStyleBackColor = true;
            this.btnSecondTheme.Click += new System.EventHandler(this.btnSecondTheme_Click);
            // 
            // lblTheme2OK
            // 
            this.lblTheme2OK.AutoSize = true;
            this.lblTheme2OK.ForeColor = System.Drawing.Color.Red;
            this.lblTheme2OK.Location = new System.Drawing.Point(174, 191);
            this.lblTheme2OK.Name = "lblTheme2OK";
            this.lblTheme2OK.Size = new System.Drawing.Size(66, 13);
            this.lblTheme2OK.TabIndex = 12;
            this.lblTheme2OK.Text = "Not Finished";
            // 
            // HotKeyPickerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 333);
            this.Controls.Add(this.lblTheme2OK);
            this.Controls.Add(this.btnSecondTheme);
            this.Controls.Add(this.chkToggle);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblThemeOK);
            this.Controls.Add(this.lblKeyOK);
            this.Controls.Add(this.btnPickHotKey);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnThemeTriggerDialog);
            this.Controls.Add(this.lblHKID);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HotKeyPickerForm";
            this.Text = "Pick Hotkey";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblHKID;
        private System.Windows.Forms.OpenFileDialog fileFirstTheme;
        private System.Windows.Forms.Button btnThemeTriggerDialog;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnPickHotKey;
        private System.Windows.Forms.Label lblKeyOK;
        private System.Windows.Forms.Label lblThemeOK;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.CheckBox chkToggle;
        private System.Windows.Forms.Button btnSecondTheme;
        private System.Windows.Forms.Label lblTheme2OK;
    }
}