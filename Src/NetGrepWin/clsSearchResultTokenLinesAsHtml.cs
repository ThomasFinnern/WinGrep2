using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Windows.Forms;
using ErrorCapture;
using MainGlobal;
using HtmlFromToken;
using AppPaths;

// ToDo: Use seperate classes for display of separate parts of used objects
namespace NetGrep
{
    public class clsSearchResultTokenLinesAsHtml
    {
        public List<clsFileResults> Files2LineResults = new List<clsFileResults>();
        private clsSearchViewProperties SearchViewProperties;

        public clsSearchResultTokenLinesAsHtml(//clsSearchResultInfo InSearchResultInfo,
            List<clsFileResults> InFiles2LineResults) //, string InSearchString)
        { 
//            SearchResultInfo = InSearchResultInfo;
            Files2LineResults = InFiles2LineResults;
//            SearchString = InSearchString;
        }


        // public string ToStringLinesHtml()
        public string FoundFilesWithTokenLinesHtmlDocument(clsSurroundingLinesPara UseLineNbrsBeforeAfter, 
            clsSearchViewProperties InSearchViewProperties)
        {
            string OutTxt = "";
            SearchViewProperties = InSearchViewProperties;

            clsHtmlPage HtmlPage = new clsHtmlPage();

            clsHtmlElement Head = clsHtmlStdElements.HEAD();
            clsHtmlElement Link = clsHtmlStdElements.LINK();

            string LinkPath;
            //LinkPath = Path.Combine(Environment.GetEnvironmentVariable("APPDATA"), Application.ProductName);
            LinkPath = Path.Combine(clsAppPaths.UserCfgPathName.PathName, @"TokenList.css");
            Link.Properties.AssignFromString(@"rel=""stylesheet"" type=""text/css"" href=""file:///" + LinkPath + @"""");
            Head.AddElement(Link);

            clsHtmlElement Title = clsHtmlStdElements.TITLE("Found files with lines containing token");
            Head.AddElement(Title);
    
            HtmlPage.Html.AddElement(Head);

            clsHtmlElement Body = clsHtmlStdElements.BODY();
            HtmlPage.Html.AddElement(Body);

            // Inside Header with Span and two Header h1 h2
            clsHtmlElement Span = null;
            if (SearchViewProperties.bDoShowTitle)
            {
                Span = clsHtmlStdElements.SPAN();
                Span.Properties.AssignFromString(" class=HeaderFoundToken"); // size =100% needed
                // Table.Properties.AssignFromString(" BORDER=0 cellspacing=0 cellpadding=3 WIDTH=100%");
                clsHtmlElement H1 = clsHtmlStdElements.H1("Token found inside files");
                Span.AddElement(H1);
                //clsHtmlElement H2 = clsHtmlStdElements.H2(SearchResultInfo.ToString4Html());
                //Span.AddElement(H2);

                Body.AddElement(Span);
                // Body.AddElement(clsHtmlStdElements.BR());

                Body.AddElement(clsHtmlStdElements.HR());
            }

            //--- Insert FileInfos ---------------------------------------------------------------------
            if (Files2LineResults.Count < 1)
            {
                // OutTxt = OutTxt + clsHtmlWrapper.WrapLineNumber("Found no matches for '" 
                //    + clsHtmlEncode.HtmlEncode(SearchString) + "'") + clsHtmlWrapper.CrLf();
                Body.AddElement(clsHtmlStdElements.BR());

                Span = clsHtmlStdElements.SPAN();
                Span.AddText(@"Found no matches");
                Span.Properties.AssignFromString(@"class=""NotFound""");
                Body.AddElement(Span);
                Body.AddElement(clsHtmlStdElements.BR());
            }
            else
            {
                // List of complete files
                foreach (clsHtmlElement ActElement in FilesWithNamesAndLinesAsHtml(UseLineNbrsBeforeAfter))
                    Body.AddElement(ActElement);
            }

            Body.AddElement(clsHtmlStdElements.HR());

            OutTxt = HtmlPage.DocumentString();
            return (OutTxt);
        }

