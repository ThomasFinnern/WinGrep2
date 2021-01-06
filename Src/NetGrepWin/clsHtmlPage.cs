using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Windows.Forms;
using MainGlobal;
using ErrorCapture;

namespace HtmlFromToken
{
    class clsHtmlPage
    {
        //private bool bIsDocTypeAssigned;
        // private bool bIsFileValid;
        /// <summary>
        /// Only assigned over 
        /// </summary>
        public string FileName;

        public clsHtmlDocType DocType = new clsHtmlDocType ();
        public clsHtmlElement Html = clsHtmlStdElements.HTML ();

        public void AssignNextLine(string NcsLine)
        {



        }

        public void AssignFromFile(string NewFileName)
        {
            if (File.Exists(NewFileName))
            {
                FileName = NewFileName;

                // Use every line from file seperately
                // Not needed for "Zum Nullpunkt zurück": foreach (string NcsLine in File.ReadAllLines(FileName, System.Text.Encoding.Default))
                foreach (string NcsLine in File.ReadAllLines(NewFileName, Encoding.Default))
                {
                    AssignNextLine(NcsLine);
                }
            }
        }

        public bool WriteHtmlFile(string FileName)
        {
            if (File.Exists(FileName))
            {
                Global.oDebugLog.DPrint("File will be overwritten");
                //string OutTxt = string.Format("Error in DoCmdReadNcsFile: File: {0} does not exist.", UsePathFileName);
                //Global.oDebugLog.MessageBox(OutTxt); 
                //return;
            }

            //----------------------------------------------------------------------------
            // Write
            //----------------------------------------------------------------------------

            FileStream OutHtmlFile = new FileStream(FileName, FileMode.Create, FileAccess.Write);
            if ((OutHtmlFile != null))
            {
                string OutTxt = this.DocumentString();
                // needed for "Zum Nullpunkt zurück":  System.Text.Encoding.Default);  // System.Text.SBCSCodePageEncoding
                StreamWriter TxtWriter = new StreamWriter(OutHtmlFile, System.Text.Encoding.Default);
                // StreamWriter TxtWriter = new StreamWriter(OutHtmlFile, System.Text.Encoding.GetEncoding(1252)); // Ü  -> ?
                // StreamWriter TxtWriter = new StreamWriter(OutHtmlFile, System.Text.Encoding.GetEncoding("ISO-8859-1")); // Ü  -> ?

                TxtWriter.Write(OutTxt);
                TxtWriter.Flush();   // Puffer => Disk
                TxtWriter.Close();

                OutHtmlFile.Close();
            }

            return true;
        }

        //public override string ToHtmlString()
        public string DocumentString()
        {

/*          
            string OutTxt = "";
            OutTxt = OutTxt + DocType.ToString();
            OutTxt = OutTxt + Html.ToHtmlString();

            return OutTxt;
*/        
            StringBuilder ActString = new StringBuilder(250000);
            
            ActString.Append(DocType.ToString ());
            Html.AppendHtml2String (ActString, "");
            ActString.Append("\r\n");

            return ActString.ToString();
        }

        /// <summary>
        /// Only for internal use. Otherwise use DocumentString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string OutTxt = "HtmlPage:";
            OutTxt += DocType.ToString();
            OutTxt += Html.bHasSubContent;
            OutTxt += Html.ToString ();

            return OutTxt;
        }
    }
}
