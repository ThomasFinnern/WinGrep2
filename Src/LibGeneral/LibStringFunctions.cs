using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using DebugLog;
using LibStdFileDateTime;
// using MainGlobal;
using ErrorCapture;
// using LanguageManager;

namespace LibStringFunctions
{
    public class LibStringFunctions
    {

        /// <summary>
        /// Searches for a number as end of string. This number will be increased and the complete string will be returned.
        /// Leading '0's will be kept but eaten when a number grows
        /// When the number increases in size and no leading zero is available the string will increase in size
        /// </summary>
        /// <param name="sInNumber">String Like "Txx0009"</param>
        /// <returns>Incremented string "Txx0010"</returns>
        public static string IncrementLastNumberInText(String sInNumber)
        {
            string sOutNumber = sInNumber;
            try
            {
                if (sInNumber.Length > 1)
                {
                    Regex r = new Regex("^([^1-9]+)([1-9][0-9]*)$");
                    Match m = r.Match(sInNumber);
                    Group g1 = m.Groups[1];
                    Group g2 = m.Groups[2];

                    string TextPart = g1.ToString();
                    string sNewNumber = g2.ToString();
                    int NewNumber = Convert.ToInt32(sNewNumber);
                    NewNumber++;

                    string sIncNumber = NewNumber.ToString();
                    Regex r2 = new Regex("^10+$");
                    //Match m2 = r.Match(sIncNumber);
                    if (r2.IsMatch(sIncNumber))
                    {
                        if (TextPart.EndsWith("0"))
                        {
                            TextPart = TextPart.Substring(0, TextPart.Length - 1);
                        }
                    }

                    sOutNumber = TextPart + sIncNumber;
                }
            }
            catch
            {
                string OutTxt = @"InNumber failed to increment: '" + sInNumber + "' ";
                MessageBox.Show(OutTxt);
            }

            return sOutNumber;
        }


        // Todo:



    } // End class
} // End namespace