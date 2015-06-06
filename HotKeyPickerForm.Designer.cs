﻿namespace CSGO_Theme_Control
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblHKID = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnThemeTriggerDialog = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnPickHotKey = new System.Windows.Forms.Button();
            this.lblKeyOK = new System.Windows.Forms.Label();
            this.lblThemeOK = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
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
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "Theme Files|*.theme";
            this.openFileDialog.InitialDirectory = "C:\\Windows\\Resources";
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
            // HotKeyPickerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 333);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblThemeOK);
            this.Controls.Add(this.lblKeyOK);
            this.Controls.Add(this.btnPickHotKey);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnThemeTriggerDialog);
            this.Controls.Add(this.lblHKID);
            this.Controls.Add(this.label1);
            this.Name = "HotKeyPickerForm";
            this.Text = "HotKeyPickerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblHKID;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnThemeTriggerDialog;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnPickHotKey;
        private System.Windows.Forms.Label lblKeyOK;
        private System.Windows.Forms.Label lblThemeOK;
        private System.Windows.Forms.Label lblError;
    }
}