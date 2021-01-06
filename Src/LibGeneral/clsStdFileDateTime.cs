using System;
using System.Collections.Generic;
using System.Text;

//namespace StandardFileDateTime
namespace LibStdFileDateTime
{
    ///------------------------------------------------------------------------------------
    /// <summary>
    /// Gets back "standard" strings from actual date and time to use in filenames and debug strings
    /// </summary>
    ///------------------------------------------------------------------------------------
    /// To Do's:
    /// ToDo: Check last parameters as they are wrong 
    ///------------------------------------------------------------------------------------
    public class clsStdFileDateTime
    {
        /// <summary>
        /// StdFileDateTimeFormatString = Format(Date, "yyyymmdd") & "_" & Trim(Format(Time, "hhmmss"))
        /// </summary>
        /// <returns></returns>
        public static string StdFileDateTimeFormatString()
        {
            //return VB6.Format(Today, "yyyymmdd") + "_" + Strings.Trim(VB6.Format(TimeOfDay, "hhmmss"));
            string OutTxt = string.Format("{0:0000}{1:00}{2:00}_{3:00}{4:00}{5:00}",
                //DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                //DateTime.Today.Minute, DateTime.Today.Second, DateTime.Today.Millisecond
                DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second
                //, DateTime.Now.Millisecond
                // DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond
            );

            return OutTxt;
        }

        // strDateTime = "Date: " + VB6.Format(Today, "dd.mm.yyyy") + " Time: " + Strings.Trim(VB6.Format(TimeOfDay, "hh:mm:ss"));
        /// <summary>
        /// String contains the names 'Date:' and 'Time:' useful for debug purposes
        /// </summary>
        /// <returns></returns>
        public static string DateTimeFormatString()
        {
            //return VB6.Format(Today, "yyyymmdd") + "_" + Strings.Trim(VB6.Format(TimeOfDay, "hhmmss"));
            string OutTxt = string.Format("Date: {0:0000}{1:00}{2:00} Time: {3:00}:{4:00}:{5:00}",
                //DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                //DateTime.Today.Minute, DateTime.Today.Second, DateTime.Today.Millisecond
                DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second
                //, DateTime.Now.Millisecond
                // DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond
            );

            return OutTxt;
        }

        /// <summary>
        /// StdFileDateTimeFormatStringMsec = Format(Date, "yyyymmdd") & "_" & Trim(Format(Time, "hhmmss") & "000msec.")
        /// </summary>
        /// <returns></returns>
        public static string StdFileDateTimeFormatStringMsec()
        {
            string OutTxt = string.Format("{0:0000}{1:00}{2:00}_{3:00}{4:00}{5:00}.{6:00}",
                //DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                //DateTime.Today.Minute, DateTime.Today.Second, DateTime.Today.Millisecond
                DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond
                // DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond
            );

            return OutTxt;
        }
    }
}