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

using System.Windows.Forms;

namespace CSGO_Theme_Control.Base_Classes.HotKey
{


    /// <summary>
    /// A class used to represent a global hotkey for Windows.
    /// These hotkeys must be registered with Windows manually 
    /// as they are not registered within the HotKey class itself.
    /// </summary>
    /// 
    /// <see cref="HotKeyDataHolder"/>
    /// 
    /// <example>
    /// <c>
    /// HotKey MyHotKey = new HotKey(0, 0, Keys.T);
    /// RegisterHotkey(MyHotKey.id, MyHotKey.keyModifier, MyHotKey.key.getHashCode());
    /// //This will register a global hotkey with windows which will send your form
    /// //a system message whenever pressed.
    /// //This message can be intercepted via overriding WndProc and searching for the message '0x0312'.
    /// </c>
    /// </example>
    public class HotKey
    {
        public readonly int  id;
        public readonly int  keyModifier;
        public readonly int  keyHashCode;
        public readonly Keys key;

        /// <summary>
        /// Constructor for HotKey class.
        /// </summary>
        /// <param name="_hotkeyID">An ID to be given to the hotkey. This ID should not be taken by any currently registered hotkeys of the program.</param>
        /// <param name="_keyModifier">Int thats represents the modifier to the key. For a list of key modifiers see Constants.KeyModifier</param>
        /// <param name="_key">The Keys enumeration value of the key represented by the Hotkey.</param>
        /// <seealso cref="CSGO_Theme_Control.Base_Classes.Constants.Constants.KeyModifier"/>
        public HotKey(int _hotkeyID, int _keyModifier, Keys _key)
        {
            id          = _hotkeyID;
            keyModifier = _keyModifier;
            key         = _key;
            keyHashCode = _key.GetHashCode();
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

        /// <summary>
        /// A method to get the hash code of an instance of HotKey.
        /// </summary>
        /// 
        /// <returns>The hash code of an instance of class HotKey.</returns>
        public override int GetHashCode()
        {
            int hash = 11;
            hash += (hash * 4) + id.GetHashCode();
            hash += (hash * 4) + keyModifier.GetHashCode();
            hash += (hash * 4) + key.GetHashCode();

            return hash;
        }

        /// <summary>
        /// Returns a new HotKey created from a provided HotKeyDataHolder.
        /// </summary>
        /// 
        /// <param name="hkdh">A HotKeyDataHolder.</param>
        /// 
        /// <returns>A new hotkey created from the given HotKeyDataHolder</returns>
        public static HotKey FormNewHotKey(HotKeyDataHolder hkdh)
        {
            return new HotKey(hkdh.id, hkdh.keyModifier, hkdh.key);
        }

        /// <summary cref="System.String">
        /// Returns the String representation of a given KeyModifier enumeration value.
        /// </summary>
        /// 
        /// <param name="km">A KeyModifier enumeration value</param>
        /// 
        /// <returns>A string representation of the KeyModifer</returns>
        public static string KeyModToString(Constants.Constants.KeyModifier km)
        {
            switch (km)
            {
                case Constants.Constants.KeyModifier.ALT:
                    return "ALT";
                case Constants.Constants.KeyModifier.CONTROL:
                    return "CONTROL";
                case Constants.Constants.KeyModifier.SHIFT:
                    return "SHIFT";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Used to get a string representation of this HotKey instance's key member with the modifier prepended.. 
        /// </summary>
        /// <returns>A string representation of the HotKey instance's key member with the modifier prepended.</returns>
        public override string ToString()
        {
            string s = KeyModToString((Constants.Constants.KeyModifier)keyModifier);
            if (s != "")
                s += " ";

            s += ((char)key).ToString();

            return s;
        }

    }
}
