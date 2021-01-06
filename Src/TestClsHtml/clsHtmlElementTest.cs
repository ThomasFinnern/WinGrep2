using System;
using System.Collections.Generic;
using System.Text;

using HtmlFromToken;
using MainGlobal;

namespace TestClsHtml
{
    public class clsHtmlElementTest
    {
        public string ExpectetText = "";
        public string ResultingText = "";
        public const int MaxTestNbr = 6;

        public bool Test4Error(int TestIdx)
        {
            bool result = true; // in case of catch
            try
            {
                switch (TestIdx)
                {
                    case 0:
                        result = TestFromText4HtmElement("<0/>");
                        break;
                    case 1:
                        result = TestFromText4HtmElement("<1>1</1>");
                        break;
                    case 2:
                        result = TestFromText4HtmElement("<2></2>", "<2/>");
                        break;
                    case 3:
                        result = TestFromText4HtmElement("3:Plain text");
                        break;
                    case 4:
                        result = TestFromText4HtmElement("<4><1>1</1><2>2</2></4>", "<4>\r\n    <1>1</1>\r\n    <2>2</2>\r\n</4>");
                        break;
                    case 5:
                        result = TestFromText4HtmElement("Plain text");
                        break;
                    case 6:
                        result = TestFromText4HtmElement("Plain text");
                        break;
                }

                // AssignErrorText();
            }
            catch (Exception ex)
            {
                string OutTxt = ex.Message;
                // MessageBox.Show(OutTxt);
                Global.oDebugLog.MessageBox(OutTxt);
            }

            return result;
        }

        public bool TestFromText4HtmElement(string PlainText4Html)
        {
            return TestFromText4HtmElement(PlainText4Html, PlainText4Html);
        }

        public bool TestFromText4HtmElement (string PlainText4Html, string InExpectedText)
        {
            clsHtmlElement Test = new clsHtmlElement();

            Test.AssignFromString(PlainText4Html);

            // Assign expected text
            ExpectetText = InExpectedText;

            // Create resulting text
            ResultingText = Test.ToHtmlString ();

            // Check result
            return Check4Difference();
        }

        public bool Check4Difference()
        {

            return Check4Difference(ResultingText, ExpectetText);
        }

        public bool Check4Difference (string HtmlElementText, string ExpectetText)
        {
            return (HtmlElementText != ExpectetText);
        }


        //public string ResultingDiffView()
        //{
        //    return ResultingDiffView(ResultingText, ExpectetText);
        //}

        //public string ResultingDiffView(string HtmlElementText, string ExpextetText)
        //{






        //}
    }
}
