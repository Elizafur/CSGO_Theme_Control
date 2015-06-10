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
using System.Drawing;

namespace CSGO_Theme_Control
{
    /// <summary>
    /// Class containing various methods that do not fit into any other class used to help with simple actions.
    /// </summary>
    public static class HelperFunc
    {

        /// <summary>
        /// Used to create whitespace of various amounts
        /// </summary>
        /// 
        /// <param name="amount">An unsigned integer representing the number of whitespaces you wish.</param>
        /// 
        /// <returns>A String containing variable amounts of whitespace.</returns>
        public static string CreateWhiteSpace(uint amount)
        {
            string s = "";
            for (int i = 0; i < amount; i++)
            {
                s += " ";
            }

            return s;
        }

        /// <summary>
        /// Creates a shorthand filename for an absolute path.
        /// </summary>
        /// 
        /// <param name="FullThemePath">Absolute path to the theme starting from the C: or equivalent drive.</param>
        /// 
        /// <returns>A new string created at the last index of '.'</returns>
        /// 
        /// <example>C:\\Windows\\Resources\\Ease of Access Themes\\hc1.theme => hc1.theme</example>
        public static string CreateShortHandTheme(string FullThemePath)
        {
            int index = FullThemePath.LastIndexOf("\\");
            return FullThemePath.Substring(index + 1);
        }

        /// <summary>
        /// Creates a string with the first character turned to uppercase.
        /// </summary>
        /// 
        /// <param name="s">String to make the first character uppercase.</param>
        /// 
        /// <returns>A new string with the first character uppercase.</returns>
        public static string UpperCaseFirstChar(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return String.Empty;
            }

            return char.ToUpper(s[0]) + s.Substring(1);
        }

        /// <summary>
        /// Mutates a provided forms location to the direct right of a parent if
        /// the parent is located in the left side of the screen
        /// otherwise it mutates the location to the direct left.
        /// </summary>
        /// 
        /// <param name="child">The child form which will be mutated.</param>
        /// 
        /// <param name="parent">The parent form to base the child's location on.</param>
        public static void CreateFormStartPosition(ref Form child, Form parent)
        {
            child.StartPosition = FormStartPosition.Manual;
            Point pLoc = parent.Location;
            //Since pLoc is the upper left hand corner and we want a point in the center of the window we divide the width
            //of the parent container by 2 and add to that X coordinate to get something near the center of the form.
            if (pLoc.X + (parent.Width / 2) < System.Windows.SystemParameters.FullPrimaryScreenWidth / 2)
                child.Location = new Point(parent.Left + parent.Width, parent.Top);
            else
                child.Location = new Point(parent.Left - (child.Width), parent.Top);
        }
    }
}
