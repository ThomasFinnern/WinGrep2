using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;

namespace CmdLine2005
{
    public class clsCmdLineConfig
    {
        //---------------------------------------------------------------------------------------------
        // Config variables 
        //---------------------------------------------------------------------------------------------

        #region Class properties

        public bool bNoAutoExit;
        public bool bCloseAfterCommandsDone;
//        public bool bDoCheckClasses;

        public bool bDoOpenLastUsedSearch;
        public bool bDontOpenLastUsedSearch;
        public bool bDoLoadLastOpenSearchesOnStart;
        public bool bDontLoadLastOpenSearchesOnStart;

        public List<Form> frmSearchResultViews;

        #endregion class properties

        //---------------------------------------------------------------------------------------------
        // Standard values
        //---------------------------------------------------------------------------------------------

        public void AssignStandardValues()
        {
            // mCfgVersion = "0.001";
            
            bNoAutoExit = false;
            bCloseAfterCommandsDone = false;
            // bDoCheckClasses = false;
            bDoOpenLastUsedSearch = false;
            bDontOpenLastUsedSearch = false;
            bDoLoadLastOpenSearchesOnStart = false;
            bDontLoadLastOpenSearchesOnStart = false;

            frmSearchResultViews = new List<Form>();
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
