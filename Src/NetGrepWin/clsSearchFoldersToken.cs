using System;
using System.Collections.Generic;
using System.Text;

namespace NetGrep
{
    [Serializable]
    public class clsSearchFoldersToken : clsGrepTokenListBase<clsSearchFoldersToken>
    {
        public clsSearchFoldersToken()
        {
            AssignStandardValues();
        }

        public override void AssignStandardValues()
        {
            base.AssignStandardValues();
            MaxTokenNumber = 40;
            AssignStandardFileName();
        }

        public static void AssignStandardFileName()
        {
            CfgFileName = "SearchFolderList.txt";
        }
    }
}
