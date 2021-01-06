using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;
using MainGlobal;

namespace HtmlFromToken
{
    public class clsHtmlElement : clsHtmlContentBase // vererbt von content, damit es in den eigenen content gehängt werden kann
    {
        public clsHtmlProperties Properties = new clsHtmlProperties ();  // ToDo: Use own Class with intenal List
        private List<clsHtmlContentBase> Contents = new List<clsHtmlContentBase>();
        private clsHtmlContentText PrePlainText = new clsHtmlContentText();

        /// <summary>
        /// Tells with true that more than one line is needed to display this
        /// </summary>
        public override bool bHasSubContent
        {
            get {
                bool bFoundsubContent = false;

                if (Contents.Count > 1)
                    bFoundsubContent = true;
                else
                {
                    if (Contents.Count == 1)
                    {
                        if (Contents[0] is clsHtmlElement)
                        {
                            //clsHtmlElement SubElement = (clsHtmlElement) Contents[0];
                            //if(SubElement.Contents.Count !=0) //not element type of <name/>
                            //    bFoundsubContent = true;
                            bFoundsubContent = true;
                        }
                    }
                }
                return bFoundsubContent;
            }
        }

        //public List<string> ContentLines
        //{
        //    get
        //    {
        //        List<string> OutContentLines = new List<string>();

        //        if (Contents.Count > 0)
        //        {
        //            foreach (clsHtmlContentBase Content in Contents)
        //            {
        //                OutContentLines.AddRange(Content.ToStringAsLines());
        //            }
        //            return OutContentLines;
        //        }
        //        else
        //            return null;
        //    }
        //    // set { mStrOffText = value; }
        //}

        public clsHtmlElement()
        {
            Name = "Uninitialized Element";
        }

        public clsHtmlElement(string InName)
        {
            Name = InName;
        }

        public clsHtmlElement(string InName, clsHtmlProperties InProperties)
        {
            Name = InName;
            Properties = InProperties;
        }

        public clsHtmlElement(string InName, string InContent)
        {
            Name = InName;

            int Idx = 0;
            ExtractContent(InContent, ref Idx);
        }

        public clsHtmlElement(string InName, string InContent, clsHtmlProperties InProperties)
        {
            Name = InName;
            Properties = InProperties;

            int Idx = 0;
            ExtractContent(InContent, ref Idx);
        }

        //public clsHtmlElement(string InName, string InProperties, List<string> InContentLines)
        //{
        //    Name = InName;
        //    Properties.AssignFromString (InProperties);
        //    TextLines = InContentLines;
        //}

        //public clsHtmlElement(string InName, string InProperties, clsHtmlElement ContentElement)
        //{
        //    Name = InName;
        //    Properties.AssignFromString (InProperties);
        //    SubElementList = new List<clsHtmlElement>();
        //    SubElementList.Add(ContentElement);
        //}

        //public clsHtmlElement(string InName, string InProperties, List<clsHtmlElement> InContentElement)
        //{
        //    Name = InName;
        //    Properties.AssignFromString (InProperties);
        //    SubElementList = InContentElement;
        //}

        //public void AddTextPart(string Content)
        //{
        //    if (TextLines == null)
        //    {
        //        TextLines = new List<string>();
        //        TextLines.Add(Content);
        //    }
        //    else
        //    { 
        //        TextLines [TextLines.Count -1] += Content;
        //    }
        //}

        /// <summary>
        /// Add text part (no further html will be decoded in line)
        /// </summary>
        /// <param name="Content"></param>
        public void AddText(string Content)
        {
            clsHtmlContentText NewText = new clsHtmlContentText ();
            Contents.Add (NewText);
            NewText.AssignText(Content);       
        }

        public void AddElement(clsHtmlElement NewElement)
        {
            Contents.Add(NewElement);          
        }

