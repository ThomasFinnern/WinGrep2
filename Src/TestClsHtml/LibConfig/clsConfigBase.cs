using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Windows.Forms;
using ErrorCapture;
using AppPaths;

namespace ConfigBase
{
    [Serializable]
//    public class clsConfigBase<T> where T : class, new()
    public abstract class clsConfigBase<T> where T : clsConfigBase<T>, new()
    {
        //--- Name and paths of config files ---------------------------------------------

        public static string StdCfgFileName
        {
            get { return @"Config." + Application.ProductName + ".ini"; }
        }

        //---------------------------------------------------------------------------------------------
        // Config variables 
        //---------------------------------------------------------------------------------------------

        #region Class properties

        // protected string mCfgVersion;

        #endregion class properties

        //public string CfgVersion
        //{
        //    get { return mCfgVersion; }
        //    set { mCfgVersion = value; }
        //}

        public static string ProgramCfgPathName
        {
            get { return clsAppPaths.ProgramCfgPathName.PathName; }
        }

        public static string ProgramCfgPathFileName
        {
            get { return Path.Combine(ProgramCfgPathName, StdCfgFileName); }
        }

        public static string UserCfgPathName
        {
            get { return clsAppPaths.UserCfgPathName.PathName; }
        }

        public static string UserCfgPathFileName
        {
            get { return Path.Combine(UserCfgPathName, StdCfgFileName); }
        }

        public static string AllUsersCfgPathName
        {
            get { return clsAppPaths.AllUsersCfgPathName.PathName; }
        }

        public static string AllUsersCfgPathFileName
        {
            get { return Path.Combine(AllUsersCfgPathName, StdCfgFileName); }
        }

        public abstract void AssignStandardValues();

        //---------------------------------------------------------------------------------------------
        // Save and Read config files 
        //---------------------------------------------------------------------------------------------

        public short SaveClass2File(string FilePathName)
        {
            short ErrFound = -1;
            try
            {
                //FilePathName = @"D:\test.ini";

                // ToDo: : put a try here
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

        ///// <summary>
        ///// Loads class from standard file in exe folder
        ///// </summary>
        ///// <param name="FilePathName"></param>
        ///// <returns></returns>
        //public static T LoadClassFromProgramFile()
        //{
        //    if (File.Exists(ProgramCfgPathFileName))
        //        return LoadClassFromFile(ProgramCfgPathFileName);
        //    else
        //        return default(T);
        //}

        //public static T LoadClassOrCreateProgramFile()
        //{
        //    T PrgConfig = LoadClassFromProgramFile();
        //    if (PrgConfig == null)
        //    {
        //        PrgConfig = new T();
        //        PrgConfig.SaveClass2ProgramFile();
        //    }

        //    return PrgConfig;
        //}

        ///// <summary>
        ///// Save class to standard file in exe folder
        ///// </summary>
        ///// <param name="FilePathName"></param>
        ///// <returns></returns>
        //public int SaveClass2ProgramFile()
        //{
        //    return SaveClass2File(ProgramCfgPathFileName);
        //}

        /// <summary>
        /// Loads class from standard file in exe folder
        /// </summary>
        /// <param name="FilePathName"></param>
        /// <returns></returns>
        public static T LoadClassFromAllUsersFile()
        {
            if (File.Exists(AllUsersCfgPathFileName))
                return LoadClassFromFile(AllUsersCfgPathFileName);
            else
                return default(T);
        }

        /// <summary>
        /// Save class to standard file in exe folder
        /// </summary>
        /// <param name="FilePathName"></param>
        /// <returns></returns>
        public int SaveClass2AllUsersFile()
        {
            return SaveClass2File(AllUsersCfgPathFileName);
        }

        public static T LoadClassOrCreateAllUsersFile()
        {
            T AllUsersConfig = LoadClassFromAllUsersFile();
            if (AllUsersConfig == null)
            {
                //AllUsersConfig = LoadClassFromProgramFile();
                //if (AllUsersConfig == null)
                //{
                    AllUsersConfig = new T();
                //}

                AllUsersConfig.SaveClass2AllUsersFile();
            }

            return AllUsersConfig;
        }

        ///// <summary>
        ///// Save class to standard file in exe folder
        ///// </summary>
        ///// <param name="FilePathName"></param>
        ///// <returns></returns>
        //public int SaveClass2AllUsersFile()
        //{
        //    return SaveClass2File(ProgramCfgPathFileName);
        //}

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
                UsrConfig = LoadClassOrCreateAllUsersFile ();
                UsrConfig.SaveClass2UserFile();
            }

            return UsrConfig;
        }

    }
}
