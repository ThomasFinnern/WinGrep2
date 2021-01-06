using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MainGlobal;
using ErrorCapture;

namespace NetGrep
{
    class clsSearchInLines
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Lines"></param>
        /// <param name="regExSearch"></param>
        /// <param name="GrepProperties"></param>
        /// <param name="FileName"></param>
        /// <param name="Files2LineResults"></param>
        /// <returns>true if a match was found</returns>
        public static bool DoSearchInLines(string FileName,
            Regex regExSearch,
            clsSearchProperties GrepProperties,
            string TitleFileName,
            //ref List<clsFileResults> Files2LineResults)
            ref clsFileResults FileResult)
        {
            bool bMatchFound = false;
            try 
            { 
                bMatchFound = DoSearchInLines(File.ReadAllLines(FileName, Encoding.Default),
                    regExSearch,
                    GrepProperties,
                    TitleFileName,
                    //ref List<clsFileResults> Files2LineResults)
                    ref FileResult);            
            }
            catch // catch (Exception Ex)
            {
                // ReadAllLines failed: Inform user 
                // ToDo: if (Global.config.BIsFileReadErrors or if (!Global.config.bDontShowFileReadErrors 
                MessageBox.Show("File: " + FileName + " could not be opened");

                // clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                //ErrCapture.ShowExeption();
            }
                
            return bMatchFound;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Lines"></param>
        /// <param name="regExSearch"></param>
        /// <param name="GrepProperties"></param>
        /// <param name="FileName"></param>
        /// <param name="Files2LineResults"></param>
        /// <returns>true if a match was found</returns>
        public static bool DoSearchInLines(IEnumerable <string> Lines, 
            Regex regExSearch, 
            clsSearchProperties GrepProperties,
            string FileName,
            //ref List<clsFileResults> Files2LineResults)
            ref clsFileResults FileResult)
        {

            //clsFileResults FileResult = null;
            FileResult = null;
            clsSurroundingFileLines SurroundingFileLines = new clsSurroundingFileLines();

            try 
            {
                //--------------------------------------------------------------------------------------
                // Go through every line
                //--------------------------------------------------------------------------------------

                // bool bMatchFound = false;
                int LineIdx = 1;
                foreach (string Line in Lines)
                {
                    int LastIdx = 0;
                    int StartIdx = -1;

                    SurroundingFileLines.AddLine (LineIdx, Line);
                    //SurroundingFileLines.KeepPreNbr = Global.Config.PrepareLineNbrPreviousToMatch;
                    //SurroundingFileLines.KeepPostNbr = Global.Config.PrepareLineNbrFollowingMatch;
                    //SurroundingFileLines.Keep.LineNbrPreviousToMatch = GrepProperties.ViewSetting.Show.LineNbrPreviousToMatch;
                    //SurroundingFileLines.Keep.LineNbrFollowingMatch = GrepProperties.ViewSetting.Show.LineNbrFollowingMatch;
                    SurroundingFileLines.Keep.LineNbrPreviousToMatch = GrepProperties.ViewSetting.Keep.LineNbrPreviousToMatch;
                    SurroundingFileLines.Keep.LineNbrFollowingMatch = GrepProperties.ViewSetting.Keep.LineNbrFollowingMatch;

                    // Search in string
                    // StartIdx = Line.IndexOf(SearchString, LastIdx, UseStringcomparison);
                    Match MatchSearch = regExSearch.Match(Line, LastIdx);
                    StartIdx = MatchSearch.Index;
                    if (MatchSearch.Success)
                    {
                        // Standard search  ?
                        if (!GrepProperties.bLinesWithNoMatch)
                        {
                            // Create an new fileresult if it does not exist
                            if (FileResult == null)
                            {
                                FileResult = new clsFileResults(FileName);
                                FileResult.SurroundingFileLines = SurroundingFileLines; 
                            }

                            SurroundingFileLines.OnMatchingLine(LineIdx);

                            clsLineResult LineResult = new clsLineResult();
                            FileResult.LinesResultInfos.Add(LineResult);
                            LineResult.Line = Line;
                            LineResult.LineIdx = LineIdx;

                            do
                            {
                                clsResultInfoInLine InsideLineInfo = new clsResultInfoInLine();

                                InsideLineInfo.StartIdx = StartIdx;
                                InsideLineInfo.Length = MatchSearch.Length;
                                LineResult.ResultInfos.Add(InsideLineInfo);

                                LastIdx = StartIdx + MatchSearch.Length;
                                MatchSearch = regExSearch.Match(Line, LastIdx);
                                StartIdx = MatchSearch.Index;
                            }
                            while (MatchSearch.Success);

                            if (GrepProperties.bStopAfterFirstMatch)
                                break;
                        }
                    }
                    else
                    {
                        // Use Lines with no match 
                        if (GrepProperties.bLinesWithNoMatch)
                        {
                            // Create an new filereult if not exists
                            if (FileResult == null)
                            {
                                FileResult = new clsFileResults(FileName);
                                FileResult.SurroundingFileLines = SurroundingFileLines;
                            }

                            SurroundingFileLines.OnMatchingLine(LineIdx);

                            clsLineResult LineResult = new clsLineResult();
                            LineResult.Line = Line;
                            LineResult.LineIdx = LineIdx;

                            clsResultInfoInLine InsideLineInfo = new clsResultInfoInLine();
                            InsideLineInfo.StartIdx = StartIdx;
                            InsideLineInfo.Length = MatchSearch.Length;
                            LineResult.ResultInfos.Add(InsideLineInfo);

                            // ??? FileResult.LinesResultInfos.Add(LineResult);


                        }
                    }

                    LineIdx++;
                }

                SurroundingFileLines.FileEnd();
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            bool bMatchFound = false;
            if (FileResult != null)
                bMatchFound = true;
            else
                bMatchFound = false;
                
            return bMatchFound ;
        }
    }
}
