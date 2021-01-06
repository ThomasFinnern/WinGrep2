using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;
using MainGlobal;
using ErrorCapture;

namespace NetGrep
{
    /// <summary>
    /// Keeps pre lines including token line. As soon as a token line is found all pre lines are kept in a special field. 
    ///    The token line will be removed 
    /// Keeps post lines up to m posdt lines
    /// 
    /// Normal case : Keeps n pre lines and m post line
    /// Special cases:
    /// 1) Token not found in m+ 1 line. Oldest line will be discared
    /// 2) Token found pre lines will be kept
    /// 3) Token in first line no pre lines just the token line to remove   
    /// 4) Post line is running out of space: return to pre line mode 
    ///    Attention : is new possible token line taken care of in new pre lines successfull ?
    /// 5) New token line while in post mode (throw away token line), keep the others
    /// 6) Postlines within ending 
    /// 7)
    /// 8)
    /// 9)
    /// 
    /// </summary>
    public class clsSurroundingFileLines
    {
        public enum eFileKeepLinesFoundNbr
        {
            eKEEP_BEFORE = 10,
            eKEEP_AFTER = 10,
            eKEEP_MAX = eKEEP_BEFORE + eKEEP_AFTER
        }

        public enum eLineState
        {
            ePreFound,
            ePostFound
        }

        public eLineState InState;
        public clsSurroundingLinesPara Keep = new clsSurroundingLinesPara ();
        //public long KeepPreNbr; // PrepareLineNbrPreviousToMatch
        //public long KeepPostNbr;// PrepareLineNbrFollowingMatch

        Dictionary<long, string> FileLines = new Dictionary<long,string> (); 
        Dictionary<long, string> PreFound = new Dictionary<long,string> (); 
        Dictionary<long, string> PostFound = new Dictionary<long,string> ();

        long lastUsedLineIdx = 0;

        // List<string> PreFound; 
        public clsSurroundingFileLines()
        {
            Keep.LineNbrPreviousToMatch = (long)eFileKeepLinesFoundNbr.eKEEP_BEFORE;
            Keep.LineNbrFollowingMatch = (long) eFileKeepLinesFoundNbr.eKEEP_AFTER;
        }

