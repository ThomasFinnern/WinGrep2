using System;
using System.Collections.Generic;
using System.Text;

namespace CmdLine2005
{
    /*===============================================================================
    CommandsBase.cls
    ---------------------------------------------------------------------------------
    
     * Base of a model of an enabled command
     * Keeps Name, Helptext and pointer to a command function 
     * Basis for inheritance

    -------------------------------------------------------------------------------*/
    //  Open Jobs:
    //      -ToDo: 
    //      -ToDo: 
    //===============================================================================

    /// <summary>
    /// Base of a model of an enabled command. This class does not contain data 
    /// from commandline
    /// Keeps the name, a help text and a pointer to a function for a command. 
    /// This is a base for inheritance
    /// </summary>
    public class clsCommandsBase 
    {
        /// <summary>
        /// Type definition : Reference to function which may be called from external 
        /// (Example: In DoCommadns in clsCommandLine)
        /// </summary>
        public delegate void DlgCmdFunction (); 

        string mCmdName;
        string mCmdHelpString;
        DlgCmdFunction mCmdFunction;

        /// <summary>
        /// Keeps the name, a helptext and a pointer to a function for a command. 
        /// </summary>
        public clsCommandsBase() { }

        /// <summary>
        /// Assigns the name for a command 
        /// </summary>
        /// <param name="InCmdName"></param>
        public clsCommandsBase(string InCmdName) 
            : this(InCmdName, "")
        {
        }

        /// <summary>
        /// Assigns the name and a help text for a command. 
        /// </summary>
        /// <param name="InCmdName">Command name</param>
        /// <param name="InCmdHelpString">Command help string</param>
        public clsCommandsBase(string InCmdName, string InCmdHelpString)
            : this(InCmdName, InCmdHelpString, null)
        {
        }

        /// <summary>
        /// Assigns the name, a help text and a pointer to a function for a command. 
        /// </summary>
        /// <param name="InCmdName">Command name</param>
        /// <param name="InCmdHelpString">Command help string</param>
        /// <param name="InCmdFunction">Assign delegate to function which may be called from external. 
        /// (Expected: DoCommands() in clsCommandLine)</param>
        public clsCommandsBase(string InCmdName, string InCmdHelpString, DlgCmdFunction InCmdFunction)
        {
            Name = InCmdName;
            HelpString = InCmdHelpString;
            CmdFunction = InCmdFunction;
        }

        /// <summary>
        /// Command name
        /// </summary>
        public string Name
        {
            get { return mCmdName; }
            set { mCmdName = value; }
        }

        /// <summary>
        /// Help string for command
        /// </summary>
        public string HelpString
        {
            get { return mCmdHelpString; }
            set { mCmdHelpString = value; }
        }

        /// <summary>
        /// Reference to function which may be called from external 
        /// (Expected: DoCommands () in clsCommandLine)
        /// </summary>
        public DlgCmdFunction CmdFunction
        {
            get { return mCmdFunction; }
            set { mCmdFunction = value; }
        }

        // ToDo: Assign tostring
        // ToDo: Assign test class 
    
    }
}
