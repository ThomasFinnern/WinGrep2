using System;
using System.Collections.Generic;
using System.Text;

namespace NetGrep
{
    public class clsResultInfoInLine
    {
        public int StartIdx;
        public int Length;

        public override string ToString()
        {
            string OutTxt = "";

            OutTxt = OutTxt + "StartIdx: " + StartIdx + " " + "\r\n";
            OutTxt = OutTxt + "Size: " + Length + " " + "\r\n";

            return (OutTxt);
        }
    }
}
