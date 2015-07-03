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

using System.IO;
using CSGO_Theme_Control.Base_Classes.Helper;

namespace CSGO_Theme_Control.Base_Classes.Assertions
{
    /// <summary>
    /// Class containing methods to assert 
    /// </summary>
    public static class Assert
    {
        /// <summary>
        /// Determines whether exceptions will be thrown in the event of a false evaluation in assertion methods.
        /// True means they will be thrown.
        /// </summary>
        private static bool  IsStrict = true;

        /// <summary>
        /// Asserts that a file exists.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>True if the file exists, false or a throw(if IsStrict) if the file doesn't exist.</returns>
        public static bool FileExists(string path)
        {
            if (!File.Exists(path))
            {
                if (IsStrict)
                    throw new AssertionFailedException("File: " + path + " does not exist.");

                return false;
            }

            return true;
        }

        /// <summary>
        /// Asserts that a file does not exist.
        /// </summary>
        /// <param name="path">Fullpath a file.</param>
        /// <returns>True if file does not exist or false if it does. If IsStrict throws if the file does exist.</returns>
        public static bool FileDoesNotExist(string path)
        {
            if (File.Exists(path))
            {
                if (IsStrict)
                    throw new AssertionFailedException("File: " + path + " exists.");

                return false;
            }

            return true;
        }

        /// <summary>
        /// Asserts that there are no files with the given extension in a folder.
        /// </summary>
        /// <param name="extension">Extension to check.</param>
        /// <param name="folder">Folder to find files in.</param>
        /// <returns>True if there are no files with the given extension otherwise false or a throw if there are files with the extension.</returns>
        public static bool NoFilesWithExtension(string extension, string folder)
        {
            string[] files = Directory.GetFiles(folder);

            foreach (string file in files)
            {
                if (HelperFunc.GetFileExtension(file) == extension)
                {
                    if (IsStrict)
                        throw new AssertionFailedException("File found containing extension " + extension + ", file: " + file);

                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Assert if a boolean expression is true.
        /// </summary>
        /// <param name="b">Boolean expression to evaluate</param>
        /// <returns>True if boolean evaluates to true otherwise false. Will throw an AssertionFailedException if IsStrict.</returns>
        public static bool Bool(bool b)
        {
            if (b)
                return true;

            if (IsStrict)
                throw new AssertionFailedException("Boolean did not evaluate to true.");

            return false;
        }

        /// <summary>
        /// Sets the strictness level of the Assertion class.
        /// </summary>
        /// <param name="strict">
        /// Strictness level of either true or false. True means that an exception is thrown when a condition fails. 
        /// False means that it will return a boolean after evaluation and will not throw in the event of failure.
        /// </param>
        public static void SetStrictness(bool strict)
        {
            IsStrict = strict;
        }


    }
}
