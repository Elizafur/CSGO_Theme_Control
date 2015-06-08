using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// <example>C:\\Windows\\Resources\\Ease of Access Themes\\hc1.theme => hc1.theme</example>
        /// </summary>
        /// 
        /// <param name="FullThemePath">Absolute path to the theme starting from the C: or equivalent drive.</param>
        /// 
        /// <returns>A new string created at the last index of '.'</returns>
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
