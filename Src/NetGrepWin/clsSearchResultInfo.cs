using System;
using System.Collections.Generic;
using System.Text;

using ErrorCapture;
using HtmlFromToken;

namespace NetGrep
{
    [Serializable]
    public class clsSearchResultInfo
    {

        #region Class properties
        //public string SearchString;
        //public string SearchFileType;
        public clsSearchProperties SearchProperties;
        public long TokenMatchedNbr;
        public long FilesMatchedNbr;
        public long FileSearchedNbr;
        public long FilesSkippedNbr;
        
        #endregion class properties

        public clsSearchResultInfo(clsSearchProperties InSearchProperties)
        {
            SearchProperties = InSearchProperties;
        }

        public clsSearchResultInfo()
        {
            SearchProperties = new clsSearchProperties ();
        }

        /// <summary>
        /// Second part of whole info
        /// </summary>
        /// <returns></returns>
        public string ToString4Html()
        {
            string OutTxt = "";
            //clsHtmlElement Span = clsHtmlStdElements.SPAN();

            //OutTxt = OutTxt + "Searched string: '" + SearchProperties.SearchString + "'";
            OutTxt = OutTxt + " in files: '" + SearchProperties.SearchFileTypesAsString + "'.";
            OutTxt = OutTxt + " Found " + TokenMatchedNbr + " matches";
            OutTxt = OutTxt + " in " + FilesMatchedNbr + " files";
            OutTxt = OutTxt + " from " + FileSearchedNbr + " files searched";
            // OutTxt = OutTxt + ". Skipped " + FilesSkippedNbr + " files";
            OutTxt = OutTxt + " in folders: '" + SearchProperties.SearchFoldersAsString + "'.";

            //Span.AddText(OutTxt);

            //return Span;
            return OutTxt;
        }

        public override string ToString()
        { 
            string OutTxt = "";

            OutTxt = OutTxt + "Searched string: '" + SearchProperties.SearchString + "'";
            OutTxt = OutTxt + " in files: '" + SearchProperties.SearchFileTypesAsString + "'";
            OutTxt = OutTxt + " in folders '" + SearchProperties.SearchFoldersAsString + "'.";
            OutTxt = OutTxt + " Found " + TokenMatchedNbr + " matches";
            OutTxt = OutTxt + " in " + FilesMatchedNbr + " files";
            OutTxt = OutTxt + " from " + FileSearchedNbr + " files searched";
            OutTxt = OutTxt + ". Skipped " + FilesSkippedNbr + " files";
            return OutTxt;
        }
    }
}
