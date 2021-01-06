using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;
using System.Xml;
using ErrorCapture;
using ConfigBase;

namespace NetGrep
{
    /// <summary>
    /// Keeps anlist of open files when program is closed
    /// </summary>
    public class clsReopenClosedFiles : clsConfigSpezialBase<clsReopenClosedFiles>
    {

        //---------------------------------------------------------------------------------------------
        // Config variables 
        //---------------------------------------------------------------------------------------------

        #region Class properties

        // private List<string> mFileList = new List<string>();
        public List<string> FileList = new List<string>();

        #endregion class properties

        public override void AssignStandardValues()
        {
            mCfgVersion = "0.001";
            // CfgFileName = @"ReopenFiles." + Application.ProductName + ".txt";

        }

        public static void AssignStandardFileName()
        {
            // CfgFileName = @"ReopenFiles." + Application.ProductName + ".txt";
            CfgFileName = @"ReopenFiles.txt";
        }

        //// CfgFileName
        //public static string CfgFileName
        //{
        //    get { return @"ReopenFiles." + Application.ProductName + ".txt"; }
        //}
    }
}
