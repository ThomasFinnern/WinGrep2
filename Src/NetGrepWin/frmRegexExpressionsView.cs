using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NetGrep
{
/*
// StreamWriter for string stream 
// new System.IO.Stream (RegexExpressionInfo01)

UnicodeEncoding uniEncoding = new UnicodeEncoding();
String message = "Message";

// You might not want to use the outer using statement that I have
// I wasn't sure how long you would need the MemoryStream object    
using(MemoryStream ms = new MemoryStream())
{
    using(StreamWriter sw = new StreamWriter(ms, uniEncoding))
    {
        sw.Write(message);
        sw.Flush();//otherwise you are risking empty stream
    }

    ms.Seek(0, SeekOrigin.Begin);

    // Test and work with the stream here. 
    // If you need to start back at the beginning, be sure to Seek again.
}



public Stream GenerateStreamFromString(string s)
{
    MemoryStream stream = new MemoryStream();
    StreamWriter writer = new StreamWriter(stream);
    writer.Write(s);
    writer.Flush();
    stream.Position = 0;
    return stream;
}Don't forget to use Using:

using (Stream s = GenerateStreamFromString("a,b \n c,d"))
{
    // ... Do stuff to stream
}

*/


    public partial class frmRegexExpressionsView : Form
    {

        public frmRegexExpressionsView()
        {
            InitializeComponent();

            // rchtInfoRegexExpression.Text = RegexExpressionInfo;
            // rchtInfoRegexExpression.LoadFile (new System.IO.Stream (RegexExpressionInfo01), RichTextBoxStreamType.RichText);
            webbRegExInfo.DocumentText = RegexExpressionHtmlInfo;
        
        
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdTest01_Click(object sender, EventArgs e)
        {
            //rchtInfoRegexExpression.LoadFile(@"d:\Pr004\Entwickl.2012\NetGrepGroup.2005\Data\RegexExpressionSyntax.rtf");
            //rchtInfoRegexExpression.LoadFile(@"d:\Pr004\Entwickl.2012\NetGrepGroup.2005\Data\RegexExpressionSyntax.rtf", RichTextBoxStreamType.RichText);
            //rchtInfoRegexExpression.LoadFile(@"d:\Pr004\Entwickl.2012\NetGrepGroup.2005\Data\RegexExpressionSyntax.rtf", RichTextBoxStreamType.TextTextOleObjs);
            //rchtInfoRegexExpression.LoadFile(@"d:\Pr004\Entwickl.2012\NetGrepGroup.2005\Data\RegexExpressionSyntax.rtf", RichTextBoxStreamType.RichNoOleObjs);
        }
        private const string RegexExpressionHtmlInfo =
@" <html> 

 <style> 
    <!--

 /* Durch Entwicklertools generiert. Dies ist möglicherweise keine exakte Darstellung der ursprünglichen Quelldatei */
BODY {
	FONT: 0.87em/1.35 ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif
}
H1 {
	MARGIN-TOP: 0px; FONT: 100 2.57em/1.167 ""Segoe UI Light"", ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif; COLOR: #707070
}
H2 {
	PADDING-BOTTOM: 5px; MARGIN: 0px; FONT-FAMILY: ""Segoe UI Light"" , ""Segoe UI"" , ""Lucida Grande"" , Verdana, Arial, Helvetica, sans-serif; COLOR: #db7100; FONT-SIZE: 1.28em; FONT-WEIGHT: normal; PADDING-TOP: 5px
}
H3 {
	PADDING-BOTTOM: 5px; MARGIN: 0px; FONT-FAMILY: ""Segoe UI Light"" , ""Segoe UI"" , ""Lucida Grande"" , Verdana, Arial, Helvetica, sans-serif; COLOR: #db7100; FONT-SIZE: 1.28em; FONT-WEIGHT: normal; PADDING-TOP: 5px
}
.contentWrapper H2 A {
	PADDING-BOTTOM: 5px; MARGIN: 0px; FONT-FAMILY: ""Segoe UI Light"" , ""Segoe UI"" , ""Lucida Grande"" , Verdana, Arial, Helvetica, sans-serif; COLOR: #db7100; FONT-SIZE: 1.28em; FONT-WEIGHT: normal; PADDING-TOP: 5px
}
.contentWrapper H3 A {
	PADDING-BOTTOM: 5px; MARGIN: 0px; FONT-FAMILY: ""Segoe UI Light"" , ""Segoe UI"" , ""Lucida Grande"" , Verdana, Arial, Helvetica, sans-serif; COLOR: #db7100; FONT-SIZE: 1.28em; FONT-WEIGHT: normal; PADDING-TOP: 5px
}
.heading {
	PADDING-BOTTOM: 5px; MARGIN: 0px; FONT-FAMILY: ""Segoe UI Light"" , ""Segoe UI"" , ""Lucida Grande"" , Verdana, Arial, Helvetica, sans-serif; COLOR: #db7100; FONT-SIZE: 1.28em; FONT-WEIGHT: normal; PADDING-TOP: 5px
}
H4 {
	MARGIN: 0px; FONT-FAMILY: ""Segoe UI"" , ""Lucida Grande"" , Verdana, Arial, Helvetica, sans-serif; COLOR: #2a2a2a; FONT-SIZE: 0.85em; FONT-WEIGHT: bold
}
.subheading {
	MARGIN: 0px; FONT-FAMILY: ""Segoe UI"" , ""Lucida Grande"" , Verdana, Arial, Helvetica, sans-serif; COLOR: #2a2a2a; FONT-SIZE: 0.85em; FONT-WEIGHT: bold
}
H5 {
	LINE-HEIGHT: 130%; MARGIN: 0px; FONT-SIZE: 0.85em; FONT-WEIGHT: normal
}
H6 {
	LINE-HEIGHT: 130%; MARGIN: 0px; FONT-SIZE: 0.85em; FONT-WEIGHT: normal
}
DIV#body {
	CLEAR: both; PADDING-TOP: 35px
}
DIV#content {
	OVERFLOW-X: auto !important; MIN-HEIGHT: 300px; WORD-WRAP: break-word
}
.BostonPostCard > DIV + DIV + DIV {
	WIDTH: auto !important
}
*:first-child + HTML .BostonPostCard > DIV + DIV + DIV {
	WIDTH: 740px !important; HEIGHT: 30px !important
}
*:first-child + HTML #contentFeedback {
	HEIGHT: 20px !important
}
*:first-child + HTML DIV#content {
	OVERFLOW: hidden
}
*:first-child + HTML DIV#nstext IMG[usemap='#excel2'] {
	BORDER-BOTTOM: medium none; BORDER-LEFT: medium none; BORDER-TOP: medium none; BORDER-RIGHT: medium none
}
DIV#nstext IMG[usemap='#excel2'] {
	BORDER-BOTTOM: 0px; BORDER-LEFT: 0px; BORDER-TOP: 0px; BORDER-RIGHT: 0px
}
.clear {
	CLEAR: both
}
.majorTitle {
	DISPLAY: none
}
.parameter {
	FONT-STYLE: italic
}
.multicol TH {
	BORDER-BOTTOM: medium none; BORDER-LEFT: medium none; PADDING-BOTTOM: 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 12px; BORDER-TOP: medium none; BORDER-RIGHT: medium none; PADDING-TOP: 0px
}
.multicol TD {
	BORDER-BOTTOM: medium none; BORDER-LEFT: medium none; PADDING-BOTTOM: 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 12px; BORDER-TOP: medium none; BORDER-RIGHT: medium none; PADDING-TOP: 0px
}
TD.innercol {
	BORDER-BOTTOM: medium none; BORDER-LEFT: medium none; PADDING-BOTTOM: 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 12px; BORDER-TOP: medium none; BORDER-RIGHT: medium none; PADDING-TOP: 0px
}
.innercol TABLE TD {
	BORDER-BOTTOM: medium none; BORDER-LEFT: medium none; PADDING-BOTTOM: 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 12px; BORDER-TOP: medium none; BORDER-RIGHT: medium none; PADDING-TOP: 0px
}
#mainBody UL LI {
	LIST-STYLE-IMAGE: none
}
P {
	PADDING-BOTTOM: 15px; LINE-HEIGHT: 18px; MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; COLOR: #2a2a2a
}
.topic A {
	COLOR: #00709f; TEXT-DECORATION: none
}
.topic A:link {
	COLOR: #00709f; TEXT-DECORATION: none
}
.topic A:visited {
	COLOR: #03697a; TEXT-DECORATION: none
}
.topic A:active {
	COLOR: #03697a; TEXT-DECORATION: none
}
.topic A:hover {
	COLOR: #3390b1; TEXT-DECORATION: none
}
.topic A.active {
	COLOR: #2a2a2a
}
.topic A.active:link {
	COLOR: #2a2a2a
}
.topic A.active:hover {
	COLOR: #2a2a2a
}
.topic A.active:visited {
	COLOR: #2a2a2a
}
.topic A.active:active {
	COLOR: #2a2a2a
}
TABLE {
	PADDING-BOTTOM: 20px; BORDER-COLLAPSE: collapse; PADDING-TOP: 20px
}
DIV#content TABLE {
	WIDTH: 100%
}
TD {
	BORDER-BOTTOM: #dbdbdb 1px solid; PADDING-BOTTOM: 10px; MARGIN: 10px; PADDING-LEFT: 8px; PADDING-RIGHT: 8px; PADDING-TOP: 10px
}
TH {
	BORDER-BOTTOM: #dbdbdb 1px solid; PADDING-BOTTOM: 10px; MARGIN: 10px; PADDING-LEFT: 8px; PADDING-RIGHT: 8px; PADDING-TOP: 10px
}
TH {
	TEXT-ALIGN: left; BACKGROUND-COLOR: #ededed; COLOR: #707070
}
TD {
	COLOR: #2a2a2a; VERTICAL-ALIGN: top
}
TABLE P {
	PADDING-BOTTOM: 0px
}
.errorMessage {
	FONT-FAMILY: ""Segoe UI Light"" , ""Segoe UI"" , ""Lucida Grande"" , Verdana, Arial, Helvetica, sans-serif; COLOR: #707070; FONT-SIZE: 36px
}
.errormessageSpacing {
	MARGIN-TOP: 3px
}
TABLE .BostonPostCard P {
	PADDING-BOTTOM: 5px
}
TABLE.members {
	WIDTH: 100%
}
TABLE.members TD {
	MIN-WIDTH: 72px
}
SPAN.sup {
	VERTICAL-ALIGN: super
}
.summary {
	MARGIN-TOP: 15px
}
DIV.mtps-table {
	DISPLAY: inline-table
}
DIV.mtps-thead {
	DISPLAY: table-header-group
}
SPAN.mtps-caption {
	PADDING-BOTTOM: 4pt; PADDING-LEFT: 4pt; PADDING-RIGHT: 4pt; DISPLAY: table-caption; PADDING-TOP: 4pt
}
DIV.mtps-row {
	PADDING-BOTTOM: 4pt; PADDING-LEFT: 4pt; PADDING-RIGHT: 4pt; DISPLAY: table-row; PADDING-TOP: 4pt
}
SPAN.mtps-cell {
	PADDING-BOTTOM: 4pt; PADDING-LEFT: 4pt; PADDING-RIGHT: 4pt; DISPLAY: table-cell; PADDING-TOP: 4pt
}
SPAN.mtps-th {
	PADDING-BOTTOM: 4pt; PADDING-LEFT: 4pt; PADDING-RIGHT: 4pt; DISPLAY: table-cell; PADDING-TOP: 4pt
}
DIV.alert > TABLE {
	BORDER-RIGHT-WIDTH: 0px; BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px
}
DIV.alert TH {
	BORDER-BOTTOM: 0px hidden; BORDER-LEFT: 0px hidden; PADDING-BOTTOM: 5px; BACKGROUND-COLOR: #ededed; PADDING-LEFT: 11px; BORDER-SPACING: 0px; PADDING-RIGHT: 11px; BORDER-COLLAPSE: collapse; BORDER-TOP: 0px hidden; FONT-WEIGHT: bold; BORDER-RIGHT: 0px hidden; PADDING-TOP: 10px
}
DIV.alert TD {
	PADDING-BOTTOM: 10px; BORDER-RIGHT-WIDTH: 0px; PADDING-LEFT: 8px; PADDING-RIGHT: 8px; BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px; PADDING-TOP: 10px
}
DIV.alert IMG {
	BORDER-BOTTOM: 0px; BORDER-LEFT: 0px; PADDING-RIGHT: 5px; BORDER-TOP: 0px; BORDER-RIGHT: 0px
}
DIV.alert P {
	MARGIN: 0px
}
.controlPlaceholder {
	PADDING-BOTTOM: 10px; BACKGROUND-COLOR: #eee; FONT-STYLE: italic; PADDING-LEFT: 10px; PADDING-RIGHT: 10px; COLOR: #aaa; PADDING-TOP: 10px
}
.input {
	FONT-WEIGHT: 700
}
.label {
	FONT-WEIGHT: 700
}
DIV.footerPrintView {
	DISPLAY: none; FONT-FAMILY: ""Segoe UI"" , ""Lucida Grande"" , Verdana, Arial, Helvetica, sans-serif; CLEAR: both; PADDING-TOP: 10px
}
.code {
	FONT-FAMILY: Consolas, Courier, monospace; COLOR: #006400
}
.multiViewItemHeading {
	FONT-STYLE: italic; MARGIN-TOP: 15px; MARGIN-BOTTOM: 3px
}
.topic .title {
	FONT-FAMILY: Segoe UI, Verdana, Arial
}
#curversion {
	COLOR: #5d5d5d; FONT-SIZE: 13px
}
.codeSnippetContainer {
	MIN-WIDTH: 260px; CLEAR: both
}
.codeSnippetContainerTabs {
	Z-INDEX: 1; POSITION: relative; HEIGHT: 23px; VERTICAL-ALIGN: middle
}
.codeSnippetContainerTab {
	PADDING-BOTTOM: 0px; FONT-STYLE: normal !important; PADDING-LEFT: 15px; WIDTH: auto; PADDING-RIGHT: 15px; FONT-FAMILY: ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif !important; FLOAT: left; HEIGHT: 22px; COLOR: #2a2a2a; FONT-SIZE: 12px; VERTICAL-ALIGN: baseline; PADDING-TOP: 0px
}
.codeSnippetContainerTabActive {
	BORDER-LEFT: #939393 1px solid; PADDING-BOTTOM: 0px; FONT-STYLE: normal !important; PADDING-LEFT: 15px; WIDTH: auto; PADDING-RIGHT: 15px; FONT-FAMILY: ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif !important; BACKGROUND: #f8f8f8; FLOAT: left; HEIGHT: 22px; COLOR: #707070; FONT-SIZE: 12px; VERTICAL-ALIGN: baseline; BORDER-TOP: #939393 1px solid; BORDER-RIGHT: #939393 1px solid; PADDING-TOP: 0px
}
.codeSnippetContainerTabPhantom {
	BORDER-LEFT: #939393 1px solid; PADDING-BOTTOM: 0px; FONT-STYLE: normal !important; PADDING-LEFT: 15px; WIDTH: auto; PADDING-RIGHT: 15px; FONT-FAMILY: ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif !important; BACKGROUND: #f8f8f8; FLOAT: left; HEIGHT: 22px; COLOR: #c2c2c2; FONT-SIZE: 12px; VERTICAL-ALIGN: baseline; BORDER-TOP: #939393 1px solid; BORDER-RIGHT: #939393 1px solid; PADDING-TOP: 0px
}
.codeSnippetContainerTabSingle {
	POSITION: relative; PADDING-BOTTOM: 0px; BACKGROUND-COLOR: #fff; FONT-STYLE: normal !important; PADDING-LEFT: 8px; WIDTH: auto; PADDING-RIGHT: 8px; FONT-FAMILY: ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif !important; FLOAT: left; HEIGHT: 22px; COLOR: #707070; FONT-SIZE: 12px; VERTICAL-ALIGN: baseline; TOP: 14px; PADDING-TOP: 0px; LEFT: 7px
}
.codeSnippetContainerTab A {
	POSITION: relative; COLOR: #2a2a2a; TOP: 2px; TEXT-DECORATION: none
}
.codeSnippetContainerTab A:link {
	POSITION: relative; COLOR: #2a2a2a; TOP: 2px; TEXT-DECORATION: none
}
.codeSnippetContainerTab A:visited {
	POSITION: relative; COLOR: #2a2a2a; TOP: 2px; TEXT-DECORATION: none
}
.codeSnippetContainerTab A:active {
	POSITION: relative; COLOR: #2a2a2a; TOP: 2px; TEXT-DECORATION: none
}
.codeSnippetContainerTabActive A {
	POSITION: relative; COLOR: #707070; TOP: 2px; TEXT-DECORATION: none
}
.codeSnippetContainerTabActive A:link {
	POSITION: relative; COLOR: #707070; TOP: 2px; TEXT-DECORATION: none
}
.codeSnippetContainerTabActive A:visited {
	POSITION: relative; COLOR: #707070; TOP: 2px; TEXT-DECORATION: none
}
.codeSnippetContainerTabActive A:active {
	POSITION: relative; COLOR: #707070; TOP: 2px; TEXT-DECORATION: none
}
.codeSnippetContainerTabPhantom A {
	POSITION: relative; COLOR: #8b8b8b !important; TOP: 2px; TEXT-DECORATION: none
}
.codeSnippetContainerTabPhantom A:link {
	POSITION: relative; COLOR: #8b8b8b !important; TOP: 2px; TEXT-DECORATION: none
}
.codeSnippetContainerTabPhantom A:visited {
	POSITION: relative; COLOR: #8b8b8b !important; TOP: 2px; TEXT-DECORATION: none
}
.codeSnippetContainerTabPhantom A:active {
	POSITION: relative; COLOR: #8b8b8b !important; TOP: 2px; TEXT-DECORATION: none
}
.codeSnippetContainerTabSingle A {
	POSITION: relative; COLOR: #707070; TOP: 2px; TEXT-DECORATION: none
}
.codeSnippetContainerTabSingle A:link {
	POSITION: relative; COLOR: #707070; TOP: 2px; TEXT-DECORATION: none
}
.codeSnippetContainerTabSingle A:visited {
	POSITION: relative; COLOR: #707070; TOP: 2px; TEXT-DECORATION: none
}
.codeSnippetContainerTabSingle A:active {
	POSITION: relative; COLOR: #707070; TOP: 2px; TEXT-DECORATION: none
}
.codeSnippetContainerTab A:hover {
	POSITION: relative; COLOR: #707070; TOP: 2px
}
.codeSnippetContainerTabActive A:hover {
	POSITION: relative; COLOR: #707070; TOP: 2px
}
.codeSnippetContainerTabPhantom A:hover {
	POSITION: relative; COLOR: #c2c2c2; TOP: 2px
}
.codeSnippetContainerTabSingle A:hover {
	POSITION: relative; COLOR: #707070; TOP: 2px
}
.codeSnippetContainerCodeContainer {
	BORDER-BOTTOM: #939393 1px solid; POSITION: relative; BORDER-LEFT: #939393 1px solid; MARGIN-BOTTOM: 12px; CLEAR: both; BORDER-TOP: #939393 1px solid; TOP: -1px; BORDER-RIGHT: #939393 1px solid
}
.codeSnippetToolBar {
	WIDTH: auto; HEIGHT: auto
}
.codeSnippetToolBarText {
	POSITION: relative; BACKGROUND-COLOR: #fff; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; FLOAT: right; HEIGHT: 0px; VERTICAL-ALIGN: top; TOP: -8px
}
.codeSnippetToolBarText A:link {
	BACKGROUND-COLOR: #fff; FONT-STYLE: normal !important; PADDING-LEFT: 8px; PADDING-RIGHT: 8px; FONT-FAMILY: ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif !important; COLOR: #2a2a2a; MARGIN-LEFT: 15px; FONT-SIZE: 10px; MARGIN-RIGHT: 15px; TEXT-DECORATION: none
}
.codeSnippetToolBarText A:visited {
	BACKGROUND-COLOR: #fff; FONT-STYLE: normal !important; PADDING-LEFT: 8px; PADDING-RIGHT: 8px; FONT-FAMILY: ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif !important; COLOR: #2a2a2a; MARGIN-LEFT: 15px; FONT-SIZE: 10px; MARGIN-RIGHT: 15px; TEXT-DECORATION: none
}
.codeSnippetToolBarText A:active {
	BACKGROUND-COLOR: #fff; FONT-STYLE: normal !important; PADDING-LEFT: 8px; PADDING-RIGHT: 8px; FONT-FAMILY: ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif !important; COLOR: #2a2a2a; MARGIN-LEFT: 15px; FONT-SIZE: 10px; MARGIN-RIGHT: 15px; TEXT-DECORATION: none
}
.codeSnippetToolBarText A:hover {
	COLOR: #707070
}
.codeSnippetContainerCode {
	PADDING-BOTTOM: 10px; MARGIN: 0px; PADDING-LEFT: 21px; WIDTH: auto; PADDING-RIGHT: 21px; PADDING-TOP: 10px
}
.codeSnippetContainerCode DIV {
	PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; PADDING-TOP: 0px
}
.codeSnippetContainerCode PRE {
	PADDING-BOTTOM: 5px; FONT-STYLE: normal; MARGIN: 0px; PADDING-LEFT: 5px; PADDING-RIGHT: 5px; FONT-FAMILY: Consolas, Courier, monospace; OVERFLOW: auto; FONT-WEIGHT: normal; PADDING-TOP: 5px
}
.highlight {
	BACKGROUND: #ffffc6
}
.programmingSelector {
	PADDING-BOTTOM: 10px; FLOAT: right; COLOR: #2a2a2a; FONT-SIZE: 12px
}
.programmingSelector .selectorSeparator {
	PADDING-LEFT: 8px; PADDING-RIGHT: 8px
}
.programmingSelector .selectorCurrent {
	FONT-FAMILY: ""Segoe UI Semibold"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif
}
.programmingSelector .selectorAvailable {
	COLOR: #0095c4
}
.programmingSelector .selectorDisabled {
	COLOR: #c2c2c2
}
.programmingSelector .selectortitle {
	PADDING-RIGHT: 4px
}
.LW_CollapsibleArea_TitleDiv {
	PADDING-BOTTOM: 5px; FONT-STYLE: normal !important; FONT-FAMILY: ""Segoe UI Light"", ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif !important; FONT-SIZE: 18px; PADDING-TOP: 20px
}
.LW_CollapsibleArea_TitleDiv_Collapsed {
	PADDING-BOTTOM: 20px; FONT-STYLE: normal !important; FONT-FAMILY: ""Segoe UI Light"", ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif !important; FONT-SIZE: 18px; PADDING-TOP: 20px
}
.LW_CollapsibleArea_TitleDiv A:hover {
	COLOR: #db7100; TEXT-DECORATION: none
}
.LW_CollapsibleArea_TitleDiv_Collapsed A:hover {
	COLOR: #db7100; TEXT-DECORATION: none
}
.LW_CollapsibleArea_Title {
	PADDING-LEFT: 10px; WORD-WRAP: break-word; WORD-BREAK: break-all
}
.LW_CollapsibleArea_HrDiv {
	PADDING-TOP: 0px
}
.LW_CollapsibleArea_Hr {
	BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: none; COLOR: #e5e5e5; BORDER-LEFT-STYLE: none
}
.sectionblock {
	PADDING-BOTTOM: 20px; PADDING-LEFT: 15px; DISPLAY: block
}
.sectionblock OL {
	LIST-STYLE-TYPE: decimal
}
.sectionblock OL OL {
	LIST-STYLE-TYPE: lower-alpha
}
.sectionblock OL OL OL {
	LIST-STYLE-TYPE: lower-roman
}
.sectionnone {
	PADDING-LEFT: 15px; DISPLAY: none
}
.LW_CollapsibleArea_TitleAhref {
	OUTLINE-STYLE: none; OUTLINE-COLOR: invert; OUTLINE-WIDTH: medium; CURSOR: hand
}
.LW_CollapsibleArea_Img {
	BORDER-RIGHT-WIDTH: 0px; MARGIN-TOP: 7px; DISPLAY: inline-block; MARGIN-BOTTOM: 0px; FLOAT: left; BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; VERTICAL-ALIGN: middle; BORDER-LEFT-WIDTH: 0px
}
.LW_CollapsibleArea_TitleDiv DIV A:link {
	COLOR: #db7100; TEXT-DECORATION: none
}
.LW_CollapsibleArea_TitleDiv DIV A:hover {
	COLOR: #db7100; TEXT-DECORATION: none
}
.LW_CollapsibleArea_TitleDiv DIV A:visited {
	COLOR: #db7100; TEXT-DECORATION: none
}
.LW_CollapsibleArea_TitleDiv DIV A:focus {
	COLOR: #db7100; TEXT-DECORATION: none
}
.LW_CollapsibleArea_TitleDiv_Collapsed DIV A:link {
	COLOR: #db7100; TEXT-DECORATION: none
}
.LW_CollapsibleArea_TitleDiv_Collapsed DIV A:hover {
	COLOR: #db7100; TEXT-DECORATION: none
}
.LW_CollapsibleArea_TitleDiv_Collapsed DIV A:visited {
	COLOR: #db7100; TEXT-DECORATION: none
}
.LW_CollapsibleArea_TitleDiv_Collapsed DIV A:focus {
	COLOR: #db7100; TEXT-DECORATION: none
}
.LW_CollapsibleArea_TitleDiv A SPAN {
	DISPLAY: block; OVERFLOW: hidden
}
.communityContentContainer {
	MARGIN-TOP: 34px; MIN-HEIGHT: 40px; CLEAR: both; BORDER-TOP: #dbdbdb 1px solid
}
.communityContentHeader {
	BORDER-BOTTOM: #d5d5d5 1px solid; PADDING-BOTTOM: 16px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; PADDING-TOP: 16px
}
.communityContentHeaderTitle {
	FONT-FAMILY: ""Segoe UI Light"", ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif; COLOR: #db7100; FONT-SIZE: 18px
}
.communityContentAddButton {
	BORDER-BOTTOM-STYLE: none; TEXT-ALIGN: center; PADDING-BOTTOM: 0px; BORDER-RIGHT-STYLE: none; PADDING-LEFT: 16px; PADDING-RIGHT: 16px; BORDER-TOP-STYLE: none; FLOAT: left; COLOR: #2c729c; BORDER-LEFT-STYLE: none; CURSOR: pointer; PADDING-TOP: 12px
}
A.communityContentAddLink {
	FONT-FAMILY: ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif
}
.communityContentAnnotationTitle {
	FONT-FAMILY: ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif
}
.communityContentAnnotationBody {
	FONT-FAMILY: ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif
}
.communityContentAnnotationUserContainer {
	FONT-FAMILY: ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif
}
.communityContentAnnotationDateContainer {
	FONT-FAMILY: ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif
}
A.communityContentCommentEditLink {
	FONT-FAMILY: ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif
}
A.communityContentDeleteLink {
	FONT-FAMILY: ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif
}
A.communityContentAddLink {
	DISPLAY: block; COLOR: #fff; FONT-SIZE: 12px; CURSOR: pointer
}
.communityContentAnnotation {
	BORDER-BOTTOM: #dbdbdb 1px solid; PADDING-BOTTOM: 10px; COLOR: #2a2a2a; PADDING-TOP: 20px
}
.communityContentAnnotationTitle {
	PADDING-BOTTOM: 5px; FONT-SIZE: 14px
}
.communityContentAnnotationBody {
	PADDING-BOTTOM: 10px; LINE-HEIGHT: 18px; WORD-WRAP: break-word; FONT-SIZE: 12px
}
.communityContentAnnotationBody > PRE {
	WHITE-SPACE: pre-wrap
}
.communityContentAnnotationAvatarContainer {
	WIDTH: 34px; PADDING-RIGHT: 5px; FLOAT: left
}
.communityContentAnnotationAvatar IMG {
	BORDER-BOTTOM: 0px; BORDER-LEFT: 0px; BORDER-TOP: 0px; BORDER-RIGHT: 0px
}
.communityContentAnnotationUserDateContainer {
	PADDING-TOP: 3px
}
.communityContentAnnotationUserContainer {
	PADDING-BOTTOM: 5px; FONT-SIZE: 10px
}
.communityContentAnnotationUserContainer {
	COLOR: #2c729c
}
.communityContentAnnotationUserContainer A {
	COLOR: #2c729c
}
.communityContentAnnotationDateContainer {
	FONT-SIZE: 10px
}
A.communityContentCommentEditLink {
	PADDING-LEFT: 20px; COLOR: #2c729c; FONT-SIZE: 10px
}
A.communityContentDeleteLink {
	PADDING-LEFT: 20px; COLOR: #2c729c; FONT-SIZE: 10px
}
.communityContentHeaderTitleContainer H2 {
	FLOAT: left; COLOR: green; FONT-SIZE: 18px
}
.topicNotInScope {
	POSITION: relative; PADDING-BOTTOM: 10px; CLEAR: both
}
.topicNotInScopeDisclaimer {
	BORDER-BOTTOM: #939393 1px solid; BORDER-LEFT: #939393 1px solid; PADDING-BOTTOM: 9px; BACKGROUND-COLOR: #efeeef; PADDING-LEFT: 10px; PADDING-RIGHT: 10px; FONT-FAMILY: ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif; COLOR: #2a2a2a; FONT-SIZE: 12px; BORDER-TOP: #939393 1px solid; BORDER-RIGHT: #939393 1px solid; PADDING-TOP: 9px
}
.topicNotInScopeDisclaimerText {
	PADDING-LEFT: 26px; PADDING-RIGHT: 0px
}
.topicNotInScopeSwitchCollectionContainer {
	FLOAT: right
}
.topicNotInScopeSwitchCollection {
	PADDING-LEFT: 5px; PADDING-RIGHT: 5px; FLOAT: left
}
.topicNotInScopeCollectionPicker {
	Z-INDEX: 2; BORDER-BOTTOM: #939393 1px solid; POSITION: absolute; BORDER-LEFT: #939393 1px solid; BACKGROUND-COLOR: #fff; LIST-STYLE-TYPE: none; MARGIN: 0px; PADDING-LEFT: 10px; WIDTH: auto; PADDING-RIGHT: 10px; DISPLAY: none; BORDER-TOP: #939393 1px solid; TOP: 30px; RIGHT: 10px; BORDER-RIGHT: #939393 1px solid; PADDING-TOP: 5px
}
.topicNotInScopeCollectionPickerItem {
	MARGIN-BOTTOM: 2px; HEIGHT: 20px
}
.topicNotInScopeImageContainer {
	FLOAT: left
}
.topicNotInScopeImageContainer2 {
	MARGIN-TOP: 5px; FLOAT: left
}
.topicNotInScopeImageContainer > IMG {
	MAX-WIDTH: none !important
}
.feedViewerBulletList UL {
	PADDING-BOTTOM: 0px; PADDING-TOP: 0px
}
.feedViewerBulletList UL LI {
	PADDING-BOTTOM: 0px
}
.feedViewerBasic {
	
}
.feedViewerItem {
	PADDING-BOTTOM: 15px
}
A.feedViewerLink {
	FONT-FAMILY: ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif; FONT-SIZE: 12px
}
A.feedViewerLink {
	COLOR: #00709f
}
A.feedViewerLink:active {
	COLOR: #00709f
}
A.feedViewerLink:hover {
	COLOR: #3390b1
}
A.feedViewerLink:visited {
	COLOR: #03697a
}
.feedViewerDescription {
	PADDING-TOP: 5px
}
.feedViewerDescription {
	LINE-HEIGHT: 18px; MARGIN-TOP: 0px; FONT-FAMILY: ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif; MARGIN-BOTTOM: 0px; COLOR: #2a2a2a; FONT-SIZE: 12px
}
.feedViewerDateAuthor {
	LINE-HEIGHT: 18px; MARGIN-TOP: 0px; FONT-FAMILY: ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif; MARGIN-BOTTOM: 0px; COLOR: #2a2a2a; FONT-SIZE: 12px
}
.feedViewerDate {
	
}
.feedViewerAuthor {
	
}
.clip10x10 {
	POSITION: relative; OVERFLOW: hidden
}
.clip10x46 {
	POSITION: relative; OVERFLOW: hidden
}
.clip11x6 {
	POSITION: relative; OVERFLOW: hidden
}
.clip11x12 {
	POSITION: relative; OVERFLOW: hidden
}
.clip16x16 {
	POSITION: relative; OVERFLOW: hidden
}
.clip20x20 {
	POSITION: relative; OVERFLOW: hidden
}
.clip20x21 {
	POSITION: relative; OVERFLOW: hidden
}
.clip22x30 {
	POSITION: relative; OVERFLOW: hidden
}
.clip23x23 {
	POSITION: relative; OVERFLOW: hidden
}
.clip25x25 {
	POSITION: relative; OVERFLOW: hidden
}
.clip26x23 {
	POSITION: relative; OVERFLOW: hidden
}
.clip29x29 {
	POSITION: relative; OVERFLOW: hidden
}
.clip30x24 {
	POSITION: relative; OVERFLOW: hidden
}
.clip30x25 {
	POSITION: relative; OVERFLOW: hidden
}
.clip31x24 {
	POSITION: relative; OVERFLOW: hidden
}
.clip32x24 {
	POSITION: relative; OVERFLOW: hidden
}
.clip38x23 {
	POSITION: relative; OVERFLOW: hidden
}
.clip51x24 {
	POSITION: relative; OVERFLOW: hidden
}
.clip10x10 {
	WIDTH: 10px; HEIGHT: 10px
}
.clip10x46 {
	WIDTH: 10px; HEIGHT: 46px
}
.clip11x6 {
	WIDTH: 11px; HEIGHT: 6px
}
.clip11x12 {
	WIDTH: 11px; HEIGHT: 12px
}
.clip16x16 {
	WIDTH: 16px; HEIGHT: 16px
}
.clip20x20 {
	WIDTH: 20px; HEIGHT: 20px
}
.clip20x21 {
	WIDTH: 20px; HEIGHT: 21px
}
.clip22x30 {
	WIDTH: 22px; HEIGHT: 30px
}
.clip23x23 {
	WIDTH: 23px; HEIGHT: 23px
}
.clip25x25 {
	WIDTH: 25px; HEIGHT: 25px
}
.clip26x23 {
	WIDTH: 26px; HEIGHT: 23px
}
.clip29x29 {
	WIDTH: 29px; HEIGHT: 29px
}
.clip30x24 {
	WIDTH: 30px; HEIGHT: 24px
}
.clip30x25 {
	WIDTH: 30px; HEIGHT: 25px
}
.clip31x24 {
	WIDTH: 31px; HEIGHT: 24px
}
.clip32x24 {
	WIDTH: 32px; HEIGHT: 24px
}
.clip38x23 {
	WIDTH: 38px; HEIGHT: 23px
}
.clip51x24 {
	WIDTH: 51px; HEIGHT: 24px
}
.clip10x10 IMG {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip10x10 INPUT {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip10x46 IMG {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip10x46 INPUT {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip11x6 IMG {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip11x6 INPUT {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip11x12 IMG {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip11x12 INPUT {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip16x16 IMG {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip16x16 INPUT {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip20x20 IMG {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip20x20 INPUT {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip20x21 IMG {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip20x21 INPUT {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip22x30 IMG {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip22x30 INPUT {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip23x23 IMG {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip23x23 INPUT {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip25x25 IMG {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip25x25 INPUT {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip26x23 IMG {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip26x23 INPUT {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip29x29 IMG {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip29x29 INPUT {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip30x24 IMG {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip30x24 INPUT {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip30x25 IMG {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip30x25 INPUT {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip31x24 IMG {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip31x24 INPUT {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip32x24 IMG {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip32x24 INPUT {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip38x23 IMG {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip38x23 INPUT {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip51x24 IMG {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.clip51x24 INPUT {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.cl_footer_logo {
	WIDTH: 90px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -3px -3px; HEIGHT: 16px; OVERFLOW: hidden
}
.isd_search {
	TOP: -3px; LEFT: -99px
}
.search_icon_technet {
	TOP: -3px; LEFT: -125px
}
.search_gray {
	WIDTH: 17px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -160px -3px; HEIGHT: 17px; OVERFLOW: hidden
}
.cl_footer_feedback_icon {
	TOP: -3px; LEFT: -183px
}
.cl_ContentFallback_Alert {
	TOP: -3px; LEFT: -209px
}
.cl_msdn_close {
	TOP: -3px; LEFT: -240px
}
.cl_printhelp_logo {
	TOP: -3px; LEFT: -268px
}
.cl_nav_resize_close {
	TOP: -3px; LEFT: -297px
}
.cl_nav_resize_open {
	TOP: -3px; LEFT: -313px
}
.toc_collapsed {
	WIDTH: 17px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -329px -3px; HEIGHT: 17px; OVERFLOW: hidden
}
.toc_expanded {
	WIDTH: 17px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -352px -3px; HEIGHT: 17px; OVERFLOW: hidden
}
.toc_empty {
	WIDTH: 17px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -375px -3px; HEIGHT: 17px; OVERFLOW: hidden
}
.cl_rss_button {
	WIDTH: 17px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -398px -3px; HEIGHT: 17px; OVERFLOW: hidden
}
.cl_CollapsibleArea_expanding {
	WIDTH: 9px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -421px -3px; HEIGHT: 12px; OVERFLOW: hidden
}
.cl_CollapsibleArea_collapsing {
	WIDTH: 9px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -436px -3px; HEIGHT: 12px; OVERFLOW: hidden
}
.topicNotInScopeInformationImage {
	TOP: -3px; LEFT: -451px
}
.cl_lw_vs_seperator {
	WIDTH: 1px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -473px -3px; HEIGHT: 17px; OVERFLOW: hidden
}
.cl_lw_vs_arrow {
	TOP: -3px; LEFT: -480px
}
.isd_settings {
	TOP: -3px; LEFT: -496px
}
.isd_print {
	TOP: -3px; LEFT: -528px
}
.isd_print_arrow {
	TOP: -3px; LEFT: -560px
}
.closedCaptionImage {
	TOP: -3px; LEFT: -604px
}
.muteImage {
	TOP: -3px; LEFT: -642px
}
.pausedImage {
	TOP: -3px; LEFT: -679px
}
.playImage {
	TOP: -3px; LEFT: -736px
}
.restartImage {
	TOP: -3px; LEFT: -793px
}
.rewindImage {
	TOP: -3px; LEFT: -831px
}
.skipImage {
	TOP: -3px; LEFT: -867px
}
.soundImage {
	TOP: -3px; LEFT: -904px
}
.tickImage {
	TOP: -3px; LEFT: -940px
}
.topicNotInScopeDropdownImage {
	TOP: -3px; LEFT: -957px
}
.cl_IC46226 {
	WIDTH: 11px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -974px -3px; HEIGHT: 11px; OVERFLOW: hidden
}
.cl_IC28506 {
	WIDTH: 11px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -991px -3px; HEIGHT: 11px; OVERFLOW: hidden
}
.cl_IC90381 {
	WIDTH: 16px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1008px -3px; HEIGHT: 16px; OVERFLOW: hidden
}
.cl_IC131682 {
	WIDTH: 15px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1030px -3px; HEIGHT: 15px; OVERFLOW: hidden
}
.cl_IC160177 {
	WIDTH: 10px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1051px -3px; HEIGHT: 10px; OVERFLOW: hidden
}
.cl_IC131792 {
	WIDTH: 17px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1067px -3px; HEIGHT: 11px; OVERFLOW: hidden
}
.cl_IC128933 {
	WIDTH: 16px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1090px -3px; HEIGHT: 16px; OVERFLOW: hidden
}
.cl_IC169559 {
	WIDTH: 16px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1112px -3px; HEIGHT: 16px; OVERFLOW: hidden
}
.cl_IC116110 {
	WIDTH: 12px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1134px -3px; HEIGHT: 10px; OVERFLOW: hidden
}
.cl_IC101471 {
	WIDTH: 16px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1152px -3px; HEIGHT: 14px; OVERFLOW: hidden
}
.cl_IC103139 {
	WIDTH: 10px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1174px -3px; HEIGHT: 10px; OVERFLOW: hidden
}
.cl_IC6709 {
	WIDTH: 16px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1190px -3px; HEIGHT: 16px; OVERFLOW: hidden
}
.cl_IC115567 {
	WIDTH: 16px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1212px -3px; HEIGHT: 16px; OVERFLOW: hidden
}
.cl_IC155188 {
	WIDTH: 17px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1234px -3px; HEIGHT: 16px; OVERFLOW: hidden
}
.cl_IC9948 {
	WIDTH: 16px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1257px -3px; HEIGHT: 16px; OVERFLOW: hidden
}
.cl_IC100399 {
	WIDTH: 16px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1279px -3px; HEIGHT: 16px; OVERFLOW: hidden
}
.cl_IC166620 {
	WIDTH: 16px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1301px -3px; HEIGHT: 16px; OVERFLOW: hidden
}
.cl_IC29808 {
	WIDTH: 16px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1323px -3px; HEIGHT: 16px; OVERFLOW: hidden
}
.cl_IC11304 {
	WIDTH: 16px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1345px -3px; HEIGHT: 16px; OVERFLOW: hidden
}
.cl_IC134134 {
	WIDTH: 16px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1367px -3px; HEIGHT: 16px; OVERFLOW: hidden
}
.cl_IC90369 {
	WIDTH: 10px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1389px -3px; HEIGHT: 12px; OVERFLOW: hidden
}
.cl_IC79755 {
	WIDTH: 16px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1405px -3px; HEIGHT: 16px; OVERFLOW: hidden
}
.cl_IC157541 {
	WIDTH: 16px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1427px -3px; HEIGHT: 16px; OVERFLOW: hidden
}
.cl_IC141795 {
	WIDTH: 16px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1449px -3px; HEIGHT: 16px; OVERFLOW: hidden
}
.cl_IC89523 {
	WIDTH: 16px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1471px -3px; HEIGHT: 16px; OVERFLOW: hidden
}
.cl_IC157062 {
	WIDTH: 16px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1493px -3px; HEIGHT: 16px; OVERFLOW: hidden
}
.cl_IC34952 {
	WIDTH: 16px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1515px -3px; HEIGHT: 16px; OVERFLOW: hidden
}
.cl_IC91302 {
	WIDTH: 16px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1537px -3px; HEIGHT: 11px; OVERFLOW: hidden
}
.cl_IC53205 {
	WIDTH: 16px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1559px -3px; HEIGHT: 16px; OVERFLOW: hidden
}
.cl_IC148674 {
	WIDTH: 16px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1581px -3px; HEIGHT: 16px; OVERFLOW: hidden
}
.cl_IC74937 {
	WIDTH: 16px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1603px -3px; HEIGHT: 16px; OVERFLOW: hidden
}
.cl_IC82306 {
	WIDTH: 16px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1625px -3px; HEIGHT: 16px; OVERFLOW: hidden
}
.cl_IC36774 {
	WIDTH: 16px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1647px -3px; HEIGHT: 16px; OVERFLOW: hidden
}
.cl_IC169559 {
	WIDTH: 16px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1669px -3px; HEIGHT: 16px; OVERFLOW: hidden
}
.cl_IC101171 {
	WIDTH: 7px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1691px -3px; HEIGHT: 10px; OVERFLOW: hidden
}
.cl_IC130242 {
	WIDTH: 13px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1704px -3px; HEIGHT: 10px; OVERFLOW: hidden
}
.cl_IC150820 {
	WIDTH: 16px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1723px -3px; HEIGHT: 16px; OVERFLOW: hidden
}
.cl_IC25161 {
	WIDTH: 16px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1745px -3px; HEIGHT: 16px; OVERFLOW: hidden
}
.cl_IC64394 {
	WIDTH: 16px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1767px -3px; HEIGHT: 16px; OVERFLOW: hidden
}
.cl_IC153696 {
	WIDTH: 14px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1789px -3px; HEIGHT: 18px; OVERFLOW: hidden
}
.cl_IC37116 {
	WIDTH: 16px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) no-repeat -1809px -3px; HEIGHT: 16px; OVERFLOW: hidden
}
#ux-header {
	Z-INDEX: 9998; POSITION: relative; PADDING-BOTTOM: 0px; LINE-HEIGHT: 1.538; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; FONT-FAMILY: ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif; COLOR: #959595; CLEAR: right; FONT-SIZE: 0.81em; PADDING-TOP: 20px
}
.MsdnPageBody #ux-header {
	PADDING-BOTTOM: 18px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; PADDING-TOP: 18px
}
#ux-header A {
	CURSOR: pointer; TEXT-DECORATION: none
}
#ux-header A:link {
	CURSOR: pointer; TEXT-DECORATION: none
}
#ux-header A:visited {
	CURSOR: pointer; TEXT-DECORATION: none
}
#ux-header .BrandLogo {
	MARGIN: 0px; FLOAT: left; HEIGHT: 32px; OVERFLOW: hidden
}
#ux-header .BrandLogo A {
	WIDTH: auto; DISPLAY: inline-block; MAX-WIDTH: 302px; BACKGROUND: 0px 50%; HEIGHT: auto; VERTICAL-ALIGN: top
}
#ux-header .BrandLogoImage {
	DISPLAY: block; MAX-WIDTH: 302px; FLOAT: left; MAX-HEIGHT: 30px; MARGIN-RIGHT: 10px
}
#ux-header .msdn.BrandLogoImage {
	MIN-WIDTH: 74px; MARGIN: 0px; BACKGROUND: url(/Areas/Epx/Themes/Msdn/Content/Images/logo.png) no-repeat 0px 0px; HEIGHT: 23px
}
#ux-header .localleftcap {
	DISPLAY: none
}
#ux-header .localrightcap {
	DISPLAY: none
}
#ux-header .topleftcorner {
	DISPLAY: none
}
#ux-header .toprightcorner {
	DISPLAY: none
}
#ux-header .bottomleftcorner {
	DISPLAY: none
}
#ux-header .bottomrightcorner {
	DISPLAY: none
}
#ux-header .GlobalBar {
	LINE-HEIGHT: 1.25; MARGIN: 0px; WIDTH: auto; FLOAT: right; FONT-SIZE: 12px; OVERFLOW: hidden
}
#ux-header .GlobalBar > DIV {
	FLOAT: left
}
#ux-header .GlobalBar .Divide {
	PADDING-LEFT: 6px; PADDING-RIGHT: 6px; COLOR: #ccc
}
.profileDivide {
	PADDING-LEFT: 6px; PADDING-RIGHT: 6px; COLOR: #ccc
}
#ux-header .GlobalBar A {
	COLOR: #3f3f3f
}
#ux-header #LocaleSelector {
	MAX-WIDTH: 270px; WHITE-SPACE: nowrap; FLOAT: left; OVERFLOW: hidden
}
#ux-header .LocaleManagementFlyoutStaticLink {
	MARGIN-RIGHT: 16px
}
#ux-header .UserName {
	TEXT-ALIGN: right; LINE-HEIGHT: 1.4; WIDTH: auto; CLEAR: both; FONT-SIZE: 13px; FONT-WEIGHT: bold
}
#ux-header .internav {
	BORDER-BOTTOM: #ccc 1px solid; PADDING-BOTTOM: 12px; MARGIN: 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; FONT: 14px ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif; CLEAR: both; PADDING-TOP: 5px
}
#ux-header .internav A {
	PADDING-BOTTOM: 0px; MARGIN: 0px 14px 0px 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; BACKGROUND: #fff; FLOAT: none; COLOR: #959595; PADDING-TOP: 0px
}
#ux-header .internav A:link {
	PADDING-BOTTOM: 0px; MARGIN: 0px 14px 0px 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; BACKGROUND: #fff; FLOAT: none; COLOR: #959595; PADDING-TOP: 0px
}
#ux-header .internav A:visited {
	PADDING-BOTTOM: 0px; MARGIN: 0px 14px 0px 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; BACKGROUND: #fff; FLOAT: none; COLOR: #959595; PADDING-TOP: 0px
}
#ux-header .internav A.active {
	BACKGROUND: 0px 50%; COLOR: #313131; FONT-WEIGHT: 500
}
#ux-header .internav A.active:hover {
	BACKGROUND: 0px 50%; COLOR: #313131; FONT-WEIGHT: 500
}
#ux-header .internav A.active:visited {
	BACKGROUND: 0px 50%; COLOR: #313131; FONT-WEIGHT: 500
}
#ux-header .internav A.active:focus {
	BACKGROUND: 0px 50%; COLOR: #313131; FONT-WEIGHT: 500
}
#ux-header .internav A:hover {
	BACKGROUND: 0px 50%; COLOR: #000
}
#ux-header .internav A:focus {
	BACKGROUND: 0px 50%; COLOR: #000
}
#ux-header .internav A:first-child {
	MARGIN-LEFT: 0px
}
#ux-header .internav A:first-child:link {
	MARGIN-LEFT: 0px
}
#ux-header .internav A:first-child:visited {
	MARGIN-LEFT: 0px
}
#ux-header .HeaderTabs {
	BORDER-BOTTOM: #d9d9d9 1px solid; POSITION: relative; PADDING-BOTTOM: 5px; TEXT-TRANSFORM: uppercase; MARGIN: 0px; PADDING-LEFT: 6px; PADDING-RIGHT: 0px; FONT: bold 11px ""Segoe UI Semibold"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif; WHITE-SPACE: nowrap; HEIGHT: auto; OVERFLOW: hidden; PADDING-TOP: 6px
}
#ux-header .LocalNavigation .TabOff {
	FLOAT: left; MARGIN-RIGHT: 15px
}
#ux-header .LocalNavigation .TabOn {
	FLOAT: left; MARGIN-RIGHT: 15px
}
#ux-header .LocalNavigation .TabOn {
	PADDING-BOTTOM: 3px; PADDING-LEFT: 5px; PADDING-RIGHT: 5px; PADDING-TOP: 3px
}
#ux-header .LocalNavigation .TabOn A {
	COLOR: #eb3c00
}
#ux-header .LocalNavigation .TabOn A:hover {
	COLOR: #eb3c00
}
#ux-header .LocalNavigation .TabOff A {
	PADDING-BOTTOM: 3px; PADDING-LEFT: 5px; PADDING-RIGHT: 5px; WHITE-SPACE: nowrap; FLOAT: left; COLOR: #666; CURSOR: pointer; PADDING-TOP: 3px
}
#ux-header .LocalNavigation .TabOff A:hover {
	COLOR: #000
}
#ux-header #HeaderSearchButton {
	POSITION: relative; TEXT-ALIGN: right; PADDING-BOTTOM: 0px; BORDER-RIGHT-WIDTH: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: 32px; PADDING-RIGHT: 0px; DISPLAY: inline-block; BACKGROUND: url(/Areas/Epx/Themes/Msdn/Content/search.png) #5c626a no-repeat 8px 50%; FLOAT: right; BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; HEIGHT: 25px; VERTICAL-ALIGN: top; OVERFLOW: hidden; BORDER-LEFT-WIDTH: 0px; CURSOR: pointer; PADDING-TOP: 0px
}
.FF#ux-header #HeaderSearchButton {
	WIDTH: 32px; HEIGHT: 26px
}
.IE7#ux-header #HeaderSearchButton {
	FLOAT: none; TOP: 1px
}
#ux-header .PassportScarab {
	PADDING-BOTTOM: 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; WHITE-SPACE: nowrap; FLOAT: left; PADDING-TOP: 0px
}
#ux-header .SearchBox {
	BORDER-BOTTOM: 0px; BORDER-LEFT: 0px; PADDING-BOTTOM: 0px; MARGIN-TOP: -5px; PADDING-LEFT: 0px; WIDTH: 215px; PADDING-RIGHT: 0px; DISPLAY: inline-block; FLOAT: right; HEIGHT: 24px; BORDER-TOP: 0px; BORDER-RIGHT: 0px; PADDING-TOP: 0px
}
#ux-header #SuggestionContainer LI {
	LIST-STYLE: none none outside; BACKGROUND: none transparent scroll repeat 0% 0%
}
#ux-header .LocaleManagementFlyoutPopup {
	Z-INDEX: 1000; BORDER-BOTTOM: #b8b8b8 1px solid; POSITION: absolute; TEXT-ALIGN: left; BORDER-LEFT: #b8b8b8 1px solid; PADDING-BOTTOM: 3px; BACKGROUND-COLOR: #fff; PADDING-LEFT: 3px; PADDING-RIGHT: 3px; DISPLAY: none; COLOR: #000; BORDER-TOP: #b8b8b8 1px solid; BORDER-RIGHT: #b8b8b8 1px solid; PADDING-TOP: 3px
}
#ux-header .LocaleManagementFlyoutPopup A {
	TEXT-ALIGN: left; PADDING-BOTTOM: 1px; PADDING-LEFT: 3px; PADDING-RIGHT: 3px; DISPLAY: block; WHITE-SPACE: nowrap; HEIGHT: 15px; COLOR: #000; FONT-SIZE: 10px; TEXT-DECORATION: none; PADDING-TOP: 1px
}
#ux-header .LocaleManagementFlyoutPopup A:visited {
	TEXT-ALIGN: left; PADDING-BOTTOM: 1px; PADDING-LEFT: 3px; PADDING-RIGHT: 3px; DISPLAY: block; WHITE-SPACE: nowrap; HEIGHT: 15px; COLOR: #000; FONT-SIZE: 10px; TEXT-DECORATION: none; PADDING-TOP: 1px
}
#ux-header .LocaleManagementFlyoutPopup A:hover {
	PADDING-BOTTOM: 1px; BACKGROUND-COLOR: #f0f7fd; PADDING-LEFT: 3px; PADDING-RIGHT: 3px; DISPLAY: block; WHITE-SPACE: nowrap; HEIGHT: 15px; TEXT-DECORATION: none; PADDING-TOP: 1px
}
#ux-header .LocaleManagementFlyoutPopup A:active {
	PADDING-BOTTOM: 1px; BACKGROUND-COLOR: #f0f7fd; PADDING-LEFT: 3px; PADDING-RIGHT: 3px; DISPLAY: block; WHITE-SPACE: nowrap; HEIGHT: 15px; TEXT-DECORATION: none; PADDING-TOP: 1px
}
#ux-header .LocaleManagementFlyoutPopupHr {
	MARGIN: 0px 11px 21px; BACKGROUND: #d0e0f0; HEIGHT: 1px
}
#ux-header .LocaleManagementFlyoutStatic {
	PADDING-BOTTOM: 1px; MARGIN: 1px; PADDING-LEFT: 3px; PADDING-RIGHT: 3px; DISPLAY: inline; WHITE-SPACE: nowrap; CURSOR: default; TEXT-DECORATION: none; PADDING-TOP: 1px
}
#ux-header .LocaleManagementFlyoutStaticHover {
	PADDING-BOTTOM: 1px; MARGIN: 1px; PADDING-LEFT: 3px; PADDING-RIGHT: 3px; DISPLAY: inline; WHITE-SPACE: nowrap; CURSOR: default; TEXT-DECORATION: none; PADDING-TOP: 1px
}
#ux-header A.LocaleManagementFlyoutStaticLink {
	DISPLAY: inline; WHITE-SPACE: nowrap; TEXT-DECORATION: none
}
#ux-header A.LocaleManagementFlyoutStaticLink:visited {
	DISPLAY: inline; WHITE-SPACE: nowrap; TEXT-DECORATION: none
}
#ux-header A.LocaleManagementFlyoutStaticLink:active {
	DISPLAY: inline; WHITE-SPACE: nowrap; TEXT-DECORATION: none
}
#ux-header .GlobalBar A:hover {
	TEXT-DECORATION: underline
}
#ux-header .GlobalBar .Icons {
	FLOAT: left
}
#ux-header .GlobalBar .Icons IMG {
	TOP: -6px
}
#ux-header UL {
	MARGIN-LEFT: 0px
}
#ux-header OL {
	MARGIN-LEFT: 0px
}
#ux-header OL {
	PADDING-BOTTOM: 0px; PADDING-LEFT: 18px; PADDING-RIGHT: 0px; PADDING-TOP: 0px
}
#ux-header #Fragment_SearchBox {
	MARGIN-TOP: -5px; DISPLAY: inline-block; FLOAT: right
}
A#idPPScarab:hover {
	TEXT-DECORATION: underline
}
A.createProfileLink:hover {
	TEXT-DECORATION: underline
}
#ux-header #HeaderSearchForm {
	BORDER-BOTTOM: 0px; BORDER-LEFT: 0px; FONT-SIZE: 12px; BORDER-TOP: 0px; BORDER-RIGHT: 0px
}
#ux-header #HeaderSearchTextBox {
	PADDING-BOTTOM: 4px; BACKGROUND-COLOR: #dedfe1; FONT-STYLE: normal !important; PADDING-LEFT: 7px; WIDTH: 172px; PADDING-RIGHT: 0px; FONT-FAMILY: ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif; COLOR: #a1a1a1 !important; PADDING-TOP: 3px
}
#ux-header #HeaderSearchForm INPUT {
	BORDER-BOTTOM: 0px; BORDER-LEFT: 0px; MARGIN: 0px; OUTLINE-STYLE: none; OUTLINE-COLOR: invert; OUTLINE-WIDTH: medium; FLOAT: left; BORDER-TOP: 0px; BORDER-RIGHT: 0px
}
#ux-header #HeaderSearchForm INPUT:active {
	BORDER-BOTTOM: 0px; BORDER-LEFT: 0px; MARGIN: 0px; OUTLINE-STYLE: none; OUTLINE-COLOR: invert; OUTLINE-WIDTH: medium; FLOAT: left; BORDER-TOP: 0px; BORDER-RIGHT: 0px
}
#ux-header #HeaderSearchForm BUTTON {
	BORDER-BOTTOM: 0px; BORDER-LEFT: 0px; MARGIN: 0px; OUTLINE-STYLE: none; OUTLINE-COLOR: invert; OUTLINE-WIDTH: medium; FLOAT: left; BORDER-TOP: 0px; BORDER-RIGHT: 0px
}
#ux-header #HeaderSearchForm BUTTON:active {
	BORDER-BOTTOM: 0px; BORDER-LEFT: 0px; MARGIN: 0px; OUTLINE-STYLE: none; OUTLINE-COLOR: invert; OUTLINE-WIDTH: medium; FLOAT: left; BORDER-TOP: 0px; BORDER-RIGHT: 0px
}
.rtl#ux-header .SearchBox {
	FLOAT: left
}
.rtl#ux-header .GlobalBar {
	FLOAT: left
}
.rtl#ux-header #HeaderSearchForm INPUT {
	FLOAT: right
}
.rtl#ux-header #HeaderSearchForm INPUT:active {
	FLOAT: right
}
.rtl#ux-header #HeaderSearchForm BUTTON {
	FLOAT: right
}
.rtl#ux-header #HeaderSearchForm BUTTON:active {
	FLOAT: right
}
.rtl#ux-header .BrandLogo {
	FLOAT: right
}
.rtl#ux-header #LocaleSelector {
	FLOAT: right
}
.rtl#ux-header .GlobalBar > DIV {
	FLOAT: right
}
.rtl#ux-header .GlobalBar .Icons {
	FLOAT: right
}
.rtl#ux-header .internav {
	MAX-WIDTH: none
}
DIV#leftNav {
	POSITION: relative; MARGIN: 0px 28px 0px 0px; WIDTH: 215px; FLOAT: left
}
DIV#tocnav {
	LINE-HEIGHT: normal; OVERFLOW-X: hidden; FONT-FAMILY: ""Segoe UI"", Verdana, Arial; FONT-SIZE: 1em
}
DIV#tocnav > DIV {
	OVERFLOW-X: hidden; WIDTH: auto; WHITE-SPACE: normal; MARGIN-BOTTOM: 10px
}
DIV#tocnav > DIV > A {
	DISPLAY: block; COLOR: #1364c4; MARGIN-LEFT: 22px; OVERFLOW: hidden; TEXT-DECORATION: none
}
DIV#tocnav > DIV > A:link {
	DISPLAY: block; COLOR: #1364c4; MARGIN-LEFT: 22px; OVERFLOW: hidden; TEXT-DECORATION: none
}
DIV#tocnav > DIV > A:visited {
	DISPLAY: block; COLOR: #1364c4; MARGIN-LEFT: 22px; OVERFLOW: hidden; TEXT-DECORATION: none
}
DIV#tocnav > DIV.current > A {
	COLOR: #e66a38; TEXT-DECORATION: none
}
DIV#tocnav > DIV.current > A:link {
	COLOR: #e66a38; TEXT-DECORATION: none
}
DIV#tocnav > DIV.current > A:visited {
	COLOR: #e66a38; TEXT-DECORATION: none
}
DIV#tocnav > DIV > A.toc_expanded {
	DISPLAY: inline-block; FLOAT: left; MARGIN-LEFT: 0px; VERTICAL-ALIGN: top
}
DIV#tocnav > DIV > A.toc_collapsed {
	DISPLAY: inline-block; FLOAT: left; MARGIN-LEFT: 0px; VERTICAL-ALIGN: top
}
DIV#tocnav > DIV > SPAN.toc_empty {
	DISPLAY: inline-block; FLOAT: left; MARGIN-LEFT: 0px; VERTICAL-ALIGN: top
}
DIV#tocnav > DIV > SPAN.toc_empty {
	OUTLINE-STYLE: none; OUTLINE-COLOR: invert; OUTLINE-WIDTH: medium; BACKGROUND: none transparent scroll repeat 0% 0%
}
DIV#tocnav > DIV.toclevel1 {
	PADDING-LEFT: 13px
}
DIV#tocnav > DIV.toclevel2 {
	PADDING-LEFT: 26px
}
DIV#tocnav > DIV.toclevel3 {
	PADDING-LEFT: 39px
}
DIV#tocnav > DIV.toclevel4 {
	PADDING-LEFT: 52px
}
DIV#tocnav > DIV.toclevel5 {
	PADDING-LEFT: 65px
}
DIV#tocnav > DIV.toclevel6 {
	PADDING-LEFT: 78px
}
DIV#tocnav > DIV.toclevel7 {
	PADDING-LEFT: 91px
}
DIV#tocnav > DIV.toclevel8 {
	PADDING-LEFT: 104px
}
DIV#tocnav > DIV.toclevel9 {
	PADDING-LEFT: 117px
}
DIV#tocnav > DIV.toclevel10 {
	PADDING-LEFT: 130px
}
A#NavigationResize {
	POSITION: absolute; MARGIN: 0px; WIDTH: 7px; DISPLAY: none; HEIGHT: 22px; OVERFLOW: hidden; TOP: 12px; CURSOR: pointer
}
A#NavigationResize > IMG {
	BORDER-BOTTOM: medium none; POSITION: relative; BORDER-LEFT: medium none; MAX-WIDTH: none; BORDER-TOP: medium none; BORDER-RIGHT: medium none
}
DIV#leftNav {
	MARGIN: 0px -1px 0px 0px; BORDER-RIGHT: #b6b6b6 1px solid
}
DIV.leftNavResize0#leftNav {
	WIDTH: 0px
}
DIV.leftNavResize1#leftNav {
	WIDTH: 280px
}
DIV.leftNavResize2#leftNav {
	WIDTH: 380px
}
DIV.leftNavResize3#leftNav {
	WIDTH: 480px
}
DIV.leftNavResize0#leftNav > DIV {
	DISPLAY: none
}
DIV#content {
	BORDER-LEFT: #b6b6b6 1px solid; MARGIN: 0px; PADDING-LEFT: 20px
}
#ratingCounter {
	MARGIN: 0px 0px 10px; DISPLAY: none; FONT-FAMILY: ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif; FONT-SIZE: 1em
}
#ratingCounter .ratingText {
	COLOR: #5d5d5d
}
.lw_vs {
	POSITION: relative; PADDING-BOTTOM: 2px; MARGIN-TOP: -8px; MARGIN-BOTTOM: 10px
}
.lw_vs DIV {
	FLOAT: left
}
.cl_lw_vs_seperator {
	MARGIN-LEFT: 10px
}
.cl_lw_vs_seperatorhide {
	WIDTH: 8px; HEIGHT: 17px; OVERFLOW: hidden
}
#vsLink {
	MARGIN-LEFT: 10px; FONT-SIZE: 1em; MARGIN-RIGHT: 4px
}
.cl_vs_arrow {
	MARGIN-TOP: 5px; CURSOR: pointer; MARGIN-RIGHT: 5px
}
#vsPanel {
	Z-INDEX: 2; BORDER-BOTTOM: #bdbdbd 1px solid; POSITION: absolute; BORDER-LEFT: #bdbdbd 1px solid; PADDING-BOTTOM: 10px; BACKGROUND-COLOR: #fff; LIST-STYLE-TYPE: none; MARGIN: 0px; PADDING-LEFT: 10px; PADDING-RIGHT: 10px; DISPLAY: none; BORDER-TOP: #bdbdbd 1px solid; TOP: 20px; BORDER-RIGHT: #bdbdbd 1px solid; PADDING-TOP: 10px
}
#vsPanel A:visited {
	COLOR: #960bb4
}
#vsPanel LI {
	MARGIN-BOTTOM: 2px; FONT-SIZE: 1em
}
#contentFeedback {
	BORDER-BOTTOM: #d2d2d2 1px solid; BORDER-LEFT: #d2d2d2 1px solid; PADDING-BOTTOM: 10px; BACKGROUND-COLOR: #f1f1f1; MARGIN: 30px 0px; PADDING-LEFT: 10px; PADDING-RIGHT: 10px; FONT-FAMILY: ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif; COLOR: #707070; CLEAR: both; FONT-SIZE: 12px; BORDER-TOP: #d2d2d2 1px solid; BORDER-RIGHT: #d2d2d2 1px solid; PADDING-TOP: 10px
}
#contentFeedbackQAContainer {
	MARGIN-TOP: 10px; DISPLAY: none
}
#contentFeedback .FeedbackTitleContainer {
	FONT-FAMILY: ""Segoe UI""; COLOR: #636363; FONT-SIZE: 0.92em
}
#contentFeedback .FeedbackTitleContainer > INPUT[type='radio'] {
	MARGIN-LEFT: 20px; MARGIN-RIGHT: 10px
}
#contentFeedback .FeedbackListContainer {
	PADDING-BOTTOM: 20px; PADDING-TOP: 10px
}
#contentFeedback .FeedbackListContainer > DIV {
	FONT-FAMILY: ""Segoe UI""; COLOR: #636363; FONT-SIZE: 0.92em
}
#contentFeedback .FeedbackTellUsMoreContainer {
	WIDTH: 100%; DISPLAY: table; MARGIN-BOTTOM: 10px; CLEAR: both; OVERFLOW: hidden
}
#contentFeedback LABEL {
	DISPLAY: inline
}
#contentFeedback INPUT[type='submit'] {
	PADDING-BOTTOM: 1px; PADDING-LEFT: 6px; PADDING-RIGHT: 6px; FONT-SIZE: 13px; PADDING-TOP: 1px
}
.FeedbackTellUsMoreContainer > TEXTAREA {
	BORDER-BOTTOM: 1px solid; BORDER-LEFT: 1px solid; PADDING-BOTTOM: 5px; MARGIN: 0px; PADDING-LEFT: 5px; WIDTH: 98%; PADDING-RIGHT: 5px; FONT-FAMILY: ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif !important; HEIGHT: 100px; COLOR: #636363; FONT-SIZE: 0.92em; BORDER-TOP: 1px solid; BORDER-RIGHT: 1px solid; PADDING-TOP: 5px
}
.FeedbackTellUsMoreContainer .TellUsMoreTextBoxSearch {
	COLOR: #000
}
.FeedbackTellUsMoreContainer .TellUsMoreTextBoxSearchLoaded {
	COLOR: #949494
}
#contentFeedback SPAN.counter {
	FONT-STYLE: italic; FONT-FAMILY: ""Segoe UI""; COLOR: #636363; FONT-SIZE: 0.84em
}
#contentFeedback INPUT[type='submit'] {
	FLOAT: right
}
#ux-footer {
	Z-INDEX: 9999; PADDING-BOTTOM: 0px; MARGIN: auto; PADDING-LEFT: 0px; WIDTH: 980px; PADDING-RIGHT: 0px; FONT-FAMILY: ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif; FONT-SIZE: 13px; PADDING-TOP: 0px
}
.ux-footer-clear {
	BORDER-BOTTOM: #bbb 1px solid; CLEAR: both
}
#ux-footer #footerRight {
	FLOAT: right; PADDING-TOP: 14px
}
#ux-footer #footerLeft {
	FLOAT: right; PADDING-TOP: 38px
}
#ux-footer #footerLeft A {
	COLOR: #2e2e2e; FONT-SIZE: 12px; VERTICAL-ALIGN: middle; TEXT-DECORATION: none
}
#ux-footer #Feedback {
	FLOAT: left
}
#ux-footer #LinkGroup {
	FLOAT: left
}
#ux-footer #FooterLogo {
	WIDTH: 90px; BACKGROUND: url(/Areas/Epx/Content/Images/ImageSprite.png) -3px -3px; FLOAT: right; HEIGHT: 16px; OVERFLOW: hidden
}
#ux-footer #FooterCopyright {
	PADDING-TOP: 24px
}
.IE7#ux-footer #FooterLogoContainer {
	WIDTH: 100px
}
.IE7#ux-footer #FooterCopyright {
	PADDING-TOP: 0px
}
.IE7#ux-footer #FooterRight {
	WIDTH: 300px
}
.IE7#ux-footer .FooterSiteFeedBack {
	WIDTH: 140px; FLOAT: right
}
#ux-footer-cols UL {
	PADDING-BOTTOM: 0px; LIST-STYLE-TYPE: none; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; BACKGROUND: none transparent scroll repeat 0% 0%; PADDING-TOP: 0px
}
#ux-footer-cols .linksContainer UL.links LI.linksTitle A {
	PADDING-BOTTOM: 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; COLOR: #444; PADDING-TOP: 0px
}
#ux-footer-cols .linksContainer A {
	PADDING-BOTTOM: 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; COLOR: #888; TEXT-DECORATION: none; PADDING-TOP: 0px
}
#Footer .linksContainer A:link {
	PADDING-BOTTOM: 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; COLOR: #888; TEXT-DECORATION: none; PADDING-TOP: 0px
}
#Footer .linksContainer A:visited {
	PADDING-BOTTOM: 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; COLOR: #888; TEXT-DECORATION: none; PADDING-TOP: 0px
}
#ux-footer-cols .linksContainer A:hover {
	COLOR: #007acc
}
#Footer .linksContainer A:focus {
	COLOR: #007acc
}
#Footer .linksTitle A:hover {
	COLOR: #007acc
}
#Footer .linksTitle A:focus {
	COLOR: #007acc
}
#ux-footer-cols .linksContainer UL.links:first-child {
	MARGIN-LEFT: 0px
}
#ux-footer-cols .linksContainer UL.links LI.linksTitle {
	PADDING-BOTTOM: 0.5em; LINE-HEIGHT: 1.4; TEXT-TRANSFORM: uppercase; FONT-WEIGHT: bold
}
#ux-footer-cols LI {
	PADDING-BOTTOM: 3px; LINE-HEIGHT: 1.5; LIST-STYLE-TYPE: none; PADDING-LEFT: 12px; PADDING-RIGHT: 0px; BACKGROUND: none transparent scroll repeat 0% 0%; PADDING-TOP: 0px
}
.IE7#ux-footer-cols {
	MIN-HEIGHT: 100%; DISPLAY: block; CLEAR: both
}
#ux-footer-cols {
	Z-INDEX: 9999; MARGIN: 0px; FONT-FAMILY: ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif
}
#ux-footer-cols .linksContainer {
	PADDING-BOTTOM: 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; PADDING-TOP: 20px
}
#ux-footer-cols .linksContainer UL.links {
	LIST-STYLE-TYPE: none; WIDTH: 193px; MARGIN-BOTTOM: 1.5em; FLOAT: left; MARGIN-LEFT: 0px
}
#ux-footer .LinkList {
	PADDING-BOTTOM: 0px; PADDING-LEFT: 8px; PADDING-RIGHT: 8px; FLOAT: left; COLOR: #707070; PADDING-TOP: 0px
}
#ux-footer .LinksDivider {
	PADDING-BOTTOM: 0px; PADDING-LEFT: 8px; PADDING-RIGHT: 8px; FLOAT: left; COLOR: #707070; PADDING-TOP: 0px
}
#ux-footer .FooterSiteFeedBack {
	PADDING-BOTTOM: 0px; PADDING-LEFT: 4px; PADDING-RIGHT: 4px; FLOAT: left; COLOR: #707070; PADDING-TOP: 0px
}
#ux-footer .LinkColumn {
	FLOAT: left
}
#ux-footer #Fragment_FooterLinks {
	FLOAT: right
}
#ux-footer #Fragment_FooterLinksBottom {
	FLOAT: right
}
#ux-footer .feedbackListItem {
	MARGIN-LEFT: -4px
}
.rtl#ux-footer #footerLeft {
	FLOAT: left
}
.rtl#ux-footer .footerRight {
	FLOAT: left
}
.rtl#ux-footer #footerRight {
	FLOAT: left
}
.rtl#ux-footer #FooterLogo {
	FLOAT: left
}
.rtl#ux-footer .feedbackListItem .LinksDivider {
	FLOAT: left
}
.rtl#ux-footer .LinkList {
	FLOAT: right
}
.rtl#ux-footer .LinkColumn {
	FLOAT: right
}
.rtl#ux-footer .LinksDivider {
	FLOAT: right
}
.rtl#ux-footer .FooterSiteFeedBack .FeedbackButton {
	MARGIN: -3px 8px 0px 0px; FLOAT: left
}
.LinkList {
	
}
.LinkList .Description {
	FONT-SIZE: 12px
}
.LinkList A {
	LINE-HEIGHT: 1.5; DISPLAY: inline-block
}
.LinkList DIV.Bulleted A {
	PADDING-LEFT: 24px; BACKGROUND: url(/Areas/Epx/Content/Images/Arrow.gif) no-repeat left center
}
.LinkList DIV.LinkColumn {
	FLOAT: left
}
.LinkList DIV.LinkColumnWithPadding A {
	PADDING-RIGHT: 5px
}
.LinkList .LinksDivider {
	FLOAT: left
}
.SiteFeedbackLinkButton {
	POSITION: relative; MARGIN-TOP: -2px; DISPLAY: inline-block; MARGIN-LEFT: 3px; VERTICAL-ALIGN: middle; OVERFLOW: hidden
}
.SiteFeedbackLinkLink {
	DISPLAY: inline-block; COLOR: #1364c4; MARGIN-LEFT: 1px; VERTICAL-ALIGN: top; CURSOR: pointer
}
.SiteFeedbackLinkLink .a:hover {
	TEXT-DECORATION: underline
}
.SiteFeedbackLinkButton IMG {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.SiteFeedbackLinkButton INPUT {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.SiteFeedbackLinkContainer {
	Z-INDEX: 9999; BORDER-BOTTOM: #7d7d7d 1px solid; POSITION: absolute; BORDER-LEFT: #7d7d7d 1px solid; BACKGROUND-COLOR: #fff; MARGIN-TOP: -16.7em; MIN-HEIGHT: 25em; WIDTH: 24.8em; MARGIN-LEFT: -5.2em; BORDER-TOP: #7d7d7d 1px solid; TOP: 50%; BORDER-RIGHT: #7d7d7d 1px solid; LEFT: 50%
}
.SiteFeedbackLinkContainer .SiteFeedbackLinkTitleContainer {
	BACKGROUND-COLOR: #f4b432; PADDING-LEFT: 11px; HEIGHT: 1.5em; COLOR: #646364; FONT-SIZE: 1.24em; FONT-WEIGHT: bold
}
.SiteFeedbackLinkContainer .SiteFeedbackLinkTitle {
	FLOAT: left
}
.SiteFeedbackLinkContainer .SiteFeedbackLinkCancel {
	TEXT-ALIGN: right; PADDING-RIGHT: 10px; FLOAT: right; CURSOR: pointer
}
.SiteFeedbackLinkContainer .SiteFeedbackLinkCancel A:link {
	COLOR: #646364; TEXT-DECORATION: none
}
.SiteFeedbackLinkContainer .SiteFeedbackLinkCancel A:hover {
	COLOR: #646364; TEXT-DECORATION: none
}
.SiteFeedbackLinkContainer .SiteFeedbackLinkCancel A:visited {
	COLOR: #646364; TEXT-DECORATION: none
}
.SiteFeedbackLinkContainer .SiteFeedbackLinkData {
	PADDING-LEFT: 10px; PADDING-RIGHT: 10px
}
.SiteFeedbackLinkContainer .SiteFeedbackLinkInfoText {
	COLOR: #5a5a5a; FONT-SIZE: 1.08em; PADDING-TOP: 11px
}
.SiteFeedbackLinkContainer .QuestionText {
	MARGIN-TOP: 11px; COLOR: #2d2d2d; FONT-SIZE: 1.08em
}
.SiteFeedbackLinkContainer .AnswerText {
	VERTICAL-ALIGN: bottom
}
.SiteFeedbackLinkContainer .AnswerText SPAN {
	COLOR: #5a5a5a; MARGIN-RIGHT: 10px
}
.SiteFeedbackLinkContainer .SiteFeedbackLinkTextArea {
	BORDER-BOTTOM: #bbb 1px solid; BORDER-LEFT: #bbb 1px solid; BACKGROUND-COLOR: #fff; WIDTH: 99%; FONT-FAMILY: ""Segoe UI"", Verdana, Arial; HEIGHT: 5.4em; OVERFLOW: hidden; BORDER-TOP: #bbb 1px solid; BORDER-RIGHT: #bbb 1px solid
}
.SiteFeedbackLinkContainer .SiteFeedbackLinkSubmit {
	MARGIN-TOP: 11px; FONT-FAMILY: ""Segoe UI"", Verdana, Arial; FLOAT: right; FONT-SIZE: 1.08em
}
.SiteFeedbackLinkContainer .SiteFeedbackLinkTextAreaContainer {
	
}
.SiteFeedbackLinkContainer .SiteFeedbackLinkSiderGraphic {
	POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: auto; PADDING-RIGHT: 0px; HEIGHT: auto; PADDING-TOP: 0px
}
.SiteFeedbackLinkContainer .SiteFeedbackLinkGraphicHolder {
	POSITION: relative; MARGIN-TOP: 11px; DISPLAY: inline-block; MARGIN-BOTTOM: 11px; MARGIN-LEFT: 11px; OVERFLOW: hidden
}
.SiteFeedbackLinkContainer .RateRadioOne {
	WIDTH: 40px; FLOAT: left
}
.SiteFeedbackLinkContainer .RateRadio {
	WIDTH: 63px; FLOAT: left
}
.SiteFeedbackLinkContainer .RateRadioLast {
	WIDTH: 40px; FLOAT: left
}
.RateRadioOne INPUT {
	PADDING-BOTTOM: 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; MARGIN-LEFT: 5%; PADDING-TOP: 0px
}
.RateRadio INPUT {
	PADDING-BOTTOM: 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; MARGIN-LEFT: 40%; MARGIN-RIGHT: 44%; PADDING-TOP: 0px
}
.RateRadioLast INPUT {
	PADDING-BOTTOM: 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; MARGIN-LEFT: 65%; MARGIN-RIGHT: 1%; PADDING-TOP: 0px
}
.SiteFeedbackLinkContainer .TellUsMoreText {
	CLEAR: both; PADDING-TOP: 11px
}
.SiteFeedbackLinkContainer .SiteFeedbackLinkCollapse {
	DISPLAY: none
}
.SiteFeedbackLinkContainer .RadioButtonHolder {
	HEIGHT: 22px; MARGIN-LEFT: 7px
}
.FooterSiteFeedBack .FeedbackButton {
	POSITION: relative; PADDING-BOTTOM: 0px; MARGIN: -3px 0px 0px 8px; PADDING-LEFT: 0px; WIDTH: 21px; PADDING-RIGHT: 0px; DISPLAY: inline-block; FLOAT: right; HEIGHT: 21px; VERTICAL-ALIGN: middle; OVERFLOW: hidden; PADDING-TOP: 0px
}
BODY {
	MARGIN: 0px auto; PADDING-LEFT: 12px; PADDING-RIGHT: 12px; MAX-WIDTH: 1220px; FONT-SIZE: 12px
}
DIV#body {
	MARGIN: 0px
}
TABLE {
	PADDING-BOTTOM: 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; PADDING-TOP: 0px
}
DIV#content TABLE {
	BORDER-BOTTOM: #bbb 1px solid; BORDER-LEFT: #bbb 1px solid; BORDER-TOP: #bbb 1px solid; BORDER-RIGHT: #bbb 1px solid
}
DIV#content TH {
	BORDER-BOTTOM: #bbb 1px solid; BORDER-LEFT: #bbb 1px solid; BORDER-TOP: #bbb 1px solid; BORDER-RIGHT: #bbb 1px solid
}
DIV#content TD {
	BORDER-BOTTOM: #bbb 1px solid; BORDER-LEFT: #bbb 1px solid; BORDER-TOP: #bbb 1px solid; BORDER-RIGHT: #bbb 1px solid
}
.contentWrapper H2 A {
	COLOR: #000
}
.contentWrapper H3 A {
	COLOR: #000
}
.heading {
	COLOR: #000
}
H1 {
	COLOR: #707070; FONT-SIZE: 3em
}
H1.heading {
	COLOR: #707070; FONT-SIZE: 3em
}
H2 {
	COLOR: #2a2a2a
}
H3 {
	COLOR: #2a2a2a
}
H4 {
	COLOR: #2a2a2a
}
H2 {
	FONT-SIZE: 1.83em
}
.subheading {
	FONT-SIZE: 1.83em
}
H3 {
	FONT-SIZE: 1.5em
}
H4 {
	FONT-SIZE: 1.33em
}
.topic A {
	COLOR: #1364c4; TEXT-DECORATION: none
}
.topic A:link {
	COLOR: #1364c4; TEXT-DECORATION: none
}
.topic A:visited {
	COLOR: #03697a; TEXT-DECORATION: none
}
.topic A:active {
	COLOR: #03697a; TEXT-DECORATION: none
}
.topic A:hover {
	COLOR: #3390b1; TEXT-DECORATION: none
}
.topic A.active {
	COLOR: #2a2a2a
}
.topic A.active:link {
	COLOR: #2a2a2a
}
.topic A.active:hover {
	COLOR: #2a2a2a
}
.topic A.active:visited {
	COLOR: #2a2a2a
}
.topic A.active:active {
	COLOR: #2a2a2a
}
.communityContentHeaderTitle {
	COLOR: #000
}
.communityEditor .additionTopicTitle {
	COLOR: #000
}
DIV#leftNav {
	WIDTH: 280px
}
DIV#tocnav {
	MARGIN: -20px 0px 0px -4px; FONT-SIZE: 1.08em
}
DIV#tocnav > DIV {
	MARGIN-BOTTOM: 5px
}
DIV#tocnav > DIV > A {
	MARGIN-LEFT: 18px
}
DIV#tocnav > DIV > A:link {
	MARGIN-LEFT: 18px
}
DIV#tocnav > DIV > A:visited {
	MARGIN-LEFT: 18px
}
DIV#tocnav > DIV > SPAN.toc_empty {
	MARGIN-LEFT: 18px
}
DIV#tocnav > DIV.current > A {
	COLOR: #000; FONT-WEIGHT: bold
}
DIV#tocnav > DIV.current > A:link {
	COLOR: #000; FONT-WEIGHT: bold
}
DIV#tocnav > DIV.current > A:hover {
	COLOR: #000; FONT-WEIGHT: bold
}
DIV#tocnav > DIV.current > A:focus {
	COLOR: #000; FONT-WEIGHT: bold
}
DIV#tocnav > DIV.current > A:visited {
	COLOR: #000; FONT-WEIGHT: bold
}
DIV#tocnav > DIV.toclevel1 {
	PADDING-LEFT: 17px
}
DIV#tocnav > DIV.toclevel2 {
	PADDING-LEFT: 34px
}
DIV#tocnav > DIV.toclevel3 {
	PADDING-LEFT: 51px
}
DIV#tocnav > DIV.toclevel4 {
	PADDING-LEFT: 68px
}
DIV#tocnav > DIV.toclevel5 {
	PADDING-LEFT: 85px
}
DIV#tocnav > DIV.toclevel6 {
	PADDING-LEFT: 102px
}
DIV#tocnav > DIV.toclevel7 {
	PADDING-LEFT: 119px
}
DIV#tocnav > DIV.toclevel8 {
	PADDING-LEFT: 136px
}
DIV#tocnav > DIV.toclevel9 {
	PADDING-LEFT: 153px
}
DIV#tocnav > DIV.toclevel10 {
	PADDING-LEFT: 170px
}
A#NavigationResize {
	TOP: 44px
}
.LW_CollapsibleArea_Title {
	FONT-FAMILY: ""Segoe UI"", ""Lucida Grande"", Verdana, Arial, Helvetica, sans-serif
}
.LW_CollapsibleArea_TitleDiv {
	PADDING-BOTTOM: 0px; MARGIN-TOP: 9px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; MARGIN-BOTTOM: 19px; PADDING-TOP: 0px
}
.LW_CollapsibleArea_TitleDiv DIV A {
	COLOR: #000
}
.LW_CollapsibleArea_TitleDiv DIV A:link {
	COLOR: #000
}
.LW_CollapsibleArea_TitleDiv DIV A:hover {
	COLOR: #000
}
.LW_CollapsibleArea_TitleDiv DIV A:visited {
	COLOR: #000
}
.LW_CollapsibleArea_TitleDiv DIV A:focus {
	COLOR: #000
}
.codeSnippetContainerTab {
	BORDER-BOTTOM: #939393 1px solid; BORDER-LEFT: medium none; BACKGROUND-COLOR: #eff5ff; FONT-SIZE: 1em; BORDER-TOP: #939393 1px solid; BORDER-RIGHT: #939393 1px solid
}
.codeSnippetContainerTab A {
	COLOR: #1364c4; FONT-WEIGHT: bold
}
.codeSnippetContainerTab A:link {
	COLOR: #1364c4; FONT-WEIGHT: bold
}
.codeSnippetContainerTab A:hover {
	COLOR: #1364c4; FONT-WEIGHT: bold
}
.codeSnippetContainerTab A:visited {
	COLOR: #1364c4; FONT-WEIGHT: bold
}
.codeSnippetContainerTab A:focus {
	COLOR: #1364c4; FONT-WEIGHT: bold
}
.codeSnippetContainerTabActive {
	BORDER-BOTTOM: #fff 1px solid; BORDER-LEFT: medium none; BACKGROUND-COLOR: #fff; FONT-SIZE: 1em
}
.codeSnippetContainerTabActive A {
	COLOR: #000; FONT-WEIGHT: bold
}
.codeSnippetContainerTabActive A:link {
	COLOR: #000; FONT-WEIGHT: bold
}
.codeSnippetContainerTabActive A:hover {
	COLOR: #000; FONT-WEIGHT: bold
}
.codeSnippetContainerTabActive A:visited {
	COLOR: #000; FONT-WEIGHT: bold
}
.codeSnippetContainerTabActive A:focus {
	COLOR: #000; FONT-WEIGHT: bold
}
.codeSnippetContainerTabSingle {
	BORDER-BOTTOM: #fff 1px solid; PADDING-BOTTOM: 0px; BACKGROUND-COLOR: #fff; PADDING-LEFT: 15px; PADDING-RIGHT: 15px; FONT-SIZE: 1em; BORDER-TOP: #939393 1px solid; TOP: auto; BORDER-RIGHT: #939393 1px solid; PADDING-TOP: 0px; LEFT: auto
}
.codeSnippetContainerTabSingle A {
	COLOR: #000; FONT-WEIGHT: bold
}
.codeSnippetContainerTabSingle A:link {
	COLOR: #000; FONT-WEIGHT: bold
}
.codeSnippetContainerTabSingle A:hover {
	COLOR: #000; FONT-WEIGHT: bold
}
.codeSnippetContainerTabSingle A:visited {
	COLOR: #000; FONT-WEIGHT: bold
}
.codeSnippetContainerTabSingle A:focus {
	COLOR: #000; FONT-WEIGHT: bold
}
.codeSnippetContainerTabPhantom {
	BORDER-BOTTOM: #fff 1px solid; BORDER-LEFT: medium none; BACKGROUND-COLOR: #f8f8f8; COLOR: #8b8b8b !important; FONT-SIZE: 1em; FONT-WEIGHT: bold
}
.codeSnippetContainerTabs > DIV:first-child {
	BORDER-LEFT: #939393 1px solid; border-top-left-radius: 4px
}
DIV.lw_vs {
	MARGIN-BOTTOM: 35px
}

 -->
   </style> 
	<!-- saved from url=(0053)http://msdn.microsoft.com/en-us/library/az24scfc.aspx -->
    <title>Regular Expression Language - Quick Reference copied from microsoft web</title>
    <head>
	</head>
	<BODY class=library>

	<H1 class=title>Regular Expression Language - Quick Reference</H1>

      <div id=""mainBody"">
        <div class=""introduction"">
          <p>A regular expression is a pattern that the regular expression engine attempts to match in input text. A pattern consists of one or more character literals, operators, or constructs.  For a brief introduction, see <span><a href=""http://msdn.microsoft.com/en-us/library/hs600312.aspx"">.NET Framework Regular Expressions</a></span>. </p>
          <p>Each section in this quick reference lists a particular category of characters, operators, and constructs that you can use to define regular expressions: </p>
        </div>
        <a id=""character_escapes"">
          
        </a>
        <div>
          
          <div class=""LW_CollapsibleArea_TitleDiv"">
            <div>
              <a href=""javascript:void(0)"" class=""LW_CollapsibleArea_TitleAhref"" title=""Collapse"">
                <span class=""cl_CollapsibleArea_expanding LW_CollapsibleArea_Img""></span>
                <span class=""LW_CollapsibleArea_Title"">Character Escapes</span>
              </a>
              <div class=""LW_CollapsibleArea_HrDiv"">
                <hr class=""LW_CollapsibleArea_Hr"" />
              </div>
            </div>
          </div>
          <div class=""sectionblock"">
            <a id=""sectionToggle0"">
              
            </a>
            <p>The backslash character (\) in a regular expression indicates that the character that follows it either is a special character (as shown in the following table), or should be interpreted literally. For more information, see <span><a href=""http://msdn.microsoft.com/en-us/library/4edbef7e.aspx"">Character Escapes in Regular Expressions</a></span>. </p>
            <div class=""caption"">
              
            </div>
            <div class=""tableSection"">
              <table>
                <tr>
                  <th>
                    <p>Escaped character</p>
                  </th>
                  <th>
                    <p>Description</p>
                  </th>
                  <th>
                    <p>Pattern</p>
                  </th>
                  <th>
                    <p>Matches</p>
                  </th>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">\a</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Matches a bell character, \u0007.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">\a</span>
                    </p>
                  </td>
                  <td>
                    <p>""\u0007"" in ""Error!"" + '\u0007'</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">\b</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>In a character class, matches a backspace, \u0008.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">[\b]{3,}</span>
                    </p>
                  </td>
                  <td>
                    <p>""\b\b\b\b"" in ""\b\b\b\b""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">\t</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Matches a tab, \u0009.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">(\w+)\t</span>
                    </p>
                  </td>
                  <td>
                    <p>""item1\t"", ""item2\t"" in ""item1\titem2\t""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">\r</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Matches a carriage return, \u000D. (<span><span class=""input"">\r</span></span> is not equivalent to the newline character, <span><span class=""input"">\n</span></span>.)</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">\r\n(\w+)</span>
                    </p>
                  </td>
                  <td>
                    <p>""\r\nThese"" in ""\r\nThese are\ntwo lines.""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">\v</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Matches a vertical tab, \u000B.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">[\v]{2,}</span>
                    </p>
                  </td>
                  <td>
                    <p>""\v\v\v"" in ""\v\v\v""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">\f</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Matches a form feed, \u000C.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">[\f]{2,}</span>
                    </p>
                  </td>
                  <td>
                    <p>""\f\f\f"" in ""\f\f\f"" </p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">\n</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Matches a new line, \u000A.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">\r\n(\w+)</span>
                    </p>
                  </td>
                  <td>
                    <p>""\r\nThese"" in ""\r\nThese are\ntwo lines.""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">\e</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Matches an escape, \u001B.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">\e</span>
                    </p>
                  </td>
                  <td>
                    <p>""\x001B"" in ""\x001B""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">\</span>
                      </span>
                      <span class=""parameter"">nnn</span>
                    </p>
                  </td>
                  <td>
                    <p>Uses octal representation to specify a character (<span class=""parameter"">nnn</span> consists of two or three digits).</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">\w\040\w</span>
                    </p>
                  </td>
                  <td>
                    <p>""a b"", ""c d"" in </p>
                    <p>""a bc d""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">\x</span>
                      </span>
                      <span class=""parameter"">nn</span>
                    </p>
                  </td>
                  <td>
                    <p>Uses hexadecimal representation to specify a character (<span class=""parameter"">nn</span> consists of exactly two digits).</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">\w\x20\w</span>
                    </p>
                  </td>
                  <td>
                    <p>""a b"", ""c d"" in </p>
                    <p>""a bc d""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">\c</span>
                      </span>
                      <span class=""parameter"">X</span>
                    </p>
                    <p>
                      <span>
                        <span class=""input"">\c</span>
                      </span>
                      <span class=""parameter"">x</span>
                    </p>
                  </td>
                  <td>
                    <p>Matches the ASCII control character that is specified by <span class=""parameter"">X</span> or <span class=""parameter"">x</span>, where <span class=""parameter"">X</span> or <span class=""parameter"">x</span> is the letter of the control character. </p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">\cC</span>
                    </p>
                  </td>
                  <td>
                    <p>""\x0003"" in ""\x0003"" (Ctrl-C) </p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">\u</span>
                      </span>
                      <span class=""parameter"">nnnn</span>
                    </p>
                  </td>
                  <td>
                    <p>Matches a Unicode character by using hexadecimal representation (exactly four digits, as represented by <span class=""parameter"">nnnn</span>).</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">\w\u0020\w</span>
                    </p>
                  </td>
                  <td>
                    <p>""a b"", ""c d"" in </p>
                    <p>""a bc d""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">\</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>When followed by a character that is not recognized as an escaped character in this and other tables in this topic, matches that character. For example, <span><span class=""input"">\*</span></span> is the same as <span><span class=""input"">\x2A</span></span>, and <span><span class=""input"">\.</span></span> is the same as <span><span class=""input"">\x2E</span></span>. This allows the regular expression engine to disambiguate language elements (such as * or ?) and character literals (represented by <span class=""code"">\*</span> or <span class=""code"">\?</span>).</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">\d+[\+-x\*]\d+\d+[\+-x\*\d+    </span>
                    </p>
                  </td>
                  <td>
                    <p>""2+2"" and ""3*9"" in ""(2+2) * 3*9""</p>
                  </td>
                </tr>
              </table>
            </div>
            <p>
              <a href=""#top"">Back to top</a>
            </p>
          </div>
        </div>
        <a id=""character_classes"">
          
        </a>
        <div>
          <div class=""LW_CollapsibleArea_TitleDiv"">
            <div>
              <a href=""javascript:void(0)"" class=""LW_CollapsibleArea_TitleAhref"" title=""Collapse"">
                <span class=""cl_CollapsibleArea_expanding LW_CollapsibleArea_Img""></span>
                <span class=""LW_CollapsibleArea_Title"">Character Classes</span>
              </a>
              <div class=""LW_CollapsibleArea_HrDiv"">
                <hr class=""LW_CollapsibleArea_Hr"" />
              </div>
            </div>
          </div>
          <div class=""sectionblock"">
            <a id=""sectionToggle1"">
              
            </a>
            <p>A character class matches any one of a set of characters. Character classes include the language elements listed in the following table. For more information, see <span><a href=""http://msdn.microsoft.com/en-us/library/20bw873z.aspx"">Character Classes in Regular Expressions</a></span>.</p>
            <div class=""caption"">
              
            </div>
            <div class=""tableSection"">
              <table>
                <tr>
                  <th>
                    <p>Character class</p>
                  </th>
                  <th>
                    <p>Description</p>
                  </th>
                  <th>
                    <p>Pattern</p>
                  </th>
                  <th>
                    <p>Matches</p>
                  </th>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">[</span>
                      </span>
                      <span class=""parameter"">character_group</span>
                      <span>
                        <span class=""input"">]</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Matches any single character in <span class=""parameter"">character_group</span>. By default, the match is case-sensitive.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">[ae] </span>
                    </p>
                  </td>
                  <td>
                    <p>""a"" in ""gray""</p>
                    <p>""a"", ""e"" in ""lane""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">[^</span>
                      </span>
                      <span class=""parameter"">character_group</span>
                      <span>
                        <span class=""input"">]</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Negation: Matches any single character that is not in <span class=""parameter"">character_group</span>. By default, characters in <span class=""parameter"">character_group</span> are case-sensitive.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">[^aei]</span>
                    </p>
                  </td>
                  <td>
                    <p>""r"", ""g"", ""n"" in ""reign""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">[</span>
                      </span>
                      <span class=""parameter"">first</span>
                      <span>
                        <span class=""input"">-</span>
                      </span>
                      <span class=""parameter"">last</span>
                      <span>
                        <span class=""input"">]</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Character range: Matches any single character in the range from <span class=""parameter"">first</span> to <span class=""parameter"">last</span>. </p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">[A-Z]</span>
                    </p>
                  </td>
                  <td>
                    <p>""A"", ""B"" in ""AB123""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">.</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Wildcard: Matches any single character except \n.</p>
                    <p>To match a literal period character (. or <span><span class=""input"">\u002E</span></span>), you must precede it with the escape character (<span><span class=""input"">\.</span></span>).</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">a.e</span>
                    </p>
                  </td>
                  <td>
                    <p>""ave"" in ""nave""</p>
                    <p>""ate"" in ""water""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">\p{</span>
                      </span>
                      <span class=""parameter"">name</span>
                      <span>
                        <span class=""input"">}</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Matches any single character in the Unicode general category or named block specified by <span class=""parameter"">name</span>.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">\p{Lu}</span>
                    </p>
                    <p>
                      <span class=""code"">\p{IsCyrillic}</span>
                    </p>
                  </td>
                  <td>
                    <p>""C"", ""L"" in ""City Lights""</p>
                    <p>""?"", ""?"" in ""??em""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">\P{</span>
                      </span>
                      <span class=""parameter"">name</span>
                      <span>
                        <span class=""input"">}</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Matches any single character that is not in the Unicode general category or named block specified by <span class=""parameter"">name</span>.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">\P{Lu}</span>
                    </p>
                    <p>
                      <span class=""code"">\P{IsCyrillic}</span>
                    </p>
                  </td>
                  <td>
                    <p>""i"", ""t"", ""y"" in ""City""</p>
                    <p>""e"", ""m"" in ""??em""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">\w</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Matches any word character. </p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">\w</span>
                    </p>
                  </td>
                  <td>
                    <p>""I"", ""D"", ""A"", ""1"", ""3"" in ""ID A1.3"" </p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">\W</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Matches any non-word character.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">\W</span>
                    </p>
                  </td>
                  <td>
                    <p>"" "", ""."" in ""ID A1.3""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">\s</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Matches any white-space character.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">\w\s</span>
                    </p>
                  </td>
                  <td>
                    <p>""D "" in ""ID A1.3""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">\S</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Matches any non-white-space character.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">\s\S</span>
                    </p>
                  </td>
                  <td>
                    <p>"" _"" in ""int __ctr"" </p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">\d</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Matches any decimal digit.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">\d</span>
                    </p>
                  </td>
                  <td>
                    <p>""4"" in ""4 = IV"" </p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">\D </span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Matches any character other than a decimal digit.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">\D</span>
                    </p>
                  </td>
                  <td>
                    <p>"" "", ""="", "" "", ""I"", ""V"" in ""4 = IV""  </p>
                  </td>
                </tr>
              </table>
            </div>
            <p>
              <a href=""#top"">Back to top</a>
            </p>
          </div>
        </div>
        <a id=""atomic_zerowidth_assertions"">
          
        </a>
        <div>
          <div class=""LW_CollapsibleArea_TitleDiv"">
            <div>
              <a href=""javascript:void(0)"" class=""LW_CollapsibleArea_TitleAhref"" title=""Collapse"">
                <span class=""cl_CollapsibleArea_expanding LW_CollapsibleArea_Img""></span>
                <span class=""LW_CollapsibleArea_Title"">Anchors</span>
              </a>
              <div class=""LW_CollapsibleArea_HrDiv"">
                <hr class=""LW_CollapsibleArea_Hr"" />
              </div>
            </div>
          </div>
          <div class=""sectionblock"">
            <a id=""sectionToggle2"">
              
            </a>
            <p>Anchors, or atomic zero-width assertions, cause a match to succeed or fail depending on the current position in the string, but they do not cause the engine to advance through the string or consume characters. The metacharacters listed in the following table are anchors. For more information, see <span><a href=""http://msdn.microsoft.com/en-us/library/h5181w5w.aspx"">Anchors in Regular Expressions</a></span>.</p>
            <div class=""caption"">
              
            </div>
            <div class=""tableSection"">
              <table>
                <tr>
                  <th>
                    <p>Assertion</p>
                  </th>
                  <th>
                    <p>Description</p>
                  </th>
                  <th>
                    <p>Pattern</p>
                  </th>
                  <th>
                    <p>Matches</p>
                  </th>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">^</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>The match must start at the beginning of the string or line. </p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">^\d{3}</span>
                    </p>
                  </td>
                  <td>
                    <p>""901"" in </p>
                    <p>""901-333-""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">$</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>The match must occur at the end of the string or before <span><span class=""input"">\n</span></span> at the end of the line or string.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">-\d{3}$</span>
                    </p>
                  </td>
                  <td>
                    <p>""-333"" in </p>
                    <p>""-901-333""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">\A</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>The match must occur at the start of the string.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">\A\d{3}</span>
                    </p>
                  </td>
                  <td>
                    <p>""901"" in </p>
                    <p>""901-333-""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">\Z</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>The match must occur at the end of the string or before <span><span class=""input"">\n</span></span> at the end of the string.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">-\d{3}\Z</span>
                    </p>
                  </td>
                  <td>
                    <p>""-333"" in </p>
                    <p>""-901-333""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">\z</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>The match must occur at the end of the string.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">-\d{3}\z</span>
                    </p>
                  </td>
                  <td>
                    <p>""-333"" in </p>
                    <p>""-901-333""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">\G</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>The match must occur at the point where the previous match ended.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">\G\(\d\)</span>
                    </p>
                  </td>
                  <td>
                    <p>""(1)"", ""(3)"", ""(5)"" in ""(1)(3)(5)[7](9)""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">\b</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>The match must occur on a boundary between a <span><span class=""input"">\w</span></span> (alphanumeric) and a <span><span class=""input"">\W</span></span> (nonalphanumeric) character.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">\b\w+\s\w+\b   </span>
                    </p>
                  </td>
                  <td>
                    <p>""them theme"", ""them them"" in ""them theme them them"" </p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">\B</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>The match must not occur on a <span><span class=""input"">\b</span></span> boundary.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">\Bend\w*\b</span>
                    </p>
                  </td>
                  <td>
                    <p>""ends"", ""ender"" in ""end sends endure lender""</p>
                  </td>
                </tr>
              </table>
            </div>
            <p>
              <a href=""#top"">Back to top</a>
            </p>
          </div>
        </div>
        <a id=""grouping_constructs"">
          
        </a>
        <div>
          <div class=""LW_CollapsibleArea_TitleDiv"">
            <div>
              <a href=""javascript:void(0)"" class=""LW_CollapsibleArea_TitleAhref"" title=""Collapse"">
                <span class=""cl_CollapsibleArea_expanding LW_CollapsibleArea_Img""></span>
                <span class=""LW_CollapsibleArea_Title"">Grouping Constructs</span>
              </a>
              <div class=""LW_CollapsibleArea_HrDiv"">
                <hr class=""LW_CollapsibleArea_Hr"" />
              </div>
            </div>
          </div>
          <div class=""sectionblock"">
            <a id=""sectionToggle3"">
              
            </a>
            <p>Grouping constructs delineate subexpressions of a regular expression and typically capture substrings of an input string. Grouping constructs include the language elements listed in the following table. For more information, see <span><a href=""http://msdn.microsoft.com/en-us/library/bs2twtah.aspx"">Grouping Constructs in Regular Expressions</a></span>.</p>
            <div class=""caption"">
              
            </div>
            <div class=""tableSection"">
              <table>
                <tr>
                  <th>
                    <p>Grouping construct</p>
                  </th>
                  <th>
                    <p>Description</p>
                  </th>
                  <th>
                    <p>Pattern</p>
                  </th>
                  <th>
                    <p>Matches</p>
                  </th>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">(</span>
                      </span>
                      <span class=""parameter"">subexpression</span>
                      <span>
                        <span class=""input"">)</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Captures the matched subexpression and assigns it a zero-based ordinal number.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">(\w)\1</span>
                    </p>
                  </td>
                  <td>
                    <p>""ee"" in ""deep""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">(?&lt;</span>
                      </span>
                      <span class=""parameter"">name</span>
                      <span>
                        <span class=""input"">&gt;</span>
                      </span>
                      <span class=""parameter"">subexpression</span>
                      <span>
                        <span class=""input"">)</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Captures the matched subexpression into a named group.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">(?&lt;double&gt;\w)\k&lt;double&gt;  </span>
                    </p>
                  </td>
                  <td>
                    <p>""ee"" in ""deep""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">(?&lt;</span>
                      </span>
                      <span class=""parameter"">name1</span>
                      <span>
                        <span class=""input"">-</span>
                      </span>
                      <span class=""parameter"">name2</span>
                      <span>
                        <span class=""input"">&gt;</span>
                      </span>
                      <span class=""parameter"">subexpression</span>
                      <span>
                        <span class=""input"">)</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Defines a balancing group definition. For more information, see the ""Balancing Group Definition"" section in <span><a href=""http://msdn.microsoft.com/en-us/library/bs2twtah.aspx"">Grouping Constructs in Regular Expressions</a></span>. </p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">(((?'Open'\()[^\(\)]*)+((?'Close-Open'\))[^\(\)]*)+)*(?(Open)(?!))$</span>
                    </p>
                  </td>
                  <td>
                    <p>""((1-3)*(3-1))"" in ""3+2^((1-3)*(3-1))""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">(?:</span>
                      </span>
                      <span class=""parameter"">subexpression</span>
                      <span>
                        <span class=""input"">)</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Defines a noncapturing group. </p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">Write(?:Line)?</span>
                    </p>
                  </td>
                  <td>
                    <p>""WriteLine"" in ""Console.WriteLine()""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">(?imnsx-imnsx:</span>
                      </span>
                      <span class=""parameter"">subexpression</span>
                      <span>
                        <span class=""input"">)</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Applies or disables the specified options within <span class=""parameter"">subexpression</span>. For more information, see <span><a href=""http://msdn.microsoft.com/en-us/library/yd1hzczs.aspx"">Regular Expression Options</a></span>.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">A\d{2}(?i:\w+)\b</span>
                    </p>
                  </td>
                  <td>
                    <p>""A12xl"", ""A12XL"" in ""A12xl A12XL a12xl""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">(?=</span>
                      </span>
                      <span class=""parameter"">subexpression</span>
                      <span>
                        <span class=""input"">)</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Zero-width positive lookahead assertion. </p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">\w+(?=\.)</span>
                    </p>
                  </td>
                  <td>
                    <p>""is"", ""ran"", and ""out"" in ""He is. The dog ran. The sun is out.""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">(?!</span>
                      </span>
                      <span class=""parameter"">subexpression</span>
                      <span>
                        <span class=""input"">)</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Zero-width negative lookahead assertion.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">\b(?!un)\w+\b</span>
                    </p>
                  </td>
                  <td>
                    <p>""sure"", ""used"" in ""unsure sure unity used""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">(?&lt;=</span>
                      </span>
                      <span class=""parameter"">subexpression</span>
                      <span>
                        <span class=""input"">)</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Zero-width positive lookbehind assertion. </p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">(?&lt;=19)\d{2}\b</span>
                    </p>
                  </td>
                  <td>
                    <p>""99"", ""50"", ""05"" in ""1851 1999 1950 1905 2003""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">(?&lt;!</span>
                      </span>
                      <span class=""parameter"">subexpression</span>
                      <span>
                        <span class=""input"">)</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Zero-width negative lookbehind assertion. </p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">(?&lt;!19)\d{2}\b</span>
                    </p>
                  </td>
                  <td>
                    <p>""51"", ""03"" in ""1851 1999 1950 1905 2003""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">(?&gt;</span>
                      </span>
                      <span class=""parameter"">subexpression</span>
                      <span>
                        <span class=""input"">)</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Nonbacktracking (or ""greedy"") subexpression. </p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">[13579](?&gt;A+B+)</span>
                    </p>
                  </td>
                  <td>
                    <p>""1ABB"", ""3ABB"", and ""5AB"" in ""1ABB 3ABBC 5AB 5AC""</p>
                  </td>
                </tr>
              </table>
            </div>
            <p>
              <a href=""#top"">Back to top</a>
            </p>
          </div>
        </div>
        <a id=""quantifiers"">
          
        </a>
        <div>
          <div class=""LW_CollapsibleArea_TitleDiv"">
            <div>
              <a href=""javascript:void(0)"" class=""LW_CollapsibleArea_TitleAhref"" title=""Collapse"">
                <span class=""cl_CollapsibleArea_expanding LW_CollapsibleArea_Img""></span>
                <span class=""LW_CollapsibleArea_Title"">Quantifiers</span>
              </a>
              <div class=""LW_CollapsibleArea_HrDiv"">
                <hr class=""LW_CollapsibleArea_Hr"" />
              </div>
            </div>
          </div>
          <div class=""sectionblock"">
            <a id=""sectionToggle4"">
              
            </a>
            <p>A quantifier specifies how many instances of the previous element (which can be a character, a group, or a character class) must be present in the input string for a match to occur. Quantifiers include the language elements listed in the following table. For more information, see <span><a href=""http://msdn.microsoft.com/en-us/library/3206d374.aspx"">Quantifiers in Regular Expressions</a></span>.</p>
            <div class=""caption"">
              
            </div>
            <div class=""tableSection"">
              <table>
                <tr>
                  <th>
                    <p>Quantifier</p>
                  </th>
                  <th>
                    <p>Description</p>
                  </th>
                  <th>
                    <p>Pattern</p>
                  </th>
                  <th>
                    <p>Matches</p>
                  </th>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">*</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Matches the previous element zero or more times. </p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">\d*\.\d</span>
                    </p>
                  </td>
                  <td>
                    <p>"".0"", ""19.9"", ""219.9""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">+</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Matches the previous element one or more times.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">""be+""</span>
                    </p>
                  </td>
                  <td>
                    <p>""bee"" in ""been"", ""be"" in ""bent""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">?</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Matches the previous element zero or one time.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">""rai?n""</span>
                    </p>
                  </td>
                  <td>
                    <p>""ran"", ""rain""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">{</span>
                      </span>
                      <span class=""parameter"">n</span>
                      <span>
                        <span class=""input"">}</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Matches the previous element exactly <span class=""parameter"">n</span> times.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">"",\d{3}""</span>
                    </p>
                  </td>
                  <td>
                    <p>"",043"" in ""1,043.6"", "",876"", "",543"", and "",210"" in ""9,876,543,210""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">{</span>
                      </span>
                      <span class=""parameter"">n</span>
                      <span>
                        <span class=""input"">,}</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Matches the previous element at least <span class=""parameter"">n</span> times.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">""\d{2,}""</span>
                    </p>
                  </td>
                  <td>
                    <p>""166"", ""29"", ""1930""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">{</span>
                      </span>
                      <span class=""parameter"">n</span>
                      <span>
                        <span class=""input"">,</span>
                      </span>
                      <span class=""parameter"">m</span>
                      <span>
                        <span class=""input"">}</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Matches the previous element at least <span class=""parameter"">n</span> times, but no more than <span class=""parameter"">m</span> times. </p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">""\d{3,5}""</span>
                    </p>
                  </td>
                  <td>
                    <p>""166"", ""17668""</p>
                    <p>""19302"" in ""193024""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">*?</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Matches the previous element zero or more times, but as few times as possible. </p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">\d*?\.\d</span>
                    </p>
                  </td>
                  <td>
                    <p>"".0"", ""19.9"", ""219.9""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">+?</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Matches the previous element one or more times, but as few times as possible. </p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">""be+?""</span>
                    </p>
                  </td>
                  <td>
                    <p>""be"" in ""been"", ""be"" in ""bent""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">??</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Matches the previous element zero or one time, but as few times as possible.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">""rai??n""</span>
                    </p>
                  </td>
                  <td>
                    <p>""ran"", ""rain""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">{</span>
                      </span>
                      <span class=""parameter"">n</span>
                      <span>
                        <span class=""input"">}?</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Matches the preceding element exactly <span class=""parameter"">n</span> times.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">"",\d{3}?""</span>
                    </p>
                  </td>
                  <td>
                    <p>"",043"" in ""1,043.6"", "",876"", "",543"", and "",210"" in ""9,876,543,210""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">{</span>
                      </span>
                      <span class=""parameter"">n</span>
                      <span>
                        <span class=""input"">,}?</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Matches the previous element at least <span class=""parameter"">n</span> times, but as few times as possible.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">""\d{2,}?""</span>
                    </p>
                  </td>
                  <td>
                    <p>""166"", ""29"", ""1930""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">{</span>
                      </span>
                      <span class=""parameter"">n</span>
                      <span>
                        <span class=""input"">,</span>
                      </span>
                      <span class=""parameter"">m</span>
                      <span>
                        <span class=""input"">}?</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Matches the previous element between <span class=""parameter"">n</span> and <span class=""parameter"">m</span> times, but as few times as possible.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">""\d{3,5}?""</span>
                    </p>
                  </td>
                  <td>
                    <p>""166"", ""17668""</p>
                    <p>""193"", ""024"" in ""193024""</p>
                  </td>
                </tr>
              </table>
            </div>
            <p>
              <a href=""#top"">Back to top</a>
            </p>
          </div>
        </div>
        <a id=""backreference_constructs"">
          
        </a>
        <div>
          <div class=""LW_CollapsibleArea_TitleDiv"">
            <div>
              <a href=""javascript:void(0)"" class=""LW_CollapsibleArea_TitleAhref"" title=""Collapse"">
                <span class=""cl_CollapsibleArea_expanding LW_CollapsibleArea_Img""></span>
                <span class=""LW_CollapsibleArea_Title"">Backreference Constructs</span>
              </a>
              <div class=""LW_CollapsibleArea_HrDiv"">
                <hr class=""LW_CollapsibleArea_Hr"" />
              </div>
            </div>
          </div>
          <div class=""sectionblock"">
            <a id=""sectionToggle5"">
              
            </a>
            <p>A backreference allows a previously matched subexpression to be identified subsequently in the same regular expression. The following table lists the backreference constructs supported by regular expressions in the .NET Framework. For more information, see <span><a href=""http://msdn.microsoft.com/en-us/library/thwdfzxy.aspx"">Backreference Constructs in Regular Expressions</a></span>.</p>
            <div class=""caption"">
              
            </div>
            <div class=""tableSection"">
              <table>
                <tr>
                  <th>
                    <p>Backreference construct</p>
                  </th>
                  <th>
                    <p>Description</p>
                  </th>
                  <th>
                    <p>Pattern</p>
                  </th>
                  <th>
                    <p>Matches</p>
                  </th>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">\</span>
                      </span>
                      <span class=""parameter"">number</span>
                    </p>
                  </td>
                  <td>
                    <p>Backreference. Matches the value of a numbered subexpression.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">(\w)\1</span>
                    </p>
                  </td>
                  <td>
                    <p>""ee"" in ""seek""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">\k&lt;</span>
                      </span>
                      <span class=""parameter"">name</span>
                      <span>
                        <span class=""input"">&gt;</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Named backreference. Matches the value of a named expression.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">(?&lt;char&gt;\w)\k&lt;char&gt;</span>
                    </p>
                  </td>
                  <td>
                    <p>""ee"" in ""seek""</p>
                  </td>
                </tr>
              </table>
            </div>
            <p>
              <a href=""#top"">Back to top</a>
            </p>
          </div>
        </div>
        <a id=""alternation_constructs"">
          
        </a>
        <div>
          <div class=""LW_CollapsibleArea_TitleDiv"">
            <div>
              <a href=""javascript:void(0)"" class=""LW_CollapsibleArea_TitleAhref"" title=""Collapse"">
                <span class=""cl_CollapsibleArea_expanding LW_CollapsibleArea_Img""></span>
                <span class=""LW_CollapsibleArea_Title"">Alternation Constructs</span>
              </a>
              <div class=""LW_CollapsibleArea_HrDiv"">
                <hr class=""LW_CollapsibleArea_Hr"" />
              </div>
            </div>
          </div>
          <div class=""sectionblock"">
            <a id=""sectionToggle6"">
              
            </a>
            <p>Alternation constructs modify a regular expression to enable either/or matching. These constructs include the language elements listed in the following table. For more information, see <span><a href=""http://msdn.microsoft.com/en-us/library/36xybswe.aspx"">Alternation Constructs in Regular Expressions</a></span>.</p>
            <div class=""caption"">
              
            </div>
            <div class=""tableSection"">
              <table>
                <tr>
                  <th>
                    <p>Alternation construct</p>
                  </th>
                  <th>
                    <p>Description</p>
                  </th>
                  <th>
                    <p>Pattern</p>
                  </th>
                  <th>
                    <p>Matches</p>
                  </th>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">|</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Matches any one element separated by the vertical bar (|) character.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">th(e|is|at)</span>
                    </p>
                  </td>
                  <td>
                    <p>""the"", ""this"" in ""this is the day. ""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">(?(</span>
                      </span>
                      <span class=""parameter"">expression</span>
                      <span>
                        <span class=""input"">)</span>
                      </span>
                      <span class=""parameter"">yes</span>
                      <span>
                        <span class=""input"">|</span>
                      </span>
                      <span class=""parameter"">no</span>
                      <span>
                        <span class=""input"">)</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Matches <span class=""parameter"">yes</span> if <span class=""parameter"">expression</span> matches; otherwise, matches the optional <span class=""parameter"">no</span> part. <span class=""parameter"">expression</span> is interpreted as a zero-width assertion. </p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">(?(A)A\d{2}\b|\b\d{3}\b)</span>
                    </p>
                  </td>
                  <td>
                    <p>""A10"", ""910"" in ""A10 C103 910""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">(?(</span>
                      </span>
                      <span class=""parameter"">name</span>
                      <span>
                        <span class=""input"">)</span>
                      </span>
                      <span class=""parameter"">yes</span>
                      <span>
                        <span class=""input"">|</span>
                      </span>
                      <span class=""parameter"">no</span>
                      <span>
                        <span class=""input"">)</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Matches <span class=""parameter"">yes</span> if the named capture <span class=""parameter"">name</span> has a match; otherwise, matches the optional <span class=""parameter"">no</span>. </p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">(?&lt;quoted&gt;"")?(?(quoted).+?""|\S+\s)</span>
                    </p>
                  </td>
                  <td>
                    <p>Dogs.jpg, ""Yiska playing.jpg"" in ""Dogs.jpg ""Yiska playing.jpg""""</p>
                  </td>
                </tr>
              </table>
            </div>
            <p>
              <a href=""#top"">Back to top</a>
            </p>
          </div>
        </div>
        <a id=""substitutions"">
          
        </a>
        <div>
          <div class=""LW_CollapsibleArea_TitleDiv"">
            <div>
              <a href=""javascript:void(0)"" class=""LW_CollapsibleArea_TitleAhref"" title=""Collapse"">
                <span class=""cl_CollapsibleArea_expanding LW_CollapsibleArea_Img""></span>
                <span class=""LW_CollapsibleArea_Title"">Substitutions</span>
              </a>
              <div class=""LW_CollapsibleArea_HrDiv"">
                <hr class=""LW_CollapsibleArea_Hr"" />
              </div>
            </div>
          </div>
          <div class=""sectionblock"">
            <a id=""sectionToggle7"">
              
            </a>
            <p>Substitutions are regular expression language elements that are supported in replacement patterns. For more information, see <span><a href=""http://msdn.microsoft.com/en-us/library/ewy2t5e0.aspx"">Substitutions in Regular Expressions</a></span>. The metacharacters listed in the following table are atomic zero-width assertions.</p>
            <div class=""caption"">
              
            </div>
            <div class=""tableSection"">
              <table>
                <tr>
                  <th>
                    <p>Character</p>
                  </th>
                  <th>
                    <p>Description</p>
                  </th>
                  <th>
                    <p>Pattern</p>
                  </th>
                  <th>
                    <p>Replacement pattern</p>
                  </th>
                  <th>
                    <p>Input string</p>
                  </th>
                  <th>
                    <p>Result string</p>
                  </th>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">$</span>
                      </span>
                      <span class=""parameter"">number</span>
                    </p>
                  </td>
                  <td>
                    <p>Substitutes the substring matched by group <span class=""parameter"">number</span>.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">\b(\w+)(\s)(\w+)\b</span>
                    </p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">$3$2$1</span>
                    </p>
                  </td>
                  <td>
                    <p>""one two"" </p>
                  </td>
                  <td>
                    <p>""two one""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">${</span>
                      </span>
                      <span class=""parameter"">name</span>
                      <span>
                        <span class=""input"">}</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Substitutes the substring matched by the named group <span class=""parameter"">name</span>.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">\b(?&lt;word1&gt;\w+)(\s)(?&lt;word2&gt;\w+)\b</span>
                    </p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">${word2} ${word1}</span>
                    </p>
                  </td>
                  <td>
                    <p>""one two"" </p>
                  </td>
                  <td>
                    <p>""two one""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">$$</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Substitutes a literal ""$"".</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">\b(\d+)\s?USD</span>
                    </p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">$$$1</span>
                    </p>
                  </td>
                  <td>
                    <p>""103 USD""</p>
                  </td>
                  <td>
                    <p>""$103""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">$&amp;</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Substitutes a copy of the whole match.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">(\$*(\d*(\.+\d+)?){1})</span>
                    </p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">**$&amp;</span>
                    </p>
                  </td>
                  <td>
                    <p>""$1.30""</p>
                  </td>
                  <td>
                    <p>""**$1.30**""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">$`</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Substitutes all the text of the input string before the match.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">B+</span>
                    </p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">$`</span>
                    </p>
                  </td>
                  <td>
                    <p>""AABBCC""</p>
                  </td>
                  <td>
                    <p>""AAAACC""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">$'</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Substitutes all the text of the input string after the match.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">B+</span>
                    </p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">$'</span>
                    </p>
                  </td>
                  <td>
                    <p>""AABBCC""</p>
                  </td>
                  <td>
                    <p>""AACCCC""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">$+</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Substitutes the last group that was captured.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">B+(C+)</span>
                    </p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">$+</span>
                    </p>
                  </td>
                  <td>
                    <p>""AABBCCDD""</p>
                  </td>
                  <td>
                    <p>AACCDD</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">$_</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Substitutes the entire input string.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">B+</span>
                    </p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">$_</span>
                    </p>
                  </td>
                  <td>
                    <p>""AABBCC""</p>
                  </td>
                  <td>
                    <p>""AAAABBCCCC""</p>
                  </td>
                </tr>
              </table>
            </div>
            <p>
              <a href=""#top"">Back to top</a>
            </p>
          </div>
        </div>
        <a id=""options"">
          
        </a>
        <div>
          <div class=""LW_CollapsibleArea_TitleDiv"">
            <div>
              <a href=""javascript:void(0)"" class=""LW_CollapsibleArea_TitleAhref"" title=""Collapse"">
                <span class=""cl_CollapsibleArea_expanding LW_CollapsibleArea_Img""></span>
                <span class=""LW_CollapsibleArea_Title"">Regular Expression Options</span>
              </a>
              <div class=""LW_CollapsibleArea_HrDiv"">
                <hr class=""LW_CollapsibleArea_Hr"" />
              </div>
            </div>
          </div>
          <div class=""sectionblock"">
            <a id=""sectionToggle8"">
              
            </a>
            <p>You can specify options that control how the regular expression engine interprets a regular expression pattern. Many of these options can be specified either inline (in the regular expression pattern) or as one or more <span><a href=""http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regexoptions.aspx"">RegexOptions</a></span> constants. This quick reference lists only inline options. For more information about inline and <span><a href=""http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regexoptions.aspx"">RegexOptions</a></span> options, see the article <span><a href=""http://msdn.microsoft.com/en-us/library/yd1hzczs.aspx"">Regular Expression Options</a></span>. </p>
            <p>You can specify an inline option in two ways:</p>
            <ul>
              <li>
                <p>By using the <a href=""http://msdn.microsoft.com/en-us/library/x044wc7s.aspx"">miscellaneous construct</a><span><span class=""input"">(?imnsx-imnsx)</span></span>, where a minus sign (-) before an option or set of options turns those options off. For example, <span><span class=""input"">(?i-mn)</span></span> turns case-insensitive matching (<span><span class=""input"">i</span></span>) on, turns multiline mode (<span><span class=""input"">m</span></span>) off, and turns unnamed group captures (<span><span class=""input"">n</span></span>) off. The option applies to the regular expression pattern from the point at which the option is defined, and is effective either to the end of the pattern or to the point where another construct reverses the option.</p>
              </li>
              <li>
                <p>By using the <a href=""http://msdn.microsoft.com/en-us/library/bs2twtah.aspx"">grouping construct</a><span><span class=""input"">(?imnsx-imnsx:</span></span><span class=""parameter"">subexpression</span><span><span class=""input"">)</span></span>, which defines options for the specified group only.</p>
              </li>
            </ul>
            <p>The .NET Framework regular expression engine supports the following inline options.</p>
            <div class=""caption"">
              
            </div>
            <div class=""tableSection"">
              <table>
                <tr>
                  <th>
                    <p>Option</p>
                  </th>
                  <th>
                    <p>Description</p>
                  </th>
                  <th>
                    <p>Pattern</p>
                  </th>
                  <th>
                    <p>Matches</p>
                  </th>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">i</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Use case-insensitive matching. </p>
                  </td>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">\b(?i)a(?-i)a\w+\b</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>""aardvark"", ""aaaAuto"" in ""aardvark AAAuto aaaAuto Adam breakfast"" </p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">m</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Use multiline mode. <span><span class=""input"">^</span></span> and <span><span class=""input"">$</span></span> match the beginning and end of a line, instead of the beginning and end of a string. </p>
                  </td>
                  <td>
                    <p>For an example, see the ""Multiline Mode"" section in <span><a href=""http://msdn.microsoft.com/en-us/library/yd1hzczs.aspx"">Regular Expression Options</a></span>.</p>
                  </td>
                  <td>
                    <p>
                      
                    </p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">n</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Do not capture unnamed groups. </p>
                  </td>
                  <td>
                    <p>For an example, see the ""Explicit Captures Only"" section in <span><a href=""http://msdn.microsoft.com/en-us/library/yd1hzczs.aspx"">Regular Expression Options</a></span>.</p>
                  </td>
                  <td>
                    <p>
                      
                    </p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">s</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Use single-line mode.</p>
                  </td>
                  <td>
                    <p>For an example, see the ""Single-line Mode"" section in <span><a href=""http://msdn.microsoft.com/en-us/library/yd1hzczs.aspx"">Regular Expression Options</a></span>.</p>
                  </td>
                  <td>
                    <p>
                      
                    </p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">x</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Ignore unescaped white space in the regular expression pattern. </p>
                  </td>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">\b(?x) \d+ \s \w+</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>""1 aardvark"", ""2 cats"" in ""1 aardvark 2 cats IV centurions"" </p>
                  </td>
                </tr>
              </table>
            </div>
            <p>
              <a href=""#top"">Back to top</a>
            </p>
          </div>
        </div>
        <a id=""miscellaneous_constructs"">
          
        </a>
        <div>
          <div class=""LW_CollapsibleArea_TitleDiv"">
            <div>
              <a href=""javascript:void(0)"" class=""LW_CollapsibleArea_TitleAhref"" title=""Collapse"">
                <span class=""cl_CollapsibleArea_expanding LW_CollapsibleArea_Img""></span>
                <span class=""LW_CollapsibleArea_Title"">Miscellaneous Constructs</span>
              </a>
              <div class=""LW_CollapsibleArea_HrDiv"">
                <hr class=""LW_CollapsibleArea_Hr"" />
              </div>
            </div>
          </div>
          <div class=""sectionblock"">
            <a id=""sectionToggle9"">
              
            </a>
            <p>Miscellaneous constructs either modify a regular expression pattern or provide information about it. The following table lists the miscellaneous constructs supported by the .NET Framework. For more information, see <span><a href=""http://msdn.microsoft.com/en-us/library/x044wc7s.aspx"">Miscellaneous Constructs in Regular Expressions</a></span>.</p>
            <div class=""caption"">
              
            </div>
            <div class=""tableSection"">
              <table>
                <tr>
                  <th>
                    <p>Construct</p>
                  </th>
                  <th>
                    <p>Definition</p>
                  </th>
                  <th>
                    <p>Example</p>
                  </th>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">(?imnsx-imnsx)</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Sets or disables options such as case insensitivity in the middle of a pattern. For more information, see <span><a href=""http://msdn.microsoft.com/en-us/library/yd1hzczs.aspx"">Regular Expression Options</a></span>.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">\bA(?i)b\w+\b</span> matches ""ABA"", ""Able"" in ""ABA Able Act""</p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">(?#</span>
                      </span>
                      <span class=""parameter"">comment</span>
                      <span>
                        <span class=""input"">)</span>
                      </span>
                    </p>
                  </td>
                  <td>
                    <p>Inline comment. The comment ends at the first closing parenthesis.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">\bA(?#Matches words starting with A)\w+\b</span>
                    </p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <span>
                        <span class=""input"">#</span>
                      </span> [to end of line]</p>
                  </td>
                  <td>
                    <p>X-mode comment. The comment starts at an unescaped <span><span class=""input"">#</span></span> and continues to the end of the line.</p>
                  </td>
                  <td>
                    <p>
                      <span class=""code"">(?x)\bA\w+\b#Matches words starting with A</span>
                    </p>
                  </td>
                </tr>
              </table>
            </div>
            <p>
              <a href=""#top"">Back to top</a>
            </p>
          </div>
        </div>
        <div>
          <div class=""LW_CollapsibleArea_TitleDiv"">
            <div>
              <a href=""javascript:void(0)"" class=""LW_CollapsibleArea_TitleAhref"" title=""Collapse"">
                <span class=""cl_CollapsibleArea_expanding LW_CollapsibleArea_Img""></span>
                <span class=""LW_CollapsibleArea_Title"">See Also</span>
              </a>
              <div class=""LW_CollapsibleArea_HrDiv"">
                <hr class=""LW_CollapsibleArea_Hr"" />
              </div>
            </div>
          </div>
          <div class=""sectionblock"">
            <a id=""seeAlsoToggle"">
              
            </a>
            <h4 class=""subHeading"">Reference</h4>
            <div class=""seeAlsoStyle"">
              <span>
                <a href=""http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.aspx"">System.Text.RegularExpressions</a>
              </span>
            </div>
            <div class=""seeAlsoStyle"">
              <span>
                <a href=""http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regex.aspx"">Regex</a>
              </span>
            </div>
            <h4 class=""subHeading"">Concepts</h4>
            <div class=""seeAlsoStyle"">
              <a href=""http://msdn.microsoft.com/en-us/library/30wbz966.aspx"">Regular Expression Classes</a>
            </div>
            <h4 class=""subHeading"">Other Resources</h4>
            <div class=""seeAlsoStyle"">
              <span>
                <a href=""http://msdn.microsoft.com/en-us/library/hs600312.aspx"">.NET Framework Regular Expressions</a>
              </span>
            </div>
            <div class=""seeAlsoStyle"">
              <a href=""http://msdn.microsoft.com/en-us/library/kweb790z.aspx"">Regular Expression Examples</a>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</div>





<div id=""contentFeedback"">
    <form method=""post"" action=""/en-us/library/feedback/add/az24scfc.aspx"">
        <input name=""__RequestVerificationToken"" type=""hidden"" value=""Xp2SrOMn/NWUhAjd1bCDjOBAB/un0nwANAC+UOTTI6rj2+O6kXN2mW4BjDKrbgQjWGFA72G74Si+EXWehFxXIMUAA271XJW4XE4J8ICOBefy0Itun2w1iY1P9zjyM63wZeQ+xw=="" />
    <div id=""contentFeedbackContainer"">
        <div class=""FeedbackTitleContainer"">
            <a name=""feedback""></a>
        Did you find this helpful?
            <input id=""rdIsUsefulYes"" name=""rdIsUseful"" type=""radio"" value=""1"" onclick=""toggleContentFeedback('Yes');"" /><label for=""rdIsUsefulYes"">Yes</label>
            <input id=""rdIsUsefulNo"" name=""rdIsUseful"" type=""radio"" value=""0"" onclick=""toggleContentFeedback('No');"" /><label for=""rdIsUsefulNo"">No</label>
        
        </div>
        
            <div id=""contentFeedbackQAContainer"">
                
                    <div id=""feedbackListNoContainer"" class=""FeedbackListContainer"">
                        
                            <div>
                                <input id=""chkbxNo201"" name=""chkbxNo"" type=""checkbox"" value=""201"" />
                                <label for=""chkbxNo201"">Not accurate</label>
                            </div>
                        
                            <div>
                                <input id=""chkbxNo202"" name=""chkbxNo"" type=""checkbox"" value=""202"" />
                                <label for=""chkbxNo202"">Not enough depth</label>
                            </div>
                        
                            <div>
                                <input id=""chkbxNo203"" name=""chkbxNo"" type=""checkbox"" value=""203"" />
                                <label for=""chkbxNo203"">Need more code examples</label>
                            </div>
                        
                    </div>
                
                <div class=""FeedbackTellUsMoreContainer"">
                    <textarea id=""feedbackText"" name=""feedbackText"" class=""TellUsMoreTextBoxSearchLoaded"" onfocus=""WatermarkFocus(this, 'Tell us more...', 'TellUsMoreTextBoxSearch')"" onblur=""WatermarkBlur(this, 'Tell us more...', 'TellUsMoreTextBoxSearchLoaded')"" onmouseover=""TextBoxCharactersCounter(this, document.getElementById('feedbackTextCounter'), 1500)"" onkeydown=""TextBoxCharactersCounter(this, document.getElementById('feedbackTextCounter'), 1500)"" onkeyup=""TextBoxCharactersCounter(this, document.getElementById('feedbackTextCounter'), 1500)"">Tell us more...</textarea>
                </div>
                <span class=""counter"">(<span id=""feedbackTextCounter"">1500</span> characters remaining)</span>
                <input type=""hidden"" id=""returnUrl"" name=""returnUrl"" value=""http://msdn.microsoft.com/en-us/library/az24scfc.aspx"" />
                <input type=""submit"" id=""submit"" value=""Submit"" title=""Click to Submit Feedback"" onclick=""WatermarkOnSubmit(document.getElementById('feedbackText'), 'Tell us more...', 'TellUsMoreTextBoxSearch')"" />
                <div style=""clear: both;""></div>
            </div>  
        
    </div>
	</BODY>
 </html> 
";





    }

}