using System;
using System.Collections.Generic;
using System.Text;

namespace NetGrep
{
    
    [Serializable]
    public class clsBackupFoldersToken : clsGrepTokenListBase<clsBackupFoldersToken>
    {
        public clsBackupFoldersToken()
        {
            AssignStandardValues();
        }

        public override void AssignStandardValues()
        {
            base.AssignStandardValues();
            MaxTokenNumber = 20;
            AssignStandardFileName();
        }

        public static void AssignStandardFileName()
        {
            CfgFileName = "BackupFolderList.txt";
        }
    }
}
