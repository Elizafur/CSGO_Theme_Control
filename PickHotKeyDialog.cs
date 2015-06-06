using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSGO_Theme_Control
{
    public partial class PickHotKeyDialog : Form
    {
        public Keys Key;
        public ThemeControl.KeyModifier KeyMod;
        private bool KeyPressed = false;


        public PickHotKeyDialog()
        {
            InitializeComponent();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (this.KeyPressed)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblError.Text = "A Key was not chosen.";
            }
        }


        private void PickHotKeyDialog_KeyDown(object sender, KeyEventArgs e)
        {
            this.lblPickKey.Text = "";
            this.lblKeyPressed.Text = ((char)e.KeyValue).ToString();
            //TODO: Make sure this is casting correctly.
            this.Key = (Keys)e.KeyValue;

            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                this.lblKeyMod.Text = "SHIFT";
                this.KeyMod = ThemeControl.KeyModifier.SHIFT;
            }
            else if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                this.lblKeyMod.Text = "ALT";
                this.KeyMod = ThemeControl.KeyModifier.ALT;
            }
            else if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                this.lblKeyMod.Text = "CONTROL";
                this.KeyMod = ThemeControl.KeyModifier.CONTROL;
            }
            else
            {
                this.lblKeyMod.Text = "NONE";
                this.KeyMod = ThemeControl.KeyModifier.NONE;
            }

            this.KeyPressed = true;

        }


    }
}
