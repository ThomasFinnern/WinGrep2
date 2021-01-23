using System;
using System.Collections.Generic;
using System.Text;

using System.Text.RegularExpressions;
using System.Windows.Forms;
using ErrorCapture;

namespace NetGrep
{
    public class clsSearchRegularExpression
    {
        //public Regex RegExSearch = null; // new Regex(".*");
        //public RegexOptions RegexOptions = new RegexOptions();

        //public clsSearchRegularExpression ()
        //{
        //    AssignStandardValues();
        //}

        //public clsSearchRegularExpression (string Searchstring, clsSearchProperties InGrepProperties)
        //{
        //    AssignStandardValues();
        //    GrepProperties = InGrepProperties;
        //    CreateSearchRegEx (Searchstring);
        //}

        //void AssignStandardValues()
        //{
        //    ;
        //}

        public static Regex CreateSearchRegEx(clsSearchProperties GrepProperties)
        {
            Regex RegExSearch = null;

            try
            {
                //--------------------------------------------------------------------------------------
                // Prepare regular expression search string
                //--------------------------------------------------------------------------------------

                string SearchString = GrepProperties.SearchString;

                if (!GrepProperties.bUseRegularExpression)
                {
                    SearchString = Regex.Escape(SearchString);                   
                }


                // clsFileResults String
                if (GrepProperties.bWholeWordsOnly)
                {
                    //* Use (?:^|\W) instead of \b at the beginning of the expression.
                    //  For example, (?:^|\W)\.NET\b
                    //  This will match either the start-of-string or a non-word character before the . character.
                    //* Use (?:\W|$) instead of \b at the end of the expression.
                    //  For example, \bC#(?:\W|$)
                    //  This will match either a non-word character or the end-of-string after the # character.

                    //SearchString = @"(?:^|(/W?))" + SearchString + @"(?:^|(/W?))";
                    SearchString = @"\b" + SearchString + @"\b";
                }

                RegexOptions RegexOptions = new RegexOptions();
                if (GrepProperties.bMatchCase)
                    RegexOptions &= ~RegexOptions.IgnoreCase; // löschen
                else
                    RegexOptions |= RegexOptions.IgnoreCase;  // setzen

                // Test regular expession for errors
                try
                {
                    RegExSearch = new Regex(SearchString, RegexOptions);
                }
                catch (Exception Ex)
                {
                    string OutTxt = "Regular expession creation (string) failed for: '"
                        + SearchString + "' \r\n" + Ex.Message;
                    MessageBox.Show(OutTxt);

                    // clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                    // ErrCapture.ShowExeption();

                    RegExSearch = null;
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }


            return RegExSearch;
        }
    }
}
