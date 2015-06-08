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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSGO_Theme_Control
{
    /// <summary>
    /// An unsafe class used to create new globa HotKeys.
    /// </summary>
    unsafe public partial class HotKeyPickerForm : Form
    {
        private Dictionary<HotKey, String>  HotKeys         = null;
        private String                      ThemeToExecute  = null;
        private Keys                        HKKey;
        private Constants.KeyModifier       HKKeyMod;
        private int                         HKID            = 0;
        private HotKeyDataHolder*           HKAddress       = null;
        private ThemeDataHolder*            ThemeData       = null;

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
        public HotKeyPickerForm(HotKeyDataHolder* _hkAddress, ThemeDataHolder* _themeData, Dictionary<HotKey, String> existingHotkeys)
        {
            InitializeComponent();
            this.HotKeys = existingHotkeys;
            this.HKID = this.getNextHKID();
            this.lblHKID.Text += HKID;
            this.HKAddress = _hkAddress;
            this.ThemeData = _themeData;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            //Used to make sure we have all things filled out;
            //Not the best way since we're using strings but whatever.
            if (lblKeyOK.Text == "Not Finished" || lblThemeOK.Text == "Not Finished")
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
                ThemeData->ThemePath = cstr;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private int getNextHKID()
        {
            if (this.HotKeys == null || this.HotKeys.Count < 1)
                return 0;

            List<int> HKIDList = new List<int>();

            foreach(KeyValuePair<HotKey, String> entry in this.HotKeys)
                HKIDList.Add(entry.Key.id);

            int max = HKIDList.Max();

            return max + 1;
        }

        private void btnThemeTriggerDialog_Click(object sender, EventArgs e)
        {
            DialogResult result = this.openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.ThemeToExecute = openFileDialog.FileName;
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
    }
}
