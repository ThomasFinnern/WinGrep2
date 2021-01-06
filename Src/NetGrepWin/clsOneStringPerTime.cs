using System;
using System.Collections.Generic;
using System.Text;

namespace NetGrep
{
    // ??? timer within or outside class ??? Used outside
    public class clsOneStringPerTime
    {
        string mLastInfo = "";
        public bool bLastInfoIsSet
        {
            get 
            {
                lock (mLastInfo)
                {
                    return mLastInfo.Length > 0;
                }
            }
        }

        /// <summary>
        /// Read last set string but deletes the original.
        /// Used to write the given method only once
        /// check bLastInfoIsSet to find ojut if it set before reading this variable
        /// </summary>
        /// <returns></returns>
        public string LastInfoOnce()
        {
            lock (mLastInfo) // used by interupt
            {
                string keep = mLastInfo;
                // mLastInfo = "";   // autdelete leads to read from system ?
                return keep;
            }
        }

        public string LastInfo
        {
            get 
            {
                lock (mLastInfo)
                {
                    return mLastInfo;
                }
            }
        
            set // multiple settings
            {
                lock (mLastInfo)
                {
                    mLastInfo = value;
                }
            }
        }
    }
}
