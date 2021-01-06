using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Windows.Forms;
using ErrorCapture;
using MainGlobal;
using HtmlFromToken;
using AppPaths;

namespace NetGrep
{
    public class clsSearchResultFileListAsHtml
    {
        public clsSearchResultInfo SearchResultInfo = null;
        public List<clsFileResults> Files2LineResults = new List<clsFileResults>();
        public string SearchString;

        public clsSearchResultFileListAsHtml(clsSearchResultInfo InSearchResultInfo,
            List<clsFileResults> InFiles2LineResults, string InSearchString)
        {
            SearchResultInfo = InSearchResultInfo;
            Files2LineResults = InFiles2LineResults;
            SearchString = InSearchString;
        }


        public string FoundFileNamesHtmlDocument()
        {
            string OutTxt = "";
            try
            {
                clsHtmlPage HtmlPage = new clsHtmlPage();

                clsHtmlElement Head = clsHtmlStdElements.HEAD();
                clsHtmlElement Link = clsHtmlStdElements.LINK();

                string LinkPath;
                // LinkPath = Path.Combine(Environment.GetEnvironmentVariable("APPDATA"), Application.ProductName);
                LinkPath = Path.Combine(clsAppPaths.UserCfgPathName.PathName, @"FileList.css");
                Link.Properties.AssignFromString(@"rel=""stylesheet"" type=""text/css"" href=""file:///" + LinkPath + @"""");
                Head.AddElement(Link);

                clsHtmlElement Title = clsHtmlStdElements.TITLE("Found files with search token");
                Head.AddElement(Title);

                HtmlPage.Html.AddElement(Head);

                clsHtmlElement Body = clsHtmlStdElements.BODY();
                HtmlPage.Html.AddElement(Body);

                // Include scripts here
                clsHtmlElement Script = new clsHtmlElement("script");
                string ScriptTxt = "";

                //ScriptTxt += "function onClickFileList(sourceElement) {" + "\r\n";
                //ScriptTxt += "    " + "    ";
                //ScriptTxt += "    window.external.webFileList_HtmlClick(sourceElement); " + "\r\n";
                //ScriptTxt += "    " + "    ";
                //ScriptTxt += "}" + "\r\n";

                //ScriptTxt += "function onDblClickFileList(sourceElement) {" + "\r\n";
                //ScriptTxt += "    " + "    ";
                //ScriptTxt += "    window.external.webFileList_HtmlDoubleClick(sourceElement); " + "\r\n";
                //ScriptTxt += "    " + "    ";
                //ScriptTxt += "}" + "\r\n";

                ScriptTxt += "function onClickFileList(sourceElement) {" + "\r\n";
                ScriptTxt += "    " + "    ";
                ScriptTxt += "    window.external.webFileList_HtmlClick(sourceElement); " + "\r\n";
                ScriptTxt += "    " + "    ";
                ScriptTxt += "}" + "\r\n";

                ScriptTxt += "function onDblClickFileList(sourceElement) {" + "\r\n";
                ScriptTxt += "    " + "    ";
                ScriptTxt += "    window.external.webFileList_HtmlDoubleClick(sourceElement); " + "\r\n";
                ScriptTxt += "    " + "    ";
                ScriptTxt += "}" + "\r\n";

/*
       document.attachEvent("onkeydown", my_onkeydown_handler);
      function my_onkeydown_handler()
       {
      switch (event.keyCode)
       {  
     case 116 :
      // 'F5' 
      event.returnValue = false;
      case 78:
      event.returnValue = false;
      event.keyCode = 0;
      window.status = "You can't refresh this page.............";
       break;
        } 
        }  
*/


                //<button onclick="window.external.Test('called from script code')">
                //    call client code from script code
                //</button>

                Script.AddText(ScriptTxt);
                Body.AddElement(Script);

                // Inside Header with Span and two Header h1 h2
                clsHtmlElement Span = null;
                Span = clsHtmlStdElements.SPAN();

                Span.Properties.AssignFromString(" class=HeaderFoundFiles"); // size =100% needed
                // Table.Properties.AssignFromString(" BORDER=0 cellspacing=0 cellpadding=3 WIDTH=100%");
                clsHtmlElement H1 = clsHtmlStdElements.H1("Results for searched string: '" 
                    + clsHtmlEncode.HtmlEncode(SearchString) + "'");
                Span.AddElement(H1);
                clsHtmlElement H2 = clsHtmlStdElements.H2(SearchResultInfo.ToString4Html());
                Span.AddElement(H2);

                Body.AddElement(Span);
                //Body.AddElement(Div);

                Body.AddElement(clsHtmlStdElements.HR());
                // Body.AddElement(clsHtmlStdElements.BR());

                //--- Insert FileInfos ---------------------------------------------------------------------
                if (Files2LineResults.Count < 1)
                {
                    // OutTxt = OutTxt + clsHtmlWrapper.WrapLineNumber("Found no matches for '" + clsHtmlEncode.HtmlEncode(SearchString) + "'") + clsHtmlWrapper.CrLf();
                    //Body.AddElement(clsHtmlStdElements.BR());

                    Span = clsHtmlStdElements.SPAN();
                    Span.AddText(@"Found no matches for '" + clsHtmlEncode.HtmlEncode(SearchString) + @"'");
                    Span.Properties.AssignFromString(@"class=""NotFound""");
                    Body.AddElement(Span);
                    Body.AddElement(clsHtmlStdElements.BR());
                }
                else
                {

                    // OutTxt = OutTxt + "Found matches for '" + clsHtmlEncode.HtmlEncode(SearchString) + "' in following files : " + clsHtmlWrapper.CrLf();
                    //clsHtmlElement Span = clsHtmlStdElements.SPAN();
                    //Span.AddText(@"Found matches for '" + clsHtmlEncode.HtmlEncode(SearchString) + @"' in following files : ");
                    //Span.Properties.AssignFromString(@"class=""Info""");
                    //Body.AddElement(Span);
                    //Body.AddElement(clsHtmlStdElements.BR());

                    // List of file names
                    foreach (clsHtmlElement ActElement in FileListAsHtml())
                        Body.AddElement(ActElement);
                }

                Body.AddElement(clsHtmlStdElements.HR());

                OutTxt = HtmlPage.DocumentString();
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            return (OutTxt);
        }

