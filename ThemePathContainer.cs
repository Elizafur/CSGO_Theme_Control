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

        public ThemePathContainer(params string[] themes)
        {
            if (themes.Count() > 2)
                throw new ArgumentException(nameof(themes) + " must be less than or equal to 2 in length.");

            for (int i = 0; i < themes.Count(); i++)
                Themes[i] = themes[i];
        }

        public string GetNextTheme()
        {
            //Ternary operator because C# is dumb and apparantly cannot implicitly convert from bool to int without long drawn out code.
            if (Themes[1] == null || Themes[1] == String.Empty)
                return Themes[0];

            return Themes[CurrentlySelectedTheme = (CurrentlySelectedTheme == 0) ? 1 : 0];
        }

        public override string ToString()
        {
            return HelperFunc.CreateShortHandTheme(Themes[0]) + ((Themes[1] == String.Empty || Themes[1] == null) ? "" : " " + HelperFunc.CreateShortHandTheme(Themes[1]));
        }

        public string AbsoluteToString()
        {
            return "\"" + Themes[0] + "\" " + ((Themes[1] == String.Empty || Themes[1] == null) ? "\"null\"" : "\"" +  Themes[1] + "\"");
        }
    }
}
