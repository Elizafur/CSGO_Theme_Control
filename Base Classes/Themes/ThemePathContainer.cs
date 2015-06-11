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
using System.Linq;

namespace CSGO_Theme_Control
{
    /// <summary>
    /// The idea of this class is to act as a container for multiple themes. 
    /// This would allow us to create a 'BindToggle' for hotkeys.
    /// Meaning if we pressed 'T', for example, it would switch between two different themes.
    /// </summary>
    public class ThemePathContainer
    {
        private String[] Themes = new String[2] { null, null };
        private int CurrentlySelectedTheme = 1; //Note(Eli): Set to 1 so our method GetNextTheme will return the first element in Themes on first run.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="themes"></param>
        public ThemePathContainer(params string[] themes)
        {
            if (themes.Count() > 2)
                throw new ArgumentException(nameof(themes) + " must be less than or equal to 2 in length.");

            for (int i = 0; i < themes.Count(); i++)
                Themes[i] = themes[i];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetNextTheme()
        {
            if (Themes[1] == null || Themes[1] == String.Empty)
                return Themes[0];

            //Ternary operator because C# is dumb and apparantly cannot implicitly convert from bool to int without long drawn out code.
            return Themes[CurrentlySelectedTheme = (CurrentlySelectedTheme == 0) ? 1 : 0];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return HelperFunc.CreateShortHandTheme(Themes[0]) + ((Themes[1] == String.Empty || Themes[1] == null) ? "" : " " + HelperFunc.CreateShortHandTheme(Themes[1]));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string AbsoluteToString()
        {
            return "\"" + Themes[0] + "\" " + ((Themes[1] == String.Empty || Themes[1] == null) ? "\"null\"" : "\"" +  Themes[1] + "\"");
        }
    }
}