        /// <summary>
        /// Creates this element from string (and sub elements)
        /// </summary>
        /// <param name="Content"></param>
        /// <param name="Idx"></param>
        public override void AssignFromString(string Content, ref int Idx)
        {
            try
            {
                //AssignFromString(Content, ref Idx);
                Properties = new clsHtmlProperties();
                Contents = new List<clsHtmlContentBase>();
                PrePlainText = new clsHtmlContentText();

                // Has "pre" text in front of "<"
                if (Content[Idx] != '<')
                    // read all plain text in front of ...
                    PrePlainText.AssignFromString(Content, ref Idx);

                ExtractElementName(Content, ref Idx);

                if (Idx < Content.Length)
                {
                    if (Content[Idx] == ' ')
                        Idx++;

                    // Property ?
                    if (Content[Idx] != '/' && Content[Idx] != '>')
                    {
                        Properties.AssignFromString(Content, ref Idx);
                    }

                    switch (Content[Idx])
                    {
                        case '/':
                            Idx += 2;
                            break;

                        case '>':
                            Idx += 1;
                            ExtractContent(Content, ref Idx);

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        /// <summary>
        /// Assigns content to element. String contains only Text
        /// </summary>
        /// <param name="Content"></param>
        public void AssignContent(string InContent)
        {
            int Idx = 0;

            Contents.Clear();
            ExtractContent(InContent, ref Idx);

            return;
        }


        public void AssignContent(string InContent, ref int Idx)
        {
            Contents.Clear();
            ExtractContent(InContent, ref Idx);

            return;
        }


        /// <summary>
        /// Add further content to element. 
        /// </summary>
        /// <param name="Content"></param>
        public void AddContent(string InContent)
        {
            int Idx = 0;

            ExtractContent(InContent, ref Idx);

            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Content"></param>
        /// <param name="Idx">Will point to the next cahracter after name</param>
        /// <returns>Found name</returns>
        private void ExtractElementName(string Content, ref int Idx)
        {
            int EndIdx;
            int StartIdx = Content.IndexOf('<', Idx);
            if (StartIdx < 0)
            {
                Idx = Content.Length;
            }
            else
            {
                StartIdx++;
                EndIdx = Content.IndexOfAny(" >/".ToCharArray(), StartIdx); // char[] { 'A', 'B', 'C' }));
                if (EndIdx < 0)
                {
                    Idx = Content.Length;
                }
                else
                {
                    Name = Content.Substring(StartIdx, EndIdx - StartIdx);
                    Idx = EndIdx;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Content"></param>
        /// <param name="Idx">Will point to the next character after name</param>
        /// <returns>Found name</returns>
        private void ExtractContent(string Content, ref int Idx)
        {
            bool IsEndOfHtmlElement = false;
            do
            {
                if (Content [Idx] != '<')
                {
                    clsHtmlContentText NewText = new clsHtmlContentText ();
                    Contents.Add (NewText);
                    NewText.AssignFromString (Content, ref Idx);
                }
                else
                {
                    int NextIdx = Idx + 1;
                    if (Content [NextIdx] == '/') // End of actual element ?
                    {
                        NextIdx++;
                        Idx++; // 110721 added

                        string TestNext = Content.Substring (NextIdx, Name.Length);
                        if (Name.CompareTo(TestNext) == 0)
                        {
                            NextIdx = NextIdx + Name.Length;
                            if (Content[NextIdx] == '>')
                            {
                                Idx = NextIdx + 1;

                                IsEndOfHtmlElement = true;
                            }
                        }
                        else
                        {
                            // 110721 not increasing IDX found
                        }
                    }
                    else
                    {
                        // Else begin of next html Element                    
                        clsHtmlElement NewElement = new clsHtmlElement ();
                        Contents.Add (NewElement);
                        NewElement.AssignFromString(Content, ref Idx);
                    }
                }
            }
            while (Idx < Content.Length && !IsEndOfHtmlElement);
        }

        bool bIsOneLineType()
        {
            bool bHasOnlyOneElement = true;
            //if (Contents.Count > 1)
            //{
            //    bHasOnlyOneElement = false;
            //}

            //if (Contents[0].bHasSubContent)
            //{
            //    bHasOnlyOneElement = false;
            //}

            bHasOnlyOneElement = !bHasSubContent;

            return bHasOnlyOneElement;
        }

        //public override List<string> ToStringAsLines()
        //{
        //    List<String> OutLines = new List<string>();

        //    string OutTxt = "";

        //    string PropertiesText = "";

            
        //    if (Properties != null)
        //    {
        //        if (Properties.Count > 0)
        //            PropertiesText = Properties.ToString ();
        //    }
        //    else
        //        PropertiesText = "";

        //    if (Contents.Count < 1)
        //    {
        //        OutTxt = OutTxt + @"<" + Name + PropertiesText + "/>";
        //        OutLines.Add(OutTxt);
        //    }
        //    else
        //    {
        //        if (bIsOneLineType())
        //        {
        //            OutTxt = OutTxt + @"<" + Name + PropertiesText + ">";
        //            OutTxt = OutTxt + Contents[0].ToString ();
        //            OutTxt = OutTxt + @"</" + Name + ">"; // +"\r\n";

        //            OutLines.Add(OutTxt);
        //        }
        //        else
        //        {
        //            string StartLine = @"<" + Name + PropertiesText + ">";
        //            string EndLine = @"</" + Name + ">";

        //            OutLines.Add(StartLine);

        //            // More than one line ?
        //            if (bHasSubContent)
        //            {
        //                OutLines.AddRange (clsHtmlBaseLib.AddStartingWhiteSpaceText2List(ContentLines));
        //            }
        //            else
        //                OutLines.AddRange(ContentLines);

        //            OutLines.Add(EndLine);
        //        }
        //    }

        //    return OutLines;
        //}

        /// <summary>
        /// Add content to the prepared string
        /// The calling function must look for the Pre text of this Element. 
        /// The pre text of containing lines will be cared in this function
        /// </summary>
        /// <param name="ActString"></param>
        /// <param name="ActPreText"></param>
        public override void AppendHtml2String(StringBuilder ActString, string ActPreText)
        {
            try
            {
                if (PrePlainText.Text.Length > 0)
                {
                    ActString.Append(PrePlainText.ToString());
                }
                else
                {
                    ActString.Append(@"<");
                    ActString.Append(Name);
                    if (Properties != null)
                        Properties.AppendHtml2String(ActString);

                    if (Contents.Count > 0)
                    {
                        if (bIsOneLineType())
                        {
                            ActString.Append(@">");
                            Contents[0].AppendHtml2String(ActString, ActPreText);
                            ActString.Append(@"</");
                            ActString.Append(Name);
                            ActString.Append(@">");
                        }
                        else
                        {
                            // More than one line ?

                            //string StartLine = @"<" + Name + PropertiesText + ">";
                            //string EndLine = @"</" + Name + ">";
                            ActString.Append(@">");
                            //if (Contents[0].DoesStartWithHtmlToken())
                            //ActString.Append("\r\n");
                            string SubPreText = "\r\n" + ActPreText + StandardPreText;
                            bool bLastContentWasText = false;
                            bool bActContentIsText = false;
                            foreach (clsHtmlContentBase Content in Contents)
                            {
                                bActContentIsText = Content.GetType().Name == "clsHtmlContentText";
                                if (!bLastContentWasText && !bActContentIsText)
                                    ActString.Append(SubPreText);
                                Content.AppendHtml2String(ActString, ActPreText + StandardPreText); // SubPreText);
                                bLastContentWasText = bActContentIsText;
                            }

                            ActString.Append("\r\n");
                            ActString.Append(ActPreText);
                            ActString.Append(@"</");
                            ActString.Append(Name);
                            ActString.Append(@">");
                        }
                    }
                    else
                    {
                        // ActString.Append(@"/>" + "\r\n"); 
                        ActString.Append(@"/>"); // <Name/>
                    }
                }
            }
            catch (Exception ex)
            {
                string OutTxt = ex.Message;
                // MessageBox.Show(OutTxt);
                Global.oDebugLog.MessageBox(OutTxt);
            }
        }

        public override bool DoesStartWithHtmlToken()
        {
            bool bDoesStartWithHtmlToken = false;

            if (Contents.Count > 0)
            {
                if (!(Contents[0] is clsHtmlContentText))
                    bDoesStartWithHtmlToken = true;
                else
                    bDoesStartWithHtmlToken = false;
            }

            return bDoesStartWithHtmlToken;
        }

        /// <summary>
        /// Use as anchor, not to concatenate strings. Includes all sub html elements
        /// </summary>
        /// <returns></returns>
        public string ToHtmlString()
        {
            StringBuilder ActString = new StringBuilder();
            AppendHtml2String(ActString, "");
            return ActString.ToString();
        }

        /// <summary>
        /// Only for internal use. Otherwise use ToHtmlString
        /// </summary>
        /// <returns></returns>
        public new virtual string ToString()
        {
            string OutTxt = "";

            if (PrePlainText.Text.Length > 0)
            {
                OutTxt += PrePlainText.ToString();
            }
            else
            {
                OutTxt += "<" + Name;

                if (Properties.Count > 0)
                    OutTxt += " Properties.Count: " + Properties.Count;
                if (Contents.Count > 0)
                    OutTxt += " Contents.Count: " + Contents.Count;

                if (bHasSubContent)
                    OutTxt += " Contains Subcontent: true";

                OutTxt += ">";
            }

 	        return OutTxt;
        }
    }
}
