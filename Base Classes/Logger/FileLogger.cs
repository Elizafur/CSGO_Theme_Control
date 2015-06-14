﻿//    This file is part of CSGO Theme Control.
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
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CSGO_Theme_Control
{
    public sealed class FileLogger
    {
        public static string THROWN_LOG_EXT = ".crashlog";
        public static string NORMAL_LOG_EXT = ".log";

        public static string GetLogDirectory()
        {
            return ThemeControl.getExeDirectory() + ThemeControl.LOG_DIRECTORY + "\\";
        }

        public static string CreateLogFullPath(bool logThrown)
        {
            string extension = (logThrown ? FileLogger.THROWN_LOG_EXT : FileLogger.NORMAL_LOG_EXT);
            string thrown = (logThrown ? "THROWN_" : "");

            String Date;
            if (logThrown)    //Create a specific log if we are exiting the application.
            {
                Date = (DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.TimeOfDay.ToString()).Replace(":", "-");
                Date = Date.Remove(Date.LastIndexOf("."));
                Date += DateTime.Now.ToString("tt");
            }
            else
            {
                Date = (DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString());
            }

            return GetLogDirectory() + "CSGO_THEME_CONTROL_" + thrown + Date + extension;
        }

        public static void Log(string context, bool shouldThrow=true)
        {
            string fullpath = CreateLogFullPath(shouldThrow);

            //if (!File.Exists(fullpath))
            //    File.Create(fullpath);

            //If we are going to close the program we should not.
            StreamWriter sw = new StreamWriter(fullpath, (shouldThrow ? false : true));
            try
            {
                sw.WriteLine("[LOG]");
                sw.WriteLine("[DATE]{" + DateTime.Now + "}");
                sw.WriteLine("[VERSION]{" + ThemeControl.VERSION_NUM + "}");
                sw.WriteLine("[CONTEXT]{");
                sw.Flush();
                sw.WriteLine(context);
                sw.WriteLine("}");
            }
            catch (Exception e)
            {
                throw new Exception("A second exception occured while trying to create a log of a prior exception.\nThis means that something incredibly wrong has happened and the program must terminate, please report this.\nContext follows:\n" + e.Message);
            }
            finally
            {
                sw.Close();

                if (shouldThrow)
                    Application.Exit();
            }
        }

        public static void CleanLogsFolder(bool cleanupThrownLogs=false)
        {
            string logFileToday = CreateLogFullPath(false);
            string logDirectory = GetLogDirectory();
            string[] files      = Directory.GetFiles(logDirectory);

            for (int i = 0; i < files.Length; i++)
            {
                string ext = HelperFunc.GetFileExtension(files[i]);
                if (cleanupThrownLogs && (ext == NORMAL_LOG_EXT || ext == THROWN_LOG_EXT))
                    File.Delete(files[i]);
                else
                    if (ext == NORMAL_LOG_EXT)
                        File.Delete(files[i]);
            }
        }

        public static List<string> ReadLog(string filepath)
        {
            List<string> rows = new List<string>();
            StreamReader sr = new StreamReader(filepath);
            StringBuilder sb = new StringBuilder();
            try
            {
                bool readingContext     = false;
                bool appendedContext    = false;

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string startOfLine = line;
                    string lineAfterBrace = line;

                    if (line.Contains("{"))
                    {
                        startOfLine = line.Split('{')[0];
                        lineAfterBrace = line.Substring(line.IndexOf('{') + 1);
                    }
                    if (!readingContext)
                    {
                        switch (startOfLine)
                        {
                            case("[LOG]"):
                                break;

                            case("[DATE]"):
                                sb.Append(HelperFunc.SurroundWith("\"", "[DATE]") + ", " + HelperFunc.SurroundWith("\"", lineAfterBrace.Replace("}", "")));
                                break;

                            case("[VERSION]"):
                                sb.Append(HelperFunc.SurroundWith("\"", "[VERSION]") + ", " + HelperFunc.SurroundWith("\"", lineAfterBrace.Replace("}", "")));
                                break;

                            case("[CONTEXT]"):
                                readingContext = true;
                                break;

                            default:
                                char[] c = new char[1000];
                                sr.ReadBlock(c, 0, 999);
                                throw new FileFormatException("Log was unreadable: " + new string(c));
                        }

                        if (sb.ToString() != String.Empty)
                            rows.Add(sb.ToString());

                        sb.Clear();
                    }
                    else
                    {
                        if (!appendedContext)
                        {
                            sb.Append(HelperFunc.SurroundWith("\"", "[CONTEXT]") + ", \"");
                            appendedContext = true;
                        }

                        if (line != "}")
                            sb.Append(line);
                        else
                        {
                            sb.Append("\"");
                            rows.Add(sb.ToString());
                            sb.Clear();
                        }
                    }
                }
            }
            finally
            {
                sr.Close();
            }

            return rows;
        }

        /// <summary>
        /// Exports log file to a CSV file.
        /// </summary>
        /// <param name="filepath">Filepath to the LOG file you wish to export</param>
        /// <param name="endpath">Filepath to the CSV file you wish to export to. If the file does not exist a new one will be created.</param>
        /// <returns>True if export was successful, false otherwise.</returns>
        public static bool ExportLogToCSV(string filepath, string endpath)
        {
            bool succeeded = true;
            bool append    = false;
            if (File.Exists(endpath))
                append = true;

            List<string> fileData = new List<string>();
            try { fileData = ReadLog(filepath); } catch { return false; }

            StreamWriter sw = new StreamWriter(endpath, append);
            try
            {
                foreach (string row in fileData)
                    sw.WriteLine(row);
            }
            catch (IOException)
            {
                succeeded = false;
            }
            finally
            {
                sw.Close();
            }

            return succeeded;
        }
    }
}