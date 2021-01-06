using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LibStringsUtf8
{
    public class clsLibStringsUtf8
    {
        //----------------------------------------------------------------------------------
        // A filesystem object may open in TristateFalse (No unicode),  
        // TristateMixed (UTF-8 unicode) or TristateTrue (UTF-16 unicode)
        // (fso As New FileSystemObject, LogTxtStream As TextStream  .....)
        // The function checks if a write of this string with file in 
        // TristateTrue mode will error out. -> returns true
        // When False TristateMixed at opening the file may be used
        //----------------------------------------------------------------------------------
        /// <summary>
        /// Checks if the string contains only character which may not be encoded with UTF-8 
        /// ? Value over 0x301B -> 12315
        /// </summary>
        /// <param name="strTest"></param>
        /// <returns>Returns true if UTF-16 is needed for this string</returns>
        public static bool StrIsNotUtf8(string strTest)
        {
            bool bStrIsNotUtf8 = false;

            int Idx; // As Integer
            int lLen; // As Integer
            int lAscW; // As Integer

            lLen = strTest.Length;
            for (Idx = 0; Idx < lLen; Idx++)
            {
                string ActChar = strTest.Substring(Idx, 1);
                byte [] result = System.Text.Encoding.Unicode.GetBytes(strTest);
                lAscW = result[0] + (result[1] << 8);
                if (lAscW > 12315)
                {
                    bStrIsNotUtf8 = true;
                    // Debug.Print("Val '" & Mid(strTest, Idx) & "':" & AscW(Mid(strTest, Idx)))
                    break;
                }
            }
            return bStrIsNotUtf8;
        }

        //----------------------------------------------------------------------------------
        // Returns True if the string contains a Unicode char which uses two bytes.
        //----------------------------------------------------------------------------------
        /// <summary>
        /// Checks every character if two bytes are needed for saving
        /// </summary>
        /// <param name="strTest"></param>
        /// <returns>True if two characters are needed for saving this sting in file</returns>
        public static bool StrIsUnicode(string strTest)
        {
            bool bStrIsUnicode = false;
            int Idx; // As Integer
		    int bLen; // As Integer
		    byte [] Map; // As Integer
    		
		    if (strTest.Length > 0) 
		    {
                Map = System.Text.UnicodeEncoding.Unicode.GetBytes(strTest);
			    bLen = Map.Length;
			    for (Idx = 1; Idx < bLen; Idx += 2)
                {
                    // Is it not an ascci character (Needs twol bytes to display
                    if (Map[Idx] > 0) 
                    {
					    bStrIsUnicode = true;
					    break;
                    }
                }
            }

            return bStrIsUnicode;
        }
    }
}

