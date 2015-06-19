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
using System.Drawing;
using System.Windows.Forms;

namespace CSGO_Theme_Control.Base_Classes.Helper
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
        /// <returns>A new string created at the last index of '\\' which results in the filename of the given themepath.</returns>
        /// 
        /// <example>C:\\Windows\\Resources\\Ease of Access Themes\\hc1.theme => hc1.theme</example>
        public static string CreateShortHandTheme(string FullThemePath)
        {
            int index = FullThemePath.LastIndexOf("\\", StringComparison.Ordinal);
            return FullThemePath.Substring(index + 1);
        }

        /// <summary>
        /// Returns the extension of a file.
        /// </summary>
        /// 
        /// <param name="file">Path to the file.</param>
        /// 
        /// <returns>A new string created at the last index of '.' which results in the extension of the given file.</returns>
        public static string GetFileExtension(string file)
        {
            int index = file.LastIndexOf(".", StringComparison.Ordinal);
            return file.Substring(index);
        }

        /// <summary>
        /// Creates a string with the first character turned to uppercase.
        /// </summary>
        /// 
        /// <param name="s">String to make the first character uppercase.</param>
        /// 
        /// <returns>A new string with the first character transformed to uppercase.</returns>
        public static string UpperCaseFirstChar(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return String.Empty;
            }

            return char.ToUpper(s[0]) + s.Substring(1);
        }

        /// <summary>
        /// Surrounds a string with the provided string.
        /// </summary>
        /// <param name="surrounding">The character/string to surround the string with</param>
        /// <param name="toSurround">The string to be surrounded</param>
        /// <returns>A new instance with the given string toSurround string by the given surrounding string.</returns>
        public static string SurroundWith(string surrounding, string toSurround)
        {
            return surrounding + toSurround + surrounding;
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
                child.Location = new Point(parent.Left - child.Width, parent.Top);
        }

        /// <summary>
        /// Attempts to convert the specified argument to a DateTime format. If the conversion fails DateTime.MaxValue is returned.
        /// </summary>
        /// <seealso cref="DateTime.MaxValue"/>
        /// <typeparam name="T">Any type convertible to datetime.</typeparam>
        /// <param name="toConvert">Value to convert</param>
        /// <returns>A properly converted datetime or DateTime.MaxValue if conversion fails.</returns>
        public static DateTime TryConvertToDateTime<T>(T toConvert)
        {
            try
            {
                return Convert.ToDateTime(toConvert);
            }
            catch (FormatException)
            {
                return DateTime.MaxValue;
            }
        }
    }
}