        public List<clsHtmlElement> FilesWithNamesAndLinesAsHtml(clsSurroundingLinesPara UseLineNbrsBeforeAfter)
        {
            List<clsHtmlElement> OutElements = new List<clsHtmlElement>();

            //OutElements.Add(clsHtmlStdElements.HR());
            // OutElements.Add(clsHtmlStdElements.HR());
            foreach (clsFileResults Files2LineResult in Files2LineResults)
            {
                // List of complete files
                foreach (clsHtmlElement ActElement in FileNameAndLinesAsHtml(Files2LineResult, UseLineNbrsBeforeAfter))
                {
                    OutElements.Add(ActElement);
                }
            }

            return (OutElements);
        }

        public List<clsHtmlElement> FileNameAndLinesAsHtml(clsFileResults Files2LineResult, 
            clsSurroundingLinesPara UseLineNbrsBeforeAfter)
        {
            // file name as title
            List<clsHtmlElement> OutElements = new List<clsHtmlElement>();
            clsLineResult ActLineResultInfo = null;
            clsLineResult PrevLineResultInfo = null;
            clsLineResult PostLineResultInfo = null;

            // Filename
            clsHtmlElement Span = clsHtmlStdElements.SPAN();
            if (SearchViewProperties.bDoShowFileNames)
            {
                Span.AddText(Files2LineResult.FileName);
                Span.Properties.AssignFromString(@"class=""FileNameTitle""");
                OutElements.Add(Span);
                OutElements.Add(clsHtmlStdElements.BR());
            }

            // File content: All token lines (with previous and post lines attached
            if (SearchViewProperties.bDoShowFileContents)
            {
                for (int Idx = 0; Idx < Files2LineResult.LinesResultInfos.Count; Idx++)
                {
                    ActLineResultInfo = Files2LineResult.LinesResultInfos[Idx];
                    if (Idx > 0)
                        PrevLineResultInfo = Files2LineResult.LinesResultInfos[Idx - 1];
                    else
                        PrevLineResultInfo = new clsLineResult();
                    if (Idx < Files2LineResult.LinesResultInfos.Count - 1)
                        PostLineResultInfo = Files2LineResult.LinesResultInfos[Idx + 1];
                    else
                        PostLineResultInfo = new clsLineResult();

                    //--- Pre Lines ----------------------------------------------------------------
                    // Todo: Keep Global.Config.ShowLineNbrPreviousToMatch) as copy within class . Init on new search ;-)
                    Dictionary<long, string> PreLinesInfo = Files2LineResult.SurroundingFileLines.PreLines(ActLineResultInfo.LineIdx,
                        UseLineNbrsBeforeAfter.LineNbrPreviousToMatch, PrevLineResultInfo.LineIdx,
                        UseLineNbrsBeforeAfter.LineNbrFollowingMatch);
                    foreach (KeyValuePair<long, string> PreLineInfo in PreLinesInfo)
                    {
                        foreach (clsHtmlElement ActElement in LineToStringHtml(PreLineInfo.Key, PreLineInfo.Value))
                        {
                            OutElements.Add(ActElement);
                        }
                    }

                    //--- Token Line ----------------------------------------------------------------
                    // List of complete lines
                    foreach (clsHtmlElement ActElement in LineToStringHtml(ActLineResultInfo))
                    {
                        OutElements.Add(ActElement);
                    }
                    OutElements.Add(clsHtmlStdElements.BR());

                    //--- Post Lines ----------------------------------------------------------------
                    // Todo: Keep Global.Config.ShowLineNbrPreviousToMatch) as copy within class . Init on new search ;-)
                    Dictionary<long, string> PostLinesInfo = Files2LineResult.SurroundingFileLines.PostLines(ActLineResultInfo.LineIdx,
                        UseLineNbrsBeforeAfter.LineNbrFollowingMatch); //, PostLineResultInfo.LineIdx);
                    
                    //// CrLf first not needed
                    //if (PostLinesInfo.Count > 0)
                    //    OutElements.Add(clsHtmlStdElements.BR());

                    foreach (KeyValuePair<long, string> PostLineInfo in PostLinesInfo)
                    {
                        foreach (clsHtmlElement ActElement in LineToStringHtml(PostLineInfo.Key, PostLineInfo.Value))
                        {
                            OutElements.Add(ActElement);
                        }
                    }

                }
            }

            return (OutElements);
        }

