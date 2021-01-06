using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Windows.Forms;
using ErrorCapture;

// ToDo: :: my documents (Mymusic ...)
// ToDo: :: ? about local application data ? templates ? CommonFilesPathName  ==> check out what to put where 

namespace AppPaths
{
    /***
         microsoft http://msdn.microsoft.com/de-de/library/system.environment.specialfolder.aspx  
    ***/
    /// <summary>
    /// Holds the pathes needed by the application by adding the application 
    /// name to already existing Environment.SpecialFolder definition.
    /// (First layer)
    /// Pathes for config files, documents and the likes will be expected from 
    /// the user in several different in subfolders. These will not be created 
    /// on starting of the class but may be created by calling function
    /// CreatePathesIfNotExist with selecting the needed folders
    /// </summary>
    public class clsAppPathsBase
    {
        [Flags]
        public enum eCreateBaseFolders : int
        {
            UserPathName = 1,
            AllUsersPathName = 2,
            ProgramCommonFilesPathName = 4,
            ExePathName = 8,
            UserDocumentsPathName = 16
        }

        /// <summary>
        /// Path to user data
        /// </summary>
        public static clsExistingPath UserPathName = new clsExistingPath(
            Path.Combine(
                // Environment.GetEnvironmentVariable("APPDATA"),
                // Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                // Environment.GetFolderPath(Environment.SpecialFolder.Programs),  // user Startmenü
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                Application.ProductName),
                clsExistingPath.CreateFolder.eDoNotCreateFolder
            );

        /// <summary>
        /// Path to all users data
        /// </summary>
        public static clsExistingPath AllUsersPathName = new clsExistingPath(
            Path.Combine(
                // Environment.GetEnvironmentVariable("ALLUSERSPROFILE"),
                // Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                Application.ProductName),
                clsExistingPath.CreateFolder.eDoNotCreateFolder
            );

        /// <summary>
        /// Path to common files of the exe
        /// </summary>
        public static clsExistingPath ProgramCommonFilesPathName = new clsExistingPath(
            Path.Combine(
                // Environment.GetEnvironmentVariable("ALLUSERSPROFILE"),
                Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles),
                Application.ProductName),
                clsExistingPath.CreateFolder.eDoNotCreateFolder
            );

        /// <summary>
        /// path to real origin for exe (debug ...) may be different to ==> c:\Program Files
        /// </summary>
        public static clsExistingPath ExePathName = new clsExistingPath(
                // Path.Combine(
                //        Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                //        Application.ProductName));
                Path.GetDirectoryName(Application.ExecutablePath),
                clsExistingPath.CreateFolder.eDoNotCreateFolder
            );

        ///// <summary>
        ///// Standard path where it shall be saved ==> c:\Program Files\appname ...
        ///// </summary>
        //public static clsExistingPath ExePrgPathName = new clsExistingPath(
        //    Path.Combine(
        //        //Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles),
        //        Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
        //        // Startup: Environment.GetFolderPath(Environment.SpecialFolder.Programs),
        //        Application.ProductName),
        //        clsExistingPath.CreateFolder.eDoNotCreateFolder
        //    );

        /// <summary>
        /// Path to all users data
        /// </summary>
        public static clsExistingPath UserDocumentsPathName = new clsExistingPath(
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Application.ProductName),
                clsExistingPath.CreateFolder.eDoNotCreateFolder
            );

        public static bool CreateApplicationNamePathes(eCreateBaseFolders Folders)
        {
            bool bIsPathExisting = false;

            if ((Folders & eCreateBaseFolders.UserPathName) == eCreateBaseFolders.UserPathName)
            {
                bIsPathExisting |= UserPathName.CreatePath();
            }
            if ((Folders & eCreateBaseFolders.AllUsersPathName) == eCreateBaseFolders.AllUsersPathName)
            {
                bIsPathExisting |= AllUsersPathName.CreatePath();
            }
            if ((Folders & eCreateBaseFolders.ProgramCommonFilesPathName) == eCreateBaseFolders.ProgramCommonFilesPathName)
            {
                bIsPathExisting |= ProgramCommonFilesPathName.CreatePath();
            }
            if ((Folders & eCreateBaseFolders.ExePathName) == eCreateBaseFolders.ExePathName)
            {
                bIsPathExisting |= ExePathName.CreatePath();
            }
            if ((Folders & eCreateBaseFolders.UserDocumentsPathName) == eCreateBaseFolders.UserDocumentsPathName)
            {
                bIsPathExisting |= UserDocumentsPathName.CreatePath();
            }
            //if (( Folders &  eCreateBaseFolders.ExePrgPathName) ==  eCreateBaseFolders.ExePrgPathName)
            //{
            //    bIsPathExisting |= ExePrgPathName.CreatePathIfNotExists();
            //}

            return bIsPathExisting;
        }

