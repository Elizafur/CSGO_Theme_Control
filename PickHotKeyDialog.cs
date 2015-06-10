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

using System;
using System.Windows.Forms;

namespace CSGO_Theme_Control
{
    /// <summary>
    /// A Form used to pick a new global hotkey.
    /// This form will monitor keypresses when active.
    /// </summary>
    public partial class PickHotKeyDialog : Form
    {
        public Keys Key;
        public Constants.KeyModifier KeyMod;
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
            }
            else
            {
                lblError.Text = "A Key was not chosen.";
            }
        }

        private void PickHotKeyDialog_KeyDown(object sender, KeyEventArgs e)
        {
            this.lblPickKey.Text    = "";
            this.lblKeyPressed.Text = ((char)e.KeyValue).ToString();
            this.Key                = (Keys)e.KeyValue;

            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                this.lblKeyMod.Text = "SHIFT";
                this.KeyMod = Constants.KeyModifier.SHIFT;
            }
            else if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                this.lblKeyMod.Text = "ALT";
                this.KeyMod = Constants.KeyModifier.ALT;
            }
            else if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                this.lblKeyMod.Text = "CONTROL";
                this.KeyMod = Constants.KeyModifier.CONTROL;
            }
            else
            {
                this.lblKeyMod.Text = "NONE";
                this.KeyMod = Constants.KeyModifier.NONE;
            }

            this.KeyPressed = true;

        }
    }
}
