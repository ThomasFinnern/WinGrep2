/** May not be needed any more
using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Timers;
using System.Windows.Forms;
using LibStdFileDateTime;
using ErrorCapture;

namespace LogInputKeys
{
    public class clsLogInputKeys
    {
        public class clsLogInKeyValue 
        {
            public enum eEventType
            {
                FormEvent,
                ProcessEvent,
                BrowserEvent
            }

            public string Origin = "";
            public long Repeated = 0;
            public eEventType EventType = eEventType.FormEvent; // Not process key
            //public Keys Keys = 0;
            public Keys KeyData = 0; // Includes Shift, Alt, Control keys

            public override string ToString()
            {
                string OutTxt = "";
                // Keys BareKey = Key ~ (Keys.Control | Keys.Shift | Keys.Alt);
                Keys BareKey = KeyData & Keys.KeyCode;

                // OutTxt += Origin + ":" + Key + ".s" + ShiftKey;
                // (keys & Keys.Control) | (keys & Keys.Shift) | (keys & Keys.Alt));// keys.ToString());
                OutTxt += Origin + " ";
                // OutTxt += KeyData.ToString() + " ";
                int iKeyCode = (int) KeyData;
                // OutTxt += OutTxt + iKeyCode.ToString() + " ";
                OutTxt += "0x" + iKeyCode.ToString("X4") + " ";

                if ((KeyData & Keys.Control) == Keys.Control) OutTxt += "Ctrl";
                if ((KeyData & Keys.Shift) == Keys.Shift) OutTxt += "Shift";
                if ((KeyData & Keys.Alt) == Keys.Alt) OutTxt += "Alt";

                OutTxt += ": " + BareKey + " ";
                uint iBareKey = (uint) BareKey;
                OutTxt += ": " + iBareKey.ToString("X4") + " ";
                
                if (EventType == eEventType.ProcessEvent ) OutTxt += ".Process";

                if (Repeated > 0)
                    OutTxt += " r" +  Repeated;
                return OutTxt;
            }
        }

        private static List <clsLogInKeyValue > KeyValues = new List<clsLogInKeyValue> ();
        //private System.Timers.Timer NoKeyPressedTimer;
        private static System.Windows.Forms.Timer NoKeyPressedTimer;
        public static bool bIsTimerActive = false;
        public static int CallCount = 0;

        public clsLogInputKeys()
        {
            // timer for delayed write  ?? Synch ...
            //NoKeyPressedTimer = new System.Timers.Timer();
            NoKeyPressedTimer = new System.Windows.Forms.Timer();
            // NoKeyPressedTimer.Interval = 500; // 0.5 sec
            // NoKeyPressedTimer.Elapsed += new ElapsedEventHandler(OnTimeOut);
            NoKeyPressedTimer.Tick += OnTimeOut;
        }

        /*------------------------------------------------------------------------
          Interfaces to events on key down, up, ...
        ------------------------------------------------------------------------* /

        public void AddKeyValue(string Origin, PreviewKeyDownEventArgs e)
        {
            AddKeyValue(Origin, e.KeyData, clsLogInKeyValue.eEventType.FormEvent);
        }

        public void AddKeyValue(string Origin, KeyEventArgs e)
        {
            AddKeyValue(Origin, e.KeyData, clsLogInKeyValue.eEventType.FormEvent);
        }

        public void AddKeyValue(string Origin, HtmlElementEventArgs e)
        {
            Keys KeyData = 0;
            KeyData = (Keys) e.KeyPressedCode;

            if (e.CtrlKeyPressed)
                KeyData |= Keys.Control;
            if (e.ShiftKeyPressed)
                KeyData |= Keys.Shift;
            if (e.AltKeyPressed)
                KeyData |= Keys.Alt;

            AddKeyValue(Origin, KeyData, clsLogInKeyValue.eEventType.BrowserEvent);
        }

        public void AddKeyValue(string Origin, Keys InKeyData)
        {
            AddKeyValue(Origin, InKeyData, clsLogInKeyValue.eEventType.ProcessEvent);
        }

        public void AddKeyValue(string Origin, Keys InKeyData, clsLogInKeyValue.eEventType EventType)
        {
            int Idx;
            bool bIsNewKey = true;

            // •KeyCode is the Keys enumeration value for the key that is down
            // •KeyData is the same as KeyCode, but combined with any SHIFT/CTRL/ALT keys
            // •KeyValue is simply an integer representation of KeyCode

            while (bIsTimerActive == true)
                ;

            CallCount++; // for easear debugging
            //if (CallCount > 1)
            //{
            //    CallCount = CallCount;
            //}

            // Check 4 repeat key 
            if (KeyValues.Count > 0)
            { 
                Idx = KeyValues.Count - 1;

                // key already pressed 
                if (EventType == KeyValues[Idx].EventType
                    && Origin == KeyValues[Idx].Origin
                    && InKeyData == KeyValues[Idx].KeyData)
                {
                    KeyValues[Idx].Repeated++;
                    bIsNewKey = false;
                }
            }

            // No repeat key
            if (bIsNewKey)  
            {
                // new key
                KeyValues.Add(new clsLogInKeyValue());
                Idx = KeyValues.Count - 1;

                KeyValues[Idx].Origin = Origin;
                // this.Keys = e.KeyCode;
                KeyValues[Idx].KeyData = InKeyData;
                KeyValues[Idx].EventType = EventType;
            }

            // Restart Timer
            NoKeyPressedTimer.Interval = 500; // 0.5 sec
            NoKeyPressedTimer.Start();
        }
        

        // Write actual key combination 
        //private static void OnTimeOut(object source, ElapsedEventArgs e)
        private static void OnTimeOut(object source, EventArgs e)
        {
            try
            {
                NoKeyPressedTimer.Stop();

                // disable further keys for shortest time
                // copy pointer so the next key will survive 
                bIsTimerActive = true;

                List<clsLogInKeyValue> OldKeyValues = KeyValues;
                KeyValues = new List<clsLogInKeyValue>();
                bIsTimerActive = false;

                // Write key values
                string OutTxt = "";

                foreach (clsLogInKeyValue KeyValue in OldKeyValues)
                {
                    OutTxt += KeyValue.ToString() + "\r\n";
                }

                if (OutTxt.Length > 0)
                    WriteLog(OutTxt);
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();

                bIsTimerActive = false;
            }
        }

        public const string StdKeyLogFileNameName = "KeyLogger";
        public const string StdKeyLogFileNameExt = "txt";
        public const string StdKeyLogFileName = StdKeyLogFileNameName + "." + StdKeyLogFileNameExt;

        private static string mKeyLogFileName = StdKeyLogFileNameName + "." + StdKeyLogFileNameExt;
        public string KeyLogFileName
        {
            get { return mKeyLogFileName; }
            set { mKeyLogFileName = value; }
        }

        public string CreateAutoDateKeyLogFileName()
        {
            mKeyLogFileName = StdKeyLogFileNameName + "." + clsStdFileDateTime.StdFileDateTimeFormatString() + "." + StdKeyLogFileNameExt;
            return mKeyLogFileName;
        }


       // write timer ....
        public void CreateFile()
        {
            FileStream DebOutFile = File.Create(mKeyLogFileName);
            DebOutFile.Close();
        }

        public string StdLogPathFileName
        {
            get
            {
                //string RetPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\Log";
                string RetPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\" + Application.ProductName + "KeyLog.txt";
                return RetPath;
            }
        }


        public static void WriteLine(string OutLine)
        {
            WriteLog(OutLine + "\r\n");
        }

        public static bool WriteLog(string OutTxt)
        {
            return WriteLog(OutTxt, false);
        }

        public static bool WriteLog(string OutTxt, bool bDoResetBefore)
        {
            FileStream LogTxtStream;

            if ((mKeyLogFileName != ""))
            {
                if ((bDoResetBefore))
                {
                    LogTxtStream = new FileStream(mKeyLogFileName, FileMode.Create, FileAccess.Write);
                }
                else
                {
                    LogTxtStream = new FileStream(mKeyLogFileName, FileMode.Append, FileAccess.Write);
                }

                if ((LogTxtStream != null))
                {
                    StreamWriter TxtWriter = new StreamWriter(LogTxtStream);
                    TxtWriter.Write(OutTxt);
                    TxtWriter.Flush();   // Puffer => Disk
                    TxtWriter.Close();

                    LogTxtStream.Close();
                }
            }

            return true;
        }
    }
}
/**/


