using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Windows.Forms;
using ErrorCapture;

// Class of application paths
namespace AppPaths
{
    /// <summary>
    /// Extends application base pathes (first layer with application name 
    /// added) for pathed to keep program and user config files, documents ... 
    /// The resulting path names will be build by adding standard path 
    /// + application name [+ config or .... name] (Second layer)
    /// The pathes will not be created on starting of the class. They shall be 
    /// created in main class of using programm with calling function 
    /// CreatePathesIfNotExist with selecting the needed folders
    /// </summary>
    [Serializable]
    public class clsAppPaths : clsAppPathsBase
    {
        [Flags]
        public enum eCreateFolders : int
        {
            UserCfgPathName = 1,
            AllUsersCfgPathName = 2,
            ProgramCfgPathName = 4,
            //ExePathName = 8,
            //ExePrgPathName = 16,
        }

        public clsAppPaths(eCreateFolders Folders)
        {
            CreateApplicationConfigPathes(Folders);
        }

        // used '.ToString ()' instead of '.PathName' as pathname will check if path is existing anf give error when not
        public static clsExistingPath ProgramCfgPathName =
            // new clsExistingPath(Path.Combine(ExeCommonFilesPathName.PathName, ""), clsExistingPath.CreateFolder.eDoNotCreateFolder); // c:\program folder\ ...
            new clsExistingPath(Path.Combine(ProgramCommonFilesPathName.ToString(), "Config"), clsExistingPath.CreateFolder.eDoNotCreateFolder); // c:\program folder\ ...

        public static clsExistingPath UserCfgPathName =
            new clsExistingPath(Path.Combine(UserPathName.PathName, "Config"), clsExistingPath.CreateFolder.eDoCreateFolder);
            // new clsExistingPath(Path.Combine(UserPathName.ToString(), "Config"), clsExistingPath.CreateFolder.eDoCreateFolder);

        public static clsExistingPath AllUsersCfgPathName =
            // new clsExistingPath(Path.Combine(AllUsersPathName.PathName, "Config"), clsExistingPath.CreateFolder.eDoCreateFolder);
            new clsExistingPath(Path.Combine(AllUsersPathName.ToString(), "Config"), clsExistingPath.CreateFolder.eDoCreateFolder);

        ////new clsExistingPath(
        ////Path.Combine(
        ////    Path.Combine(UserPathName.PathName,
        ////        Application.ProductName),
        ////    "Config"));

        public static bool CreateApplicationConfigPathes(eCreateFolders Folders)
        {
            bool bIsPathExisting = false;

            if ((Folders & eCreateFolders.UserCfgPathName) == eCreateFolders.UserCfgPathName)
            {
                CreateApplicationNamePathes(eCreateBaseFolders.UserPathName);
                bIsPathExisting |= UserCfgPathName.CreatePath();
            }

            if ((Folders & eCreateFolders.AllUsersCfgPathName) == eCreateFolders.AllUsersCfgPathName)
            {
                CreateApplicationNamePathes(eCreateBaseFolders.AllUsersPathName);
                bIsPathExisting |= AllUsersCfgPathName.CreatePath();
            }

            if ((Folders & eCreateFolders.ProgramCfgPathName) == eCreateFolders.ProgramCfgPathName)
            {
                CreateApplicationNamePathes(eCreateBaseFolders.ProgramCommonFilesPathName);
                bIsPathExisting |= ProgramCfgPathName.CreatePath();
            }

            return bIsPathExisting;
        }

        public static bool DeleteApplicationConfigPathes(eCreateFolders Folders)
        {
            bool bIsPathExisting = false;

            if ((Folders & eCreateFolders.UserCfgPathName) == eCreateFolders.UserCfgPathName)
            {
                bIsPathExisting |= UserCfgPathName.DeletePath();
            }

            if ((Folders & eCreateFolders.AllUsersCfgPathName) == eCreateFolders.AllUsersCfgPathName)
            {
                bIsPathExisting |= AllUsersCfgPathName.DeletePath();
            }

            if ((Folders & eCreateFolders.ProgramCfgPathName) == eCreateFolders.ProgramCfgPathName)
            {
                bIsPathExisting |= ProgramCfgPathName.DeletePath();
            }

            return bIsPathExisting;
        }

        public static void AssignExeConfigPathName32BitOnWin7_64Bit()
        {
            ProgramCfgPathName =
                new clsExistingPath(Path.Combine(ProgramCommonFilesPathName.ToString(), "Config"), 
                clsExistingPath.CreateFolder.eDoNotCreateFolder); 
        }
    }
}
