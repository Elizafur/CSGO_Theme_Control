using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO_Theme_Control
{
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
    }
}
