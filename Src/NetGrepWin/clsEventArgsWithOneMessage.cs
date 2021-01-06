using System;
using System.Collections.Generic;
using System.Text;

namespace NetGrep
{
    public class clsEventArgsWithOneMessage : EventArgs 
    {
        private String mMessage;

        public String Message
        {
            get { return mMessage; }
            set { mMessage = value; }
        }

        public clsEventArgsWithOneMessage(String InMessage)
        {
            mMessage = InMessage;
        }
    }
}

