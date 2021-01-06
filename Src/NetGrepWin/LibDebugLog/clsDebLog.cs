using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using System.Windows.Forms;
using LibStdFileDateTime;
using ErrorCapture;

using CmdLine2005; // ToDo: Muss wieder raus

namespace DebugLog
{
    public class clsDebugLog
    {
        public const string StdDebFileNameName = "DebugLog";
        public const string StdDebFileNameExt = "txt";
        public const string StdDebFileName = StdDebFileNameName + "." + StdDebFileNameExt;

        private string mLogFileName = StdDebFileNameName + "." + StdDebFileNameExt;
        public string LogFileName
        {
            get { return mLogFileName; }
            set { mLogFileName = value; }
        }

        public bool bWrite2FileLog = true;
        public bool bDontDoDebugPrint = false;
        public bool bDontRaiseEvent = false;
        public bool bDontShowMessageBox = false;

        // ToDo: Events for UserInfoChanges instead of using frmCommandLine CommandLineInfo
        /// <summary>
        /// Pointer to adjoining form where the debug messages will e written
        /// </summary>
        frmCommandLine mCommandLineInfo;
        public frmCommandLine CommandLineInfo
        {
            get { return mCommandLineInfo; }
            set { mCommandLineInfo = value; }
        } 
               
        // ToDo: Include ChangeErrTextEventHandler in all writes and not only in debug.print
        public event ChangeErrTextEventHandler ChangeErrText;
        public delegate void ChangeErrTextEventHandler(string strError);

        // ToDo: DebugLevel, 
        // ToDo: OutDepth for Tabs in front 

        public string CreateAutoDateDebugFileName()
        {
            mLogFileName = StdDebFileNameName + "." + clsStdFileDateTime.StdFileDateTimeFormatString() + "." + StdDebFileNameExt;
            return mLogFileName;
        }

        public void CreateFile()
        {
            FileStream DebOutFile = File.Create(mLogFileName);
            DebOutFile.Close();
        }

        public string StdLogPathFileName
        {
            get
            {
                //string RetPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\Log";
                string RetPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\" + Application.ProductName + "Log.txt";
                return RetPath;
            }
        }


        public void WriteLine(string OutLine)
        {
            WriteLog(OutLine + "\r\n");
        }


        public void WriteUserInfoLine(string OutLine)
        {
            WriteUserInfo(OutLine + "\r\n");
        }

        public void WriteUserInfo(string OutText)
        {
            Write(OutText);

            if (mCommandLineInfo != null)
            {
                mCommandLineInfo.AddInfo(OutText);
            }
        }

        public void WriteUserInfoTitle(string OutText)
        {
            if (mCommandLineInfo != null)
            {
                mCommandLineInfo.SetTitle(OutText);
            }

            string Divider = "=========================================================" + "\r\n";
            OutText = Divider + OutText + "\r\n" + Divider;

            Write(OutText);
        }

        // public static WriteLines (string [] );
        // public static Write (string );
        public void Write(string OutTxt)
        {
            WriteLog(OutTxt);
        }

        static string strLastLogText= "";
        public void DPrint(string strLog)
        {
            strLastLogText = strLog;

            if (!bDontDoDebugPrint)
            {
                //Debug.Print(strLog);
            }

            if (bWrite2FileLog)
            {
                WriteLog(strLog + "\r\n");
            }

            if (!bDontRaiseEvent)
            {
                if (ChangeErrText != null)
                {
                    ChangeErrText(strLog);
                }
            }
        }

        public void MessageBox (string strLog)
        {
            DPrint(strLog);

            if (!bDontShowMessageBox)
                System.Windows.Forms.MessageBox.Show(strLog);
        }

        public bool WriteLog(string OutTxt)
        {
            return WriteLog(OutTxt, false);
        }

        public bool WriteLog(string OutTxt, bool bDoResetBefore)
        {
            FileStream LogTxtStream;

            if ((mLogFileName != ""))
            {
                if ((bDoResetBefore))
                {
                    LogTxtStream = new FileStream(mLogFileName, FileMode.Create, FileAccess.Write);
                }
                else
                {
                    LogTxtStream = new FileStream(mLogFileName, FileMode.Append, FileAccess.Write);
                }

                if ((LogTxtStream != null))
                {
                    StreamWriter TxtWriter = new StreamWriter(LogTxtStream);
                    TxtWriter.Write(OutTxt);
                    TxtWriter.Flush();   // Puffer => Disk
                    TxtWriter.Close();

                    LogTxtStream.Close();
                }
            }

            return true;
        }

        // Build proper path with (new) folders or returns "C:\temp"
        // ToDo: replace with better solution
        // Path Changed = true
        private bool PrepareStandardLogPath(ref string StdFilePath)
        {
            bool functionReturnValue = false;
            // Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
            //int Idx;

            //string [] vPartsSrc;
            //string vPartsDst;
            //string strBuildPath;

            // Remove last "\" if existent
            if (StdFilePath.EndsWith("\\"))
            {
                StdFilePath = StdFilePath.Substring(0, StdFilePath.Length - 1);
            }

            if (!Directory.Exists(StdFilePath))
            {
                Directory.CreateDirectory(StdFilePath);

                // ToDo: check  fso.CreateFolder (StdFilePath)
                functionReturnValue = true;
            }

            if (!Directory.Exists((StdFilePath)))
            {
                StdFilePath = "C:\\Temp";
                if (!Directory.Exists((StdFilePath)))
                {
                    Directory.CreateDirectory(StdFilePath);
                }
            }
            return functionReturnValue;
        }
    }
}
