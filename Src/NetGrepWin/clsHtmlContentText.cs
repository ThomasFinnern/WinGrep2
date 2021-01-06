using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlFromToken
{
    class clsHtmlContentText : clsHtmlContentBase
    {
        //private string Text;
/*
erstes blank 
    String.fromCharCode(160) liefert das numerische Entity-Aequivalent &#160; fuer ein non-breaking space  . Fuege dieses am Anfang des Textknotens ein.
&nbsp;
*/

        public string Text = "";

        //public override void AssignFromString(string Content)
        //{
        //    int Idx = 0;
        //    AssignFromString(Content, ref Idx);
        //}

        public override void AssignFromString(string Content, ref int Idx)
        {
            int StartIdx = Idx;
            int EndIdx = Idx;

            EndIdx = Content.IndexOf('<', Idx);
            if (EndIdx > -1)
            {
                Text = Content.Substring(StartIdx, EndIdx - StartIdx);
                Idx = EndIdx;
            }
            else
            {
                EndIdx = Content.Length;
                Text = Content.Substring(StartIdx, EndIdx - StartIdx);

                Idx = Content.Length;
            }
        }

        public override bool bHasSubContent
        {
            get { return false; }
        }

        public void AssignText(string InText)
        {
            Text = InText;
        }

        //public override List<string> ToStringAsLines()
        //{
        //    List<string> Result = new List<string>();
        //    Result.Add(Text);

        //    return Result;
        //}

        public override bool DoesStartWithHtmlToken()
        {
            bool bDoesStartWithHtmlToken = false;

            //if (Contents.Count > 0)
            //{
            //    if (!Contents[0] is clsHtmlContentText)
            //        bDoesStartWithHtmlToken = true;
            //}

            return bDoesStartWithHtmlToken;
        }


                /// <summary>
        /// Add content to the prepared string
        /// The calling function must look for the Pre text of this Element. 
        /// The pre text of containing lines will be cared in this function
        /// </summary>
        /// <param name="ActString"></param>
        /// <param name="ActPreText"></param>
        public override void AppendHtml2String(StringBuilder ActString, string ActPreText)
        {
            ActString.Append (Text);
        }

        public override string ToString()
        {
            return Text;
        }

    }
}
