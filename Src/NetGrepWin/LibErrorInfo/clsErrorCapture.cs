using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using LibStdFileDateTime;
using System.Windows.Forms;

//using DebugLog;
using MainGlobal;

namespace ErrorCapture
{
    public enum ToStringStyle : int
    {
        Fat_OneParameterPerLine = 0x00,
        Flat_AllParameterInOneLine = 0x01,
    };

    public class clsErrorCapture
    {
        private Exception mEx;
        public Exception Ex 
        {
            get { return mEx; }
        }

        public static string ErrFileName;

        public clsErrorCapture(Exception InEx)
        {
            this.AssignException (InEx);
        }

        public void AssignException(Exception InEx)
        {
            mEx = InEx;

            /*
            // Write into file
            if (ErrFileName != null)
            {
                StreamWriter SWriter;
                if (!File.Exists(ErrFileName)) 
                {
                    // Create a file to write to.
                    SWriter = File.CreateText(ErrFileName);
                }
                else
                {
                    SWriter = File.AppendText(ErrFileName);
                }

                string Header = "[ErrorCapture: " + StdFileDateTime.StdFileDateTimeFormatStringMsec () + "]";
                SWriter.WriteLine(Header);
                SWriter.WriteLine(Ex.ToString ());
                SWriter.Flush();
                SWriter.Close();
            }
            */

            string OutTxt = "";
            OutTxt = OutTxt + "=================================================================" + "\r\n";
            OutTxt = OutTxt + "[ErrorCapture: " + clsStdFileDateTime.StdFileDateTimeFormatStringMsec() + "]" + "\r\n";
            OutTxt = OutTxt + "-----------------------------------------------------------------" + "\r\n";
            OutTxt = OutTxt + ">> Message   : " + Ex.Message + "\r\n";
            OutTxt = OutTxt + "-----------------------------------------------------------------" + "\r\n";
            OutTxt = OutTxt + ">> Source    : " + Ex.Source + "\r\n";
            OutTxt = OutTxt + "-----------------------------------------------------------------" + "\r\n";
            OutTxt = OutTxt + ">> Stacktrace: " + Ex.StackTrace + "\r\n";
            OutTxt = OutTxt + "-----------------------------------------------------------------" + "\r\n";
            OutTxt = OutTxt + ">> TargetSite: " + Ex.TargetSite + "\r\n";
            OutTxt = OutTxt + "-----------------------------------------------------------------" + "\r\n";
            OutTxt = OutTxt + ">> ToString  : \r\n" + Ex.ToString() + "\r\n";
            OutTxt = OutTxt + "-----------------------------------------------------------------" + "\r\n";
            Global.oDebugLog.WriteLog(OutTxt);
        }

        public void ShowExeption()
        {
            //frmErrorOut ErrorOut = new frmErrorOut();
            //ErrorOut.ErrorCapture = this;
            // ErrorOut.Parent = 
            // Application.DoEvents ();
            // ErrorOut.ShowDialog ();

            // Application.DoEvents();

            MessageBox.Show(Ex.ToString(), Ex.TargetSite.ToString(), 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);        
        }
    }
}
