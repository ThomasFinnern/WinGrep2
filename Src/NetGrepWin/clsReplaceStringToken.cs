using System;
using System.Collections.Generic;
using System.Text;

namespace NetGrep
{
    [Serializable]
    public class clsReplaceStringToken : clsGrepTokenListBase<clsReplaceStringToken>
    {
        public clsReplaceStringToken()
        {
            AssignStandardValues();
        }

        public override void  AssignStandardValues()
        {
            base.AssignStandardValues();
            AssignStandardFileName();
        }

        public static void AssignStandardFileName()
        {
            CfgFileName = "ReplaceStringList.txt";
        }
    }
}
