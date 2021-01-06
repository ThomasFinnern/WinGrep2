using System;
using System.Collections.Generic;
using System.Text;

using ConfigBase;

namespace NetGrep
{
    public class clsTestRegExSearchData : clsConfigSpezialBase<clsTestRegExSearchData>
    {
        //---------------------------------------------------------------------------------------------
        // Config variables 
        //---------------------------------------------------------------------------------------------
        public const int cSlotNbr = 11;

        #region Class properties

        // Slot 0 : Last used Slot 1-10 can be saved and loaded
        private List<string> mSearchToken = new List<string>(cSlotNbr);
        private List<List<string>> mTexts2SearchIn = new List<List<string>>(cSlotNbr);

        #endregion class properties

        public List<string> SearchToken
        {
            // prepare 11 filled value
            get
            {
                return mSearchToken;
            }
            set
            {
                mSearchToken = value;
            }
        }

        public List<List<string>> Texts2SearchIn
        {
            // prepare 11 filled value
            get
            {
                return mTexts2SearchIn;
            }
            set
            {
                mTexts2SearchIn = value;
            }
        }

        //---------------------------------------------------------------------------------------------
        // Config getter and setter
        //---------------------------------------------------------------------------------------------


        //---------------------------------------------------------------------------------------------
        // Standard values
        //---------------------------------------------------------------------------------------------

        public override void AssignStandardValues()
        {
            mCfgVersion = "0.001";
        }

        //---------------------------------------------------------------------------------------------
        // Config class construction
        //---------------------------------------------------------------------------------------------

        public clsTestRegExSearchData()
        {
            CfgFileName = "TestRegExSearchData.txt";
            AssignStandardValues();
        }

        public override string ToString()
        {
            string OutTxt = "";

            OutTxt = OutTxt + "TestRegExSearchData:" + "\r\n";

            OutTxt = OutTxt + "mCfgVersion: " + mCfgVersion + "\r\n";
            //OutTxt = OutTxt + "LastUsedSearchGroup: " + LastUsedSearchGroup + "\r\n";

            int Idx = 0;
            OutTxt = OutTxt + "10 Lines Of Text to search in: " + "\r\n";
            List<string> Lines2SearchIn = Texts2SearchIn[0];
            foreach (string Line2SearchIn in Lines2SearchIn)
            {
                OutTxt = OutTxt + "\t- " + Line2SearchIn + "\r\n";
                Idx++;
                if (Idx > 9) 
                    break;
            }

            return OutTxt;
        }       
    }
}


