using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <param name="amount">An unsigned integer representing the number of whitespaces you wish.</param>
        /// <returns>A String containing variable amounts of whitespace.</returns>
        public static String CreateWhiteSpace(uint amount)
        {
            String s = "";
            for (int i = 0; i < amount; i++)
            {
                s += " ";
            }

            return s;
        }

        public static String createShortHandTheme(string FullThemePath)
        {
            int index = FullThemePath.LastIndexOf("\\");
            return FullThemePath.Substring(index + 1);
        }

        public static String UpperCaseFirstChar(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return String.Empty;
            }

            return char.ToUpper(s[0]) + s.Substring(1);
        }

    }
}
