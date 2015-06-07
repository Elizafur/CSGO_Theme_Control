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
    unsafe public partial class HotKeyPickerForm : Form
    {
        private Dictionary<HotKey, String>  HotKeys         = null;
        private String                      ThemeToExecute  = null;
        private Keys                        HKKey;
        private ThemeControl.KeyModifier    HKKeyMod;
        private int                         HKID            = 0;
        private HotKeyDataHolder*           HKAddress       = null;
        private ThemeDataHolder*            ThemeData       = null;

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
