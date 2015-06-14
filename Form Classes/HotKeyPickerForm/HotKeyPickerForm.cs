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
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CSGO_Theme_Control.Base_Classes.HotKey;
using CSGO_Theme_Control.Base_Classes.Themes;

namespace CSGO_Theme_Control
{
    /// <summary>
    /// An unsafe class used to create new global HotKeys.
    /// </summary>
    unsafe public partial class HotKeyPickerForm : Form
    {
        private Dictionary<HotKey, ThemePathContainer>  HotKeys         = null;
        private String                                  ThemeToExecute  = null;
        private String                                  Theme2ToExecute = null;
        private Keys                                    HKKey;
        private Constants.KeyModifier                   HKKeyMod;
        private Int32                                   HKID            = 0;
        private HotKeyDataHolder*                       HKAddress       = null;
        private ThemeDataHolder*                        ThemeData       = null;

        /// <summary>
        /// Constructor for HotKeyPickerForm class.
        /// </summary>
        /// 
        /// <param name="_hkAddress">
        /// A pointer to a HotKeyDataHolder. The members of this struct will be mutated by the form.
        /// The contents of this pointer will include values selected via user keyboard input on this form.
        /// </param>
        /// 
        /// <param name="_themeData">
        /// A pointer to a ThemeDataHolder struct. The members of this struct will be mutated by the form.
        /// The contents of this pointer will be a user selected path to a theme file. 
        /// </param>
        /// 
        /// <param name="existingHotkeys">A dictionary of existing Hotkeys and their corresponding actions.</param>
        public HotKeyPickerForm(HotKeyDataHolder* _hkAddress, ThemeDataHolder* _themeData, Dictionary<HotKey, ThemePathContainer> existingHotkeys)
        {
            InitializeComponent();
            this.HotKeys = existingHotkeys;
            this.HKID = this.getNextHKID();
            this.lblHKID.Text += HKID;
            this.HKAddress = _hkAddress;
            this.ThemeData = _themeData;

            this.btnSecondTheme.Hide();
            this.lblTheme2OK.Hide();
        }

        /// <summary>
        /// Method to get the next available HotKey ID for your application.
        /// </summary>
        /// <returns>The next hotkey ID available for use in your program. (Usually last registered hotkey id + 1).</returns>
        public int getNextHKID()
        {
            if (this.HotKeys == null || this.HotKeys.Count < 1)
                return 0;

            List<int> HKIDList = new List<int>();

            foreach(KeyValuePair<HotKey, ThemePathContainer> entry in this.HotKeys)
                HKIDList.Add(entry.Key.id);

            int max = HKIDList.Max();

            return max + 1;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            //Used to make sure we have all things filled out;
            //Not the best way since we're using strings but whatever.
            if ((lblKeyOK.Text == "Not Finished" || lblThemeOK.Text == "Not Finished") || (chkToggle.Checked && lblTheme2OK.Text == "Not Finished"))
            {
                this.lblError.Text = "A required field was not selected.";
                return;
            }

            HKAddress->id          = this.HKID;
            HKAddress->key         = this.HKKey;
            HKAddress->keyModifier = (int)this.HKKeyMod;
            HKAddress->keyHashCode = this.HKKey.GetHashCode();

            fixed (char* cstr = this.ThemeToExecute)
            {
                ThemeData->ThemePath1 = cstr;
            }

            if (chkToggle.Checked)
            {
                fixed (char* cstr = this.Theme2ToExecute)
                {
                    ThemeData->ThemePath2 = cstr;
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void btnThemeTriggerDialog_Click(object sender, EventArgs e)
        {
            DialogResult result = this.fileFirstTheme.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.ThemeToExecute = fileFirstTheme.FileName;
                this.lblThemeOK.Text = "Finished";
                this.lblThemeOK.ForeColor = Color.Green;
            }
        }

        private void btnPickHotKey_Click(object sender, EventArgs e)
        {
            PickHotKeyDialog phkd = new PickHotKeyDialog();
            Form casted = (Form)phkd;
            HelperFunc.CreateFormStartPosition(ref casted, this);
            phkd = (PickHotKeyDialog)casted;

            DialogResult result = phkd.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.HKKey    = phkd.Key;
                this.HKKeyMod = phkd.KeyMod;

                this.lblKeyOK.Text = "Finished";
                this.lblKeyOK.ForeColor = Color.Green;
            }
        }

        private void chkToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (chkToggle.Checked)
            {
                btnSecondTheme.Show();
                lblTheme2OK.Show();
            }
            else
            {
                btnSecondTheme.Hide();
                lblTheme2OK.Hide();
            }
        }

        private void btnSecondTheme_Click(object sender, EventArgs e)
        {
            DialogResult result = this.fileFirstTheme.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Theme2ToExecute = fileFirstTheme.FileName;
                this.lblTheme2OK.Text = "Finished";
                this.lblTheme2OK.ForeColor = Color.Green;
            }
        }
    }
}
