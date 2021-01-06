using System;
using System.Collections.Generic;
using System.Text;

using ConfigBase;

namespace NetGrep
{
    
    /// <summary>
    /// Keeps the properties and the resulting html pages for saving and loading
    /// </summary>
    [Serializable]
    public class clsDataOfOneSearch : clsConfigSpezialBase<clsDataOfOneSearch> 
    {
        //---------------------------------------------------------------------------------------------
        // Config variables 
        //---------------------------------------------------------------------------------------------

        #region Class properties

        // base: protected string mCfgVersion;
        /// <summary>
        /// Fixed token (they will not be ordered and be kept even if not used for a long time)
        /// </summary>
        protected List<string> mFixedTokenList = new List<string>();

        clsSearchProperties mSearchProperties;
        clsSearchExecute mSearchResults;



        #endregion Class properties

        //---------------------------------------------------------------------------------------------
        // Config getter and setter
        //---------------------------------------------------------------------------------------------

        public clsSearchProperties SearchProperties
        {
            get { return mSearchProperties; }
            set { mSearchProperties = value; }
        }

        public clsSearchExecute SearchResults
        {
            get { return mSearchResults; }
            set { mSearchResults = value; }
        }

        //---------------------------------------------------------------------------------------------
        // Standard values
        //---------------------------------------------------------------------------------------------

        public override void AssignStandardValues()
        {
            mCfgVersion = "0.001";
// if filename empty assign standar one
            mSearchProperties = new clsSearchProperties ();            
        }


        public static void AssignFileName(string FileName)
        {
            CfgFileName = FileName;
        }

        //---------------------------------------------------------------------------------------------
        // Config class construction
        //---------------------------------------------------------------------------------------------

        public clsDataOfOneSearch()
        {
            AssignStandardValues();
        }

        //---------------------------------------------------------------------------------------------
        // Accessor functions
        //---------------------------------------------------------------------------------------------



    }
}
