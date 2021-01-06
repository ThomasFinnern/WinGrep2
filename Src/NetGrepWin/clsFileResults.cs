using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using ErrorCapture;
using HtmlFromToken;

namespace NetGrep
{
    [Serializable]
    public class clsFileResults
    {
        // Name
        // type t
        // Type Text 
        // Folder
        // Matches
        // size
        // date

        public clsFileResults(string UseFileName)
        {
            FileName = UseFileName;
        }

        private clsFileResults()
        {
            FileName = "";
        }

        #region Class properties

        public string FileName;
        public string TypeT;
        public string TypeAsText;

        #endregion class properties

        public long MatchedNbr
        {
            get
            {
                long ActMatchNbr = 0;
                foreach (clsLineResult ResultInfo in LinesResultInfos)
                {
                    ActMatchNbr += ResultInfo.MatchedNbr;
                }
                return ActMatchNbr;
            }
        }

        public long Size;
        public string Date;
        public clsSurroundingFileLines SurroundingFileLines = null;
        public List<clsLineResult> LinesResultInfos = new List<clsLineResult> ();

        public List<long> GetUsedLineNumbers()
        {
            List<long> UsedLineNumbers = new List<long>();
            foreach (clsLineResult ResultInfo in LinesResultInfos)
            {
                //if (!UsedLineNumbers.Contains())
                UsedLineNumbers.Add(ResultInfo.LineIdx);
            }

            return UsedLineNumbers;
        }

        // Attention: there may be more than one
        public clsLineResult GetLineResultFromLineIdx(int LineIdx)
        {
            clsLineResult LineResult = new clsLineResult();
            foreach (clsLineResult ResultInfo in LinesResultInfos)
            {
                if (ResultInfo.LineIdx == LineIdx)
                {
                    LineResult = ResultInfo;
                    break;
                }
            }

            return LineResult;
        }

        public clsLineResult GetNextLineResultFromLineIdx(ref int LineIdx, ref int ColumnIdx, ref int Length)
        {
            clsLineResult LineResult = null;
            foreach (clsLineResult ResultInfo in LinesResultInfos)
            {
                // Result above or in actual line 
                if (ResultInfo.LineIdx >= LineIdx)
                {
                    // Reult above actual line : take first result in line
                    if (ResultInfo.LineIdx > LineIdx)
                    {
                        LineResult = ResultInfo;
                        LineIdx = ResultInfo.LineIdx;
                        ColumnIdx = ResultInfo.ResultInfos[0].StartIdx;
                        Length = ResultInfo.ResultInfos[0].Length;
                        break;
                    }
                    else
                    { 
                        // Started in Line
                        foreach (clsResultInfoInLine ResultInfoInLine in ResultInfo.ResultInfos)
                        {
                            // In front of first result ?
                            if (ColumnIdx < ResultInfoInLine.StartIdx)
                            {
                                LineResult = ResultInfo;
                                LineIdx = ResultInfo.LineIdx;
                                ColumnIdx = ResultInfoInLine.StartIdx;
                                Length = ResultInfoInLine.Length;

                                break;                            
                            }
                        }

                        // Something found ?
                        if (LineResult != null)
                            break;                        
                    }
                }
            }

            return LineResult;
        }

        public clsLineResult GetPreviousLineResultFromLineIdx(ref int LineIdx, ref int ColumnIdx, ref int Length)
        {
            clsLineResult LineResult = null;

            // foreach (clsLineResult ResultInfo in LinesResultInfos.Reverse())
            //	foreach (string s in arr.Reverse<string>())
            for (int Idx = LinesResultInfos.Count - 1;  Idx >= 0; Idx--)
            {
                clsLineResult ResultInfo = LinesResultInfos[Idx];
                // Reult above actual line 
                if (ResultInfo.LineIdx <= LineIdx)
                {
                    if (ResultInfo.LineIdx < LineIdx)
                    {
                        LineResult = ResultInfo;
                        LineIdx = ResultInfo.LineIdx;
                        ColumnIdx = ResultInfo.ResultInfos[ResultInfo.ResultInfos.Count -1].StartIdx;
                        Length = ResultInfo.ResultInfos[ResultInfo.ResultInfos.Count - 1].Length;

                        break;
                    }
                    else
                    {
                        // Started in Line
                        //  foreach (clsResultInfoInLine clsResultInfoInLine in ResultInfo.ResultInfos)
                        for (int InfoIdx = ResultInfo.ResultInfos.Count - 1; InfoIdx >= 0; InfoIdx--)
                        {
                            clsResultInfoInLine ResultInfoInLine = ResultInfo.ResultInfos[InfoIdx];
                            // In front of first result ?
                            if (ColumnIdx > ResultInfoInLine.StartIdx + ResultInfoInLine.Length)
                            {
                                LineResult = ResultInfo;
                                LineIdx = ResultInfo.LineIdx;
                                ColumnIdx = ResultInfoInLine.StartIdx;
                                Length = ResultInfoInLine.Length;

                                break;
                            }
                        }

                        // Something found ?
                        if (LineResult != null)
                            break;
                    }
                }
            }

            return LineResult;
        }

        public clsLineResult MatchingLineResult(long LineNumber)
        {
            clsLineResult FoundLineResult = null;

            foreach (clsLineResult LinesResult in LinesResultInfos)
            {
                if (LinesResult.LineIdx == LineNumber)
                {
                    FoundLineResult = LinesResult;
                    break;
                }

                // Guess for ordered list             
                if (LinesResult.LineIdx > LineNumber)
                    break;            
            }

            return FoundLineResult;
        }

        public string ToStringLines()
        {
            string OutTxt = "";

            OutTxt = OutTxt + "FileName: " + FileName + "\r\n";

            foreach (clsLineResult ResultInfo in LinesResultInfos)
            {
                OutTxt = OutTxt + ResultInfo.ToStringLine();
            }

            return (OutTxt);
        }

        public override string ToString()
        {
            string OutTxt = "";
            OutTxt = OutTxt + "FileName: " + FileName + "\r\n";
 
            foreach (clsLineResult ResultInfo in LinesResultInfos)
            {
                OutTxt = OutTxt + ResultInfo + "\r\n";
            }

            return (OutTxt);
        }
    }
}
