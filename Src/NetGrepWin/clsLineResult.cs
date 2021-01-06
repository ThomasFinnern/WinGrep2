using System;
using System.Collections.Generic;
using System.Text;

using ErrorCapture;
using HtmlFromToken;

namespace NetGrep
{
    public class clsLineResult
    {
        public string Line = "";
        public int LineIdx = -1;

        public long MatchedNbr
        {
            get
            {
                //long ActMatchNbr = 0;
                //foreach (clsLineResult ResultInfo in ResultInfos)
                //{
                //    ActMatchNbr += ResultInfo.ResultInfos.Count;
                //}
                //return ActMatchNbr;
                return ResultInfos.Count;
            }
        }

        public List<clsResultInfoInLine> ResultInfos = new List<clsResultInfoInLine>();

        public string ReplaceMatchWith(string ReplaceString)
        {
            string OutTxt = "";
            foreach (clsResultInfoInLine ResultInfo in ResultInfos)
            {
                OutTxt += ResultInfo.ToString ();
                // OutTxt += ResultInfo.ReplaceMatchWith(ReplaceString);
            }

            return OutTxt;
        }

        public string ToStringLine()
        {
            string OutTxt = "";
            OutTxt = OutTxt + LineIdx.ToString("D6");
            OutTxt = OutTxt + ": " + Line.Trim () + "\r\n";

            return (OutTxt);
        }

        public override string ToString()
        {
            string OutTxt = "";
            OutTxt = OutTxt  + "Line: " + Line + " \r\n";
            OutTxt = OutTxt + "Idx: " + LineIdx + " \r\n";

            foreach (clsResultInfoInLine ResultInfo in ResultInfos)
            {
                OutTxt = OutTxt + ResultInfo + "\r\n";
            }

            return (OutTxt);
        }
    }

}


