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
    public class clsTestclsGrepTokenListMerge : clsGrepTokenListMerge<clsTestclsGrepTokenListMerge> 
    {
        //---------------------------------------------------------------------------------------------
        // Config variables 
        //---------------------------------------------------------------------------------------------

        #region Class properties

        // base: protected string mCfgVersion;

        #endregion Class properties

        //---------------------------------------------------------------------------------------------
        // Config getter and setter
        //---------------------------------------------------------------------------------------------

        //---------------------------------------------------------------------------------------------
        // Standard values
        //---------------------------------------------------------------------------------------------

        //---------------------------------------------------------------------------------------------
        // Config class construction
        //---------------------------------------------------------------------------------------------

        public clsTestclsGrepTokenListMerge()
        {
            AssignStandardValues();
        }

        //---------------------------------------------------------------------------------------------
        // Accessor functions
        //---------------------------------------------------------------------------------------------

        //---------------------------------------------------------------------------------------------
        // Test this class
        //---------------------------------------------------------------------------------------------

        public static bool TestClass(ref string OutTxt)
        {
            bool ErrFound = false;
            string ErrInfoTxt = "Error in clsTestclsGrepTokenListMerge: ";

            try
            {
                clsTestclsGrepTokenListMerge Test1 = new clsTestclsGrepTokenListMerge();
                string FileName = @".\clsTestclsGrepTokenListMerge.01.txt";
                Test1.TokenList.Add("first string");
                Test1.TokenList.Add("second string");
                Test1.TokenList.Add("third string");

                Test1.FixedTokenList.Add("fixed first string");
                Test1.FixedTokenList.Add("fixed second string");
                Test1.FixedTokenList.Add("fixed third string");

                Test1.SaveClass2File(FileName);

                clsTestclsGrepTokenListMerge Test2 = clsTestclsGrepTokenListMerge.LoadClassFromFile(FileName);


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
