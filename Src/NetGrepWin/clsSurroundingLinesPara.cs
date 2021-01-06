using System;
using System.Collections.Generic;
using System.Text;

namespace NetGrep
{
    public class clsSurroundingLinesPara
    {
        public long LineNbrPreviousToMatch;
        public long LineNbrFollowingMatch;

        public clsSurroundingLinesPara()
        {
            AssignStandardValues();
        }

        public clsSurroundingLinesPara(clsSurroundingLinesPara Orig)
        {
            AssignStandardValues();

            this.LineNbrPreviousToMatch = Orig.LineNbrPreviousToMatch;
            this.LineNbrFollowingMatch = Orig.LineNbrFollowingMatch;
        }

        public void AssignStandardValues()
        {
            LineNbrPreviousToMatch = 0;
            LineNbrFollowingMatch = 0;
        }

        public clsSurroundingLinesPara Clone()
        {
            clsSurroundingLinesPara NewClass = new clsSurroundingLinesPara(this);
            return NewClass;
        }

        public override string ToString()
        {
            string OutTxt = "";

            OutTxt = OutTxt + "PreviousToMatch: " + LineNbrPreviousToMatch.ToString() +"\r\n";
            OutTxt = OutTxt + "FollowingMatch: " + LineNbrFollowingMatch.ToString() + "\r\n";

            return OutTxt;
        }
    }
}
