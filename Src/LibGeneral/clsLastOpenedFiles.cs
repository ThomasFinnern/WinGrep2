using System;
using System.Collections.Generic;
using System.Text;

using ErrorCapture;

namespace LibStringFunctions
{
    [Serializable]
    public class clsLastOpenedFiles : clsTokenListFixedLength<clsLastOpenedFiles>
    {
        public clsLastOpenedFiles()
        {
            AssignStandardValues();
        }

        public override void AssignStandardValues()
        {
            base.AssignStandardValues();
            AssignStandardFileName();
        }

        public static void AssignStandardFileName()
        {
            CfgFileName = "LastOpenedFilesList.txt";        
        }
    }




}