        public List<clsHtmlElement> FileListAsHtml()
        {
            List<clsHtmlElement> OutElements = new List<clsHtmlElement>();
            try
            {
                // string OutTxt = "";
                clsHtmlElement Table = null;
                clsHtmlElement Tr = null;
                clsHtmlElement Td = null;
                clsHtmlElement Th = null;

                // Header of table

                Table = clsHtmlStdElements.TABLE();
                // Table.Properties.AssignFromString(" BORDER=0 cellspacing=0 cellpadding=0 WIDTH=100%");
                // Table.Properties.AssignFromString(" BORDER=0 cellspacing=0 cellpadding=0 WIDTH=100% align=left");

                Tr = clsHtmlStdElements.TR();

                Th = clsHtmlStdElements.TH();
                Th.AddText("Filename");
                //Td.Properties.AssignFromString(" class=header");
                Tr.AddElement(Th);

                //Th = clsHtmlStdElements.TH();
                //Th.AddText("T");
                //// Td.Properties.AssignFromString(" class=header");
                //Tr.AddElement(Th);

                //Th = clsHtmlStdElements.TH();
                //Th.AddText("Type");
                //// Td.Properties.AssignFromString(" class=header");
                //Tr.AddElement(Th);

                Th = clsHtmlStdElements.TH();
                Th.AddText("Folder");
                // Td.Properties.AssignFromString(" class=header");
                Tr.AddElement(Th);

                Th = clsHtmlStdElements.TH();
                Th.AddText("Matches");
                // Td.Properties.AssignFromString(" class=header");
                Tr.AddElement(Th);

                Th = clsHtmlStdElements.TH();
                Th.AddText("Size");
                // Td.Properties.AssignFromString(" class=header");
                Tr.AddElement(Th);

                Th = clsHtmlStdElements.TH();
                Th.AddText("Date/Time");
                // Td.Properties.AssignFromString(" class=header");
                Tr.AddElement(Th);

                Table.AddElement(Tr);

                foreach (clsFileResults Files2LineResult in Files2LineResults)
                {
                    FileInfo ResultFileInfo = new FileInfo(Files2LineResult.FileName);

                    string FileName = Path.GetFileName(Files2LineResult.FileName);
                    string FileFolder = Path.GetDirectoryName(Files2LineResult.FileName);
                    //string T = ".";
                    //string Type = "ttt"; // 
                    string Matches = Files2LineResult.MatchedNbr.ToString();
                    string Size = ResultFileInfo.Length.ToString();
                    string DateTime = ResultFileInfo.CreationTime.ToString();

                    Tr = clsHtmlStdElements.TR();

                    clsHtmlProperties OnDblClick = new clsHtmlProperties();
                    OnDblClick.AddFromString(@"onclick=""onClickFileList(this)""");
                    OnDblClick.AddFromString(@"ondblclick=""onDblClickFileList(this)""");

                    Td = clsHtmlStdElements.TD();
                    Td.AddText(FileName);
                    Td.Properties = OnDblClick;

                    // Td.Properties.AssignFromString(" class=header");
                    Tr.AddElement(Td);

                    //Td = clsHtmlStdElements.TD();
                    //Td.AddText(T);
                    //// Td.Properties.AssignFromString(" class=header");
                    //Tr.AddElement(Td);

                    //Td = clsHtmlStdElements.TD();
                    //Td.AddText(Type);
                    //// Td.Properties.AssignFromString(" class=header");
                    //Tr.AddElement(Td);

                    Td = clsHtmlStdElements.TD();
                    Td.AddText(FileFolder);
                    Td.Properties = OnDblClick;
                    // Td.Properties.AssignFromString(" class=header");
                    Tr.AddElement(Td);

                    Td = clsHtmlStdElements.TD();
                    Td.AddText(Matches);
                    Td.Properties = OnDblClick;
                    // Td.Properties.AssignFromString(" class=header");
                    Tr.AddElement(Td);

                    Td = clsHtmlStdElements.TD();
                    Td.AddText(Size);
                    Td.Properties = OnDblClick;
                    // Td.Properties.AssignFromString(" class=header");
                    Tr.AddElement(Td);

                    Td = clsHtmlStdElements.TD();
                    Td.AddText(DateTime);
                    Td.Properties = OnDblClick;
                    // Td.Properties.AssignFromString(" class=header");
                    Tr.AddElement(Td);

                    Table.AddElement(Tr);
                    //// clsHtmlElement Span = clsHtmlStdElements.SPAN();
                    //Span.AddText(Files2LineResult.FileName);
                    //// yyy;
                    //Span.Properties.AssignFromString(@"class=""FileNameText""");
                    //OutElements.Add(Span);
                }

                OutElements.Add(Table);
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
            return (OutElements);
        }

        public bool WriteResultFileHtml(string FileName)
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
                string OutTxt = this.FoundFileNamesHtmlDocument();
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
