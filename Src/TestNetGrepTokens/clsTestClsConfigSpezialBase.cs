using System;
using System.Collections.Generic;
using System.Text;

using DebugLog;
using ErrorCapture;
using ConfigBase;

namespace NetGrep
{
    [Serializable]
    public class clsTestClsConfigSpezialBase : clsConfigSpezialBase<clsTestClsConfigSpezialBase> 
    {

        //---------------------------------------------------------------------------------------------
        // Config variables 
        //---------------------------------------------------------------------------------------------

        #region Class properties

        // protected string mCfgVersion;
        protected int mIntValue;
        protected string mStringValue;
        protected bool mboolValue;
        protected List<string> mListOfStringsValue = new List<string>();

        #endregion class properties

        //---------------------------------------------------------------------------------------------
        // Config getter and setter
        //---------------------------------------------------------------------------------------------

        //public string CfgVersion
        //{
        //    get { return mCfgVersion; }
        //    set { mCfgVersion = value; }
        //}

        public int IntValue
        {
            get { return mIntValue; }
            set { mIntValue = value; }
        }

        public string StringValue
        {
            get { return mStringValue; }
            set { mStringValue = value; }
        }

        public bool boolValue
        {
            get { return mboolValue; }
            set { mboolValue = value; }
        }

        public List<string> ListOfStringsValue
        {
            get { return mListOfStringsValue; }
            set { mListOfStringsValue = value; }
        }

        //---------------------------------------------------------------------------------------------
        // Standard values
        //---------------------------------------------------------------------------------------------

        public override void AssignStandardValues()
        {
            CfgVersion = "03.003";

            mIntValue = 1112;
            mStringValue = "string";
            mboolValue = true;
        }

        //---------------------------------------------------------------------------------------------
        // Config class construction
        //---------------------------------------------------------------------------------------------

        public clsTestClsConfigSpezialBase()
        {
            AssignStandardValues();
        }


        public static bool TestClass(ref string OutTxt)
        {
            bool ErrFound = false;
            string ErrInfoTxt = "Error in clsTestClsConfigSpezialBase: ";

            try
            {
                clsTestClsConfigSpezialBase Test1 = new clsTestClsConfigSpezialBase();
                string FileName = @".\clsTestClsConfigSpezialBase.01.txt";
                Test1.ListOfStringsValue.Add("first string");
                Test1.ListOfStringsValue.Add("second string");
                Test1.ListOfStringsValue.Add("third string");

                Test1.SaveClass2File(FileName);

                clsTestClsConfigSpezialBase Test2 = clsTestClsConfigSpezialBase.LoadClassFromFile(FileName);

                //mIntValue = 1111;
                if (Test1.IntValue != Test2.IntValue)
                {
                    ErrFound = true;
                    OutTxt += ErrInfoTxt + "Int value unequal" + @"\r\n";
                }
                //mStringValue = "string";
                if (Test1.StringValue != Test2.StringValue)
                {
                    ErrFound = true;
                    OutTxt += ErrInfoTxt + "String value unequal" + @"\r\n";
                }
                //mboolValue = true;
                if (Test1.boolValue != Test2.boolValue)
                {
                    ErrFound = true;
                    OutTxt += ErrInfoTxt + "Bool value unequal" + @"\r\n";
                }
                // mListOfStringsValue.Add("first string");
                if (Test1.ListOfStringsValue.Count != Test2.ListOfStringsValue.Count)
                {
                    ErrFound = true;
                    OutTxt += ErrInfoTxt + "List <string> counts value unequal" + @"\r\n";
                }
                // mListOfStringsValue.Add("second string");
                if (Test2.ListOfStringsValue.Count > 0)
                {
                    if (Test1.ListOfStringsValue[0] != Test2.ListOfStringsValue[0])
                    {
                        ErrFound = true;
                        OutTxt += ErrInfoTxt + "List [0] value unequal" + @"\r\n";
                    }
                }
                // mListOfStringsValue.Add("third string");
                if (Test2.ListOfStringsValue.Count > 0)
                {
                    if (Test1.ListOfStringsValue[Test2.ListOfStringsValue.Count - 1] != Test2.ListOfStringsValue[Test2.ListOfStringsValue.Count - 1])
                    {
                        ErrFound = true;
                        OutTxt += ErrInfoTxt + "List [last] value unequal" + @"\r\n";
                    }
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
