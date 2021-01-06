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
    public class clsTestClsConfigSpezialBase : clsConfigSpezialBase<clsTestClsConfigSpezialBase> 
    {
        //---------------------------------------------------------------------------------------------
        // Config variables 
        //---------------------------------------------------------------------------------------------

        #region Class properties

        // base: protected string mCfgVersion;

        /// <summary>
        /// Standad token (may include some fixed ones). The last used one will be put to the head . 
        /// The oldest token will fall out if the list grows too long
        /// </summary>
        protected List<string> mTokenList = new List<string>();
        /// <summary>
        /// Fixed token (they will not be ordered and be kept even if not used for a long time)
        /// </summary>
        protected List<string> mFixedTokenList = new List<string>();

        /// <summary>
        /// Number of standard token to be shown in front of Fixed List
        /// </summary>
        protected int mPreFixedTokenNumber;
        /// <summary>
        /// Number of fixed token to be shown bevor further standard tokens 
        /// </summary>
        protected int mFirstFixedTokenNumber;
        /// <summary>
        /// The token list keeps not more than these number of items
        /// </summary>
        protected int mMaxTokenNumber;
        /// <summary>
        /// The fixed token list keeps not more than these number of items
        /// </summary>
        protected int mMaxFixedNumber;

        #endregion Class properties

        //---------------------------------------------------------------------------------------------
        // Config getter and setter
        //---------------------------------------------------------------------------------------------

        public List<string> TokenList
        {
            get { return mTokenList; }
            set { mTokenList = value; }
        }

        public List<string> FixedTokenList
        {
            get { return mFixedTokenList; }
            set { mFixedTokenList = value; }
        }

        /// <summary>
        /// Number of items shown previous to the fixed elements
        /// </summary>
        public int PreFixedTokenNumber
        {
            get { return mPreFixedTokenNumber; }
            set { mPreFixedTokenNumber = value; }
        }

        /// <summary>
        /// Number of fixed items shown before standard items are shown again
        /// </summary>
        public int FirstFixedTokenNumber
        {
            get { return mFirstFixedTokenNumber; }
            set { mFirstFixedTokenNumber = value; }
        }

        /// <summary>
        /// Maximal number of items saved as standard tokens
        /// </summary>
        public int MaxTokenNumber
        {
            get { return mMaxTokenNumber; }
            set { mMaxTokenNumber = value; }
        }

        /// <summary>
        /// Maximal number of items saved as fixed tokens
        /// </summary>
        public int MaxFixedNumber
        {
            get { return mMaxFixedNumber; }
            set { mMaxFixedNumber = value; }
        }

        //---------------------------------------------------------------------------------------------
        // Standard values
        //---------------------------------------------------------------------------------------------

        public override void AssignStandardValues()
        {
            mCfgVersion = "0.001";
            //AutoFilenameAfterRandomCmd = true;

            Clear(); // token lists

            mPreFixedTokenNumber = 7;
            mFirstFixedTokenNumber = 10;
            mMaxTokenNumber = 25;
            mMaxFixedNumber = 15;            
        }

        // public void ClearTokenLists()
        public void Clear()
        {
            mFixedTokenList = new List<string>();
            mTokenList = new List<string>();
        }

        public static void AssignFileName(string FileName)
        {
            CfgFileName = FileName;
        }

        //---------------------------------------------------------------------------------------------
        // Config class construction
        //---------------------------------------------------------------------------------------------

        public clsTestClsConfigSpezialBase()
        {
            AssignStandardValues();
        }

        //---------------------------------------------------------------------------------------------
        // Accessor functions
        //---------------------------------------------------------------------------------------------

        public List<string> MergedTokenList()
        {
            List<string> OutTokens = new List<string>();

            //int FillIdx = 0;
            int TokenIdx = 0;
            int FixedIdx = 0;
            int LastTokenIdx = 0;
            int MaxOutIdx = 0;
            //int Idx = 0;
            //int Idx = 0;

            // Unfixed part
            if (TokenList.Count > 0)
            {
                FillTokenList(ref OutTokens, PreFixedTokenNumber - 1, mTokenList, ref TokenIdx);
            }

            // fixed part
            if (FixedTokenList.Count > 0)
            {
                FillTokenList(ref OutTokens, PreFixedTokenNumber + FirstFixedTokenNumber - 1,
                    mFixedTokenList, ref FixedIdx);
            }

            // Left over unfixed tokens
            if (mTokenList.Count > TokenIdx)
            {
                MaxOutIdx = OutTokens.Count + mTokenList.Count - TokenIdx - 1;
                if (MaxOutIdx > MaxTokenNumber)
                {
                    if (MaxTokenNumber > 10)
                        MaxOutIdx = MaxTokenNumber;
                }
                FillTokenList(ref OutTokens, MaxOutIdx, mTokenList, ref TokenIdx);
            }

            // Left over fixed tokens  show all available or limi it to max token number
            if (mFixedTokenList.Count > FixedIdx)
            {
                MaxOutIdx = OutTokens.Count + mFixedTokenList.Count - FixedIdx - 1;
                if (MaxOutIdx > MaxTokenNumber)
                {
                    if (MaxTokenNumber > 10)
                        MaxOutIdx = MaxTokenNumber;
                }
                FillTokenList(ref OutTokens, LastTokenIdx, mTokenList, ref FixedIdx);
            }

            return OutTokens;
        }

        private void FillTokenList(ref List<string> OutTokens, int MaxOutIdx, List<string> InTokens,
            ref int InIdx)
        {
            while (InIdx < InTokens.Count && OutTokens.Count - 1 < MaxOutIdx)
            {
                // Use only once
                if (!OutTokens.Contains(InTokens[InIdx]))
                {
                    OutTokens.Add(InTokens[InIdx]);
                }
                InIdx++;
            }
        }

        public bool ContainsFixedToken(string TestToken)
        {
            return mFixedTokenList.Contains(TestToken);
        }

        /// <summary>
        /// Assigns a new token if not existing as first element. 
        /// If the elements already exists it is moved to the first place
        /// </summary>
        /// <param name="NewToken"></param>
        public void AddUsedToken(string NewToken)
        {
            if (TokenList.Count > 0)
            {
                // New token already in first place ?
                if (mTokenList[0].CompareTo(NewToken) == 0)
                    return;

                if (mTokenList.Contains(NewToken))
                {
                    mTokenList.Remove(NewToken);
                }
            }

            mTokenList.Insert(0, NewToken);

            if (mMaxTokenNumber > 1)
            {
                while (mTokenList.Count > mMaxTokenNumber)
                    mTokenList.RemoveAt(mTokenList.Count);
            }
        }
        public void AddFreeToken2List(string NewToken)
        {
            if (!TokenList.Contains(NewToken))
            {
                if (mTokenList.Count < mMaxTokenNumber)
                    mTokenList.Add(NewToken);
            }
        }

        public void AddFixToken2List(string NewToken)
        {
            if (!FixedTokenList.Contains(NewToken))
            {
                if (mFixedTokenList.Count < mMaxTokenNumber)
                    mFixedTokenList.Add(NewToken);
            }
        }


        /*
         * more functions :
           token / fixed  contains // look in both
           remove doubles 
        */

        public override string ToString()
        {
            string OutTxt = "";

            if (TokenList.Count > 0)
            {
                OutTxt += "Token:" + "\r\n";
                foreach (string Token in mTokenList)
                {
                    OutTxt += "   " + Token + "\r\n";
                }
            }

            if (FixedTokenList.Count > 0)
            {
                OutTxt += "Fixed token:" + "\r\n";
                foreach (string Token in mFixedTokenList)
                {
                    OutTxt += "   " + Token + "\r\n";
                }
            }

            return OutTxt;
        }

        //---------------------------------------------------------------------------------------------
        // Test this class
        //---------------------------------------------------------------------------------------------

        public static bool TestClass(ref string OutTxt)
        {
            bool ErrFound = false;
            string ErrInfoTxt = "Error in clsTestClsConfigSpezialBase: ";

            try
            {
                clsTestClsConfigSpezialBase Test1 = new clsTestClsConfigSpezialBase();
                string FileName = @".\clsTestClsConfigSpezialBase.01.txt";
                Test1.TokenList.Add("first string");
                Test1.TokenList.Add("second string");
                Test1.TokenList.Add("third string");

                Test1.FixedTokenList.Add("fixed first string");
                Test1.FixedTokenList.Add("fixed second string");
                Test1.FixedTokenList.Add("fixed third string");

                Test1.SaveClass2File(FileName);

                clsTestClsConfigSpezialBase Test2 = clsTestClsConfigSpezialBase.LoadClassFromFile(FileName);


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
