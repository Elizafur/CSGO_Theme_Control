using System;

namespace CSGO_Theme_Control.Base_Classes.Themes
{
    /// <summary>
    /// Exception thrown when a provided Theme does not exist within a given ThemePathContainer instance.
    /// <seealso cref="ThemePathContainer"/>
    /// </summary>
    public class ThemeDoesNotExistException : Exception
    {
        public ThemeDoesNotExistException(){}
        public ThemeDoesNotExistException(string msg) : base(msg){}
        public ThemeDoesNotExistException(string msg, Exception inner) : base(msg, inner){}
    }
}
