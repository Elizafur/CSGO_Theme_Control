using System.IO;

namespace CSGO_Theme_Control.Base_Classes.AssertionClass
{
    /// <summary>
    /// TODO: All docs within this class.
    /// </summary>
    public static class Assert
    {
        private static bool IsStrict = true;
        private const string ASSERTION_FAILED = "Assertion Failed: ";

        public static bool FileExists(string path)
        {
            if (!File.Exists(path))
            {
                if (IsStrict)
                    throw new AssertionFailedException(ASSERTION_FAILED + "File: " + path + " does not exist.");

                return false;
            }

            return true;
        }

        public static bool FileDoesNotExist(string path)
        {
            if (File.Exists(path))
            {
                if (IsStrict)
                    throw new AssertionFailedException(ASSERTION_FAILED + "File: " + path + " exists.");

                return false;
            }

            return true;
        }

        public static bool NoFilesWithExtension(string extension, string folder)
        {
            string[] files = Directory.GetFiles(folder);

            foreach (string file in files)
            {
                if (HelperFunc.GetFileExtension(file) == extension)
                {
                    if (IsStrict)
                        throw new AssertionFailedException(ASSERTION_FAILED + "File found containing extension " + extension + ", file: " + file);

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
                throw new AssertionFailedException(ASSERTION_FAILED + "");

            return false;
        }

        /// <summary>
        /// Sets the strictness level of the Assertion class.
        /// </summary>
        /// <param name="strict">
        /// Strictness level of either true or false. True means that an exception is thrown when a condition fails. 
        /// False means that it will return a boolean after evaluation and will not throw in the event of failure.
        /// </param>
        public static void setStrictness(bool strict)
        {
            IsStrict = strict;
        }


    }
}
