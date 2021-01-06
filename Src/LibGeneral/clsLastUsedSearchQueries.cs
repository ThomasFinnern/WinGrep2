using System;
using System.Collections.Generic;
using System.Text;

using ErrorCapture;
using LibStringFunctions;

namespace NetGrep 
{
    [Serializable]
    public class clsLastUsedSearchQueries : clsObjectListFixedLength<clsSearchProperties, clsLastUsedSearchQueries>
    {
        public clsLastUsedSearchQueries()
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
            CfgFileName = "LastUsedSearchQueries.txt";        
        }
    }




}