        public List<clsHtmlElement> LineToStringHtml(clsLineResult ResultInfo)
        {
            // file name as title
            List<clsHtmlElement> OutElements = new List<clsHtmlElement>();
            
            //--- Line number ------------------------------------------------------
            clsHtmlElement Span = clsHtmlStdElements.SPAN();
            clsHtmlElement Strong;
            if (SearchViewProperties.bDoShowLineNumbers)
            {
                Span.AddText(ResultInfo.LineIdx.ToString("D6") + ": ");
                Span.Properties.AssignFromString(@"class=""LineNumber""");
                OutElements.Add(Span);
            }

            /**/
            Span = clsHtmlStdElements.SPAN();

            //--- Line content ------------------------------------------------------
            string EncodedText;
            int LastIdx = 0;
            foreach (clsResultInfoInLine ResultInfoLine in ResultInfo.ResultInfos)
            {
                //--- Pre text ------------------------------------------------
                int StartIdx = ResultInfoLine.StartIdx;
                if (SearchViewProperties.bDoShowWholeLine)
                {
                    // EncodedText = ResultInfo.Line.Substring(LastIdx, StartIdx - LastIdx);
                    EncodedText = clsHtmlEncode.HtmlEncode(ResultInfo.Line.Substring(LastIdx, StartIdx - LastIdx));
                    Span.AddText(EncodedText);
                }
                LastIdx = StartIdx;

                //--- Token text ------------------------------------------------
                Strong = clsHtmlStdElements.SPAN();
                Strong.Properties.AssignFromString(" class=Token");
                // Teststring for encoding "äüöß<>ÄÖÜ~#][\\"" Testä Testü Testö Testß Test< Test> TestÄ TestÖ TestÜ Test~ Test# Test] Test[ Test\\
                // EncodedText = ResultInfo.Line.Substring(LastIdx, ResultInfoLine.Length);
                EncodedText = clsHtmlEncode.HtmlEncode(ResultInfo.Line.Substring(LastIdx, ResultInfoLine.Length));
                //EncodedText = ResultInfo.Line.Substring(LastIdx, ResultInfoLine.Size);
                Strong.AddText(EncodedText);
                LastIdx += ResultInfoLine.Length;
                Span.AddElement(Strong);
            }

            //--- Post text ------------------------------------------------
            if (SearchViewProperties.bDoShowWholeLine)
            {
                // 
//                if (LastIdx < ResultInfo.Line.Length - 1)
                if (LastIdx <= ResultInfo.Line.Length - 1)
                {
                    // EncodedText = ResultInfo.Line.Substring(LastIdx, ResultInfo.Line.Length - LastIdx);
                    EncodedText = clsHtmlEncode.HtmlEncode(ResultInfo.Line.Substring(LastIdx, ResultInfo.Line.Length - LastIdx));
                    Span.AddText(EncodedText);
                }
            }
            
            OutElements.Add(Span);

            // OutElements.Add(clsHtmlStdElements.BR());

            return (OutElements);
        }

        public List<clsHtmlElement> LineToStringHtml(long LineIdx, string Line)
        {
            // file name as title
            List<clsHtmlElement> OutElements = new List<clsHtmlElement>();

            //--- Line number ------------------------------------------------------
            clsHtmlElement Span = clsHtmlStdElements.SPAN();
            if (SearchViewProperties.bDoShowLineNumbers)
            {
                // clsHtmlElement Strong;
                Span.AddText(LineIdx.ToString("D6") + ": ");
                Span.Properties.AssignFromString(@"class=""LineNumber""");
                OutElements.Add(Span);
            }

            /**/
            Span = clsHtmlStdElements.SPAN();

            //--- Line content ------------------------------------------------------
            string EncodedText;
            EncodedText = clsHtmlEncode.HtmlEncode(Line);
            Span.AddText(EncodedText);
            OutElements.Add(Span);

            OutElements.Add(clsHtmlStdElements.BR());

            return (OutElements);
        }

        public List<clsHtmlElement> FileLinesAsHtml(clsFileResults Files2LineResult)
        {
            List<clsHtmlElement> OutElements = new List<clsHtmlElement>();

            foreach (clsLineResult ResultInfo in Files2LineResult.LinesResultInfos)
            {
                foreach (clsHtmlElement ActElement in LineToStringHtml(ResultInfo))
                {
                    OutElements.Add(ActElement);
                }
            }

            return (OutElements);
        }

