using System;
using System.Collections.Generic;
using System.Text;

namespace NetGrep
{
    class clsSearchPropertiesTestRegExSearch : clsSearchProperties
    {
        //---------------------------------------------------------------------------------------------
        // Config variables 
        //---------------------------------------------------------------------------------------------

        #region Class properties



        #endregion class properties

        //---------------------------------------------------------------------------------------------
        // Config getter and setter
        //---------------------------------------------------------------------------------------------

        //public string xSearchString
        //{
        //    //get { return mSearchString; }
        //    //set { mSearchString = value; }
        //}

        //---------------------------------------------------------------------------------------------
        // Standard values
        //---------------------------------------------------------------------------------------------

        public override void AssignStandardValues()
        {
            base.AssignStandardValues();
            
        
            
        }

        //---------------------------------------------------------------------------------------------
        // Config class construction
        //---------------------------------------------------------------------------------------------

        public clsSearchPropertiesTestRegExSearch()
        {
            CfgFileName = "SearchPropertiesTestRegExSearch.cfg";
            AssignStandardValues();
        }

        //---------------------------------------------------------------------------------------------
        // accessor functions
        //---------------------------------------------------------------------------------------------

        public override string ToString()
        {
            string OutTxt = base.ToString ();



            return OutTxt;
        }
    }
}
