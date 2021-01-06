using System;
using System.Collections.Generic;
using System.Text;

using ConfigBase;
using ErrorCapture;

namespace NetGrep
{
    class clsConfigSearchRequest : clsConfigSpezialBase<clsConfigSearchRequest>
    {
        //---------------------------------------------------------------------------------------------
        // Config variables 
        //---------------------------------------------------------------------------------------------

        public static string mCfgFileName;
        //public override static string CfgFileName
        //{
        //    get { return mCfgFileName; }
        //    set { mCfgFileName = value; }
        //}

        #region Class properties
            protected bool bUseRegularExpression;
            // protected string mInPathFileName;
            //protected string mText2Add;
            //protected string mNumbers2Substract;

        #endregion class properties

        //---------------------------------------------------------------------------------------------
        // Config getter and setter
        //---------------------------------------------------------------------------------------------

        //public string InPathFileName
        //{
        //    get { return mInPathFileName; }
        //    set { mInPathFileName = value; }
        //}

        //---------------------------------------------------------------------------------------------
        // Standrd values
        //---------------------------------------------------------------------------------------------

        public override void AssignStandardValues()
        {
            //mCfgVersion = "0.001";
            //InPathFileName = "";

            // Text2Add = "T01";
            // Numbers2Substract = "0";
            //PicturePoolPathFileName = UserPicDestinationPath + @"\" + clsPictFileList.StdPicListFileName; // !!! Todo !!!
            //AutoFilenameAfterRandomCmd = true;
        }

        //---------------------------------------------------------------------------------------------
        // Config class construction
        //---------------------------------------------------------------------------------------------

        public clsConfigSearchRequest()
        {
            AssignStandardValues();
        }
    }
}
