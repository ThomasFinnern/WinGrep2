using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ErrorInformation
{
    public enum ToStringStyle : int
    {
        Fat_OneParameterPerLine = 0x00,
        Flat_AllParameterInOneLine = 0x01,
    };

    class ErrorInfo
    {
        string mErrorText;
        string mWarningText;
        bool mbErrorFound;
        bool mbWarningFound;
        string mErrorSource;
        List<ErrorInfo> mErrorList;  // TODO find a better name

        public ErrorInfo()
        {
            this.Clear();
        }

        // use this GetType().FullName; 
        public ErrorInfo(string CallingTypeFullString) 
        {
            this.Clear();
            mErrorSource = CallingTypeFullString;
        }

        public ErrorInfo(ErrorInfo ExistingErrInfo)
        {
            //this.Clear();
            mErrorText = ExistingErrInfo.ErrorText;
            mWarningText = ExistingErrInfo.WarningText;
            mErrorSource = ExistingErrInfo.ErrorSource;
            mbErrorFound = ExistingErrInfo.bErrorFound;
            mbWarningFound = ExistingErrInfo.bWarningFound;
            mErrorList = ExistingErrInfo.mErrorList;
        }

        [XmlIgnore]
        public string ErrorText
        {
            get { return mErrorText; }
            set
            {
                if (value != null)
                {
                    if (value.Length > 0)
                    {
                        mErrorText = value;
                        mbErrorFound = true;
                    }
                    else
                    {
                        // tried with empty value
                        mErrorText = "";
                        mbErrorFound = false;
                    }
                }
                else
                {
                    // tried but not successfull : then set error or not set error thats the question
                    mErrorText = "";
                    mbErrorFound = false;
                }

                // TODO: Add classname automatically into 
                // mErrorSource = GetType().FullName; // this shall be outer class
            }
        }

        [XmlIgnore]
        public string WarningText
        {
            get { return mWarningText; }
            set
            {
                if (value != null)
                {
                    if (value.Length > 0)
                    {
                        mWarningText = value;
                        mbWarningFound = true;
                    }
                    else
                    {
                        // tried with empty value
                        mWarningText = "";
                        mbWarningFound = false;
                    }
                }
                else
                {
                    // tried but not successfull : then set error or not set error thats the question
                    mWarningText = "";
                    mbWarningFound = false;
                }
            }
        }

        [XmlIgnore]
        public bool bErrorFound
        {
            get { return mbErrorFound; }
            set { mbErrorFound = value; }
        }

        [XmlIgnore]
        public bool bWarningFound
        {
            get { return mbWarningFound; }
            set { mbWarningFound = value; }
        }

        // Source File/class it was raised
        [XmlIgnore]
        public string ErrorSource
        {
            get { return mErrorSource; }
            set 
            {
                if (value != null)
                {
                    if (value.Length > 0)
                    {
                        mErrorSource = value;
                        mbErrorFound = true;
                    }
                    else
                    {
                        // tried with empty value
                        mErrorSource = "";
                        mbErrorFound = false;
                    }
                }
                else
                {
                    // tried but not successfull : then set error or not set error thats the question
                    mErrorSource = "";
                    mbErrorFound = false;
                }
            }
        }

        [XmlIgnore]
        public List<ErrorInfo> ErrorList
        {
            get { return mErrorList; }
            set { mErrorList = value; }
        }
    
    /*
        public string 
        {
            get { return m; }
            set { m = value; }
        }
        public string 
        {
            get { return m; }
            set { m = value; }
        }
*/

        public void AddErrorLine (string ErrorLine)
        {
            if(ErrorLine != null)
            {
                if (ErrorText.Length > 0)
                {
                    ErrorText = ErrorText + "\r\n" + ErrorLine;                
                }
                else
                {
                    ErrorText = ErrorLine;                
                }
            }
        }

        public void AddWarningLine (string WarningLine)
        {
            if(WarningLine != null)
            {
                if (WarningText.Length > 0)
                {
                    WarningText = WarningText + "\r\n" + WarningLine;                
                }
                else
                {
                    WarningText = WarningLine;                
                }
            }
        }

        public void AddErrorInfo(ErrorInfo ExistingErrInfo)
        {
            // AddErrorInfo(ErrorInfo newErrInfo, "");
            mErrorList.Add(ExistingErrInfo);
            if (ExistingErrInfo.bErrorFound)
            {
                mbErrorFound = true;
                if (ErrorText.Length == 0)
                {
                    // Todo: Is assignment in this case necessary ?
                    ErrorText = "Additional Errors see list below";
                }
            }

            if (ExistingErrInfo.bWarningFound)
            {
                mbWarningFound = true;
                if (WarningText.Length == 0)
                {
                    // Todo: Is assignment in this case necessary ?
                    WarningText = "Additional Errors in list";
                }
            }
        }

        // AddText to existing info in front of warning, or error
        /* Example : Chunks of lines are read from a file. The line handling class 
         * detects an error and creates an ErrorInfo object. The enclosing file 
         * reading class wants to add the info about filename and line where the 
         * error happens to the already createt Error message
         */
        public void AssignPreText(string PreText)
        {
            // Text exists as otherwise no addional info is generated 
            if (mErrorText.Length > 0)
                mErrorText = PreText + mErrorText;

            // Text exists as otherwise no addional info is generated 
            if (mWarningText.Length > 0)
                mWarningText = PreText + mWarningText;

            // the Errorsource may be changed without hassling from outside
            // Text exists as otherwise no addional info is generated 
            //if (mErrorSource.Length == 0)
            //    mErrorSource = PreText + mErrorSource;
        }

        public void Clear()
        {
            mErrorText = "";
            mWarningText = "";
            mErrorSource = "";
            mbErrorFound = false;
            mbWarningFound = false;
            mErrorList = new List<ErrorInfo>();
        }

        public ErrorInfo Clone()
        {
            ErrorInfo OutErrorInfo = new ErrorInfo();

            OutErrorInfo.ErrorText = mErrorText;
            OutErrorInfo.WarningText = mWarningText;
            OutErrorInfo.ErrorSource = mErrorSource;
            OutErrorInfo.bErrorFound = mbErrorFound;
            OutErrorInfo.bWarningFound = mbWarningFound;
            OutErrorInfo.ErrorList = mErrorList;

            return OutErrorInfo;
        }


        // ToDo: fill out toString
        public override string ToString()
        {
            return ToDebugString("");
        }

        public string ToDebugString(ToStringStyle IsFlat)
        {
            return ToDebugString("", IsFlat);
        }

        public string ToDebugString(string StartText)
        {
            return ToDebugString(StartText, ToStringStyle.Fat_OneParameterPerLine); 
        }

        public virtual string ToDebugString(string StartText, ToStringStyle IsFlat)
        {
            string OutTxt = "";
            string DivText; // dividerText
            
            if (IsFlat == ToStringStyle.Fat_OneParameterPerLine)
                DivText = "\r\n" + StartText + "   ";
            else
                DivText = "; ";

            // Expected is an ident at the beginning of the line
            OutTxt = OutTxt + StartText;

            OutTxt = OutTxt + "[ErrorInfo]" + DivText;
            OutTxt = OutTxt + string.Format("bErrorFound= {0}", mbErrorFound) + DivText;
            OutTxt = OutTxt + string.Format("ErrorText= \"{0}\"", mErrorText) + DivText;
            OutTxt = OutTxt + string.Format("bWarningFound= {0}", mbWarningFound) + DivText;
            OutTxt = OutTxt + string.Format("WarningText= \"{0}\"", mWarningText) + DivText;
            OutTxt = OutTxt + string.Format("ErrorSource= \"{0}\"", mErrorSource);

            if (mErrorList.Count > 0)
                OutTxt = OutTxt + DivText + ">>>Appended Entries";

            foreach (ErrorInfo NestedErr in mErrorList)
            {
                if (IsFlat == ToStringStyle.Fat_OneParameterPerLine)
                    OutTxt = OutTxt + "\r\n" + NestedErr.ToDebugString(StartText + "      ", IsFlat); 
                else
                    OutTxt = OutTxt + DivText + "[" + NestedErr.ToDebugString (IsFlat) + "]"; 
            }

            return OutTxt;
        }

        // ToDo: fill out bTestClassOk
        public virtual ErrorInfo TestClassIsOk()  // Todo: Return ErrorInfo ?
        {
            //bool bIsClassOk = true;
            ErrorInfo ErrorBack = new ErrorInfo();

/**
            // Test for giving back texts 
            ErrorBack.ErrorText = "This is a error test message";
            //Implizit: ErrorBack.bErrorFound = true;

            ErrorBack.WarningText = "This is a warning test message";
            // Implizit: ErrorBack.bWarningFound = true;
/**/

            // TODO Create exact tests

            ErrorInfo Test01 = new ErrorInfo();

            //---------------------------------------------------------------
            // Check for Autoset of error found flag
            //---------------------------------------------------------------
            Test01.ErrorText = "";
            if (Test01.bErrorFound == true)
            {
                ErrorInfo AddError = new ErrorInfo();
                AddError.ErrorText = "Autoset of 'error found' flag is true even if error message text was '' ";
                AddError.bErrorFound = true;
                ErrorBack.AddErrorInfo(AddError);
            }

            Test01.ErrorText = "yxz";
            if (Test01.bErrorFound == false)
            {
                ErrorInfo AddError = new ErrorInfo();
                AddError.ErrorText = "Autoset of 'error found' flag does not work";
                AddError.bErrorFound = true;
                ErrorBack.AddErrorInfo(AddError);
            }

            Test01.ErrorText = "";
//            if (Test01.bErrorFound == true)
            if (Test01.bErrorFound == false) // bring an error
            {
                ErrorInfo AddError = new ErrorInfo();
                AddError.ErrorText = "Autoset of 'error found' is not changed to back to false when there given Error text is \"\" ";
                AddError.bErrorFound = true;
                ErrorBack.AddErrorInfo(AddError);
            }

            //---------------------------------------------------------------
            // Check for Autoset of error found flag
            //---------------------------------------------------------------
            Test01.WarningText = "";
            if (Test01.bWarningFound == true)
            {
                ErrorInfo AddError = new ErrorInfo();
                AddError.ErrorText = "Autoset of 'WarningFound' flag is true even if warning message text was '' ";
                AddError.bErrorFound = true;
                ErrorBack.AddErrorInfo(AddError);
            }

            Test01.WarningText = "yxz";
            if (Test01.bWarningFound == false)
            {
                ErrorInfo AddError = new ErrorInfo();
                AddError.ErrorText = "Autoset of 'WarningFound' flag does not work";
                AddError.bErrorFound = true;
                ErrorBack.AddErrorInfo(AddError);
            }

            Test01.WarningText = "";
            if (Test01.bWarningFound == true)
            {
                ErrorInfo AddError = new ErrorInfo();
                AddError.ErrorText = "Autoset of 'WarningFound' is not changed to back to false when there given Warning text is \"\" ";
                AddError.bErrorFound = true;
                ErrorBack.AddErrorInfo(AddError);
            }

            //---------------------------------------------------------------
            // Check for addition of Error messages
            //---------------------------------------------------------------
            int ActLen;
            ActLen = Test01.ErrorText.Length;
            Test01.AddErrorLine ("asdf");
            if (ActLen == Test01.ErrorText.Length)
            {
                ErrorInfo AddError = new ErrorInfo();
                AddError.ErrorText = "AddErrorLine failed";
                AddError.bErrorFound = true;
                ErrorBack.AddErrorInfo(AddError);
            }

            //---------------------------------------------------------------
            // Check for addition of Warning messages
            //---------------------------------------------------------------
            //int ActLen;
            ActLen = Test01.WarningText.Length;
            Test01.AddWarningLine ("asdf");
            if (ActLen == Test01.WarningText.Length)
            {
                ErrorInfo AddError = new ErrorInfo();
                AddError.ErrorText = "AddWarningLine failed";
                AddError.bErrorFound = true;
                ErrorBack.AddErrorInfo(AddError);
            }

            //---------------------------------------------------------------
            // Todo: Check for addition of complete
            //---------------------------------------------------------------







            
            //Debug.Print ErrorBack;

            return ErrorBack;
        }
    }
}
