using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;

namespace HtmlFromToken
{
    class clsHtmlDocType
    {
        // public const string HtmlDocTypeText01 = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">";
        // public const string HtmlDocTypeText01 = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD HTML 4.01 Frameset//EN "" ""http://www.w3.org/TR/html4/frameset.dtd"">";
        public const string HtmlDocTypeText01 = @"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01 Transitional//EN"" ""http://www.w3.org/TR/html4/loose.dtd"">";
        // public const string HtmlDocTypeText01 = "";
        protected string mFirstLine = "";
        public string FirstLine
        {
            get { return mFirstLine; }
            set { mFirstLine = value; }
        }

        public override string ToString()
        {
            string OutTxt = "";
            if (FirstLine.Length > 0)
                OutTxt = FirstLine + "\r\n";

            return OutTxt;
        }

        public clsHtmlDocType()
        {
            AssignStdDocType();
        }

        public void AssignStdDocType()
        {
            FirstLine = HtmlDocTypeText01;
        }
    }
}
