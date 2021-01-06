using System;
using System.Collections.Generic;
using System.Text;

namespace NetGrep
{
    [Serializable]
    public class clsSearchStringToken : clsGrepTokenListBase<clsSearchStringToken>
    {
        public clsSearchStringToken()
        {
            AssignStandardValues();
        }

        public override void  AssignStandardValues()
        {
            base.AssignStandardValues();

            MaxTokenNumber = 35;
            AssignStandardFileName();
        }

        public static void AssignStandardFileName()
        {
            CfgFileName = "SearchStringList.txt";
        }
    }
}
