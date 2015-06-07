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
    unsafe public partial class HotkeyRemovalForm : Form
    {
        private Dictionary<HotKey, String>  HotKeys         = null;
        private HotKeyDataHolder*           HKAddress       = null;

        public HotkeyRemovalForm(HotKeyDataHolder* _hkAddress, Dictionary<HotKey, String> existingHotkeys)
        {
            InitializeComponent();
            this.HotKeys = existingHotkeys;
            this.HKAddress = _hkAddress;

            foreach (KeyValuePair<HotKey, String> entry in this.HotKeys)
            {
                this.cmbHotkeys.Items.Add(entry.Key);
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (this.cmbHotkeys.SelectedIndex == -1)
            {
                this.lblError.Text = "No hotkey was selected.";
                return;
            }


            HotKey selected = (HotKey)cmbHotkeys.Items[cmbHotkeys.SelectedIndex];

            //Sends all the hotkeys information to a selected address which will then be used to remove from the
            //Hotkey list in the main ThemeControl form.
            HKAddress->id               = selected.id;
            HKAddress->keyModifier      = selected.keyModifier;
            HKAddress->key              = selected.key;
            HKAddress->keyHashCode      = selected.key.GetHashCode();
            this.DialogResult = DialogResult.OK;
        }

        
    }
}
