using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using System.Windows.Forms;
using MainGlobal;
using ErrorCapture;

namespace CmdLine2005
{
    // ToDo: update description
    /*===============================================================================
    clsCommandLine.cls
    ---------------------------------------------------------------------------------
     * Parses a command line or file for detecting commands, options and other 
     * entries like files. These are collected in lists. The commands and 
     * options may preceed either "/" or "-" minus as supported in the token from 
     * the user of the class. Every " is taken as a start of text and the next " is 
     * searched. The text in between will be taken as command or option
     * 
     * Options: (Dictionary with or without assignment)
     *   These are normally preceeded with a slash or minus. Double arguments will cause
     *   overriding where the last one wins.
     *   All options shall be collected before every command is executet one after the other.
     *   "/Option": If the option does not contain a specifier like "=off" it is 
     *   taken as /Option=True
     * 
     * Commands: (Dictionary with or without assignment)
     *   Commands are seperated by blanks or tab. 
     *   Examples: "Create" "Write" "Load" ...
     * 
     * Command files:
     *    When a file is parsed, each seperate line is treated as a seperate 
     *    argument / command list.
     *    Therefore every read command (line) has to be reparsed before proceeding
     *    This will be done automatically if not otherwise specified at calling the
     *    function ReadFileCmdLines. 

     // ToDo: The last commands are deleted with a new line of file while 
     * the options will be collected together or overwritten with the new valus -> not solved now
     
     *    Also the function ClearCommandsAndOptions together with ParseCmdLine supports
     *    repeated command lines with empty object 
     * -------------------------------------------------------------------------------
     * The user of this class adds the expected commands and options assignments 
     * into this class. He adds the name, heldpdescription and associated function 
     * when defining the assignment
     * The commands are parsed in clsCmdLineToken into token   
     * 
     * Over the ActAssCommand and ActAssOption can the assigned program reference 
     * the data of the command or option (See example in AssignStandardCommandsOptions 
     * with "Command file name"
     *
     *
     * Reference needed:
     *    - 
     * Hint:
     *    - Read options before doing arguments
    ---------------------------------------------------------------------------------
     * Examples:
     *   Arguments
     *       /Mode=Erodieren
     *       /Backup
     *       /File=Setup.exe   Supported
     *       /Arg2=1111  /Arg2=2222  /Arg2=3333 >> leads to 3333
     * Not supported Types
     *       /File Setup.exe   Actual Not supported
     *       /F Setup.exe
     *       /Options=//YES with space//
    -------------------------------------------------------------------------------*/

    //  Open Jobs:
    //      ToDo: Capsulate the options for access of not existing options
    //      ToDo: Replace assign with enable -> enable option , command ... Dont forget Ass in names ...
    //      ToDo: Handl external acces to not known options or commands -> 
    //      ToDo: Use flat in string outputs
    //      ToDo: The arc vectors are a list of strings usually -> use it in construction and as return value of ParseCmdLineIntoTokens and ParseCmdLine (-> two routines)
    //      ToDo: When transfering commands poptions or filenames basck they should get "" around if needed
    //      ToDo: Support - and / exchangeable 
    //      ToDo: Support -- to end options and command . After this there are only files
    //      ToDo: change options into own class with assigned subroutine to call
    //      ToDo: change commands into own class with assigned subroutine to call which may be inherited ...
    //      ToDo: change options : make spezial class for bool with autoreturn of assigned variable -> delegate { CheckOpt1 = oTest.InOptions ["CheckOptUnknown"].bValue; CheckCmd = oTest.InCommands ["CheckCmdUnknown"].Value; ... -> use in bTestClassOk()  
    //      -ToDo: 
    //===============================================================================

    /// <summary>
    /// Keeps one command from commandline including a assigned value if present
    /// Example CmdFile="Commands.txt"
    /// bIsEnabledCmd is set when the found command is assigned to list of enabled commands
    /// bValue is a boolen property and set when the assigned value (Useblue="True") is true 
    /// or matches the string given by enable command
    /// </summary>
    public class InCommand : CommandFromToken
    {
        public bool bIsEnabledCommand;
        // public bool bValue;

        public InCommand() { }
        public InCommand(CommandFromToken InToken) : base(InToken) { }
     
        public override string ToString()
        {
            string OutTxt = base.ToString() + " enabled:" + bIsEnabledCommand;
            return OutTxt;
        }
    }

    /// <summary>
    /// Keeps one option from commandline including a assigned value if present
    /// Example DoUpdate="True"
    /// bIsEnabledCmd is set when the found command is assigned to list of enabled commands
    /// bValue is a boolen property and set when the assigned value (Useblue="True") is true 
    /// or matches the string given by enable command
    /// </summary>
    public class InOption : OptionFromToken
    {
        /// Keeps option assignment from commandline including a assigned value if present
        /// Example CmdFile="Commands.txt"
        public bool bIsOptionEnabled;
        public bool bValue;

        public InOption() { }
        public InOption(OptionFromToken InToken) : base(InToken) { }

        public override string ToString()
        {
            string OutTxt = base.ToString() + " enabled:" + bIsOptionEnabled;
            return OutTxt;
        } 
    }

    /// <summary>
    /// Parses a command line or file for detecting commands, options and other 
    /// entries like files. The enabled commands and option may be assigned to this class
    /// </summary>
    public partial class clsCommandLine
    {
        // User of class defines (assignes) which commands and options are valid and available
        Dictionary<string, clsCommandsBase> mAssCommands = new Dictionary<string, clsCommandsBase>();
        Dictionary<string, clsOptionsBase> mAssOptions = new Dictionary<string, clsOptionsBase>();

        Dictionary<string, InCommand> mInCommands = new Dictionary<string, InCommand>();
        Dictionary<string, InOption> mInOptions = new Dictionary<string, InOption>();

        // Keeps input data (token) from user or commandline
        clsCommandLineToken mCmdLineInToken = new clsCommandLineToken();

        // Not used commands
        private List<string> mLeftOverCmdLineTokens = new List<string>();
        public List<string> LeftOverCmdLineTokens
        {
            get { return mLeftOverCmdLineTokens; }
        }

