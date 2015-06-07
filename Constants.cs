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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO_Theme_Control
{
    /// <summary>
    /// A class containing representations of various string and int constants used throughout the program as variables.
    /// </summary>
    public static class Constants
    {
        public const string CSGO_PROC_NAME      = "csgo";
        public const string CMD_CHANGE_THEME    = "/C rundll32.exe %SystemRoot%\\system32\\shell32.dll,Control_RunDLL %SystemRoot%\\system32\\desk.cpl desk,@Themes /Action:OpenTheme /file:\"{0}\"";
        //CMD_CHANGE_THEME Note: The {0} following 'file:' should be formatted to include whatever file should be set as the theme.

        public const string WIN_AERO_THEME      = "C:\\Windows\\Resources\\Themes\\aero.theme";
        public const string WIN_CLASSIC_THEME   = "C:\\Windows\\Resources\\Ease of Access Themes\\hcwhite.theme";

        public const string APP_CONFIG_LOCATION = "cfg\\Config.ThemeControlCfg";

        public const int WM_SYSCOMMAND          = 0x0112;
        public const int SC_CLOSE               = 0xF060;
        public const int HOTKEY_DOWN            = 0x0312;

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
