using System;
using System.Collections.Generic;
using System.Text;

namespace CmdLine2005
{
    /*===============================================================================
    clsOptionsBase.cs
    -------------------------------------------------------------------------------
    
     * Base of a model of an enabled option. This class does not contain data 
     * from commandline
     * Keeps Name, Helptext and pointer to a option function 
     * Basis for inheritance

    -------------------------------------------------------------------------------*/
    //  Open Jobs:
    //      -ToDo: 
    //      -ToDo: 
    //===============================================================================

    /// <summary>
    /// Base of a model of an enabled option. This class does not contain data 
    /// from commandline
    /// Keeps the name, a help text and a pointer to a function for an option. 
    /// This is a base for inheritance
    /// </summary>
    public class clsOptionsBase 
    {
        /// Type definition : Reference to function which may be called from external 
        /// (Example: In DoCommadns in clsCommandLine)
        /// </summary>
        public delegate void DlgOptFunction(); // reference to function without argument

        string mOptName;
        string mOptHelpString;
        DlgOptFunction mOptFunction;
        //delegate void () mOptFunction ;

        //string mStrValue;
        string mStrOnText;
        string mStrOffText;

        /// <summary>
        /// Keeps the name, a helptext and a pointer to a function for a option. 
        /// </summary>
        public clsOptionsBase() { }

        /// <summary>
        /// Assigns the name for a option
        /// </summary>
        /// <param name="InOptName"></param>
        public clsOptionsBase(string InOptName) 
            : this(InOptName, "")
        {
        }

        /// <summary>
        /// Assigns the name and a help text for a option
        /// </summary>
        /// <param name="InOptName">Option name</param>
        /// <param name="InOptHelpString">Option help string</param>
        public clsOptionsBase(string InOptName, string InOptHelpString) 
            : this (InOptName, InOptHelpString, null)
        {
        }

        /// <summary>
        /// Assigns the name and a help text for an option
        /// </summary>
        /// <param name="InOptName">Option name</param>
        /// <param name="InOptHelpString">Option help string</param>
        /// <param name="InOptFunction">Assign delegate to function which may be called from external. 
        /// (Expected: DoCommands() in clsCommandLine)</param>
        public clsOptionsBase(string InOptName, string InOptHelpString, DlgOptFunction InOptFunction)
        //public clsOptionsBase(string InOptName, string InOptHelpString, Delegate InOptFunction)
        {
            Name = InOptName;
            HelpString = InOptHelpString;
            OptFunction = InOptFunction;
        }

        /// <summary>
        /// Option name
        /// </summary>
        public string Name
        {
            get { return mOptName; }
            set { mOptName = value; }
        }

        /// <summary>
        /// Help string for option
        /// </summary>
        public string HelpString
        {
            get { return mOptHelpString; }
            set { mOptHelpString = value; }
        }

        /// <summary>
        /// Reference to function which may be called from external 
        /// (Expected: DoCommands () in clsCommandLine)
        /// </summary>
        public DlgOptFunction OptFunction
        //public Delegate OptFunction
        {
            get { return mOptFunction; }
            set { mOptFunction = value; }
        }

        /// <summary>
        /// This text shall represent an true state
        /// </summary>
        public string StrOnText
        {
            get { return mStrOnText; }
            set { mStrOnText = value; }
        }

        /// <summary>
        /// This text shall represent an false state
        /// </summary>
        public string StrOffText
        {
            get { return mStrOffText; }
            set { mStrOffText = value; }
        }

        /// <summary>
        /// Compares given option value 
        /// with standard values or set 
        /// </summary>
        /// <param name="OptValue"></param>
        /// <returns></returns>
        public bool bIsOptionSet(string OptValue)
        { 
            bool bIsOptionSet = false;

            // User defined off
            if (string.Compare(OptValue, mStrOnText, true) == 0) // string found
            {
                return true;
            }

            // User defined off
            if (string.Compare(OptValue, mStrOffText, true) == 0) // string found
            {
                return false;
            }

            //----------------------------------------------------------
            // Common settings
            //----------------------------------------------------------

            if (string.Compare(OptValue.ToLower (), "true", true) == 0) // string found
            {
                bIsOptionSet = true;
            }
            if (string.Compare(OptValue.ToLower(), "false", true) == 0) // string found
            {
                bIsOptionSet = false;
            }

            if (string.Compare(OptValue.ToLower(), "on", true) == 0) // string found
            {
                bIsOptionSet = true;
            }
            if (string.Compare(OptValue.ToLower(), "off", true) == 0) // string found
            {
                bIsOptionSet = false;
            }

            if (string.Compare(OptValue.ToLower(), "set", true) == 0) // string found
            {
                bIsOptionSet = true;
            }
            if (string.Compare(OptValue.ToLower(), "clear", true) == 0) // string found
            {
                bIsOptionSet = false;
            }

            return bIsOptionSet; 
        }

        // ToDo: Assign tostring
        // ToDo: Assign test class 
    
    }
}
