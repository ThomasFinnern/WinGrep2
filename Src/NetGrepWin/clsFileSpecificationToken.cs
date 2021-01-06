using System;
using System.Collections.Generic;
using System.Text;

namespace NetGrep
{
    [Serializable]
    public class clsFileSpecificationToken : clsGrepTokenListBase<clsFileSpecificationToken>
    {
        public clsFileSpecificationToken()
        {
            AssignStandardValues();
        }

        public override void AssignStandardValues()
        {
            base.AssignStandardValues();
            MaxTokenNumber = 35;
            AssignStandardFileName();
        }

        public static void AssignStandardFileName()
        {
            CfgFileName = "SearchFileSpecList.txt";        
        }

    }
}
