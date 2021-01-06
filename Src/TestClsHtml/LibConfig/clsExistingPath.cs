using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Windows.Forms;
using ErrorCapture;

namespace AppPaths
{
    // [Serializable]
    /// <summary>
    /// Keeps string for given path. If flag is set for creation the path will
    /// be created if not already existing. using property 'PathName' will 
    /// give an error message when the path does not exist. To retrieve the 
    /// path name the function 'ToString ()' may be used
    /// </summary>
    public class clsExistingPath
    {
        public enum CreateFolder : int
        { 
            eDoNotCreateFolder,
            eDoCreateFolder
        }

        //// ToDo: Try to use this class as string replacement
        //public string this ()
        //{
        //    return mPathName;
        //}


        public clsExistingPath(string InPathName, CreateFolder DoCreateFolder)
        {
            mPathName = InPathName;

            if (DoCreateFolder == CreateFolder.eDoCreateFolder)
                bIsPathExisting = CreatePath();
            else
                bIsPathExisting = Directory.Exists(InPathName);
        }

        public bool bIsPathExisting = false;

        private string mPathName;
        public string PathName
        {
            get
            {   
                // Warning for the programmer
                if (!bIsPathExisting)
                {
                    string OutTxt = string.Format ("Path: '{0}' does not yet exist", mPathName);
                    MessageBox.Show(OutTxt);                
                }
                return mPathName;
            }
        }

        /// <summary>
        /// Assigns new path name and creates it if it does not exists
        /// </summary>
        /// <param name="PathName"></param>
        /// <returns>Path does exists = true</returns>
        public bool CreatePath(string InPathName)
        {
            mPathName = InPathName;
            return CreatePath();
        }

        /// <summary>
        /// Creates path already given if it does not exists
        /// </summary>
        /// <returns>Path does exists = true</returns>
        public bool CreatePath()
        {
            bool bSuccessfull = false;

            try
            {
                // Destination path exists ?
                if (Directory.Exists(mPathName))
                {
                    bSuccessfull = true;
                }
                else
                {
                    try
                    {
                        Directory.CreateDirectory(mPathName);
                    }
                    catch 
                    {
                        bSuccessfull = false;
                    }                        
                        
                    // if path exists create file
                    if (Directory.Exists(mPathName))
                    {
                        bSuccessfull = true;
                    }
                    else
                    {
                        string OutTxt = "Failed to create folder: '" + mPathName + "'";
                        MessageBox.Show(OutTxt);
                    }
                }

            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            bIsPathExisting = bSuccessfull;
            return bSuccessfull;
        }

        /// <summary>
        /// Deletes the folder given
        /// </summary>
        /// <returns></returns>
        public bool DeletePath()
        { 
            bool bIsDeleted = false;
            try
            {
                if (Directory.Exists(mPathName))
                {
                    Directory.Delete (mPathName, true);
                }

                bIsDeleted = true;
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            return bIsDeleted;
        }

        /// <summary>
        /// May be used to get path name without error "Path not existing"
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return mPathName;
        }
    }
}
