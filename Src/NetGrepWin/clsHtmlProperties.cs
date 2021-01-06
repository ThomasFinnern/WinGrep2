using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;

namespace HtmlFromToken
{
    public class clsHtmlProperties 
    {
        //        Dictionary<string, clsHtmlProperty> Attributes;

        /// <summary>
        /// Name, Value
        /// </summary>
        Dictionary<string, string> Properties = new Dictionary<string,string> ();

        public int Count
        {
            get { return Properties.Count; }
            // set { mStrOffText = value; }
        }

        public clsHtmlProperties() { }
        public clsHtmlProperties(string InProperties) 
        {
            AssignFromString(InProperties);
        }

        //clsHtmlProperty Property [string Name]
        //{
        //  get { return mName; }
        //    set { mName = value; }
        //  }   

        // Assign ....
        public void Add(string Name, string Value)
        {
            try
            {
                if (Name.Length == 0)
                    return;
                if (Properties.ContainsKey(Name))
                    Properties[Name] = Value;
                else
                {
                    Properties.Add(Name, Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Every property assignment within the given string .
        /// A blank is used as a Separation character 
        /// A 2=2 is used as assignment character
        /// </summary>
        /// <param name="InProperties"></param>
        public void AssignFromString(string InProperties)
        {
            try
            {
                // ToDo: nFill out;
                Properties = new Dictionary<string, string>();
                int NextIdx = 0;
                do
                {
                    clsHtmlProperty ActProperty = new clsHtmlProperty();

                    NextIdx = ActProperty.AssignFromString(InProperties, NextIdx);
                    if (ActProperty.Name.Length > 0)
                        Properties.Add(ActProperty.Name, ActProperty.Value);
                    // else
                    //    NextIdx = -1;
                } while (NextIdx > -1); // Next item possible ?
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return;
        }

        /// <summary>
        /// Every property assignment within the given string .
        /// A blank is used as a Separation character 
        /// A 2=2 is used as assignment character
        /// </summary>
        /// <param name="InProperties"></param>
        public void AddFromString(string InProperties)
        {
            try
            {
                int NextIdx = 0;
                do
                {
                    clsHtmlProperty ActProperty = new clsHtmlProperty();

                    NextIdx = ActProperty.AssignFromString(InProperties, NextIdx);
                    if (ActProperty.Name.Length > 0)
                        Properties.Add(ActProperty.Name, ActProperty.Value);
                    // else
                    //    NextIdx = -1;
                } while (NextIdx > -1); // Next item possible ?
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return;
        }

        /// <summary>
        /// detects 
        /// evry property assignment within the given string .
        /// A blank is used as a Separation character 
        /// A 2=2 is used as assignment character
        /// </summary>
        /// <param name="InProperties"></param>
        public void AssignFromString(string Content, ref int Idx)
        {
            try
            {
                int StartIdx = Idx;
                int EndIdx = Content.IndexOfAny(" >/".ToCharArray(), StartIdx +1);

                if (EndIdx > -1)
                {
                    string ActProperty = Content.Substring(StartIdx, EndIdx - StartIdx);
                    AddFromString(ActProperty);
                    Idx = EndIdx;

                    if (Content[EndIdx] == ' ')
                        AssignFromString(Content, ref Idx);
                }
                else
                {
                    Idx = Content.Length;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<string> Keys()
        {
            List<string> ActKeys = new List<string>();
            foreach (string PropertyName in Properties.Keys)
            {
                ActKeys.Add(PropertyName);
            }
            // List<string> ActKeys = Properties.Keys;

            return ActKeys;
        }

        // Assign ....
        public void Remove(string Name)
        {
            try
            {
                if (Name.Length == 0)
                    return;
                if (Properties.ContainsKey(Name))
                {
                    Properties.Remove (Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AppendHtml2String(StringBuilder ActString)
        {
            if(Properties.Count > 0)
            {
                foreach (KeyValuePair<string, string> Property in Properties)
                {
                    clsHtmlProperty ActProperty = new clsHtmlProperty(Property.Key, Property.Value);
                    ActProperty.AppendHtml2String (ActString);
            
                    // OutTxt = OutTxt + ActProperty.ToString();
                }
            }
        }

        public override string ToString()
        {
            string OutTxt = "";
            if (Properties.Count > 0)
            {            
                foreach (KeyValuePair<string, string> Property in Properties)
                {
                    clsHtmlProperty ActProperty = new clsHtmlProperty(Property.Key, Property.Value);
                    OutTxt = OutTxt + ActProperty.ToString ();
                }
            }
            return OutTxt;
        }

    }
}
