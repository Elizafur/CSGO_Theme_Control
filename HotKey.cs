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
    /// An unsafe struct which holds a char*.
    /// This struct is primarily to retrieve data from different forms via use of
    /// 'unsafe' pointers to instances of these structs.
    /// </summary>
    /// <remarks>
    /// ThemePath: A c_string representation of an absolute path to a theme.
    /// </remarks>
    unsafe public struct ThemeDataHolder
    {
        public char* ThemePath1;
        public char* ThemePath2;
    }
    
    /// <summary>
    /// A struct representation of a HotKey.
    /// This is valuable as it is able to be used as a pointer.
    /// This allows us to transfer data about HotKeys between forms.
    /// </summary>
    /// <remarks>
    /// id: A signed int32 representation of the hotkeys windows ID.
    /// keyModifier: A signed int32 representation of the modifer key in this hotkey. <seealso cref="Constants.KeyModifier"/>
    /// keyHashCode: A signed int32 hash code of the key.
    /// key: A Keys representation of they key pressed. <seealso cref="Keys"/>
    /// </remarks>
    public struct HotKeyDataHolder
    {
        public int id;
        public int keyModifier;
        public int keyHashCode;
        public Keys key;
    }

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
        public int id;
        public int keyModifier;
        public int keyHashCode;
        public Keys key;

        /// <summary>
        /// Constructor for HotKey class.
        /// </summary>
        /// <param name="_hotkeyID">An ID to be given to the hotkey. This ID should not be taken by any currently registered hotkeys of the program.</param>
        /// <param name="_keyModifier">Int thats represents the modifier to the key. For a list of key modifiers see Constants.KeyModifier</param>
        /// <param name="_key">The Keys enumeration value of the key represented by the Hotkey.</param>
        /// <seealso cref="Constants.KeyModifier"/>
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

        /// <summary>
        /// A method to get the hash code of an instance of HotKey.
        /// </summary>
        /// 
        /// <returns>The hash code of an instance of class HotKey.</returns>
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
        public static String KeyModToString(Constants.KeyModifier km)
        {
            if (km == Constants.KeyModifier.ALT)
                return "ALT";
            else if (km == Constants.KeyModifier.CONTROL)
                return "CONTROL";
            else if (km == Constants.KeyModifier.SHIFT)
                return "SHIFT";
            else
                return "";
        }

        /// <summary>
        /// Used to get a string representation of this HotKey instance's key member. 
        /// </summary>
        /// <returns>A string representation of the HotKey instance's key member. </returns>
        public override string ToString()
        {
            string s = KeyModToString((Constants.KeyModifier)this.keyModifier);
            if (s != "")
                s += " ";

            s += ((char)this.key).ToString();

            return s;
        }

    }
}
