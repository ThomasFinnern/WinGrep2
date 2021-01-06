using System;
using System.Collections.Generic;
using System.Text;

using DebugLog;
using ErrorCapture;
using ConfigBase;

namespace NetGrep
{
    [Serializable]
    public class clsTestClsGrepTokenListBase : clsGrepTokenListBase<clsTestClsGrepTokenListBase>
    {
        public static bool TestClass(ref string OutTxt)
        {
            bool ErrFound = false;
            string ErrInfoTxt = "Error in clsTestClsGrepTokenListBase: ";

            try
            {
                clsTestClsGrepTokenListBase Test1 = new clsTestClsGrepTokenListBase();
                string FileName = @".\clsTestClsGrepTokenListBase.01.txt";

                Test1.CfgVersion = "10.001";
                Test1.PreFixedTokenNumber = 8;
                Test1.FirstFixedTokenNumber = 11;
                Test1.MaxTokenNumber = 26;
                Test1.MaxFixedNumber = 16;

                Test1.FixedTokenList.Add("first string");
                Test1.FixedTokenList.Add("second string");
                Test1.TokenList.Add("first string");
                Test1.TokenList.Add("second string");
                Test1.TokenList.Add("third string");

                Test1.SaveClass2File(FileName);

                clsTestClsGrepTokenListBase Test2 = (clsTestClsGrepTokenListBase) clsTestClsGrepTokenListBase.LoadClassFromFile(FileName);

                if (Test1.CfgVersion != Test2.CfgVersion)
                {
                    ErrFound = true;
                    OutTxt += ErrInfoTxt + "CfgVersion value unequal" + @"\r\n";
                }
                
                if (Test1.PreFixedTokenNumber != Test2.PreFixedTokenNumber)
                {
                    ErrFound = true;
                    OutTxt += ErrInfoTxt + "PreFixedTokenNumber value unequal" + @"\r\n";
                }
                //mboolValue = true;
                if (Test1.FirstFixedTokenNumber != Test2.FirstFixedTokenNumber)
                {
                    ErrFound = true;
                    OutTxt += ErrInfoTxt + "FirstFixedTokenNumber value unequal" + @"\r\n";
                }

                if (Test1.MaxTokenNumber != Test2.MaxTokenNumber)
                {
                    ErrFound = true;
                    OutTxt += ErrInfoTxt + "MaxTokenNumber value unequal" + @"\r\n";
                }

                if (Test1.MaxFixedNumber != Test2.MaxFixedNumber)
                {
                    ErrFound = true;
                    OutTxt += ErrInfoTxt + "MaxFixedNumber value unequal" + @"\r\n";
                }
                                
                //-------------------------------------------------------------------------------
                if (Test1.FixedTokenList.Count != Test2.FixedTokenList.Count)
                {
                    ErrFound = true;
                    OutTxt += ErrInfoTxt + "FixedTokenList <string> counts value unequal" + @"\r\n";
                }
                if (Test2.FixedTokenList.Count > 0)
                {
                    if (Test1.FixedTokenList[0] != Test2.FixedTokenList[0])
                    {
                        ErrFound = true;
                        OutTxt += ErrInfoTxt + "FixedTokenList [0] value unequal" + @"\r\n";
                    }
                }
                
                if (Test2.FixedTokenList.Count > 0)
                {
                    if (Test1.FixedTokenList[Test2.FixedTokenList.Count - 1] != Test2.FixedTokenList[Test2.FixedTokenList.Count - 1])
                    {
                        ErrFound = true;
                        OutTxt += ErrInfoTxt + "FixedTokenList [last] value unequal" + @"\r\n";
                    }
                }

                if (Test1.TokenList.Count != Test2.TokenList.Count)
                {
                    ErrFound = true;
                    OutTxt += ErrInfoTxt + "TokenList <string> counts value unequal" + @"\r\n";
                }

                if (Test2.TokenList.Count > 0)
                {
                    if (Test1.TokenList[0] != Test2.TokenList[0])
                    {
                        ErrFound = true;
                        OutTxt += ErrInfoTxt + "TokenList [0] value unequal" + @"\r\n";
                    }
                }
                // mListOfStringsValue.Add("third string");
                if (Test2.TokenList.Count > 0)
                {
                    if (Test1.TokenList[Test2.TokenList.Count - 1] != Test2.TokenList[Test2.TokenList.Count - 1])
                    {
                        ErrFound = true;
                        OutTxt += ErrInfoTxt + "TokenList [last] value unequal" + @"\r\n";
                    }
                }

                //-------------------------------------------------------------------------------
                // test order
                //-------------------------------------------------------------------------------

                // Empty class

                Test1 = new clsTestClsGrepTokenListBase();
                Test1.CfgVersion = "10.001";
                Test1.PreFixedTokenNumber = 3;
                Test1.FirstFixedTokenNumber = 2;
                Test1.MaxTokenNumber = 10;
                Test1.MaxFixedNumber = 4;

                List<string> Result;
                Result = Test1.MergedTokenList();
                if (Result.Count > 0)
                {
                    ErrFound = true;
                    OutTxt += ErrInfoTxt + "MergedTokenList count =" + Result.Count + " should be zero" + @"\r\n";
                }

                //---  --------------------------------------------------
                List<string> TestToken = new List<string>();
                TestToken.Add("first string");
                TestToken.Add("second string");
                TestToken.Add("third string");
                TestToken.Add("fourth string");
                TestToken.Add("fifth string");
                TestToken.Add("sixth string");
                TestToken.Add("sevent string");
                TestToken.Add("eigth string");
                TestToken.Add("nineth string");
                TestToken.Add("tenth string");
                List<string> TestFixToken = new List<string>();
                TestFixToken.Add("first fixed string");
                TestFixToken.Add("second fixed string");
                TestFixToken.Add("third fixed string");
                TestFixToken.Add("fourth fixed string");
                TestFixToken.Add("fifth fixed string");
                TestFixToken.Add("sixth fixed string");
                TestFixToken.Add("sevent fixed string");
                TestFixToken.Add("eigth fixed string");
                TestFixToken.Add("nineth fixed string");
                TestFixToken.Add("tenth fixed string");
                
                Test1.TokenList.Add(TestToken [0]);
                Result = Test1.MergedTokenList();
                if (Result.Count != 1)
                {
                    ErrFound = true;
                    OutTxt += ErrInfoTxt + "MergedTokenList count =" + Result.Count + " expected is 1 (from token)" + @"\r\n";
                }

                Test1.Clear();

                Test1.FixedTokenList.Add(TestFixToken[0]);
                Result = Test1.MergedTokenList();
                if (Result.Count != 1)
                {
                    ErrFound = true;
                    OutTxt += ErrInfoTxt + "MergedTokenList count =" + Result.Count + " expected is 1 (from 1 fixed token)" + @"\r\n";
                }

                Test1.TokenList.Add(TestToken[0]);
                Result = Test1.MergedTokenList();
                if (Result.Count != 2)
                {
                    ErrFound = true;
                    OutTxt += ErrInfoTxt + "MergedTokenList count =" + Result.Count + " expected is 2 (from 1 fixed and 1 standard token)" + @"\r\n";
                }
                else
                {
                    if (Result[1] != TestFixToken[0])
                    {
                        ErrFound = true;
                        OutTxt += ErrInfoTxt + "MergedTokenList Fixed token is not last token" + @"\r\n";
                    }
                }

                Test1.TokenList.Add(TestToken[1]);
                Result = Test1.MergedTokenList();
                if (Result.Count != 3)
                {
                    ErrFound = true;
                    OutTxt += ErrInfoTxt + "MergedTokenList count =" + Result.Count + " expected is 3 (from 1 fixed and 2 standard token)" + @"\r\n";
                }
                else
                {
                    if (Result[2] != TestFixToken[0])
                    {
                        ErrFound = true;
                        OutTxt += ErrInfoTxt + "MergedTokenList Fixed token is not last token" + @"\r\n";
                    }
                }

                Test1.TokenList.Add(TestToken[2]);
                Result = Test1.MergedTokenList();
                if (Result.Count != 4)
                {
                    ErrFound = true;
                    OutTxt += ErrInfoTxt + "MergedTokenList count =" + Result.Count + " expected is 4 (from 1 fixed and 3 standard token)" + @"\r\n";
                }
                else
                {
                    if (Result[3] != TestFixToken[0])
                    {
                        ErrFound = true;
                        OutTxt += ErrInfoTxt + "MergedTokenList Fixed token is not last token" + @"\r\n";
                    }
                }
                //-----------------------------------------------

                Test1.TokenList.Add(TestToken[3]);
                Result = Test1.MergedTokenList();
                if (Result.Count != 5)
                {
                    ErrFound = true;
                    OutTxt += ErrInfoTxt + "MergedTokenList count =" + Result.Count + " expected is 5 (from 1 fixed and 4 standard token)" + @"\r\n";
                }
                else
                {
                    if (Result[3] != TestFixToken[0])
                    {
                        ErrFound = true;
                        OutTxt += ErrInfoTxt + "MergedTokenList Fixed token is not first fixed position" + @"\r\n";
                    }
                    if (Result[4] != TestToken[3])
                    {
                        ErrFound = true;
                        OutTxt += ErrInfoTxt + "MergedTokenList Stanadrd token is not last token" + @"\r\n";
                    }
                }

                Test1.TokenList.Add(TestToken[4]);
                Result = Test1.MergedTokenList();
                if (Result.Count != 6)
                {
                    ErrFound = true;
                    OutTxt += ErrInfoTxt + "MergedTokenList count =" + Result.Count + " expected is 5 (from 1 fixed and 5 standard token)" + @"\r\n";
                }
                else
                {
                    if (Result[3] != TestFixToken[0])
                    {
                        ErrFound = true;
                        OutTxt += ErrInfoTxt + "MergedTokenList Fixed token is not first fixed position" + @"\r\n";
                    }
                    if (Result[4] != TestToken[3])
                    {
                        ErrFound = true;
                        OutTxt += ErrInfoTxt + "MergedTokenList Stanadrd token is not in position" + @"\r\n";
                    }
                    if (Result[5] != TestToken[4])
                    {
                        ErrFound = true;
                        OutTxt += ErrInfoTxt + "MergedTokenList Stanadrd token is not last token" + @"\r\n";
                    }
                }

                Test1.FixedTokenList.Add(TestFixToken[1]);
                Result = Test1.MergedTokenList();
                if (Result.Count != 6)
                {
                    ErrFound = true;
                    OutTxt += ErrInfoTxt + "MergedTokenList count =" + Result.Count + " expected is 6 (from 2 fixed and 4 standard token)" + @"\r\n";
                }
                else
                {
                    if (Result[3] != TestFixToken[0])
                    {
                        ErrFound = true;
                        OutTxt += ErrInfoTxt + "MergedTokenList Fixed token is not on first fixed position" + @"\r\n";
                    }
                    if (Result[4] != TestFixToken[1])
                    {
                        ErrFound = true;
                        OutTxt += ErrInfoTxt + "MergedTokenList Fixed token is not on position" + @"\r\n";
                    }
                    if (Result[5] != TestToken[4])
                    {
                        ErrFound = true;
                        OutTxt += ErrInfoTxt + "MergedTokenList Stanadrd token is not last token" + @"\r\n";
                    }
                }

                Test1.FixedTokenList.Add(TestFixToken[1]);
                Result = Test1.MergedTokenList();
                if (Result.Count != 7)
                {
                    ErrFound = true;
                    OutTxt += ErrInfoTxt + "MergedTokenList count =" + Result.Count + " expected is 7 (from 3 fixed and 4 standard token)" + @"\r\n";
                }
                else
                {
                    if (Result[3] != TestFixToken[0])
                    {
                        ErrFound = true;
                        OutTxt += ErrInfoTxt + "MergedTokenList Fixed token is not on first fixed position" + @"\r\n";
                    }
                    if (Result[4] != TestFixToken[1])
                    {
                        ErrFound = true;
                        OutTxt += ErrInfoTxt + "MergedTokenList Fixed token is not on position" + @"\r\n";
                    }
                    if (Result[5] != TestToken[3])
                    {
                        ErrFound = true;
                        OutTxt += ErrInfoTxt + "MergedTokenList Stanadrd token is not last token" + @"\r\n";
                    }
                    if (Result[6] != TestToken[4])
                    {
                        ErrFound = true;
                        OutTxt += ErrInfoTxt + "MergedTokenList Stanadrd token is not last token" + @"\r\n";
                    }
//yyy                    if (Result[6] != TestFixToken[2])
//                    {
//                        ErrFound = true;
//                        OutTxt += ErrInfoTxt + "MergedTokenList Fixed token is not last token" + @"\r\n";
//                    }
                }

                Test1.FixedTokenList.Add(TestFixToken[2]);
                Result = Test1.MergedTokenList();
                if (Result.Count != 8)
                {
                    ErrFound = true;
                    OutTxt += ErrInfoTxt + "MergedTokenList count =" + Result.Count + " expected is 7 (from 3 fixed and 5 standard token)" + @"\r\n";
                }
                else
                {
                    if (Result[3] != TestFixToken[0])
                    {
                        ErrFound = true;
                        OutTxt += ErrInfoTxt + "MergedTokenList Fixed token is not on first fixed position" + @"\r\n";
                    }
                    if (Result[4] != TestFixToken[1])
                    {
                        ErrFound = true;
                        OutTxt += ErrInfoTxt + "MergedTokenList Fixed token is not on position" + @"\r\n";
                    }
                    if (Result[5] != TestToken[3])
                    {
                        ErrFound = true;
                        OutTxt += ErrInfoTxt + "MergedTokenList Stanadrd token is not last token" + @"\r\n";
                    }
                    if (Result[6] != TestToken[4])
                    {
                        ErrFound = true;
                        OutTxt += ErrInfoTxt + "MergedTokenList Stanadrd token is not last token" + @"\r\n";
                    }
                    if (Result[7] != TestFixToken[2])
                    {
                        ErrFound = true;
                        OutTxt += ErrInfoTxt + "MergedTokenList Fixed token is not last token" + @"\r\n";
                    }
                }

                // empty class

                // add severel items

                // ....
            
            
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
