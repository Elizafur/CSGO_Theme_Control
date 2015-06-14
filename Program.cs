//    This file is part of CSGO Theme Control.
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
using System.Windows.Forms;
using CSGO_Theme_Control.Base_Classes.AssertionClass;

namespace CSGO_Theme_Control
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ThemeControl());
            }
            else
            {
                if (args[0] == "--test")
                {
                    if (args.Length < 2)
                        throw new ArgumentException("Please enter a class to test.\nUsage: --test <Class.cs>");

                    if (args[1] == "FileLogger.cs")
                    {
                        string file = FileLogger.CreateLogFullPath(false);
                        FileLogger.Log("Test1", false);
                        FileLogger.Log("Test2", false);
                        FileLogger.CleanLogsFolder();
                        Assert.NoFilesWithExtension(FileLogger.NORMAL_LOG_EXT, FileLogger.GetLogDirectory());

                        FileLogger.CleanLogsFolder(true);
                        Assert.NoFilesWithExtension(FileLogger.THROWN_LOG_EXT, FileLogger.GetLogDirectory());

                        FileLogger.Log("Test Export", false);
                        Assert.Bool(FileLogger.ExportLogToCSV(file, FileLogger.GetLogDirectory() + "exported.csv"));
                    }
                    else
                    {
                        throw new NotImplementedException("Class: " + args[1] + " has not been implemented in the tester yet.");
                    }
                }
            }
        }
    }
}
