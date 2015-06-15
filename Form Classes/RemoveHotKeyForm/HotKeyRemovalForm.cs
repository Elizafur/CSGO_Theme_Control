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
using System.Windows.Forms;
using CSGO_Theme_Control.Base_Classes.HotKey;
using CSGO_Theme_Control.Base_Classes.Themes;

namespace CSGO_Theme_Control.Form_Classes.RemoveHotKeyForm
{
    /// <summary>
    /// An unsafe class used to remove global hotkeys.
    /// </summary>
    unsafe public partial class HotKeyRemovalForm : Form
    {
        private readonly HotKeyDataHolder* HKAddress;

        /// <summary>
        /// Constructor for HotKeyRemovalForm class.
        /// </summary>
        /// 
        /// <param name="_hkAddress">
        /// Pointer to a HotKeyDataHolder struct. This structs members will be mutated by the Form.
        /// The contents of this pointer will include values selected via user keyboard input on this form.
        /// </param>
        /// 
        /// <param name="existingHotkeys">A dictionary of existing Hotkeys and their corresponding actions.</param>
        public HotKeyRemovalForm(HotKeyDataHolder* _hkAddress, Dictionary<HotKey, ThemePathContainer> existingHotkeys)
        {
            InitializeComponent();
            HKAddress = _hkAddress;

            foreach (KeyValuePair<HotKey, ThemePathContainer> entry in existingHotkeys)
            {
                cmbHotkeys.Items.Add(entry.Key);
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (cmbHotkeys.SelectedIndex == -1)
            {
                lblError.Text = @"No hotkey was selected.";
                return;
            }

            HotKey selected = (HotKey)cmbHotkeys.Items[cmbHotkeys.SelectedIndex];

            //Sends all the hotkeys information to a selected address which will then be used to remove from the
            //Hotkey list in the main ThemeControl form.
            HKAddress->id               = selected.id;
            HKAddress->keyModifier      = selected.keyModifier;
            HKAddress->key              = selected.key;
            HKAddress->keyHashCode      = selected.key.GetHashCode();
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Returns a DialogResult of Yes. This is a signal that all hotkeys should be removed from the parent list.
        /// </summary>
        private void btnRemoveAllHotKeys_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        } 
    }
}
