namespace CSGO_Theme_Control.Form_Classes.HelpUserForm
{
    partial class HelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            this.lblLinkToGithub = new System.Windows.Forms.LinkLabel();
            this.txtHelpBox = new System.Windows.Forms.RichTextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtDefaultThemePath = new System.Windows.Forms.RichTextBox();
            this.txtUserThemePath = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTroubleShoot = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lblLinkToGithub
            // 
            this.lblLinkToGithub.AutoSize = true;
            this.lblLinkToGithub.Location = new System.Drawing.Point(64, 9);
            this.lblLinkToGithub.Name = "lblLinkToGithub";
            this.lblLinkToGithub.Size = new System.Drawing.Size(241, 13);
            this.lblLinkToGithub.TabIndex = 0;
            this.lblLinkToGithub.TabStop = true;
            this.lblLinkToGithub.Text = "For updates visit the CSGO Theme Control Github";
            this.lblLinkToGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLinkToGithub_LinkClicked);
            // 
            // txtHelpBox
            // 
            this.txtHelpBox.BackColor = System.Drawing.SystemColors.Control;
            this.txtHelpBox.Location = new System.Drawing.Point(12, 116);
            this.txtHelpBox.Name = "txtHelpBox";
            this.txtHelpBox.ReadOnly = true;
            this.txtHelpBox.Size = new System.Drawing.Size(352, 79);
            this.txtHelpBox.TabIndex = 1;
            this.txtHelpBox.Text = "";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(275, 346);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 31);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtDefaultThemePath
            // 
            this.txtDefaultThemePath.Location = new System.Drawing.Point(101, 79);
            this.txtDefaultThemePath.Multiline = false;
            this.txtDefaultThemePath.Name = "txtDefaultThemePath";
            this.txtDefaultThemePath.ReadOnly = true;
            this.txtDefaultThemePath.Size = new System.Drawing.Size(229, 20);
            this.txtDefaultThemePath.TabIndex = 3;
            this.txtDefaultThemePath.Text = "";
            this.txtDefaultThemePath.WordWrap = false;
            // 
            // txtUserThemePath
            // 
            this.txtUserThemePath.Location = new System.Drawing.Point(101, 31);
            this.txtUserThemePath.Name = "txtUserThemePath";
            this.txtUserThemePath.ReadOnly = true;
            this.txtUserThemePath.Size = new System.Drawing.Size(228, 42);
            this.txtUserThemePath.TabIndex = 4;
            this.txtUserThemePath.Text = "";
            this.txtUserThemePath.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Custom Themes:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Default Themes:";
            // 
            // txtTroubleShoot
            // 
            this.txtTroubleShoot.BackColor = System.Drawing.SystemColors.Control;
            this.txtTroubleShoot.Location = new System.Drawing.Point(12, 201);
            this.txtTroubleShoot.Name = "txtTroubleShoot";
            this.txtTroubleShoot.ReadOnly = true;
            this.txtTroubleShoot.Size = new System.Drawing.Size(352, 139);
            this.txtTroubleShoot.TabIndex = 7;
            this.txtTroubleShoot.Text = "";
            this.txtTroubleShoot.WordWrap = false;
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 389);
            this.Controls.Add(this.txtTroubleShoot);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUserThemePath);
            this.Controls.Add(this.txtDefaultThemePath);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtHelpBox);
            this.Controls.Add(this.lblLinkToGithub);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HelpForm";
            this.Text = "Help";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblLinkToGithub;
        private System.Windows.Forms.RichTextBox txtHelpBox;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RichTextBox txtDefaultThemePath;
        private System.Windows.Forms.RichTextBox txtUserThemePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtTroubleShoot;
    }
}