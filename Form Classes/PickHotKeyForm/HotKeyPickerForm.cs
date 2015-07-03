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
using CSGO_Theme_Control.Base_Classes.Constants;
using CSGO_Theme_Control.Base_Classes.Helper;
using CSGO_Theme_Control.Base_Classes.HotKey;
using CSGO_Theme_Control.Base_Classes.Themes;
using CSGO_Theme_Control.Form_Classes.PickHotKeyForm.HotKeyDialogForm;

namespace CSGO_Theme_Control.Form_Classes.PickHotKeyForm
{
    /// <summary>
    /// An unsafe class used to create new global HotKeys.
    /// </summary>
    unsafe public partial class HotKeyPickerForm : Form
    {
        private readonly Dictionary<HotKey, ThemePathContainer> HotKeys;
        private          string                                 ThemeToExecute;
        private          string                                 Theme2ToExecute;
        private          Keys                                   HKKey;
        private          Constants.KeyModifier                  HKKeyMod;
        private readonly Int32                                  HKID;
        private readonly HotKeyDataHolder*                      HKAddress;
        private readonly ThemeDataHolder*                       ThemeData;

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
            HotKeys         = existingHotkeys;
            HKID            = getNextHKID();
            lblHKID.Text    += HKID;
            HKAddress       = _hkAddress;
            ThemeData       = _themeData;

            btnSecondTheme.Hide();
            lblTheme2OK.Hide();
        }

        /// <summary>
        /// Method to get the next available HotKey ID for your application.
        /// </summary>
        /// <returns>The next hotkey ID available for use in your program. (Usually last registered hotkey id + 1).</returns>
        public int getNextHKID()
        {
            if (HotKeys == null || HotKeys.Count < 1)
                return 0;

            List<int> HKIDList = new List<int>();

            foreach(KeyValuePair<HotKey, ThemePathContainer> entry in HotKeys)
                HKIDList.Add(entry.Key.id);

            int max = HKIDList.Max();

            return max + 1;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            //Used to make sure we have all things filled out;
            //Not the best way since we're using strings but whatever.
            if ((lblKeyOK.Text == @"Not Finished" || lblThemeOK.Text == @"Not Finished") || (chkToggle.Checked && lblTheme2OK.Text == @"Not Finished"))
            {
                lblError.Text = @"A required field was not selected.";
                return;
            }

            HKAddress->id          = HKID;
            HKAddress->key         = HKKey;
            HKAddress->keyModifier = (int)HKKeyMod;
            HKAddress->keyHashCode = HKKey.GetHashCode();

            fixed (char* cstr = ThemeToExecute)
            {
                ThemeData->ThemePath1 = cstr;
            }

            if (chkToggle.Checked)
            {
                fixed (char* cstr = Theme2ToExecute)
                {
                    ThemeData->ThemePath2 = cstr;
                }
            }

            DialogResult = DialogResult.OK;
            Close();

        }

        private void btnThemeTriggerDialog_Click(object sender, EventArgs e)
        {
            DialogResult result = fileFirstTheme.ShowDialog();
            if (result == DialogResult.OK)
            {
                ThemeToExecute = fileFirstTheme.FileName;
                lblThemeOK.Text = @"Finished";
                lblThemeOK.ForeColor = Color.Green;
            }
        }

        private void btnPickHotKey_Click(object sender, EventArgs e)
        {
            PickHotKeyDialog phkd = new PickHotKeyDialog();
            HelperFunc.CreateFormStartPosition(ref phkd, this);

            DialogResult result = phkd.ShowDialog();

            if (result != DialogResult.OK)
                return;

            HKKey    = phkd.Key;
            HKKeyMod = phkd.KeyMod;

            lblKeyOK.Text = @"Finished";
            lblKeyOK.ForeColor = Color.Green;
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
            DialogResult result = fileFirstTheme.ShowDialog();
            if (result == DialogResult.OK)
            {
                Theme2ToExecute = fileFirstTheme.FileName;
                lblTheme2OK.Text = @"Finished";
                lblTheme2OK.ForeColor = Color.Green;
            }
        }
    }
}
