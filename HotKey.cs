using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSGO_Theme_Control
{
    unsafe public struct ThemeDataHolder
    {
        public char* ThemePath;
    }

    public struct HotKeyDataHolder
    {
        public int id;
        public int keyModifier;
        public int keyHashCode;
        public Keys key;
    }

    public class HotKey
    {
        public int id;
        public int keyModifier;
        public int keyHashCode;
        public Keys key;

        public HotKey(int _hotkeyID, int _keyModifier, Keys _key)
        {
            this.id          = _hotkeyID;
            this.keyModifier = _keyModifier;
            this.key         = _key;
            this.keyHashCode = _key.GetHashCode();
        }

        public static bool operator==(HotKey h1, HotKey h2)
        {

            if (ReferenceEquals(h1, h2)) return true;

            if (ReferenceEquals(h1, null) || ReferenceEquals(h2, null)) return false;

            //We don't need to check for keyHash here since if the key is equal, the hash will be as well.
            return (h1.id == h2.id && h1.key == h2.key && h1.keyModifier == h2.keyModifier);
        }

        public static bool operator!=(HotKey h1, HotKey h2)
        {
            return !(h1 == h2);
        }

        public override bool Equals(object o)
        {
            if (o == null)
                return false;

            HotKey hk = o as HotKey;
            if ((object)hk == null)
                return false;

            return (this == hk);
        }

        public override int GetHashCode()
        {
            if (this == null)
                return 0;

            int hash = 11;
            hash += (hash * 4) + id.GetHashCode();
            hash += (hash * 4) + keyModifier.GetHashCode();
            hash += (hash * 4) + key.GetHashCode();

            return hash;
        }

        public static HotKey FormNewHotKey(HotKeyDataHolder hkdh)
        {
            return new HotKey(hkdh.id, hkdh.keyModifier, hkdh.key);
        }

    }
}
