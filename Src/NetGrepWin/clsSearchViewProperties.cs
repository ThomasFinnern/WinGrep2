using System;
using System.Collections.Generic;
using System.Text;

using System.Xml.Serialization;
using System.Xml;
using ErrorCapture;

namespace NetGrep
{
    [Serializable]
    public class clsSearchViewProperties
    {
        #region Class properties

        /// <summary>
        /// Line numbers pre and post to matching line found to show after search
        /// </summary>
        public clsSurroundingLinesPara Show = new clsSurroundingLinesPara();  // 
        /// <summary>
        /// Line numbers pre and post to matching line found kept after serach for later showing
        /// </summary>
        public clsSurroundingLinesPara Keep = new clsSurroundingLinesPara();  // 

        public bool bDoShowTitle;
        public bool bDoShowLineNumbers;
        public bool bDoShowFixedFont;
        public bool bDoShowFileNames;
        public bool bDoShowFileContents;
        public bool bDoShowWholeLine;
        public bool bDoShowDoubleBlanks;

        #endregion class properties

        public clsSearchViewProperties()
        {
            AssignStandardValues();
        }

        public clsSearchViewProperties(clsSearchViewProperties Orig)
        {
            AssignStandardValues();

            this.Show = Orig.Show.Clone();
            this.Keep = Orig.Keep.Clone();
            this.bDoShowTitle = Orig.bDoShowTitle;
            this.bDoShowLineNumbers = Orig.bDoShowLineNumbers;
            this.bDoShowFixedFont = Orig.bDoShowFixedFont;
            this.bDoShowFileNames = Orig.bDoShowFileNames;
            this.bDoShowFileContents = Orig.bDoShowFileContents;
            this.bDoShowWholeLine = Orig.bDoShowWholeLine;
        }

        public void AssignStandardValues()
        {
            bDoShowTitle = true;
            bDoShowLineNumbers = true;
            bDoShowFixedFont = true;
            bDoShowFileNames = true;
            bDoShowFileContents = true;
            bDoShowWholeLine = true;
        }

        public clsSearchViewProperties Clone()
        {
            clsSearchViewProperties NewClass = new clsSearchViewProperties(this);
            return NewClass;        
        }

        public override string ToString()
        {
            string OutTxt = "";

            OutTxt = OutTxt + "Show: " + Show.ToString() + "\r\n";
            OutTxt = OutTxt + "Keep: " + Keep.ToString() + "\r\n";
            OutTxt = OutTxt + "bDoShowPlaneView: " + bDoShowTitle.ToString() + "\r\n";
            OutTxt = OutTxt + "bDoShowLineNumbers: " + bDoShowLineNumbers.ToString() + "\r\n";
            OutTxt = OutTxt + "bDoShowFixedFont: " + bDoShowFixedFont.ToString() + "\r\n";
            OutTxt = OutTxt + "bDoShowFileNames: " + bDoShowFileNames.ToString() + "\r\n";
            OutTxt = OutTxt + "bDoShowFileContents: " + bDoShowFileContents.ToString() + "\r\n";
            OutTxt = OutTxt + "bDoShowWholeLine: " + bDoShowWholeLine.ToString() + "\r\n";
            //OutTxt = OutTxt + ": " + .ToString() + "\r\n";
            //OutTxt = OutTxt + ": " + .ToString() + "\r\n";

            return OutTxt;
        }

    }
}
