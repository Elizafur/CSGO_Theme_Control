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
}
