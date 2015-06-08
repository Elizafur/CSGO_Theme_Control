//    This file is part of CSGO Theme Control.
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
    partial class HotKeyRemovalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HotKeyRemovalForm));
            this.cmbHotkeys = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFinish = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.btnRemoveAllHotKeys = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbHotkeys
            // 
            this.cmbHotkeys.FormattingEnabled = true;
            this.cmbHotkeys.Location = new System.Drawing.Point(87, 36);
            this.cmbHotkeys.Name = "cmbHotkeys";
            this.cmbHotkeys.Size = new System.Drawing.Size(121, 21);
            this.cmbHotkeys.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hotkey to remove";
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(169, 239);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(141, 50);
            this.btnFinish.TabIndex = 2;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(13, 210);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 3;
            // 
            // btnRemoveAllHotKeys
            // 
            this.btnRemoveAllHotKeys.Location = new System.Drawing.Point(12, 266);
            this.btnRemoveAllHotKeys.Name = "btnRemoveAllHotKeys";
            this.btnRemoveAllHotKeys.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAllHotKeys.TabIndex = 4;
            this.btnRemoveAllHotKeys.Text = "Remove all";
            this.btnRemoveAllHotKeys.UseVisualStyleBackColor = true;
            this.btnRemoveAllHotKeys.Click += new System.EventHandler(this.btnRemoveAllHotKeys_Click);
            // 
            // HotKeyRemovalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 301);
            this.Controls.Add(this.btnRemoveAllHotKeys);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbHotkeys);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HotKeyRemovalForm";
            this.Text = "Remove Hotkey";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbHotkeys;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnRemoveAllHotKeys;
    }
}