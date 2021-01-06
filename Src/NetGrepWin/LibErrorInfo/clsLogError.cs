using System;
using System.Collections.Generic;
using System.Text;

//using DebugLog;

namespace ErrorCapture
{
    public class clsLogError
    {

        //===============================================================================
        // clsLogInfo.bat
        //-------------------------------------------------------------------------------
        // Helper for class clsLogErrors
        //
        //
        //
        //-------------------------------------------------------------------------------
        // Walter Maschinenbau GmbH     Copyright (c) 2006
        //
        //
        //
        //===============================================================================

        public enum eErrorType //errclass
        {
            EC_UNDEFINED,
            EC_WARNING,
            EC_ERROR
        }

        public clsLogError()
        {
            TextItemNumber = 0;
            LanguageText = "";
            ErrorType = eErrorType.EC_UNDEFINED;
            ErrorText = "";
        }

        public clsLogError(int itemNumber, string InfoText, eErrorType errCls, string ErrText)
        {
            TextItemNumber = itemNumber;
            LanguageText = InfoText;
            ErrorType = errCls;
            ErrorText = ErrText;
        }

        public int TextItemNumber;
        public string LanguageText;
        public eErrorType ErrorType;
        public string ErrorText;

        public string Text()
        {
            return Text ("");
        }

        public string Text(string StartTxt)
        {
            return Text (StartTxt, false);
        }

        public string Text(string StartTxt, bool bFlat)
        {
            string OutTxt = "";
            // short Idx;
            string Separator;
            string WarnErrTxt;

            if (bFlat == true)
            {
                Separator = "\t";
            }
            else
            {
                Separator = "\n"+ StartTxt + "\t";
            }

            //--------------------------------------------
            if (ErrorType == eErrorType.EC_ERROR)
            {
                WarnErrTxt = "ERROR";
            }
            else
            {
                if (ErrorType == eErrorType.EC_WARNING)
                {
                    WarnErrTxt = "Warning";
                }
                else
                    WarnErrTxt = "Undefined";
            }

            // ToDo: this may be written without so many big spacig seperators
            OutTxt = OutTxt + StartTxt + ": Text Item number " + TextItemNumber  + " Type: " + WarnErrTxt 
                + Separator + " Error Text: " + ErrorText
                + Separator + " Language Text: " + LanguageText;

            return OutTxt;
        }
    }
}