        /// <summary>
        /// Docuent with no file name header or any other
        /// </summary>
        /// <returns></returns>
        public string FoundLinesWithTokenHtmlDocument()
        {
            string OutTxt = "";

            clsHtmlPage HtmlPage = new clsHtmlPage();

            clsHtmlElement Head = clsHtmlStdElements.HEAD();
            clsHtmlElement Link = clsHtmlStdElements.LINK();

            string LinkPath;
            LinkPath = Path.Combine(Environment.GetEnvironmentVariable("APPDATA"), Application.ProductName);
            LinkPath = Path.Combine(LinkPath, @"TokenList.css");
            Link.Properties.AssignFromString(@"rel=""stylesheet"" type=""text/css"" href=""" + LinkPath + @"""");
            Head.AddElement(Link);

            clsHtmlElement Title = clsHtmlStdElements.TITLE("Found lines with token");
            Head.AddElement(Title);

            HtmlPage.Html.AddElement(Head);

            clsHtmlElement Body = clsHtmlStdElements.BODY();
            HtmlPage.Html.AddElement(Body);

            //--- Insert LineInfos from first ---------------------------------------------------------
            if (Files2LineResults.Count > 0)
            {
                clsFileResults Files2LineResult = Files2LineResults[0];

                foreach (clsLineResult LineResultInfo in Files2LineResult.LinesResultInfos)
                {
                    // List of complete lines
                    foreach (clsHtmlElement ActElement in LineToStringHtml(LineResultInfo))
                        Body.AddElement(ActElement);
                }
            }
            Body.AddElement(clsHtmlStdElements.HR());

            OutTxt = HtmlPage.DocumentString();
            return (OutTxt);
        }
        // FoundFilesWithTokenLinesHtmlDocument
        public bool WriteFileFoundFilesWithTokenLinesHtmlDocument(string FileName)
        {
            if (File.Exists(FileName))
            {
                Global.oDebugLog.DPrint("File will be overwritten");
                //string OutTxt = string.Format("Error in DoCmdReadNcsFile: File: {0} does not exist.", UsePathFileName);
                //Global.oDebugLog.MessageBox(OutTxt); 
                //return;
            }

            //----------------------------------------------------------------------------
            // Write
            //----------------------------------------------------------------------------

            FileStream OutHtmlFile = new FileStream(FileName, FileMode.Create, FileAccess.Write);
            if ((OutHtmlFile != null))
            {
                string OutTxt = this.FoundFilesWithTokenLinesHtmlDocument(
                    new clsSurroundingLinesPara(),
                    new clsSearchViewProperties()); // show all 
                StreamWriter TxtWriter = new StreamWriter(OutHtmlFile, System.Text.Encoding.Default);

                TxtWriter.Write(OutTxt);
                TxtWriter.Flush();   // Puffer => Disk
                TxtWriter.Close();

                OutHtmlFile.Close();
            }

            return true;
        }

        // FoundLinesWithTokenHtmlDocument
        public bool WriteFileFoundLinesWithTokenHtmlDocument(string FileName)
        {
            if (File.Exists(FileName))
            {
                Global.oDebugLog.DPrint("File will be overwritten");
                //string OutTxt = string.Format("Error in DoCmdReadNcsFile: File: {0} does not exist.", UsePathFileName);
                //Global.oDebugLog.MessageBox(OutTxt); 
                //return;
            }

            //----------------------------------------------------------------------------
            // Write
            //----------------------------------------------------------------------------

            FileStream OutHtmlFile = new FileStream(FileName, FileMode.Create, FileAccess.Write);
            if ((OutHtmlFile != null))
            {
                string OutTxt = this.FoundLinesWithTokenHtmlDocument();
                StreamWriter TxtWriter = new StreamWriter(OutHtmlFile, System.Text.Encoding.Default);

                TxtWriter.Write(OutTxt);
                TxtWriter.Flush();   // Puffer => Disk
                TxtWriter.Close();

                OutHtmlFile.Close();
            }

            return true;
        }

    }
}