        public List<string> FileListFromLeftOverCommands()
        {
            List<string> PathFileNamesList = new List<string>();
            try
            {
                foreach (string PathFileName in mLeftOverCmdLineTokens)
                {
                    if (File.Exists(PathFileName))
                        PathFileNamesList.Add(PathFileName);
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            return PathFileNamesList;
        }

        //// Last operated user option or command
        //List <InCommand> mActiveCommand = new List <InCommand>();
        /// <summary>
        /// Single actual used command for access of the command parameters
        /// </summary>
        InCommand mActiveCommand = null;
        
        //List <InOption> mActiveOption = new List <InOption>();
        /// <summary>
        /// Single actual used option for acces of the parameters
        /// Actual not used as aaccess is over dictionary
        /// </summary>
        //InOption> mActiveOption = null;

        // ToDo: Test how to achive or use mbShowHelpMessageOnEmptyCmdline
        bool mbShowHelpMessageOnEmptyCmdline;

        // ToDo : Return Commands and options from tokens class 
        /* 
        public clsCommandLineToken CmdLineData 
        {
            get { return CmdLineData; }
        }
        */

        //// ToDo: Remove 
        // Check if "frmCommandLine CommandLineInfo" is necessary
        //frmCommandLine mCommandLineInfo = null;
        ///// <summary>
        ///// Pointer to adjoining form where the debug messages will e written
        ///// </summary>
        //public frmCommandLine CommandLineInfo
        //{
        //    get { return mCommandLineInfo; }
        //    set { mCommandLineInfo = value; }
        //}

        /// <summary>
        /// Collection (Dictionary) of enabled commands with their data
        /// </summary>
        public Dictionary<string, clsCommandsBase> AssignedCommands
        {
            get { return mAssCommands; }
            set { mAssCommands = value; }
        }

        /// <summary>
        /// Collection (Dictionary) of enabled options with their data
        /// </summary>
        public Dictionary<string, clsOptionsBase> AssignedOptions
        {
            get { return mAssOptions; }
            set { mAssOptions = value; }
        }

        /// <summary>
        /// Parsed commands from commandline with value as bool or string
        /// </summary>
        public Dictionary<string, InCommand> InCommandItems
        {
            get { return mInCommands; }
            set { mInCommands = value; }
        }

        /// <summary>
        /// Parsed commands from commandline with value as bool or string
        ///  
        /// </summary>
        /// <remarks>
        /// Args: For compatibility with easy commandline see imagewall programm
        /// Must only be used to read the number of arguments 
        /// </remarks>
        public List<CommandFromToken> Args
        {
            get { return mCmdLineInToken.Commands; }
            // set { mInCommands = value; }
        }

        /// <summary>
        /// Returns command object with given name. If command is not set (null) a dummy option is given back
        /// </summary>
        /// <param name="CaptionName"></param>
        /// <returns></returns>
        /// <remarks>Assign result into variable as it is otherwise created for every assignment</remarks>
        public InCommand InCommand(string Name)
        {
            return InCommand(Name, "");
        }

        public InCommand InCommand(string Name, string FallbackValue)
        {
            InCommand RetCommandVal = null;

            try
            {
                if (InCommandItems.ContainsKey(Name))
                    RetCommandVal = InCommandItems[Name];

                if (RetCommandVal == null)
                {
                    RetCommandVal = new InCommand(new CommandFromToken(Name, FallbackValue));
                }
            }
            catch // (Exception Ex)
            {
                // if (Ex.Message                 
                // if (RetOptionVal == null)
                {
                    RetCommandVal = new InCommand(new CommandFromToken(Name, FallbackValue));
                }
            }

            return RetCommandVal;
        }

        /// <summary>
        /// Parsed options from commandline with value as bool or string
        /// </summary>
        public Dictionary<string, InOption> InOptionItems
        {
            get { return mInOptions; }
            set { mInOptions = value; }
        }

        /// <summary>
        /// Parsed options from commandline with value as bool or string
        /// </summary>
        /// <remarks>
        /// Opts: for compatibility with easy commandline see imagewall programm
        /// Must only be used to read the number of options 
        /// </remarks>
        public List<OptionFromToken> Opts
        {
            get { return mCmdLineInToken.Options; }
            // set { mInOptions = value; }
        }

        /// <summary>
        /// Returns object of option with given name. If option is not set (null) a dummy option is given back
        /// </summary>
        /// <param name="OptionName"></param>
        /// <returns></returns>
        /// <remarks>Assign result into variable as it is otherwise created for every assignment</remarks>
        public InOption InOption(string Name)
        {
            return InOption(Name, "");
        }

        /// <summary>
        /// Returns object of option with given name. If option is not set (null) 
        /// a dummy option is given back with the assigned fallback as value
        /// </summary>
        /// <param name="OptionName"></param>
        /// <param name="FallbackValue"></param>
        /// <returns></returns>
        /// <remarks>Assign result into variable as it is otherwise created for every assignment</remarks>
        public InOption InOption (string Name, string FallbackValue)
        {
            InOption RetOptionVal = null;
            try
            {
                if (InOptionItems.ContainsKey(Name))
                    RetOptionVal = InOptionItems[Name];
                else
                {
                    RetOptionVal = new InOption(new OptionFromToken(Name, FallbackValue));
                    RetOptionVal.bValue = RetOptionVal.bIsOptionSet(); // false;
                }
            }
            catch // (Exception Ex)
            {
                // if (Ex.Message                 
                // if (RetOptionVal == null)
                {
                    RetOptionVal = new InOption(new OptionFromToken(Name, FallbackValue));
                    RetOptionVal.bValue = false;
                }
            }
            return RetOptionVal;
        }

        /// <summary>
        /// Return single actual used command for access of the command parameters
        /// This shall be used in the delegates of command to access the assigned command line value
        /// </summary>
        public InCommand ActiveCommand
        {
            get 
            {
                return mActiveCommand;
            }
            set
            {
                mActiveCommand = value;            
            }
        }

        //public void AddActiveCommand(InCommand NewCmd)
        //{
        //    mActiveCommand.Add(NewCmd);
        //    return;
        //}

        //public void RemoveActiveCommand()
        //{
             
        //    mActiveCommand.RemoveAt (mActiveCommand.Count-1);
        //    return;
        //}



        ///// <summary>
        ///// This shall be used in the delegates of an option to access an command the assigned option line value
        ///// </summary>
        //public InOption ActiveOption
        //{
        //    get
        //    {
        //        if (mActiveOption.Count > 0)
        //        {
        //            return mActiveOption[mActiveOption.Count - 1];
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    //set { mActiveOption = value; }
        //}

        //public void AddActiveOption(InOption NewCmd)
        //{
        //    mActiveOption.Add(NewCmd);
        //    return;
        //}

        //public void RemoveActiveOption()
        //{

        //    mActiveOption.RemoveAt(mActiveOption.Count - 1);
        //    return;
        //}

        /// <summary>
        /// Assign child commands here. Example commands from files
        /// </summary>
        clsCommandLine mChildCmdObject = null;
        public clsCommandLine ChildCmdObject
        {
            get
            {
                return mChildCmdObject;
            }
            set { mChildCmdObject = value; }
        }

        /// <summary>
        /// Access to "youngest" command
        /// When a commandline object calls a file commandlineobject then 
        /// the actual file commandline is needed to be accessed instead of 
        /// the first parent one
        /// </summary>
        public clsCommandLine ActCmdObject
        {
            get
            {
                clsCommandLine RetCmdObject = this;
                while (RetCmdObject.ChildCmdObject != null)
                {
                    RetCmdObject = RetCmdObject.ChildCmdObject;
                }

                return RetCmdObject;
            }

            // set { mActCmdObject = value; }
        }

        /// <summary>
        /// Enables given command for command line
        /// </summary>
        /// <param name="NewAssCommand">Command text</param>
        public void AssignCommand(clsCommandsBase NewAssCommand)
        {
            if (NewAssCommand.Name != string.Empty)
            {
                if (mAssCommands.ContainsKey(NewAssCommand.Name))
                    mAssCommands.Remove(NewAssCommand.Name);
                mAssCommands.Add(NewAssCommand.Name, NewAssCommand);
            }
        }

        /// <summary>
        /// Activates the requirement of a helpmessage 
        /// if no option or coommand are used on the commandline
        /// </summary>
        public bool bShowHelpMessageOnEmptyCmdline
        {
            get { return mbShowHelpMessageOnEmptyCmdline; }
            set { mbShowHelpMessageOnEmptyCmdline = value; }
        }

        /*        public Dictionary<string, string> SupportedOptions
                {
                    get { return mSupportedOptions; }
                    // set { ;}
                }
        */
        /// <summary>
        /// Enable given option for command line
        /// </summary>
        /// <param name="InOptName">Option name</param>
        /// <param name="InOptHelpString">Help text to Option</param>

        public void AssignOption(string InOptName, string InOptHelpString)
        {
            AssignOption(InOptName, InOptHelpString, delegate { });
        }

        /// <summary>
        /// Enable given option for command line
        /// </summary>
        /// <param name="InOptName">Option name</param>
        /// <param name="InOptHelpString">Help text for Option</param>
        /// <param name="InOptFunction">assign a delgetae function which will be run on "DoCommands"</param>
        public void AssignOption(string InOptName, string InOptHelpString, clsOptionsBase.DlgOptFunction InOptFunction)
        {
            clsOptionsBase NewAssOption = new clsOptionsBase(InOptName, InOptHelpString, InOptFunction);
            AssignOption(NewAssOption);
        }

        /// <summary>
        /// Enable given option for command line
        /// </summary>
        /// <param name="NewAssOption"></param>
        public void AssignOption(clsOptionsBase NewAssOption)
        {
            if (NewAssOption.Name != string.Empty)
            {
                if (mAssOptions.ContainsKey(NewAssOption.Name))
                    mAssOptions.Remove(NewAssOption.Name);
                mAssOptions.Add(NewAssOption.Name, NewAssOption);
            }
        }

        /// <summary>
        /// Enable usual commands and options 
        /// </summary>
        public void AssignStandardCommandsOptions()
        {
            //--------------------------------------------
            // Define standard options
            //this.AssignOption(@"?", "Prints Help ", HelpMessage());  
            // Function has to be assigned later or be overwritten as result may go to a window
            this.AssignOption(@"?", "Prints Help ", 
                delegate {
                    CreateHelpTextAndWriteFile(ActCmdObject.InOption("OutHelpFile").Value);
                });
            //this.AssignOption(@"h", "Prints Help ", delegate {this.HelpMessage ();}); 
            // Function has to be assigned later or be overwritten as result may go to a window
            this.AssignOption(@"h", "Prints Help ", delegate {CreateHelpTextAndWriteFile(ActCmdObject.InOption("OutHelpFile").Value);});

            // Help info will be written to a text file
            this.AssignOption(@"OutHelpFile", @"=""Filename"": Defines the file for writing the Help texts. Must be defined before using /? or /h");

            // ToDo: this.AssignOption (@"CfgFile=", @"=""Filename"": Select config file");
            // ToDo: this.AssignOption (@"InOutFile", @"=""Filename"": Exchange file for reading and writing of data"); 
            this.AssignOption(@"NoAutoExit", "Commands form stays open after all commands are executed");
            this.AssignOption(@"CloseAfterCommandsDone", "Program will exit when all is done");
            this.AssignOption(@"DontShowMessageBox", "Will not show messageboxes when a error occurs. The messages will be written into the logfile", 
                delegate { 
                    Global.oDebugLog.bDontShowMessageBox = ActCmdObject.InOption("DontShowMessageBox").bValue;
                    });
            // ToDo: this.AssignOption (@"UseSingleStep", "=ON/OFF Every Command line will be waited for");

            // Help info will be written to a text file
            this.AssignOption(@"CmdPath", @"=""Path"": Defines the path for command files");

            // Define standard commands
            // Function has to be assigned later or be overwritten as result may go to a window
            //this.AssignCommand (@"DoTestClasses","Call the standard self tests of the used classes (If supported)", delegate );
            // ToDo: assign commandfile
            clsCommandsBase nextCmd = new clsCommandsBase(@"CmdFile", @"=""Filename"" Select command file to use for multiple commandlines",
				//// langManager
                //delegate 
				//{ 
				//	this.ActCmdObject.DoCommandsFromFile(this.ActCmdObject.ActiveCommand.Value, 
				//	this.ActCmdObject.InOption("CmdPath").Value); 
				//}	

                delegate 
                {
                    string FileName = ""; 
                    string CmdPath= @".\";
                    string TmpCmdPath;

                    if (this.ActCmdObject.ActiveCommand.Value != null)
                        FileName = this.ActCmdObject.ActiveCommand.Value;

                    TmpCmdPath = this.ActCmdObject.InOption("CmdPath").Value;
                    if (TmpCmdPath != null)
                        if (TmpCmdPath != "")
                            CmdPath = TmpCmdPath;
                    this.ActCmdObject.DoCommandsFromFile(FileName, CmdPath); 
                }
            );
            this.AssignCommand(nextCmd);
        }

        /// <summary>
        /// Simulate command like comming from Commandline
        /// </summary>
        /// <param name="InCmd">command name</param>
        public void AddCmdLineCommand(string InCmd)
        {
            // ToDo: AddCmdLineCommand
            if (InCmd != string.Empty)
            {
                AddCmdLineCommand(InCmd, "");
            }
        }

        /// <summary>
        /// Simulate command like comming from Commandline
        /// </summary>
        /// <param name="InCmd">Command name</param>
        /// <param name="Assignment">String: A value assigned to this command</param>
        public void AddCmdLineCommand(string InCmd, string Assignment)
        {
            if (InCmd != string.Empty)
            {
                mCmdLineInToken.AddCommand(InCmd, Assignment);
            }
        }

        /// <summary>
        /// Simulate Option like comming from Commandline
        /// </summary>
        /// <param name="InOption">Option name</param>

        public void AddCmdLineOption(string InOption)
        {
            // ToDo: AddCmdLineCommand
            AddCmdLineOption(InOption, "");
        }

        /// <summary>
        /// Simulate Option like comming from Commandline
        /// </summary>
        /// <param name="InOption">Option name</param>
        /// <param name="Assignment">A value assigned to this �ption</param>
        public void AddCmdLineOption(string InOption, string Assignment)
        {
            if (InOption != string.Empty)
            {
                mCmdLineInToken.AddOption(InOption, Assignment);
            }
        }

        /// <summary>
        /// Complete string of a commandline with out programm name
        /// </summary>
        public string CommandLine
        {
            get { return mCmdLineInToken.CommandLine; }
            set { mCmdLineInToken.CommandLine = value; }
        }

        /// <summary>
        /// Assign given commandline
        /// Collect all options values and call all option assigned functions
        /// Call all command assigned functions (May call functions a command file)
        /// </summary>
        /// <param name="CmdLine">commandline text</param>
        /// <returns></returns>
        public bool CmdLineDoCommands(string CmdLine)
        {
            this.CommandLine = CmdLine;
            return CmdLineDoCommands();
        }

        /// <summary>
        /// Collect all options values and call all option assigned functions
        /// Call all command assigned functions (May call functions in a command file)
        /// </summary>
        /// <returns></returns>
        public bool CmdLineDoCommands()
        {
            Application.DoEvents();

            // Reset old commands
            mInCommands = new Dictionary<string, InCommand>();
            // mInOptions = new Dictionary<string, InOption>();
            // Global.oDebugLog.CommandLineInfo = CommandLineInfo;
            mLeftOverCmdLineTokens = new List<string>();

            //--------------------------------------------------------------------------
            // Show Helpmessage if no arguments found in line
            //--------------------------------------------------------------------------
            if (mCmdLineInToken.Commands.Count == 0 && mCmdLineInToken.Options.Count == 0)
            {
                if (mbShowHelpMessageOnEmptyCmdline)
                {
                    //if (mAssOptions.ContainsKey("?"))
                    //{
                        clsOptionsBase oHelpCmd = mAssOptions["?"];
                        oHelpCmd.OptFunction();
                    //}
                    //else
                    //{
                    //    if (mAssOptions.ContainsKey("h"))
                    //    {
                    //        clsOptionsBase oHelpCmd = mAssOptions["h"];
                    //        oHelpCmd.OptFunction();
                    //    }
                    //}
                }
            }
            else
            {
                //--------------------------------------------------------------------------
                // First collect all options
                //--------------------------------------------------------------------------

                //For Idx = 0 To Commands.Opts.count - 1
                //If (bSingleStepActive = True) Then
                //    MsgBox "Do next Option ?", vbOKOnly, "Wait before next Option"
                //End If

                //// foreach (KeyValuePair<string, clsOptionsBase> Opt in mCmdLineData.Options)
                //foreach (OptionFromToken ActOption in mCmdLineInToken.Options)
                //{
                //    InOption LocalOptions = new InOption(ActOption);
                //    //mActiveOption.Add(LocalOptions);

                //    // ToDo: ? use lower case for Options ?
                //    if (mAssOptions.ContainsKey(ActOption.Name))
                //    {
                //        LocalOptions.bIsEnabledOption = true;
                //        // Value is true or false 
                //        LocalOptions.bValue = mAssOptions[ActOption.Name].bIsOptionSet(ActOption.Value);

                //        // Do assigned function 
                //        clsOptionsBase oDoOpt = mAssOptions[ActOption.Name];
                //        if (oDoOpt.OptFunction != null)
                //            oDoOpt.OptFunction();
                //    }
                //    else
                //    {
                //        LocalOptions.bIsEnabledOption = false;
                //        LocalOptions.bValue = false;
                //        if (string.Compare(LocalOptions.Value, "True", true) == 0) // string found
                //            LocalOptions.bValue = true;
                //    }

                //    if (mInOptions.ContainsKey(LocalOptions.Name))
                //        mInOptions.Remove(LocalOptions.Name);
                //    mInOptions.Add(LocalOptions.Name, LocalOptions);
                //}

                TransferCopyOfAllAvailableOptions(this);


                //--------------------------------------------------------------------------
                // Do all Commands
                //--------------------------------------------------------------------------

                foreach (CommandFromToken ActCommand in mCmdLineInToken.Commands)
                {
                    InCommand LocalCommand = new InCommand(ActCommand);
                    //AddActiveCommand(LocalCommand);

                    // ToDo: ? use lower case for Commands ?
                    if (mAssCommands.ContainsKey(ActCommand.Name))
                    {
                        ActiveCommand = LocalCommand;

                        LocalCommand.bIsEnabledCommand = true;
                        // Value is true or false 
                        //mActiveCommand.bValue = mAssCommands [ActCommand.Name].bIsOptionSet(ActCommand.Value);

                        // Do assigned function 
                        clsCommandsBase oDoCmd = mAssCommands[ActCommand.Name];
                        if (oDoCmd != null)
                            oDoCmd.CmdFunction();

                        ActiveCommand = null;
                    }
                    else
                    {
                        LocalCommand.bIsEnabledCommand = false;
                        // ToDo: Throw unknown command
                        // string OutTxt = string.Format("Found unknown command: '{0}' in commandline. Command was not executed", ActCommand.Name);
                        // Global.oDebugLog.MessageBox(OutTxt);
                        mLeftOverCmdLineTokens.Add(ActCommand.Name);
                    }

                    Application.DoEvents();

                    //if (mInCommands.ContainsKey(LocalCommand.Name))
                    //    mInCommands.Remove(LocalCommand.Name);
                    //mInCommands.Add(LocalCommand.Name, LocalCommand);

                    // RemoveActiveCommand();
                }
            }
            return true;
        }

        //---------------------------------------------------------------------------
        // Parse command line
        //---------------------------------------------------------------------------
        // Destinguish between options and commands
        public void ParseProgrammCmdLine()
        {
            int Idx = 0;
            List<string> Args = new List<string> ();

            foreach (string Arg in Environment.GetCommandLineArgs())
            {
                // First argument is exe itself
                if (Idx > 0)
                    Args.Add(Arg);
                else
                    Idx++;
            }

            if (Args.Count > 0)
                mCmdLineInToken.ParseTokenArray(Args.ToArray ());
        }

        public bool TransferCopyOfAllAvailableOptions(clsCommandLine DestCmdLine)
        {
            bool bIsOk = false;

            // foreach (KeyValuePair<string, clsOptionsBase> Opt in mCmdLineData.Options)
            foreach (OptionFromToken ActOption in mCmdLineInToken.Options)
            {
                InOption LocalOptions = new InOption(ActOption);
                //mActiveOption.Add(LocalOptions);

                // ToDo: ? use lower case for Options ?
                // Option is defined ?
                if (mAssOptions.ContainsKey(ActOption.Name))
                {
                    LocalOptions.bIsOptionEnabled = true;
                    // Value is true or false 
                    LocalOptions.bValue = mAssOptions[ActOption.Name].bIsOptionSet(ActOption.Value);
                }
                else
                {
                    LocalOptions.bIsOptionEnabled = false;
                    LocalOptions.bValue = false;
                    if (string.Compare(LocalOptions.Value, "True", true) == 0) // string found
                        LocalOptions.bValue = true;
                }

                if (DestCmdLine.InOptionItems.ContainsKey(LocalOptions.Name))
                    DestCmdLine.InOptionItems.Remove(LocalOptions.Name);
                DestCmdLine.InOptionItems.Add(LocalOptions.Name, LocalOptions);

                // Do assigned function (Value must be assigned before call
                if (mAssOptions.ContainsKey(ActOption.Name))
                {
                    clsOptionsBase oDoOpt = mAssOptions[ActOption.Name];
                    if (oDoOpt.OptFunction != null)
                        oDoOpt.OptFunction();
                }
            }
            
            bIsOk = true;

            return bIsOk;
        }

        /// <summary>
        /// Opens a file and interprets each line as a command line
        /// DoCommandsFromFile is called after each line sepertely
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public bool DoCommandsFromFile(string FileName, string CmdPath)
        {
            bool bIsDone = false;
            string FullPath = "";
            string OutTxt = "";

            Global.oDebugLog.WriteUserInfoTitle("- Do commands from file");

            OutTxt = "DoCommandsFromFile Path: " + CmdPath + " File:" + FileName;
            try
            {
                FullPath = Path.GetFullPath(CmdPath);
            }
            catch {
                FullPath = "Not detectable";
            }

            OutTxt = "DoCommandsFromFile Path: " + CmdPath 
                + " File:" + FileName 
                + " FullPath:" + FullPath;
            Global.oDebugLog.WriteLine(OutTxt);

            if (!Directory.Exists(CmdPath))
            {
                OutTxt = "Command directory does not exist: "
                    + CmdPath + ", Path: " + FullPath;
                Global.oDebugLog.MessageBox(OutTxt);
            }
            else
            {
                try
                {
                    string UsePathFileName = Path.Combine(CmdPath, FileName);

                    if (!File.Exists(UsePathFileName))
                    {
                        // string FullPath = Path.GetFullPath(UsePathFileName);
                        OutTxt = "Command file does not exist: " + UsePathFileName
                            + ", \r\nFullPath: " + FullPath;
                        Global.oDebugLog.MessageBox(OutTxt);
                    }
                    else
                    {
                        // clsCommandLine oSaveActCmdObject = ActCmdObject;
                        clsCommandLine oFileCommands = new clsCommandLine();
                        // Access for user of class
                        // ActCmdObject = oFileCommands;
                        ChildCmdObject = oFileCommands;

                        //FileStream CmdFile = File.OpenRead (FileName);  

                        // Use known assignments
                        oFileCommands.AssignedCommands = mAssCommands;
                        oFileCommands.AssignedOptions = mAssOptions;
                        // Keep actual option for child command file 
                        TransferCopyOfAllAvailableOptions(oFileCommands);

                        // Use every line from file seperately
                        foreach (string ActCmdLine in File.ReadAllLines(UsePathFileName, Encoding.Default))
                        {
                            ActCmdLine.Trim();
                            // Comment found ?
                            if (ActCmdLine.Length > 0)
                            {
                                if (!ActCmdLine.StartsWith("//"))
                                {
                                    oFileCommands.CommandLine = ActCmdLine;
                                    oFileCommands.CmdLineDoCommands();
                                }
                            }
                        }

                        // Transfer assigned options
                        foreach (KeyValuePair<string, InOption> ChildInOption in ChildCmdObject.InOptionItems)
                        {
                            if (InOptionItems.ContainsKey(ChildInOption.Key))
                                InOptionItems.Remove(ChildInOption.Key);
                            InOptionItems.Add(ChildInOption.Key, ChildInOption.Value);
                        }

                        // Reassign to saved object
                        // ActCmdObject = oSaveActCmdObject;
                        this.ChildCmdObject = null;

                        bIsDone = true;
                    }
                }
                catch (Exception Ex)
                {
                    clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                    ErrCapture.ShowExeption();
                }
            }
            return bIsDone;
        }

        /// <summary>
        /// Use Supported commandline from static void Main(string[] args)
        /// Unlike C and C++, the name of the program in C# is not treated as the first command line argument
        /// The commandline is already Supported as array of token
        /// </summary>
        /// <param name="NewAssCommands"></param>
        /// <param name="NewAssOptions"></param>
        /// <param name="NewCmdLine"></param>
        public clsCommandLine(Dictionary<string, clsCommandsBase> NewAssCommands,
            Dictionary<string, clsOptionsBase> NewAssOptions,
            string NewCmdLine)
        {
            mAssCommands = NewAssCommands;
            mAssOptions = NewAssOptions;

            mCmdLineInToken.CommandLine = NewCmdLine;
        }

        /// <summary>
        /// Use Supported commandline from static void Main(string[] args)
        /// Unlike C and C++, the name of the program in C# is not treated as the first command line argument
        /// The commandline is already Supported as array of token
        /// </summary>
        public clsCommandLine() 
        {
            // Assigns all possible options and commands
            defineCommands();
        }

        /// <summary>
        /// Empty actual command line data
        /// </summary>
        public void ClearCmdLineData()
        {
            //mSupportedCommands.Clear();
            //mSupportedOptions.Clear();
            CommandLine = "";
        }

        // ToDo: ClearInput ? ClearAssignments ?
        /// <summary>
        /// Empties enabled options and enabled commands
        /// </summary>
        public void ClearAssignments()
        {
            mAssCommands.Clear();
            mAssOptions.Clear();
            //mFiles.Clear();
            //mCommandFileLines.Clear();
        }

        /// <summary>
        /// Show found commands, arguments and ! additional texts (not put into commands ...) 
        /// </summary>
        /// <returns>Complete message in one string</returns>
        public override string ToString()
        {
            string strDivider = "----------------------------------------------------------\r\n";
            string OutTxt = "";
            //mCmdLineData.CommandLine
            OutTxt += strDivider + "CommandLine: '" + CommandLine + "'\r\n";
            OutTxt += strDivider + "HelpMessage:\r\n";
            OutTxt += strDivider + CreateHelpText() + "\r\n"; // CreateHelpTextAlignWord
            OutTxt += strDivider + "CmdData:\r\n";
            OutTxt += strDivider + mCmdLineInToken.ToString() + "\r\n";

            // ToDo: print act InOptions and InCommands with tostring () in their class
            // ToDo: print Chiold commands if existing 
            OutTxt += strDivider;

            return OutTxt;
        }

        public string InCommandsToString()
        {
            string OutTxt = "";
            try
            {
                foreach (KeyValuePair<string, InCommand> InCommand in InCommandItems)
                {
                    OutTxt += InCommand.Value.ToString() + "\r\n";
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            return OutTxt;
        }

        public string InOptionsToString()
        {
            string OutTxt = "";
            try
            {
                foreach (KeyValuePair<string, InOption> InOption in InOptionItems)
                {
                    OutTxt += InOption.Value.ToString() + "\r\n";
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            return OutTxt;
        }



        public string CreateHelpTextAndWriteFile(string PathFileName)
        {
            string OutTxt = CreateHelpTextAlignWord(34, 100); // CreateHelpText();
            // following does not work
            // Console.OpenStandardOutput(); 
            //Console.Write(OutTxt);
            if (PathFileName.Equals (""))
                CreateHelpMessageFile(OutTxt);
            else
                CreateHelpMessageFile(OutTxt, PathFileName);

            if (Global.oDebugLog.CommandLineInfo != null)
            {
                Global.oDebugLog.CommandLineInfo.AddInfo("Possible commands and options");
                Global.oDebugLog.CommandLineInfo.AddInfo(OutTxt);
                Application.DoEvents();
            }
            return OutTxt;
        }

        /// <summary>
        /// Shows all enabled options and commands with adjourning help texts in a table 
        /// </summary>
        /// <returns>Complete message in one string</returns>
        public string CreateHelpText()
        {
            string OutTxt = "";
            string OptTxt = "";
            Int32 MaxLenCmds = 0;
            Int32 MaxLenOpts = 0;
            Int32 ActLen;
            string Empty;

            // Align help : second row starts will same character. go through all commands 
            // and options find biggest length, do multiple of 3/4 charcters
            foreach (KeyValuePair<string, clsCommandsBase> Cmd in mAssCommands)
            {
                ActLen = Cmd.Key.Length;
                if (MaxLenCmds < ActLen)
                    MaxLenCmds = ActLen;
            }

            foreach (KeyValuePair<string, clsOptionsBase> Cmd in mAssOptions)
            {
                ActLen = Cmd.Key.Length;
                if (MaxLenOpts < ActLen)
                    MaxLenOpts = ActLen;
            }

            // New start of help texts
            // Keep at least 1 space. Therefore is needed one more for multiplication
            MaxLenCmds = ((MaxLenCmds + 1 + 4) / 4) * 4;
            MaxLenOpts = ((MaxLenOpts + 1 + 4) / 4) * 4;

            foreach (KeyValuePair<string, clsCommandsBase> Cmd in mAssCommands)
            {
                if (OutTxt != string.Empty)
                { OutTxt += "\r\n"; }

                clsCommandsBase oCmdBase = Cmd.Value;
                Empty = new string(' ', MaxLenCmds - Cmd.Key.Length);
                OutTxt += "   - " + Cmd.Key + Empty + oCmdBase.HelpString;
            }

            OutTxt = "Possible Commands \r\n" + OutTxt;

            foreach (KeyValuePair<string, clsOptionsBase> Opt in mAssOptions)
            {
                if (OptTxt != string.Empty)
                    OptTxt = OptTxt + "\r\n";

                clsOptionsBase oOptBase = Opt.Value;
                Empty = new string(' ', MaxLenOpts - Opt.Key.Length);
                OptTxt = OptTxt + "   - " + Opt.Key + Empty + oOptBase.HelpString;
            }

            OutTxt = "Possible arguments \r\n" + OptTxt + "\r\n" + OutTxt;

            return OutTxt;
        }

        /// <summary>
        /// Shows all enabled options and commands with adjourning help texts in a table 
        /// </summary>
        /// <returns>Complete message in one string</returns>
        public string CreateHelpTextAlignWord(int LimitLenCmdOpts, int Limit2Border)        
        {
            string OutTxt = "";
            string OptTxt = "";
            Int32 MaxLenTokenCmds = 0;
            Int32 MaxLenTokenOpts = 0;
            Int32 ActLen;
            string EmptyPart;
            string Token;

            try
            {
                if (LimitLenCmdOpts > 20)
                    LimitLenCmdOpts -= 3; // 3 Spaces

                // Align help : second row starts will same character. go through all commands 
                // and options find biggest length, do multiple of 3/4 charcters
                foreach (KeyValuePair<string, clsCommandsBase> Cmd in mAssCommands)
                {
                    ActLen = Cmd.Key.Length;
                    if (MaxLenTokenCmds < ActLen)
                    {
                        if (LimitLenCmdOpts == 0) // No limits
                            MaxLenTokenCmds = ActLen;
                        else 
                            if (ActLen < LimitLenCmdOpts)
                                MaxLenTokenCmds = ActLen;
                            else
                                MaxLenTokenCmds = LimitLenCmdOpts;
                    }
                }

                if (LimitLenCmdOpts > 20)
                    LimitLenCmdOpts -= 1; // 3 Spaces and a slash 

                foreach (KeyValuePair<string, clsOptionsBase> Opt in mAssOptions)
                {
                    ActLen = Opt.Key.Length;
                    if (MaxLenTokenOpts < ActLen)
                    {
                        if (LimitLenCmdOpts == 0) // No limits
                            MaxLenTokenOpts = ActLen;
                        else
                            if (ActLen < LimitLenCmdOpts)
                                MaxLenTokenOpts = ActLen;
                            else
                                MaxLenTokenOpts = LimitLenCmdOpts;
                    }
                }

                // New start of help texts
                // Keep at least 1 space. Therefore is needed one more for multiplication
                MaxLenTokenCmds = ((MaxLenTokenCmds + 1 + 4) / 4) * 4;
                MaxLenTokenOpts = ((MaxLenTokenOpts + 1 + 4) / 4) * 4;

                foreach (KeyValuePair<string, clsCommandsBase> Cmd in mAssCommands)
                {
                    if (OutTxt != string.Empty) // Next Line found
                    { OutTxt += "\r\n"; }

                    clsCommandsBase oCmdBase = Cmd.Value;
                    Token = "   " + Cmd.Key;
                    if (MaxLenTokenCmds > Token.Length)
                    {
                        if (MaxLenTokenCmds - Token.Length > 0)
                        {
                            EmptyPart = new string(' ', MaxLenTokenCmds - Token.Length);
                            Token += EmptyPart;
                        }
                    }

                    OutTxt += Token + ":";
                    if (Token.Length + 1 + oCmdBase.HelpString.Length < Limit2Border)
                        OutTxt += oCmdBase.HelpString;
                    else
                        OutTxt += FormatHelpTextComment(oCmdBase.HelpString, Limit2Border, Token.Length + 1, MaxLenTokenCmds);// -1 : Ident
                }

                OutTxt = "Possible Commands \r\n" + OutTxt;

                foreach (KeyValuePair<string, clsOptionsBase> Opt in mAssOptions)
                {
                    if (OptTxt != string.Empty) // Next Line
                        OptTxt = OptTxt + "\r\n";

                    clsOptionsBase oOptBase = Opt.Value;
                    Token = "   /" + Opt.Key;
                    if (MaxLenTokenOpts > Token.Length)
                    {
                        if (MaxLenTokenOpts - Token.Length > 0)
                        {
                            EmptyPart = new string(' ', MaxLenTokenOpts - Token.Length);
                            Token += EmptyPart;
                        }
                    }

                    OptTxt = OptTxt + Token + ":";
                    if (Token.Length + 1 + oOptBase.HelpString.Length < Limit2Border)
                        OptTxt = OptTxt + oOptBase.HelpString;
                    else
                        OptTxt = OptTxt + FormatHelpTextComment(oOptBase.HelpString, Limit2Border, Token.Length + 1, MaxLenTokenOpts); // -1 : Ident
                }

                OutTxt = "Possible arguments \r\n" + OptTxt + "\r\n" + OutTxt + "\r\n";

            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            return OutTxt;
        }

        private string FormatHelpTextComment(string HelpString, int Limit2Border, int AlreadyUsedInFirstLine,  int EmptyTokenNbr)
        {
            string OutTxt = "";
            string MaxPart ;
            int LastSpaceIdx;
            int StartIdx;

            try
            {
                //-- First Line -----------------------------------
                MaxPart = HelpString.Substring(0, Limit2Border - AlreadyUsedInFirstLine);
                LastSpaceIdx = MaxPart.LastIndexOf(' ');
                if (LastSpaceIdx > -1)
                {
                    OutTxt += HelpString.Substring(0, LastSpaceIdx);
                    StartIdx = LastSpaceIdx + 1;
                }
                else
                {
                    LastSpaceIdx = HelpString.IndexOf(' ', Limit2Border - AlreadyUsedInFirstLine); ;
                    if (LastSpaceIdx > -1)
                    {
                        OutTxt += HelpString.Substring(0, LastSpaceIdx);
                        StartIdx = LastSpaceIdx + 1;
                    }
                    else
                    {
                        OutTxt += HelpString;
                        StartIdx = HelpString.Length;
                    }
                }

                //--- All Other Lines -------------------------------------
                
                while (StartIdx < HelpString.Length)
                {
                    string Empty = new string(' ', EmptyTokenNbr + 1); // +1: Ident one character
                    OutTxt += "\r\n" + Empty;
                    int TransferNumber = Limit2Border - EmptyTokenNbr;
                    if (HelpString.Length < (TransferNumber + StartIdx))
                    {
                        TransferNumber = HelpString.Length - StartIdx;
                        OutTxt += HelpString.Substring(StartIdx, TransferNumber);
                        StartIdx = HelpString.Length;
                    }
                    else
                    {
                        MaxPart = HelpString.Substring(StartIdx, TransferNumber); 
                        LastSpaceIdx = MaxPart.LastIndexOf(' ');
                        if (LastSpaceIdx > -1)
                        {
                            OutTxt += MaxPart.Substring(0, LastSpaceIdx);
                            StartIdx = StartIdx + LastSpaceIdx + 1;
                        }
                        else
                        {
                            LastSpaceIdx = HelpString.IndexOf(' ', StartIdx + TransferNumber);
                            if (LastSpaceIdx > -1)
                            {
                                OutTxt += HelpString.Substring(0, LastSpaceIdx);
                                StartIdx = StartIdx + LastSpaceIdx + 1;
                            }
                            else
                            {
                                OutTxt += HelpString.Substring(StartIdx);
                                StartIdx = HelpString.Length;
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            return OutTxt;
        }


        /// <summary>
        /// Write HelpMessage into file CommandsHelp.txt
        /// </summary>
        /// <param name="OutTxt">If given the given text will be written into the file. 
        /// Otherwise standard helpmessage will be created and used</param>
        /// <returns>Used Text for writing into file</returns>
        public string CreateHelpMessageFile(string OutTxt)
        {
            return CreateHelpMessageFile(OutTxt, @".\" + Application.ProductName + "CommandsHelp.txt");
        }

        /// <summary>
        /// Write HelpMessage into file CommandsHelp.txt
        /// </summary>
        /// <param name="OutTxt">If given the given text will be written into the file. 
        /// Otherwise standard helpmessage will be created and used</param>
        /// <returns>Used Text for writing into file</returns>
        public string CreateHelpMessageFile(string OutTxt, string PathFileName)
        {
            // Create an instance of StreamWriter to write text to a file.
            // The using statement also closes the StreamWriter.
            using (StreamWriter sw = new StreamWriter(PathFileName))
            {
                // OutTxt normally given but ...
                if (OutTxt.Equals(""))
                    OutTxt = CreateHelpText();

                // Add some text to the file.
                sw.Write(OutTxt);
                //sw.WriteLine("header for the file.");
                //sw.WriteLine("-------------------");
                //// Arbitrary objects can also be written to the file.
                //sw.Write("The date is: ");
                sw.WriteLine(DateTime.Now);
            }

            return OutTxt;
        }

        /// <summary>
        /// Write HelpMessage into file CommandsHelp.txt
        /// </summary>
        /// <param name="OutTxt">If given the given text will be written into the file. 
        /// Otherwise standard helpmessage will be created and used</param>
        /// <returns>Used Text for writing into file</returns>
        public string PrintHelpMessageFile(string OutTxt)
        {
            // Create an instance of StreamWriter to write text to a file.
            // The using statement also closes the StreamWriter.
            using (StreamWriter sw = new StreamWriter(@".\" + Application.ProductName + ".CommandsHelp.txt"))
            {
                // OutTxt normally given but ...
                if (OutTxt.Equals(""))
                    OutTxt = CreateHelpText();

                // Add some text to the file.
                sw.Write(OutTxt);
                //sw.WriteLine("header for the file.");
                //sw.WriteLine("-------------------");
                //// Arbitrary objects can also be written to the file.
                //sw.Write("The date is: ");
                sw.WriteLine(DateTime.Now);
            }

            return OutTxt;
        }
        /*
               [DllImport("kernel32.dll")]
                public static extern Boolean AllocConsole();
                [DllImport("kernel32.dll")]
                public static extern Boolean FreeConsole();
                [DllImport("kernel32.dll", SetLastError = true)]
                static extern bool AttachConsole(uint dwProcessId);
                
         
                public Form1()
                {
                    AllocConsole();
                    InitializeComponent();
                }

                Console.Write ();

                private void Form1_FormClosing(object sender, FormClosingEventArgs e)
                {
                    FreeConsole();
                }
        */

        //Public Function Text(Optional StartTxt As String = "", Optional TabTxt As String = vbTab)
        public string DebText()
        {
            return DebText("");
        }

        public string DebText(string StartTxt)
        {
            return DebText("", false);
        }

        public string DebText(string StartTxt, bool bFlat)
        {
            // int Idx;
            string OutTxt = "";

            OutTxt += " " + mCmdLineInToken.ToString();

            return OutTxt;
        }

        /// <summary>
        /// Tests (most?) functions of this class
        /// </summary>
        /// <returns>true if all testes were sucessfull</returns>
        public bool bTestClassOk()
        {
            bool bTestClassOk;

            bTestClassOk = true;

            try
            {
                //--- DetermineMachineType ---------------------------
                // Try special values

                clsCommandLine oTest = new clsCommandLine();

                bTestClassOk = mCmdLineInToken.bTestClassOk();

                // oTest.CommandLine = "Cmd1 /Opt1 -Opt2 cmd2=Value2 cmd3=\"Value3\" cmd4='Value4' /Opt3=On /Opt4=off /Opt5=\"off\" /Opt6='off' /Opt7=Otherwise";




                // Define standard options
                oTest.AssignStandardCommandsOptions();

                //                bool CheckOpt1 = false;
                oTest.AssignOption(@"CheckOpt1", "Test CheckOpt1");
                oTest.AssignOption(@"CheckOpt2", "Test CheckOpt2");
                oTest.AssignOption(@"CheckOpt3", "Test CheckOpt3");
                oTest.AssignOption(@"CheckOpt4", "Test CheckOpt4");
                oTest.AssignOption(@"CheckOpt5", "Test CheckOpt5");
                oTest.AssignOption(@"CheckOpt6", "Test CheckOpt6");

                if (!oTest.AssignedOptions.ContainsKey(@"CheckOpt1"))
                {
                    bTestClassOk = false;
                }

                oTest.CommandLine = "/CheckOpt1 /CheckOpt2=True /CheckOpt3=\"Set\" /CheckOpt4=On  /CheckOpt5=Off /NoOpt";
                oTest.CmdLineDoCommands();

                //---------------------------------------------------------
                // Options
                //----------------------------------------------------------

                if (!oTest.InOptionItems.ContainsKey(@"CheckOpt1"))
                {
                    bTestClassOk = false;
                }

                if (!oTest.InOptionItems["CheckOpt1"].bIsOptionEnabled)
                {
                    bTestClassOk = false;
                }

                if (!oTest.InOptionItems["CheckOpt1"].bValue)
                {
                    bTestClassOk = false;
                }

                if (!oTest.InOptionItems["CheckOpt2"].bValue)
                {
                    bTestClassOk = false;
                }

                if (!oTest.InOptionItems["CheckOpt3"].bValue)
                {
                    bTestClassOk = false;
                }

                if (!oTest.InOptionItems["CheckOpt4"].bValue)
                {
                    bTestClassOk = false;
                }

                if (oTest.InOptionItems["CheckOpt5"].bValue)
                {
                    bTestClassOk = false;
                }

                if (!oTest.InOptionItems["CheckOpt5"].bIsOptionEnabled)
                {
                    bTestClassOk = false;
                }

                if (oTest.InOptionItems["NoOpt"].bIsOptionEnabled)
                {
                    bTestClassOk = false;
                }

                bool CheckOpt1 = false;

                oTest.AssignOption(@"CheckOpt1", "Test CheckOpt1", delegate { CheckOpt1 = oTest.ActCmdObject.InOptionItems["CheckOpt1"].bValue; });
                oTest.CmdLineDoCommands();
                if (!CheckOpt1)
                {
                    bTestClassOk = false;
                }

                oTest.AssignOption(@"CheckOpt1", "Test CheckOpt1", delegate { CheckOpt1 = oTest.ActCmdObject.InOptionItems["CheckOpt1"].bValue; });
                oTest.CmdLineDoCommands();
                if (!CheckOpt1)
                {
                    bTestClassOk = false;
                }


                //----------------------------------------------------------
                // Commands
                //----------------------------------------------------------
                bool CheckCmd1 = false;

                //oTest.AssignCommand(@"CheckCmd1", "Test Command 01",
                //    delegate { CheckCmd1 = oTest.InOptions ["CheckCmd1"].bValue; });
                clsCommandsBase nextCmd = new clsCommandsBase(@"CheckCmd1", "Test Command 01",
                    delegate { CheckCmd1 = oTest.InOptionItems["CheckOpt1"].bValue; });
                oTest.AssignCommand(nextCmd);

                oTest.CommandLine = "CheckCmd1 /Opt1 NoKnownCommand";
                oTest.CmdLineDoCommands();
                if (!CheckCmd1)
                {
                    bTestClassOk = false;
                }


                /*
                // bool CheckOpt1;
                CheckOpt1 = oTest.AssignedOptions ["CheckOpt1"].OptionIsSet;
                if (!CheckOpt1)
                {
                    bTestClassOk = false;
                }

                /*
                // Define standard commands
                oTest.AssignCommand(@"/AddedTwice", "Call 1");
                oTest.AssignCommand(@"/AddedTwice", "Call 2");

                oTest.AssignCommand(@"/TestCommand", "TestCommand");
                if (! oTest.SupportedCommands.ContainsKey(@"/TestCommand"))
                {
                    bTestClassOk = false;
                }

                oTest.AssignOption(@"/TestOptions", "TestOptions");
                if (! oTest.SupportedOptions.ContainsKey(@"/TestOptions"))
                {
                    bTestClassOk = false;
                }

                oTest.CommandLine = @"/CmdFile=""TestCommands.cmd"" /h /NoAutoExit xxxFile.txt";

                if (oTest.Commands.Count != 1)
                {
                    bTestClassOk = false;
                }

                if (oTest.Options.Count != 2)
                {
                    bTestClassOk = false;
                }

                if (oTest.Files.Count != 1)
                {
                    bTestClassOk = false;
                }

                */

                //If (MachineType != "PowerDiamond") 
                //    bTestClassOk = False;
                //End If
            }
            catch (Exception ex)
            {
                string OutTxt = "Error while testing class clsCommandLine: " + ex.Message;
                Global.oDebugLog.MessageBox(OutTxt);
                        
                bTestClassOk = false;
            }

            return bTestClassOk;
        }
    }
}
