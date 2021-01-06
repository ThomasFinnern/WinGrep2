using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;

namespace HtmlFromToken
{
    public class clsHtmlBaseLib
    {
        public const string StartWhiteSpaceText = @"    ";

        //public static void WrapWithStarter(ref List<String> HtmlLines)
        //{
        //    foreach (string HtmlLine in HtmlLines)
        //        HtmlLine = StartWhiteSpaceText + HtmlLine;
        //}

        public static List<String> WrapWithStartandEndToken(string StartToken, List<String> HtmlLines, string EndToken)
        {
            List<String> OutLines = new List<string>();

            OutLines.Add(StartToken);
            foreach (string HtmlLine in HtmlLines)
            {
                OutLines.Add(StartWhiteSpaceText + HtmlLine);
            }

            OutLines.Add(EndToken);

            return OutLines;
        }

        public static List<String> AddStartingWhiteSpaceText2List(List<String> HtmlLines)
        {
            List<String> OutLines = new List<string>();

            foreach (string HtmlLine in HtmlLines)
            {
                OutLines.Add(StartWhiteSpaceText + HtmlLine);
            }

            return OutLines;
        }




    }
}
