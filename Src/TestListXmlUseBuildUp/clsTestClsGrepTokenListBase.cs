using System;
using System.Collections.Generic;
using System.Text;

using DebugLog;
using ErrorCapture;
using ConfigBase;

namespace NetGrep
{
    [Serializable]
    /// <summary>
    /// Keeps two lists "token" and "fixed token" 
    /// New entries are placed in front
    /// too old entries will be deleted
    /// Entries in the fixed list will not be deleted 
    /// A OutList to use external will contain the merge of fixed and token 
    /// The fixed token will begin to merge at certain IDX for the out list
    /// A token may exist in both list but will be only once in the out list
    /// </summary>
    public class clsTestClsGrepTokenListBase : clsGrepTokenListBase<clsTestClsGrepTokenListBase> 
    {
        //---------------------------------------------------------------------------------------------
        // Config variables 
        //---------------------------------------------------------------------------------------------

        #region Class properties

        #endregion Class properties

        //---------------------------------------------------------------------------------------------
        // Config getter and setter
        //---------------------------------------------------------------------------------------------

        //---------------------------------------------------------------------------------------------
        // Standard values
        //---------------------------------------------------------------------------------------------

        //public override void AssignStandardValues()
        //{
        //    mCfgVersion = "0.001";
        //    //AutoFilenameAfterRandomCmd = true;

        //    Clear(); // token lists

        //    mPreFixedTokenNumber = 7;
        //    mFirstFixedTokenNumber = 10;
        //    mMaxTokenNumber = 25;
        //    mMaxFixedNumber = 15;            
        //}

        // ToDo: Check for own filename ?
        //public static void AssignFileName(string FileName)
        //{
        //    CfgFileName = FileName;
        //}

        //---------------------------------------------------------------------------------------------
        // Config class construction
        //---------------------------------------------------------------------------------------------

        public clsTestClsGrepTokenListBase()
        {
            AssignStandardValues();
        }

        //---------------------------------------------------------------------------------------------
        // Accessor functions
        //---------------------------------------------------------------------------------------------

        //public override string ToString()
        //{
        //    string OutTxt = "";

        //    if (TokenList.Count > 0)
        //    {
        //        OutTxt += "Token:" + "\r\n";
        //        foreach (string Token in mTokenList)
        //        {
        //            OutTxt += "   " + Token + "\r\n";
        //        }
        //    }

        //    if (FixedTokenList.Count > 0)
        //    {
        //        OutTxt += "Fixed token:" + "\r\n";
        //        foreach (string Token in mFixedTokenList)
        //        {
        //            OutTxt += "   " + Token + "\r\n";
        //        }
        //    }

        //    return OutTxt;
        //}

        //---------------------------------------------------------------------------------------------
        // Test this class
        //---------------------------------------------------------------------------------------------

        public static bool TestClass(ref string OutTxt)
        {
            bool ErrFound = false;
            string ErrInfoTxt = "Error in clsTestClsGrepTokenListBase: ";

            try
            {
                clsTestClsGrepTokenListBase Test1 = new clsTestClsGrepTokenListBase();
                string FileName = @".\clsTestClsGrepTokenListBase.01.txt";
                Test1.TokenList.Add("first string");
                Test1.TokenList.Add("second string");
                Test1.TokenList.Add("third string");

                Test1.FixedTokenList.Add("fixed first string");
                Test1.FixedTokenList.Add("fixed second string");
                Test1.FixedTokenList.Add("fixed third string");

                Test1.SaveClass2File(FileName);

                clsTestClsGrepTokenListBase Test2 = clsTestClsGrepTokenListBase.LoadClassFromFile(FileName);


                if (Test1.PreFixedTokenNumber != Test2.PreFixedTokenNumber)
                {
                    ErrFound = true;
                    OutTxt += ErrInfoTxt + "PreFixedTokenNumber value unequal" + "\r\n";
                }

                if (Test1.FirstFixedTokenNumber != Test2.FirstFixedTokenNumber)
                {
                    ErrFound = true;
                    OutTxt += ErrInfoTxt + "FirstFixedTokenNumber value unequal" + "\r\n";
                }

                if (Test1.MaxTokenNumber != Test2.MaxTokenNumber)
                {
                    ErrFound = true;
                    OutTxt += ErrInfoTxt + "MaxTokenNumber value unequal" + "\r\n";
                }

                if (Test1.MaxFixedNumber != Test2.MaxFixedNumber)
                {
                    ErrFound = true;
                    OutTxt += ErrInfoTxt + "Int value unequal" + "\r\n";
                }

                //if (Test1.StringValue != Test2.StringValue)
                //{
                //    ErrFound = true;
                //    OutTxt += ErrInfoTxt + "String value unequal" + "\r\n";
                //}
                
                //if (Test1.boolValue != Test2.boolValue)
                //{
                //    ErrFound = true;
                //    OutTxt += ErrInfoTxt + "Bool value unequal" + "\r\n";
                //}
                
                if (Test1.TokenList.Count != Test2.TokenList.Count)
                {
                    ErrFound = true;
                    OutTxt += ErrInfoTxt + "List <string> counts value unequal" + "\r\n";
                }

                if (Test2.TokenList.Count > 0)
                {
                    if (Test1.TokenList[0] != Test2.TokenList[0])
                    {
                        ErrFound = true;
                        OutTxt += ErrInfoTxt + "List [0] value unequal" + "\r\n";
                    }
                }

                if (Test2.TokenList.Count > 0)
                {
                    if (Test1.TokenList[Test2.TokenList.Count - 1] != Test2.TokenList[Test2.TokenList.Count - 1])
                    {
                        ErrFound = true;
                        OutTxt += ErrInfoTxt + "List [last] value unequal" + "\r\n";
                    }
                }

                if (Test2.FixedTokenList.Count > 0)
                {
                    if (Test1.FixedTokenList[0] != Test2.FixedTokenList[0])
                    {
                        ErrFound = true;
                        OutTxt += ErrInfoTxt + "Fixed list [0] value unequal" + "\r\n";
                    }
                }

                if (Test2.FixedTokenList.Count > 0)
                {
                    if (Test1.FixedTokenList[Test2.FixedTokenList.Count - 1] != Test2.FixedTokenList[Test2.FixedTokenList.Count - 1])
                    {
                        ErrFound = true;
                        OutTxt += ErrInfoTxt + "Fixed list [last] value unequal" + "\r\n";
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
