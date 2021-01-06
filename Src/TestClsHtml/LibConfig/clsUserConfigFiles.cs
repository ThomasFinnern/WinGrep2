using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using AppPaths;
using System.Windows.Forms;

namespace LibConfig
{
    // User files which can't be created but a original is in programm (all users) folder
    class clsUserConfigFiles
    {
        public List<string> CfgFileList = new List<string> ();

        public void Check4ExistingFilesOrCopy ()
        {
            foreach (string FileName in CfgFileList)
            {
                Check4ExistingUserFileOrCopy (FileName);
            }
        
        }

        public bool Check4ExistingUserFileOrCopy(string FileName)
        {
            bool bFileDoesExist = false;
            string PathFileName = Path.Combine(clsAppPaths.UserCfgPathName.PathName, FileName);
            if (File.Exists(PathFileName))
                bFileDoesExist = true;
            else
            {
                if (Check4ExistingAllUserFileOrCopy(FileName))
                {
                    // Copy programm config file to all users 
                    string SrcPathFileName = Path.Combine(clsAppPaths.AllUsersCfgPathName.PathName, FileName);
                    File.Copy(SrcPathFileName, PathFileName);
                    if (File.Exists(PathFileName))
                    {
                        bFileDoesExist = true;
                    }
                    // No second message
                    //else
                    //{
                    //    string OutTxt = string.Format("File: {0} not found ", PathFileName);
                    //    MessageBox.Show(OutTxt);
                    //}
                }
            }

            return bFileDoesExist;
        }

        public bool Check4ExistingAllUserFileOrCopy(string FileName)
        {
            bool bFileDoesExist = false;
            string PathFileName = Path.Combine(clsAppPaths.AllUsersCfgPathName.PathName, FileName);
            if (File.Exists (PathFileName))
                bFileDoesExist = true;
            else
            {
                if (Check4ExistingPrgCfgFile(FileName))
                {
                    // Copy programm config file to all users 
                    string SrcPathFileName = Path.Combine(clsAppPaths.ProgramCfgPathName.PathName, FileName);
                    File.Copy(SrcPathFileName, PathFileName);
                    if (File.Exists(PathFileName))
                    {
                        bFileDoesExist = true;
                    }
                    // No second message
                    //else
                    //{
                    //    string OutTxt = string.Format("File: {0} not found ", PathFileName);
                    //    MessageBox.Show(OutTxt);
                    //}
                }
            }

            return bFileDoesExist;
        }

        public bool Check4ExistingPrgCfgFile(string FileName)
        {
            bool bFileDoesExist = false;
            string PathFileName = Path.Combine(clsAppPaths.ProgramCfgPathName.PathName, FileName);

            if (File.Exists(PathFileName))
            {
                bFileDoesExist = true;
            }
            else
            {
                string OutTxt = string.Format("User configuration file: {0} not found ", PathFileName);
                MessageBox.Show(OutTxt);
            }

            return bFileDoesExist;
        }

    }
}
