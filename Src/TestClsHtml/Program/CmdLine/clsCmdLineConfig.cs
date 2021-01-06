using System;
using System.Collections.Generic;
using System.Text;

namespace CmdLine2005
{
    class clsCmdLineConfig
    {
        //---------------------------------------------------------------------------------------------
        // Config variables 
        //---------------------------------------------------------------------------------------------

        #region Class properties

        public bool bNoAutoExit;
        public bool bCloseAfterCommandsDone;
        public bool bDoCheckClasses;

        public bool bDoOpenLastUsedSearch;
        public bool bDontOpenLastUsedSearch;
        public bool bDoLoadLastOpenSearchesOnStart;
        public bool bDontLoadLastOpenSearchesOnStart;

        #endregion class properties

        //---------------------------------------------------------------------------------------------
        // Standard values
        //---------------------------------------------------------------------------------------------

        public void AssignStandardValues()
        {
            // mCfgVersion = "0.001";
            
            bNoAutoExit = false;
            bCloseAfterCommandsDone = false;
            bDoCheckClasses = false;
            //bDoOpenLastUsedFile = false;
            //bDontOpenLastUsedFile = false;
        }

        //---------------------------------------------------------------------------------------------
        // Config class construction
        //---------------------------------------------------------------------------------------------

        public clsCmdLineConfig()
        {
            AssignStandardValues();
        }
    }
}