        public void AddLine(long LineNbr, string Line)
        {
            try
            {
                switch (InState)
                {
                    case eLineState.ePreFound:
                        if (PreFound.Count > Keep.LineNbrPreviousToMatch + 1) // +1: Found line is kept as number +1
                        {
                            long LeastNbr = LineNbr;
                            foreach (KeyValuePair<long, string> LineInfo in PreFound)
                            {
                                if (LeastNbr > LineInfo.Key)
                                    LeastNbr = LineInfo.Key;
                            }

                            PreFound.Remove(LeastNbr);
                        }

                        PreFound.Add(LineNbr, Line);
                        break;

                    case eLineState.ePostFound:
                        // Max number kept ? 
                        if (PostFound.Count > Keep.LineNbrFollowingMatch)
                        {
                            foreach (KeyValuePair<long, string> LineInfo in PostFound)
                            {
                                FileLines.Add(LineInfo.Key, LineInfo.Value);
                            }
                            PostFound = new Dictionary<long, string>();

                            InState = eLineState.ePreFound;
                            PreFound.Add(LineNbr, Line); // Needed if  actual line keeps search token
                        }
                        else
                        {
                            PostFound.Add(LineNbr, Line);
                        }

                        break;
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        public void OnMatchingLine(long LineNbr)
        {
            string dummy;
            try
            {
                switch (InState)
                {
                    case eLineState.ePreFound:
                        // if (PreFound.Keys[PreFound.Count - 1] != LineNbr)
                        if (!PreFound.TryGetValue(LineNbr, out dummy))
                        {
                            string OutTxt = "AddFoundLine: PreFound.Keys[PreFound.count - 1] != LineNumber";
                            MessageBox.Show(OutTxt);
                            return;
                        }

                        foreach (KeyValuePair<long, string> LineInfo in PreFound)
                        {
                            if (LineNbr != LineInfo.Key)
                                FileLines.Add(LineInfo.Key, LineInfo.Value);
                        }

                        PreFound = new Dictionary<long, string>();
                        InState = eLineState.ePostFound;

                        break;

                    case eLineState.ePostFound:
                        //if (PostFound.Keys[PreFound.Count - 1] != LineNbr)
                        if (!PostFound.TryGetValue(LineNbr, out dummy))
                        {
                            string OutTxt = "AddFoundLine: PostFound.Keys[PreFound.count - 1] != LineNumber";
                            MessageBox.Show(OutTxt);
                            return;
                        }

                        foreach (KeyValuePair<long, string> LineInfo in PostFound)
                        {
                            if (LineNbr != LineInfo.Key)
                                FileLines.Add(LineInfo.Key, LineInfo.Value);
                        }
                        PostFound = new Dictionary<long, string>();

                        // InState = eLineState.ePostFound;
                        break;
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        public void FileEnd()
        {
            InitLines(); // cONTENT  shall be replaced by content of initlines
        }

        public void InitLines()
        {
            try
            {
                lastUsedLineIdx = 0;

                // Update of line list
                switch (InState)
                {
                    // throw away not used pre matching
                    case eLineState.ePreFound:
                        PreFound = new Dictionary<long, string>();
                        // InState = eLineState.ePreFound;

                        break;

                    // Save post matching
                    case eLineState.ePostFound:
                        //if (PostFound.Keys[PreFound.Count - 1] != LineNbr)

                        InState = eLineState.ePreFound;

                        foreach (KeyValuePair<long, string> LineInfo in PostFound)
                        {
                            FileLines.Add(LineInfo.Key, LineInfo.Value);
                        }
                        PostFound = new Dictionary<long, string>();

                        break;
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="LineIdx">Matching line index</param>
        /// <param name="MaxItems">Expected longest range</param>
        /// <param name="PrevIdx">Previous Matching index</param>
        /// <param name="PrevMaxItems">Expected longest range of previous match</param>
        /// <returns></returns>
        public Dictionary<long, string> PreLines(long LineIdx, long MaxItems, long PrevIdx, long PrevPostItems)
        {
            Dictionary<long, string> OutPreLines = new Dictionary<long, string>();
            string OutLine;
            long StartIdx;

            try
            {
                // Does interfere with post lines of last matching Line ?
                long InBetweenItems = 0;
                if (PrevIdx > 0)
                {
                    InBetweenItems = LineIdx - PrevIdx - PrevPostItems -1;

                    // A) All inbetween Lines are alrerady written
                    if (InBetweenItems <= 0)
                        MaxItems = 0;
                    else
                    {
                        // B) Post items of previous are reaching pre items of this match
                        // InBetweenItems -= (PrevMaxItems + 1);
                        if (MaxItems > InBetweenItems)
                            MaxItems = InBetweenItems;

                    }
                }

                StartIdx = LineIdx - MaxItems;
                for (long Idx = StartIdx; Idx < LineIdx; Idx++)
                {
                    if (FileLines.TryGetValue(Idx, out OutLine))
                    {
                        OutPreLines.Add(Idx, OutLine);
                    }
                    //else
                    //    break;
                }

                lastUsedLineIdx = LineIdx;
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            return OutPreLines;
        }

        /// <summary>
        /// Lines after matching Line
        /// </summary>
        /// <param name="LineIdx">Matching line index</param>
        /// <param name="MaxItems">Expected longest range</param>
        /// <param name="PostIdx">Next Matching index</param>
        /// <returns></returns>
        /// 
        ///public Dictionary<long, string> PostLines(long LineIdx, long MaxItems, long PostIdx)
        public Dictionary<long, string> PostLines(long LineIdx, long MaxItems)
        {
            Dictionary<long, string> OutPreLines = new Dictionary<long, string>();

            string OutLine;
            try
            {
                // as the next search token line is missing in th e list the post lines will stop before printing too much lines
                //long InBetweenItems = MaxItems;  // May be biggest long but ...
                //if (PostIdx > LineIdx)
                //    InBetweenItems = PostIdx - LineIdx;

                //if (MaxItems > InBetweenItems)
                //    MaxItems = InBetweenItems;

                long EndIdx = LineIdx + MaxItems + 1;
                for (long Idx = LineIdx + 1; Idx < EndIdx; Idx++)
                {
                    if (FileLines.TryGetValue(Idx, out OutLine))
                    {
                        OutPreLines.Add(Idx, OutLine);
                    }
                    else
                        break;
                }

                lastUsedLineIdx = LineIdx;
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            return OutPreLines;
        }

        public override string ToString()
        {
            string OutTxt = "";

            OutTxt = OutTxt + "InState: " + InState.ToString();
            OutTxt = OutTxt + "PreFound.Count: " + PreFound.Count;
            OutTxt = OutTxt + "PostFound.Count: " + PostFound.Count;
            OutTxt = OutTxt + "FileLines.Count: " + FileLines.Count;

            OutTxt = OutTxt + Keep.ToString ();

            return OutTxt;
        }

        public string ToStringAll()
        {
            string OutTxt = "";

            OutTxt = OutTxt + "InState: " + InState.ToString();
            OutTxt = OutTxt + "PreFound: " + PreFound.ToString();
            OutTxt = OutTxt + "PostFound: " + PostFound.ToString();
            OutTxt = OutTxt + "FileLines: " + FileLines.ToString();

            return OutTxt;
        }
    }
}