        public static void AssignExpectedExePathName()
        {
            ExePathName = new clsExistingPath(
                Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                    Application.ProductName),
                    clsExistingPath.CreateFolder.eDoNotCreateFolder
                );
        }

        public static void AssignExpectedProgramCommonFilesPathName32BitOnWin7_64Bit()
        {
            ProgramCommonFilesPathName = new clsExistingPath(
                Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + " (x86)",
                    // "Program Files (x86)",
                    Application.ProductName),
                    clsExistingPath.CreateFolder.eDoNotCreateFolder
                );
        }

        public static void AssignExePathName32BitOnWin7_64Bit()
        {
            ExePathName = new clsExistingPath(
                Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + " (x86)",
                    // "Program Files (x86)",
                    Application.ProductName),
                    clsExistingPath.CreateFolder.eDoNotCreateFolder
                );
        }


        public static bool DeleteApplicationNamePathes(eCreateBaseFolders Folders)
        {
            bool bIsPathExisting = false;

            if ((Folders & eCreateBaseFolders.UserPathName) == eCreateBaseFolders.UserPathName)
            {
                bIsPathExisting |= UserPathName.DeletePath();
            }
            if (( Folders &  eCreateBaseFolders.AllUsersPathName) ==  eCreateBaseFolders.AllUsersPathName)
            {
                bIsPathExisting |= AllUsersPathName.DeletePath();
            }
            if ((Folders & eCreateBaseFolders.ProgramCommonFilesPathName) == eCreateBaseFolders.ProgramCommonFilesPathName)
            {
                bIsPathExisting |= ProgramCommonFilesPathName.DeletePath();
            }
            if ((Folders & eCreateBaseFolders.ExePathName) == eCreateBaseFolders.ExePathName)
            {
                bIsPathExisting |= ExePathName.DeletePath();
            }
            if ((Folders & eCreateBaseFolders.UserDocumentsPathName) == eCreateBaseFolders.UserDocumentsPathName)
            {
                bIsPathExisting |= UserDocumentsPathName.DeletePath();
            }
            //if (( Folders &  eCreateBaseFolders.ExePrgPathName) ==  eCreateBaseFolders.ExePrgPathName)
            //{
            //    bIsPathExisting |= ExePrgPathName.CreatePathIfNotExists();
            //}

            return bIsPathExisting;
        }

        //static string ProgramFilesx86()
        //{
        //    if (8 == IntPtr.Size
        //        || (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))
        //    {
        //        return Environment.GetEnvironmentVariable("ProgramFiles(x86)");
        //    }

        //    return Environment.GetEnvironmentVariable("ProgramFiles");

        //    Environment.GetEnvironmentVariable("PROGRAMFILES(X86)") ?? 
        //        Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)

        //}


    }





/*
Application Folder
	

An application folder under the Program Files folder. Typically C:\Program Files\Company Name\App Name.

Common Files Folder
	

A folder for components that are shared across applications. Typically C:\Program Files\Common.

Common Files Folder (64-bit)
	

Same as the Common Files Folder, but for use only with 64-bit installers. For more information, see How to: Create a Windows Installer for a 64-bit Platform.

Custom Folder
	

A folder that you create on a target computer, or a predefined Windows folder that is not a special folder. Defaults to same location as the Application folder.

Fonts Folder
	

A virtual folder that contains fonts. Typically C:\Winnt\Fonts.

Module Retargetable Folder
	

A custom folder that you can use to specify an alternative location for a merge module.

Program Files Folder
	

The root node for program files. Typically C:\Program Files.

Program Files Folder (64-bit)
	

Same as the Program Files Folder, but for use only with 64-bit installers. For more information, see How to: Create a Windows Installer for a 64-bit Platform.

System Folder
	

The Windows System folder for shared system files. Typically C:\Winnt\System32.

System Folder (64-bit)
	

Same as the System Folder, but for use only with 64-bit installers. For more information, see How to: Create a Windows Installer for a 64-bit Platform.

User's Application Data Folder
	

A folder that serves as a repository for application-specific data on a per-user basis. Typically C:\Documents and Settings\username\Application Data.

User's Desktop
	

A folder that contains files and folders that appear on the desktop on a per-user basis. Typically C:\Documents and Settings\username\Desktop.

User's Favorites Folder
	

A folder that serves as a repository for the user's favorite items. Typically C:\Documents and Settings\username\Favorites.

User's Personal Data Folder
	

A folder that serves as a per-user repository for documents. Typically C:\Documents and Settings\username\My Documents.

User's Programs Menu
	

A folder that contains a user's program groups. Typically C:\Documents and Settings\username\Start Menu\Programs.

User's Send To Menu
	

A folder that contains a user's Send To menu items. Typically C:\Documents and Settings\username\SendTo.

User's Start Menu
	

A folder that contains a user's Start menu items. Typically C:\Documents and Settings\username\Start Menu.

User's Template Folder
	

A folder that contains document templates on a per-user basis. Typically C:\Documents and Settings\username\Templates.

Windows Folder
	

Windows or system root directory. Typically C:\Winnt.

Web Custom Folder
	

A custom folder on a Web server, identified by an HTTP address.
*/



}

