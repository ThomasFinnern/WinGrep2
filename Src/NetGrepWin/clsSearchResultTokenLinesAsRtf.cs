using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace NetGrep
{
    /// <summary>
    /// Rich text format of search result
    /// </summary>
    class clsSearchResultTokenLinesAsRtf
    {
        public clsFileResults FileResults;
        private int LastUnderlineStart = -1;
        private int LastUnderlineLength = -1;

        public clsSearchResultTokenLinesAsRtf()
        {
            FileResults = new clsFileResults ("unknownNameFileResult.txt");
        }

        public clsSearchResultTokenLinesAsRtf(clsFileResults InFileResults)
        {
            FileResults = InFileResults;
        }

        public void AssignText(RichTextBox richTextBoxFileContent, 
            RichTextBox richTextBoxLineIdx)
        {
            //// richTextBoxFileContent.rtf = "Not found file .... "
            //richTextBoxFileContent.Text = File.ReadAllText(NextFileName);
            int Idx = 0;

            richTextBoxFileContent.Clear();

            if (!File.Exists(FileResults.FileName))
                return;

            List <long> UsedLineNumbers = FileResults.GetUsedLineNumbers ();

            foreach (string Line in File.ReadAllLines(FileResults.FileName, Encoding.Default))
            {
                // Its a new line
                if (Idx > 0)
                    richTextBoxFileContent.AppendText("\r\n");

                Idx++;
                if (!UsedLineNumbers.Contains(Idx))
                {
                    richTextBoxFileContent.AppendText (Line); // +"\r\n";
                    // richTextBoxFileContent.Rtf += "\r\n";
                }
                else
                {
                    AssignTokenLine(Idx, richTextBoxFileContent);                
                }

                // richTextBoxLineIdx.AppendText(888888.ToString() + "\r\n");
                richTextBoxLineIdx.AppendText(Idx.ToString() + "\r\n");
            }

            // richTextBoxFileContent.SelectionStart = 0;
        }

        public void AssignTokenLine(int LineIdx, RichTextBox richTextBoxFileContent)
        {
            clsLineResult ResultInfo = FileResults.GetLineResultFromLineIdx(LineIdx);

            int LastIdx = 0;
            foreach (clsResultInfoInLine ResultInfoLine in ResultInfo.ResultInfos)
            {
                //--- Pre text ------------------------------------------------
                int StartIdx = ResultInfoLine.StartIdx;
                richTextBoxFileContent.AppendText (ResultInfo.Line.Substring(LastIdx, StartIdx - LastIdx));
                LastIdx = StartIdx;

                //--- Token text ------------------------------------------------

                // Bold on
                // http://www.codeproject.com/KB/cs/RTFSyntaxColour.aspx
                // richTextBoxFileContent.Rtf += "<b>";
                // richTextBoxFileContent.SelectionStart = richTextBoxFileContent.TextLength;
                richTextBoxFileContent.SelectionLength = 0;
                // Set Formatting
                // richTextBoxFileContent.SelectionColor = Color.DarkGreen;
                richTextBoxFileContent.SelectionColor = Color.DarkGreen;
                richTextBoxFileContent.SelectionFont = new Font(richTextBoxFileContent.SelectionFont, FontStyle.Bold);

                // Assing Token
                richTextBoxFileContent.AppendText(ResultInfo.Line.Substring(LastIdx, ResultInfoLine.Length));

                // Reset Format
                richTextBoxFileContent.SelectionColor = richTextBoxFileContent.ForeColor;
                richTextBoxFileContent.SelectionFont = new Font(richTextBoxFileContent.SelectionFont, FontStyle.Regular);

                //// richtextbox.SelectionColor = Color.Blue;
                //Color saveColor = richTextBoxFileContent.SelectionColor;
                //richTextBoxFileContent.SelectionColor = Color.Green;

                //richTextBoxFileContent.SelectedText = ResultInfo.Line.Substring(LastIdx, ResultInfoLine.Size);

                // Bold off
                // richTextBoxFileContent.Rtf += "<\b>";
                //richTextBoxFileContent.SelectionColor = saveColor;
                //richTextBoxFileContent.SelectedText = "";
                LastIdx += ResultInfoLine.Length;
            }

            if (LastIdx < ResultInfo.Line.Length - 1)
            {
                richTextBoxFileContent.AppendText (ResultInfo.Line.Substring(LastIdx, ResultInfo.Line.Length - LastIdx));
            }
            richTextBoxFileContent.Rtf += "\r\n";
        }

        public bool SelectNextResult(RichTextBox richTextBoxFileContent, 
            RichTextBox richTextBoxLineIdx,
            ref int RtfLineIdx, ref int ColumnIdx, ref int Length, 
            bool bIsStartOfFileResultFound)
        {
            // A field was selected before
            if (LastUnderlineStart > -1 && LastUnderlineLength > -1)
            {
                UnMarkActualToken(richTextBoxFileContent);
            }
        
            int LineIdx = RtfLineIdx +1;
            clsLineResult LineResult = FileResults.GetNextLineResultFromLineIdx(ref LineIdx, ref ColumnIdx, ref Length);

            if (LineResult != null)
            {
                // --- Scroll result into view ------------------------
                RtfLineIdx = LineIdx - 1; // ToDo: In standard search begin counting with 0 !!!
                Scroll2Selection(richTextBoxFileContent, richTextBoxLineIdx, RtfLineIdx);

                //--- Underline found result ------------------------------------------
                MarkActualToken(richTextBoxFileContent, RtfLineIdx, ColumnIdx, Length);

                LastUnderlineStart = richTextBoxFileContent.SelectionStart;
                LastUnderlineLength = Length;

                bIsStartOfFileResultFound = false;
            }
            else
            {
                richTextBoxFileContent.SelectionStart = 0;

                LastUnderlineStart = -1;
                LastUnderlineLength = -1;

                bIsStartOfFileResultFound = true;
            }

            return bIsStartOfFileResultFound;
        }

        private void MarkActualToken(RichTextBox richTextBoxFileContent, int RtfLineIdx, int ColumnIdx, int Length)
        {
            richTextBoxFileContent.SelectionStart =
                richTextBoxFileContent.GetFirstCharIndexFromLine(RtfLineIdx) + ColumnIdx;
            richTextBoxFileContent.SelectionLength = Length;
            richTextBoxFileContent.SelectionFont = new Font(richTextBoxFileContent.SelectionFont, FontStyle.Underline | FontStyle.Bold);
            richTextBoxFileContent.SelectionLength = 0;
        }

        private void UnMarkActualToken(RichTextBox richTextBoxFileContent)
        {
            // A field was selected before
            if (LastUnderlineStart > -1 && LastUnderlineLength > -1)
            {
                richTextBoxFileContent.SelectionStart = LastUnderlineStart;
                richTextBoxFileContent.SelectionLength = LastUnderlineLength;
                richTextBoxFileContent.SelectionFont = new Font(richTextBoxFileContent.SelectionFont, FontStyle.Bold);
                richTextBoxFileContent.SelectionLength = 0;
            }
        }

        private void Scroll2Selection(RichTextBox richTextBoxFileContent, RichTextBox richTextBoxLineIdx, int RtfLineIdx)
        {
            //--- Scroll windows -----------------------------------------------------------
            if (RtfLineIdx > 7)
            {
                richTextBoxFileContent.SelectionStart =
                    richTextBoxFileContent.GetFirstCharIndexFromLine(RtfLineIdx-7);
                richTextBoxLineIdx.SelectionStart =
                    richTextBoxLineIdx.GetFirstCharIndexFromLine(RtfLineIdx - 7);
            }
            else
            {
                richTextBoxFileContent.SelectionStart = 0;
                richTextBoxLineIdx.SelectionStart = 0;
            }

            richTextBoxFileContent.ScrollToCaret();
            richTextBoxLineIdx.ScrollToCaret();
        }

        public bool SelectPreviousResult(RichTextBox richTextBoxFileContent,
            RichTextBox richTextBoxLineIdx,
            ref int RtfLineIdx, ref int ColumnIdx, ref int Length,
            bool bIsStartOfFileResultFound)
        {
            // A field was selected before
            if (LastUnderlineStart > -1 && LastUnderlineLength > -1)
            {
                UnMarkActualToken(richTextBoxFileContent);            
            }
        
            int LineIdx = RtfLineIdx + 1;
            clsLineResult LineResult = FileResults.GetPreviousLineResultFromLineIdx(ref LineIdx, ref ColumnIdx, ref Length);

            if (LineResult != null)
            {
                // --- Scroll result into view ------------------------
                RtfLineIdx = LineIdx - 1; // ToDo: In standard search begin counting with 0 !!!
                Scroll2Selection(richTextBoxFileContent, richTextBoxLineIdx, RtfLineIdx);

                //--- Underline found result ------------------------------------------
                MarkActualToken(richTextBoxFileContent, RtfLineIdx, ColumnIdx, Length);

                LastUnderlineStart = richTextBoxFileContent.SelectionStart;
                LastUnderlineLength = Length;

                bIsStartOfFileResultFound = false;
            }
            else
            {
                richTextBoxFileContent.SelectionStart = richTextBoxFileContent.TextLength;

                LastUnderlineStart = -1;
                LastUnderlineLength = -1;

                bIsStartOfFileResultFound = true;
            }

            return bIsStartOfFileResultFound;
        }



    }
}
