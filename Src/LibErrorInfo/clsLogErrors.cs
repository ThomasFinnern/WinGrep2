using System;
using System.Collections.Generic;
using System.Text;

//using DebugLog;

namespace ErrorCapture
{
    public class clsLogErrors
    {

        //===============================================================================
        // clsLogErrors.cls
        //-------------------------------------------------------------------------------
        // Keeps error messages when opening new package files
        //
        //-------------------------------------------------------------------------------
        //
        //===============================================================================

        private List<clsLogError> mLogInfo;
        public List<clsLogError> LogInfo 
        {
            get { return mLogInfo; }
            set { mLogInfo = value; }
        }

        public clsLogErrors()
        {
            Init ();
        }

        public void Init()
        {
            // oLogError
            mLogInfo = new List<clsLogError>();
        }

        public bool AddItem(int itemNumber, string InfoText, clsLogError.eErrorType ErrType, string ErrText)
        {
            bool bIsOk = false;

            clsLogError NewErrorEntry = new clsLogError(itemNumber, InfoText, ErrType, ErrText);
            mLogInfo.Add (NewErrorEntry);

            bIsOk = true;
            return bIsOk;
        }

        public int ItemCount
        {
            get { return mLogInfo.Count; }
        }

        public bool GetItemData(short Idx, ref int Number, ref clsLogError.eErrorType errType, ref string ErrText)
        {
            bool bIsOk = false;

            if ((Idx >= mLogInfo.Count) || (Idx < 0))
            {
                return bIsOk; // false
            }

            clsLogError ActclsLogError = mLogInfo[Idx];

            //    item = lst(i)
            Number = ActclsLogError.TextItemNumber;
            errType = ActclsLogError.ErrorType;
            ErrText = ActclsLogError.ErrorText;

            return true;

        }


/* 
        public bool FillOutGrid(ref AxMSFlexGridLib.AxMSFlexGrid grid)
        {
            // grid.Rows = 1

            short i;

            // grid.WordWrap = True

            grid.Rows = itemCnt + 1;
            for (i = 0; i <= itemCnt - 1; i++)
            {
                //grid.Rows = grid.Rows + 1
                grid.set_TextMatrix(i + 1, 0, (string)lst(i).itemNum);

                if ((lst(i).err_class == defClsLogErrors.errclass.EC_ERROR))
                {
                    grid.set_TextMatrix(i + 1, 1, "ERROR");
                }
                else
                {
                    grid.set_TextMatrix(i + 1, 1, "WARNING");
                }

                grid.set_TextMatrix(i + 1, 2, lst(i).err_text);


            }
            return i;

        }
*/
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
            //short Idx;
            string Separator;

            if (bFlat == true)            
            {
                Separator = "\t";
            }
            else
            {
                Separator = "\r\n" + StartTxt + "\t";
            }

            OutTxt = StartTxt + "Log Info has " + mLogInfo.Count.ToString () + " entries" + Separator;
            // List<clsLogError> mLogInfo;
            foreach (clsLogError LogError in mLogInfo)
            {
                OutTxt = OutTxt + LogError.Text(StartTxt + "\t", false);
            }

            return OutTxt;
       }
    }
}
