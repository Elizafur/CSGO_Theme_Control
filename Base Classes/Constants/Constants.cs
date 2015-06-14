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
using System.IO;

namespace CSGO_Theme_Control.Base_Classes.Constants
{
    /// <summary>
    /// A class containing representations of various string and int constants used throughout the program as variables.
    /// </summary>
    public static class Constants
    {

        /// <summary>
        /// System process name of counter-strike global offensive. 
        /// </summary>
        public const string CSGO_PROC_NAME      = "csgo";

        /// <summary>
        /// System command to change the users theme.
        /// </summary>
        /// <remarks>
        /// The {0} following 'file:' should be formatted to include whatever file should be set as the theme. 
        /// </remarks>
        public const string CMD_CHANGE_THEME    = "/C rundll32.exe %SystemRoot%\\system32\\shell32.dll,Control_RunDLL %SystemRoot%\\system32\\desk.cpl desk,@Themes /Action:OpenTheme /file:\"{0}\"";

        /// <summary>
        /// Absolute path to Windows Aero theme.
        /// </summary>
        public static string WIN_THEME_AERO      = Path.GetPathRoot(Environment.SystemDirectory) + "Windows\\Resources\\Themes\\aero.theme";

        /// <summary>
        /// Absolute path to Windows classic theme.
        /// </summary>
        public static string WIN_THEME_CLASSIC   = Path.GetPathRoot(Environment.SystemDirectory) + "Windows\\Resources\\Ease of Access Themes\\hcwhite.theme";

        /// <summary>
        /// Relative path to the config file of this program.
        /// </summary>
        public const string APP_CONFIG_LOCATION  = "cfg\\Config.ThemeControlCfg";

        /// <summary>
        /// "A window receives this message when the user chooses a command from the Window menu 
        /// (formerly known as the system or control menu) or when the user chooses the maximize button, minimize button, restore button, or close button."
        /// src: https://msdn.microsoft.com/en-us/library/windows/desktop/ms646360%28v=vs.85%29.aspx
        /// </summary>
        public const int WIN_MSG_WM_SYSCOMMAND   = 0x0112;

        /// <summary>
        /// Windows message to close the window.
        /// </summary>
        public const int WIN_MSG_SC_CLOSE        = 0xF060;

        /// <summary>
        /// Posted when the user presses a hot key registered by the RegisterHotKey function. 
        /// The message is placed at the top of the message queue associated with the thread that registered the hot key.        
        /// src: https://msdn.microsoft.com/en-us/library/windows/desktop/ms646279%28v=vs.85%29.aspx
        /// </summary>
        public const int WIN_MSG_HOTKEY_DOWN     = 0x0312;

        /// <summary>
        /// Key enumeration to represent modifier (alt, control, shift, windows key) keys as integers.
        /// </summary>
        public enum KeyModifier
        {
            NONE = 0,
            ALT = 1,
            CONTROL = 2,
            SHIFT = 4,
            WINKEY = 8
        }
    }
}
