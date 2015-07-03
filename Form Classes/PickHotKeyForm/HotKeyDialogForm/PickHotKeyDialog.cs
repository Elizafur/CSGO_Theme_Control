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
using CSGO_Theme_Control.Base_Classes.Constants;

namespace CSGO_Theme_Control.Form_Classes.PickHotKeyForm.HotKeyDialogForm
{
    /// <summary>
    /// A Form used to pick a new global hotkey.
    /// This form will monitor keypresses when active.
    /// </summary>
    public partial class PickHotKeyDialog : Form
    {
        public  Keys                    Key;
        public  Constants.KeyModifier   KeyMod;
        private bool                    KeyPressed;

        public PickHotKeyDialog()
        {
            InitializeComponent();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (KeyPressed)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                lblError.Text = @"A Key was not chosen.";
            }
        }

        //Note(Eli): This is done because the function keys when casted to characters do not display properly and 
        //instead map to various keys around the keyboard.
        private string getKeyString(Keys k)
        {
            switch (Key)
            {
                case Keys.F1:
                    return "F1";
                case Keys.F2:
                    return "F2";
                case Keys.F3:
                    return "F3";
                case Keys.F4:
                    return "F4";
                case Keys.F5:
                    return "F5";
                case Keys.F6:
                    return "F6";
                case Keys.F7:
                    return "F7";
                case Keys.F8:
                    return "F8";
                case Keys.F9:
                    return "F9";
                case Keys.F10:
                    return "F10";
                case Keys.F11:
                    return "F11";
                case Keys.F12:
                    return "F12";
                default:
                    return ((char)k).ToString();
            }
        }

        private void PickHotKeyDialog_KeyDown(object sender, KeyEventArgs e)
        {
            lblPickKey.Text    = "";
            Key                = (Keys)e.KeyValue;
            lblKeyPressed.Text = getKeyString(Key);

            if ((ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                lblKeyMod.Text = @"SHIFT";
                KeyMod = Constants.KeyModifier.SHIFT;
            }
            else if ((ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                lblKeyMod.Text = @"ALT";
                KeyMod = Constants.KeyModifier.ALT;
            }
            else if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                lblKeyMod.Text = @"CONTROL";
                KeyMod = Constants.KeyModifier.CONTROL;
            }
            else
            {
                lblKeyMod.Text = @"NONE";
                KeyMod = Constants.KeyModifier.NONE;
            }

            KeyPressed = true;

        }
    }
}
