using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Xml;

using System.Windows.Forms;
//using MainGlobal;
using ErrorCapture;
// using ConfigBase;

namespace ConfigBase
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
//    public class clsGrepTokenListBase : clsConfigSpezialBase <clsGrepTokenListBase>
//    public class clsGrepTokenListBase<T> : clsConfigSpezialBase<T> where T : clsGrepTokenListBase<T>, new()
//    public class clsConfigSpezialBase<T> where T : clsConfigSpezialBase<T>, new()
//    public class clsGrepTokenListBase<T> where T : clsGrepTokenListBase<T>, new ()
    public abstract class clsGrepTokenListBase<T> where T : clsGrepTokenListBase <T> , new ()
    {
        //---------------------------------------------------------------------------------------------
        // Config variables 
        //---------------------------------------------------------------------------------------------

        #region Class properties

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

        protected string mCfgVersion;

        //--- Name and paths of config files ---------------------------------------------
        public static string CfgFileName;

        #endregion Class properties

        //---------------------------------------------------------------------------------------------
        // Config getter and setter
        //---------------------------------------------------------------------------------------------

        protected List<string> TokenList
        {
            get 
            { 
                if (mTokenList == null) 
                    mFixedTokenList = new List<string>();
            
                return mTokenList; 
            }
        }

        protected List<string> FixedTokenList
        {
            get
            {
                if (mFixedTokenList == null)
                    mFixedTokenList = new List<string>();

                return mFixedTokenList;
            }
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

        public string CfgVersion
        {
            get { return mCfgVersion; }
            set { mCfgVersion = value; }
        }

        public static string ProgramCfgPathName
        {
            get { return Path.GetDirectoryName(Application.ExecutablePath); }
        }

        public static string ProgramCfgPathFileName
        {
            get { return Path.Combine(ProgramCfgPathName, CfgFileName); }
        }

        public static string UserCfgPathName
        {
            get { return Path.Combine(Environment.GetEnvironmentVariable("APPDATA"),
              Application.ProductName); }
        }

        public static string UserCfgPathFileName
        {
            get { return Path.Combine(UserCfgPathName, CfgFileName); }
        }

        //---------------------------------------------------------------------------------------------
        // Standard values
        //---------------------------------------------------------------------------------------------

        public virtual void AssignStandardValues()
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

        public clsGrepTokenListBase()
        {
            //CfgFileName = "SearchParameter.cfg";
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
                FillTokenList (ref OutTokens, PreFixedTokenNumber -1, mTokenList, ref TokenIdx);
            }

            // fixed part
            if (FixedTokenList.Count > 0)
            {
                FillTokenList (ref OutTokens, PreFixedTokenNumber + FirstFixedTokenNumber -1, 
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

        private void FillTokenList (ref List<string> OutTokens, int MaxOutIdx, List<string> InTokens, 
            ref int InIdx)
        {
            while (InIdx < InTokens.Count && OutTokens.Count -1 < MaxOutIdx)
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

        //---------------------------------------------------------------------------------------------
        // Save and Read config files 
        //---------------------------------------------------------------------------------------------

        public short SaveClass2File(string FilePathName)
        {
            short ErrFound = -1;
            try
            {
                //FilePathName = @"D:\test.ini";

                XmlSerializer ser = new XmlSerializer(typeof(T));
                XmlTextWriter xml = new XmlTextWriter(FilePathName, Encoding.UTF8);

                xml.Formatting = Formatting.Indented;
                xml.Indentation = 4;
                xml.IndentChar = (char)32;

                ser.Serialize(xml, this);
                xml.Close();

                ErrFound = 0;
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            return ErrFound;
        }

        /// <summary>
        /// Load a complete configuration from file 
        /// </summary>
        /// <returns></returns>
        /// <param name="FilePathName">Define file with path where to load from</param>
        /// <returns></returns>
        public static T LoadClassFromFile(string FilePathName)
        {
            T ConfigRenamePiwmContainer = default(T);

            XmlSerializer ser = new XmlSerializer(typeof(T));
            try
            {
                //if (!rdr.Value.Equals (""))
                if (File.Exists(FilePathName))
                {
                    XmlTextReader rdr = new XmlTextReader(FilePathName);
                    if (ser.CanDeserialize(rdr))
                    {
                        ConfigRenamePiwmContainer = (T)ser.Deserialize(rdr);
                        rdr.Close();
                    }
                    else
                    {
                        rdr.Close();
                    }
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            return ConfigRenamePiwmContainer;
        }

        /// <summary>
        /// Loads class from standard file in exe folder
        /// </summary>
        /// <param name="FilePathName"></param>
        /// <returns></returns>
        public static T LoadClassFromProgramFile()
        {
            if (File.Exists(ProgramCfgPathFileName))
                return LoadClassFromFile(ProgramCfgPathFileName);
            else
                return default(T);
        }

        public static T LoadClassOrCreateProgramFile()
        {
            T PrgConfig = LoadClassFromProgramFile();
            if (PrgConfig == null)
            {
                PrgConfig = new T();
                PrgConfig.SaveClass2ProgramFile();
            }
            
            return PrgConfig;
        }

        /// <summary>
        /// Save class to standard file in exe folder
        /// </summary>
        /// <param name="FilePathName"></param>
        /// <returns></returns>
        public int SaveClass2ProgramFile()
        {
            return SaveClass2File(ProgramCfgPathFileName);
        }

        /// <summary>
        /// Loads class from user file in exe folder
        /// </summary>
        /// <param name="FilePathName"></param>
        /// <returns></returns>
        public static T LoadClassFromUserFile()
        {
            try
            {
                // Destination path exists ?
                if (!Directory.Exists(UserCfgPathName))
                {
                    // Try to create
                    Directory.CreateDirectory(UserCfgPathName);
                }

                // Load file if directory exists
                if (Directory.Exists(UserCfgPathName))
                {
                    if (File.Exists(UserCfgPathFileName))
                    {
                        return LoadClassFromFile(UserCfgPathFileName);
                    }
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            return default(T);
        }

        /// <summary>
        /// Save class to user file in exe folder
        /// </summary>
        /// <param name="FilePathName"></param>
        /// <returns></returns>
        public int SaveClass2UserFile()
        {
            // Destination path exists ?
            if (!Directory.Exists(UserCfgPathName))
            {
                Directory.CreateDirectory(UserCfgPathName);
            }

            // if path exists create file
            if (Directory.Exists(UserCfgPathName))
            {
                return SaveClass2File(UserCfgPathFileName);
            }

            return -1;
        }

        public static T LoadClassOrCreateUserFile()
        {
            T UsrConfig = LoadClassFromUserFile();
            if (UsrConfig == null)
            {
                UsrConfig = LoadClassOrCreateProgramFile ();
                UsrConfig.SaveClass2UserFile();
            }

            return UsrConfig;
        }

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
    }
}
