using System;
using System.Collections.Generic;
using System.Text;

/// Functions from Visual basic are missing in C#. So here some are simulated
namespace LibVbReplacements
{
    public class clsVbReplacement
    {
        public static bool IsNumeric(string strTest)
        {
            // bool bIsNumeric = true;
            if (strTest.Length < 1)
                return false; // needed in LangMan
            
            bool bIsSignMode = true;
            foreach (char charTest in strTest)
            {
                // First char ? -> check for sing characters too
                if (bIsSignMode)
                {
                    if (!"-+0123456789.".Contains(charTest.ToString()))
                        return false;
                    bIsSignMode = false;
                }
                else
                {
                    if (!"0123456789.".Contains(charTest.ToString()))
                        return false;
                }
            }

            return true;
        }

        // Constants.vbCrLf -> Environment.NewLine
        // Microsoft.VisualBasic.
        // ControlChars.CrLf.
        // Internet: Migrates from VB 6 constants to C#
//        Environment
//            '\t'
        // Constants

        // .

    }
}