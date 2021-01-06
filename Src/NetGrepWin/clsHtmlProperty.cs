using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;

namespace HtmlFromToken
{
    public class clsHtmlProperty
    {
        public string mName = "";
        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }

        public string mValue = "";
        public string Value
        {
            get { return mValue; }
            set { mValue = value; }
        }

        public clsHtmlProperty()
        {
            ;        
        
        }

        public clsHtmlProperty(string Name)
        {
            this.mName = Name;                        
        }

        public clsHtmlProperty(string Name, string Value)
        {
            this.mName = Name;
            this.mValue = Value;                        
        }

        /// <summary>
        /// will take 
        /// </summary>
        /// <param name="InProperty"></param>
        public int AssignFromString(string InProperty, int NextIdx)
        {
            int FoundIdx = -1;
            //bool bHasNextProperty;
         
            if (InProperty [NextIdx] == (' '))
                NextIdx ++;
                
            // On last character ?
            if (NextIdx >= InProperty.Length)
                return -1;

            FoundIdx = InProperty.IndexOf ("=", NextIdx);
            if (FoundIdx > -1)
            {
                int StartIdx = 0;
                int StopIdx = 0;
                int EquityIdx = FoundIdx;
                Name = InProperty.Substring (NextIdx, FoundIdx - NextIdx);
                
                StartIdx = FoundIdx + 1;
                char apostrophe = InProperty[StartIdx];
                // Value in apostrophes ?
                if (apostrophe == '\"' || apostrophe == '\'')
                {
                    StartIdx ++;
                    StopIdx = InProperty.IndexOf (apostrophe, StartIdx);
                    if (StartIdx < StopIdx)
                    {
                        Value = InProperty.Substring (StartIdx, StopIdx - StartIdx);
                        FoundIdx = StopIdx +1;    
                        if (FoundIdx >= InProperty.Length)
                            FoundIdx = -1;
                    }
                    else
                        FoundIdx = -1;
                }
                else               
                {
                    // find blank or end of string
                    StopIdx = InProperty.IndexOf (" ", StartIdx);
                    if (StopIdx < 0)
                        StopIdx = InProperty.Length;

                
                    if (StartIdx < StopIdx)
                    {
                        Value = InProperty.Substring (StartIdx, StopIdx - StartIdx);
                        FoundIdx = StopIdx +1;    
                        if (FoundIdx >= InProperty.Length)
                            FoundIdx = -1;
                    }
                    else
                        FoundIdx = -1;
                }
            }

            return FoundIdx;
        }

        public void AppendHtml2String(StringBuilder ActString)
        {
            if (Name.Length > 0)
            {
                // OutTxt = OutTxt + " " + Name + @"=""" + Value + @"""";
                ActString.Append(" ");
                ActString.Append(Name);
                ActString.Append(@"=""");
                ActString.Append(Value);
                ActString.Append(@"""");
            }
        }
   
        public override string ToString()
        { 
            string OutTxt = "";
            if (Name.Length > 0)
                OutTxt = OutTxt + " " + Name + @"=""" + Value + @"""";

 	        return OutTxt;
        }
    }
}
