using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;

namespace HtmlFromToken
{
    public abstract class clsHtmlContentBase
    {
        //bool mbHasSubContent = false;
        public string Name;
        protected static string StandardPreText = "    ";

        public abstract bool bHasSubContent {get;}
        //public virtual bool bHasSubContent
        //{
        //    get {
        //        MessageBox.Show("!!! bHasSubContent: Function not dervied !!!");
        //        return mbHasSubContent;
        //    }
        //}

        //public abstract bool bPreventsNewLines;
        //{
        //    get;
        //}

        //public abstract void AssignFromString(string Content);
        public virtual void AssignFromString(string Content)
        { // ToDo: checkout why this is not possible with abstract
            int Idx = 0;
            AssignFromString(Content, ref Idx);
        }

        public abstract void AssignFromString(string Content, ref int Idx);
        //public virtual void AssignFromString(string Content, ref int Idx) 
        //{
        //    MessageBox.Show("!!! AssignFromString: Function not dervied !!!");
        //}

        //public abstract List<string> ToStringAsLines();
        //public virtual List<string> ToStringAsLines()
        //{
        //    MessageBox.Show("!!! ToStringAsLines: Function not dervied !!!");
        //    List<string> Dummy = new List<string>();
        //    return Dummy;
        //} 
        public abstract void AppendHtml2String(StringBuilder ActString, string ActPreText);

        public override string ToString()
        {
            string OutTxt = "";
            
            OutTxt = "Name: " + Name;

            return OutTxt;
        }

        public abstract bool DoesStartWithHtmlToken();
    }
}
