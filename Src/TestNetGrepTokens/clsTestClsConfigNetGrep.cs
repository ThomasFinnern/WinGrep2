using System;
using System.Collections.Generic;
using System.Text;

using DebugLog;
using ErrorCapture;
using ConfigBase;

namespace NetGrep
{
    [Serializable]
    public class clsTestClsConfigNetGrep : clsConfigNetGrep
    {
        //---------------------------------------------------------------------------------------------
        // Config variables 
        //---------------------------------------------------------------------------------------------

        #region Class properties

        #endregion class properties

        //---------------------------------------------------------------------------------------------
        // Config getter and setter
        //---------------------------------------------------------------------------------------------

        //public string CfgVersion
        //{
        //    get { return mCfgVersion; }
        //    set { mCfgVersion = value; }
        //}

        //public int IntValue
        //{
        //    get { return mIntValue; }
        //    set { mIntValue = value; }
        //}

        //public string StringValue
        //{
        //    get { return mStringValue; }
        //    set { mStringValue = value; }
        //}

        //public bool boolValue
        //{
        //    get { return mboolValue; }
        //    set { mboolValue = value; }
        //}

        //public List<string> ListOfStringsValue
        //{
        //    get { return mListOfStringsValue; }
        //    set { mListOfStringsValue = value; }
        //}

        //---------------------------------------------------------------------------------------------
        // Standard values
        //---------------------------------------------------------------------------------------------

        public override void AssignStandardValues()
        {
            //mCfgVersion = "0.001";
            
            //mIntValue = 1111; 
            //mStringValue= "string";
            //mboolValue = true;
        }

        //---------------------------------------------------------------------------------------------
        // Config class construction
        //---------------------------------------------------------------------------------------------

        public clsTestClsConfigNetGrep()
        {
            AssignStandardValues();
        }


        public static bool TestClass(ref string OutTxt)
        {
            bool ErrFound = false;
            string ErrInfoTxt = "Error in clsTestClsConfigNetGrep: ";

            try
            {
                clsConfigNetGrep Test1 = new clsConfigNetGrep();
                string FileName = @".\clsTestClsConfigNetGrep.01.txt";

                Test1.CfgVersion = "11.11";
                //Test1.bCmdLineUseLastSearchProperties = true;

                Test1.ViewSetting.Show.LineNbrPreviousToMatch = 2;
                Test1.ViewSetting.Show.LineNbrFollowingMatch = 4;

                Test1.SaveClass2File(FileName);

                clsConfigNetGrep Test2 = clsConfigNetGrep.LoadClassFromFile(FileName);
                
                if (Test1.CfgVersion != Test2.CfgVersion)
                {
                    ErrFound = true;
                    OutTxt += ErrInfoTxt + "CfgVersion value unequal" + @"\r\n";
                }

                //if (Test1.bCmdLineUseLastSearchProperties != Test2.bCmdLineUseLastSearchProperties)
                //{
                //    ErrFound = true;
                //    OutTxt += ErrInfoTxt + "bCmdLineUseLastSearchProperties value unequal" + @"\r\n";
                //}

                if (Test1.ViewSetting.Show.LineNbrPreviousToMatch != Test2.ViewSetting.Show.LineNbrPreviousToMatch)
                {
                    ErrFound = true;
                    OutTxt += ErrInfoTxt + "ShowLineNbrPreviousToMatch value unequal" + @"\r\n";
                }

                if (Test1.ViewSetting.Show.LineNbrFollowingMatch != Test2.ViewSetting.Show.LineNbrFollowingMatch)
                {
                    ErrFound = true;
                    OutTxt += ErrInfoTxt + "ShowLineNbrFollowingMatch value unequal" + @"\r\n";
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
                
                OutTxt += ErrCapture.ToString();
                ErrFound = true;
            }

            return ErrFound;
        }




    }
}
