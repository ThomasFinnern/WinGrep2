using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using MainGlobal;

namespace CmdLine2005
{
    /*===============================================================================
    clsCommandLineToken.cls
    -------------------------------------------------------------------------------
         Parses a command line or file for detecting commands and options. These are 
         collected in lists.  The options may be preceeded by either 
         "/" or "-" minus
          Every " is taken as a start sign and the next " is searched. The text in
         between will be taken as part of a command or option 
      Options: (Dictionary with or without assignment)
         These are normally preceeded with a slash or minus. Double arguments will cause
         overriding where the last one wins.
         All options shall be collected before every command is executet one after the other.
      Commands: (Dictionary with or without assignment)
         Commands are seperated by blanks or tab. 
       Command files:
         When a file is parsed, each seperate line is treated as a seperate command.
         Therefore every read command (line) has to be reparsed before proceeding
         This will done automatically if not otherwise specified at calling the
         function ReadFileCmdLines
         Also the function ClearCommandsAndOptions together with ParseCmdLine supports
         repeated command lines with empty object before
      
     -------------------------------------------------------------------------------
     User of class defines which commands and options are valid and available
        

         
     
      Reference needed:
         - 
      Hint:
         - Read options before doing arguments
    -------------------------------------------------------------------------------
     Examples:
        Arguments
            /Mode=Erodieren
            /Backup
            /File=Setup.exe   Supported
            /Arg2=1111  /Arg2=2222  /Arg2=3333 >> leads to 3333
     Not supported Types
            /File Setup.exe   Actual Not supported
            /F Setup.exe
            /Options=//YES with space//

    -------------------------------------------------------------------------------*/

    //  Open Jobs:
    //      ToDo: Handling of files how to ?
    //      -ToDo: 
    //      -ToDo: 
    //      -ToDo: 
    //===============================================================================

    /// <summary>
    /// Keeps one command from commandline including a assigned value if present
    /// Example CmdFile="Commands.txt"
    /// </summary>
    public class CommandFromToken
    {
        public string Name;
        public string Value;

        public CommandFromToken() { }
        public CommandFromToken(string InName, string InValue) 
        {
            Name = InName;
            Value = InValue;
        }
        public CommandFromToken(CommandFromToken InToken)
        {
            Name = InToken.Name;
            Value = InToken.Value;
        }

        public override string ToString()
        {
            string OutTxt = "Name:" + Name + " Value: " + Value;
            return OutTxt;
        }
    }

    /// <summary>
    /// Keeps one option from commandline including a assigned value if present
    /// Example DoUpdate="True"
    /// </summary>
    public class OptionFromToken
    {
        // ToDo: Return value as object 
        /// Keeps option assignment from commandline including a assigned value if present
        /// Example CmdFile="Commands.txt"
        public string Name;
        public string Value;

        public OptionFromToken() { }
        public OptionFromToken(string InName, string InValue) 
        {
            Name = InName;
            Value = InValue;
        }
        public OptionFromToken(OptionFromToken InToken)
        {
            Name = InToken.Name;
            Value = InToken.Value;
        }
        public bool bIsOptionSet()
        {
            return bIsOptionSet(Value);
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

            //----------------------------------------------------------
            // Common settings
            //----------------------------------------------------------

            if (string.Compare(OptValue.ToLower(), "true", true) == 0) // string found
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

        public override string ToString()
        {
            string OutTxt = "Name:" + Name + " Value: " + Value;
            return OutTxt;
        }
    }

    /// <summary>
    /// Extracts/parses form given commandline options and command with given values
    /// Keeps a list of all commands and option with their values.
    /// </summary>
    public class clsCommandLineToken
    {

        // ToDo: List of dicts (Commands, Options) for sorting in input order
        // Dictionary<string, string> mCommands = new Dictionary<string, string>();
        List<CommandFromToken> mCommands = new List<CommandFromToken>(); // other data
        //Dictionary<string, string> mOptions = new Dictionary<string, string>();
        List<OptionFromToken> mOptions = new List<OptionFromToken>(); // other data

        List<string> mFiles = new List<string>(); // other data

        /// <summary>
        /// List of found commands
        /// </summary>
        public List<CommandFromToken> Commands
        {
            get {return mCommands;}
            // set ....
        }
        /// <summary>
        /// Simulate a command (without value assignment) from command line 
        /// </summary>
        /// <param name="InCmd">Command name</param>
        public void AddCommand(string InCmd)
        {
            AddCommand(InCmd, "");
        }
        
        /// <summary>
        /// Simulate a command with value assignment from command line 
        /// </summary>
        /// <param name="InCmd">Command name</param>
        /// <param name="Assignment">Command value</param>
        public void AddCommand(string InCmd, string Assignment)
        {
            if (InCmd != string.Empty)
            {
                InCommand NewInCmd = new InCommand();
                NewInCmd.Name = InCmd;
                NewInCmd.Value = Assignment;

                mCommands.Add(NewInCmd);
            }
        }

        /// <summary>
        /// List of found Options 
        /// </summary>
        public List<OptionFromToken> Options
        {
            get {return mOptions;}
            // set ....
        }

        /// <summary>
        /// Simulate a option (without value assignment) from command line 
        /// </summary>
        /// <param name="InOpt"></param>
        public void AddOption(string InOpt)
        {
            AddOption(InOpt, "");
        }

        /// <summary>
        /// Simulate a option with value assignment from command line
        /// </summary>
        /// <param name="InOpt">Option name</param>
        /// <param name="Assignment">Option value</param>
        public void AddOption(string InOpt, string Assignment)
        {
            if (InOpt != string.Empty)
            {
                InOption NewInOpt = new InOption();
                NewInOpt.Name = InOpt;
                NewInOpt.Value = Assignment;

                mOptions.Add(NewInOpt);
            }
        }
        
        /// <summary>
        /// Takes complete commandline and parses its tokens.
        /// On reading it assembles the kept token back to a similar token
        /// </summary>
        public string CommandLine 
        {
            /// Collect all token into one command string
            get 
            { 
                string OutTxt = "";
                
                // 
                foreach (InOption ActOption in mOptions)
                {
                    if (ActOption.Value != string.Empty)
                        OutTxt += "/" + ActOption.Name + "=" + ActOption.Value + " ";
                    else
                        OutTxt += "/" + ActOption.Name + " ";
                }

                foreach (InCommand ActCommand in mCommands)
                {
                    if (ActCommand.Value != string.Empty)
                        OutTxt += "/" + ActCommand.Name + "=" + ActCommand.Value + " ";
                    else
                        OutTxt += "/" + ActCommand.Name + " ";
                }


//                foreach (string Token in mFiles)
//                    OutTxt += Token + " ";
                
                return OutTxt; 
            }

            // Take complete command line string and make tokens out of it
            // Then sort the token into options and commands
            set 
            { 
                ParseTokenArray(ParseCmdLine(value)); 
            }
        }
        
        
/*
        List<string> Files
        {
            get {return mFiles;}    
            // set ....
        }
*/

  /*      public void AddFiles(string InCmd, string InHelp)
        {
            if (InCmd != string.Empty)
            {
                mOptions.Add(InCmd, InHelp);
            }
        } */
        
        /// <summary>
        /// Use if the commandline is already supported as array of token 
        /// All options and commands shall e given as separate strings in a string array 
        /// Unlike C and C++, the name of the program in C# is not treated as the first command line argument
        /// </summary>
        /// <param name="CompleteArgs"></param>
        public clsCommandLineToken(string[] CompleteArgs)
        {
            ParseTokenArray(CompleteArgs);
        }

        /// <summary>
        /// Parses a command line or file for detecting commands and options. These are collected in lists. 
        /// The options may be preceeded by either "/" or "-" minus. 
        /// Every " is taken as a start sign and the next " is searched. 
        /// The text in between will be taken as part of a command or option 
        /// </summary>
        public clsCommandLineToken() { }

        /// <summary>
        /// Parses for valid tokens and adds it to 
        /// It may be necesary to empty the resulting commandline before
        /// </summary>
        /// <param name="CmdLineToken"></param>
        public void ParseTokenArray(string[] CmdLineToken)
        {
            string[] TokenElements;

            foreach (string ActToken in CmdLineToken)
            {
                try
                {
                    // Is it an option ? 
                    if (ActToken.Substring(0) [0] == '-' || ActToken.Substring(0) [0] == '/')
                    {
                        // Assignment found ?
                        if (ActToken.IndexOf("=") >= 0)
                        {
                            TokenElements = ActToken.Split('='); // key=value
                            // Remove surrounding ""
                            if (TokenElements[1].StartsWith ("\"") && TokenElements[1].EndsWith ("\""))
                                TokenElements[1] = TokenElements[1].Substring (1,TokenElements[1].Length -2);

                            AddOption(TokenElements [0].Substring(1), TokenElements [1]);
                        }
                        else
                        {
                            // AddOption(ActToken.Substring(1), "");
                            AddOption(ActToken.Substring(1), "True");
                        }
                    }
                    else
                    {   // It is a command

                        // Assignment found ?
                        if (ActToken.IndexOf("=") >= 0)
                        {
                            TokenElements = ActToken.Split('='); // key=value
                            // Remove surrounding ""
                            if (TokenElements[1].StartsWith("\"") && TokenElements[1].EndsWith("\""))
                                TokenElements[1] = TokenElements[1].Substring(1, TokenElements[1].Length - 2);

                            AddCommand(TokenElements [0], TokenElements [1]);
                        }
                        else
                        {
                            AddCommand(ActToken, "");
                        }
                    }
                }
                catch (Exception ex)
                {
                    string OutTxt = ex.Message;
                    // MessageBox.Show(OutTxt);
                    Global.oDebugLog.MessageBox(OutTxt);
                }
            }
        }

        /// <summary>
        /// Deletes all assigned command and options token
        /// </summary>
        public void Clear()
        {
            mCommands.Clear();
            mOptions.Clear(); 
            
            //mCommandFileLines.Clear();
        }

        /// <summary>
        /// Parses a command line for token of arguments and options. 
        /// Every " is taken as a start sign and the next " is searched. 
        /// The text in between will be taken as an option or command part 
        /// </summary>
        /// <param name="InCommandLine"></param>
        /// <returns>Commands and option as seperate tokens</returns>
        public string[] ParseCmdLine(string InCommandLine)
        {
            string [] Tokens;
            mCommands = new List<CommandFromToken>();
            Tokens = ParseCmdLineIntoTokens(InCommandLine);
            return Tokens;
        }

        /// <summary>
        /// Parses a command line for token of arguments and options. 
        /// Every " is taken as a start sign and the next " is searched. 
        /// The text in between will be taken as an option or command part 
        /// </summary>
        /// <param name="strLine"></param>
        /// <returns>Commands and option as seperate tokens</returns>
        public string [] ParseCmdLineIntoTokens(string strLine)
        {
            List<string> OutList = new List<string>();
            string ActToken = "";
            bool bArgHasStarted = false;
            bool bInQuote = false;

            foreach (char ActChar in strLine)
            {
                // Test for space or tab.
                if (ActChar != ' ' && ActChar != '\r' && ActChar != '\n')
                {
                    // -> Neither space nor tab.

                    // Test if already in argument.
                    if (!bArgHasStarted)
                    {
                        bArgHasStarted = true;
                        bInQuote = false;

                        //New argument begins.
                        if (ActToken != string.Empty)
                            OutList.Add(ActToken);

                        ActToken = "";
                    }
                    
                    // Test for quotation ""
                    //if (ActChar == @"""") 
                    if (ActChar == '"')
                        // if (ActChar == "\"")    
                        bInQuote = !bInQuote; //toggle quote, do not add to argument
                    else
                        // Concatenate character to current argument.
                        ActToken = ActToken + ActChar;
                }            
                else
                {
                    //Found a space or tab.
                    if (bInQuote)  //add to argument
                        ActToken = ActToken + ActChar;
                    else
                    {
                        //Set bInQuote flag to False.
                        bArgHasStarted = false;
                        if (ActToken != string.Empty)
                            OutList.Add (ActToken);

                        ActToken = "";                    
                    }
                }
            } // for each
            
            if (ActToken != string.Empty)
                OutList.Add (ActToken);

            // string [OutList.Count] OutStrings; 
            // string OutStrings []; 
            // string OutStrings [OutList.Count]; 
            // OK
            string[] OutStrings = new string[OutList.Count];
            OutList.CopyTo (OutStrings);
            return OutStrings; 
        }
        
        
        // Show found commands, arguments and ! additional texts (not put into commands ...)
        /// <summary>
        /// Showcontaining commands and options
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string OutTxt = "";
            string OptTxt = "";
            string CmdTxt = "";
            //string FilesTxt = "";

            OptTxt = "";
            foreach (InOption ActOption in mOptions)
            {
                if (OptTxt != string.Empty) 
                    { OptTxt += "\r\n"; }
                OptTxt = OptTxt + "   - " + ActOption.Name + "\t\t" + ActOption.Value;
            }

            OutTxt += "Arguments:\r\n" + OptTxt + "\r\n";

            CmdTxt = "";
            foreach (InCommand ActCommand in mCommands)
            {
                if (CmdTxt != string.Empty) 
                    { CmdTxt += "\r\n"; }

                CmdTxt = CmdTxt + "   - " + ActCommand.Name + "\t\t" + ActCommand.Value;
            }

            OutTxt += "Commands:\r\n" + CmdTxt;


            //foreach (string Cmd in mFiles)
            //{
            //    if (FilesTxt != string.Empty)
            //        FilesTxt = FilesTxt + "\r\n";
            //    FilesTxt = FilesTxt + "   - " + Cmd;
            //}

            // OutTxt += "\r\n\r\nFiles\r\n" + FilesTxt + "\r\n" + OutTxt;

            return OutTxt;
        }

        // ToDo: -> Fillout bTestClassOk
        /// <summary>
        /// Tests this class with parsing functions of a commandline 
        /// </summary>
        /// <returns>True if all tests were successfull</returns>
        public bool bTestClassOk() 
        { 
            bool bTestClassOk;

            bTestClassOk = true;
            try
            {
                //--- DetermineMachineType ---------------------------
                // Try special values
                
                clsCommandLineToken oTest = new clsCommandLineToken();
                oTest.CommandLine = "Cmd1 /Opt1 -Opt2 cmd2=Value2 cmd3=\"Value3\" cmd4='Value4' /Opt3=On /Opt4=off /Opt5=\"off\" /Opt6='off' /Opt7=Otherwise";

                if (oTest.Commands.Count != 4)
                    bTestClassOk = false;

                if (oTest.Options.Count != 7)
                    bTestClassOk = false;


                bool bFndCmd1 = false, bFndCmd2 = false, bFndCmd3 = false, bFndCmd4 = false; // , bFndCmd1 = false, ;
                bool bFndOpt1 = false, bFndOpt2 = false, bFndOpt3 = false, bFndOpt4 = false, bFndOpt5 = false,
                    bFndOpt6 = false, bFndOpt7 = false; // , bFndOpt1 = false, 

                foreach (InCommand ActCommand in oTest.Commands)
                {
                    switch (ActCommand.Name)
                    {
                        case "Cmd1":
                            bFndCmd1 = true;
                            if (string.Compare(ActCommand.Value, "") != 0)
                                bTestClassOk = false;
                            break;

                        case "cmd2":
                            bFndCmd2 = true;
                            if (string.Compare(ActCommand.Value, "Value2") != 0)
                                bTestClassOk = false;
                            break;

                        case "cmd3":
                            bFndCmd3 = true;
                            if (string.Compare(ActCommand.Value, "Value3") != 0)
                                bTestClassOk = false;
                            break;

                        case "cmd4":
                            bFndCmd4 = true;
                            if (string.Compare(ActCommand.Value, "'Value4'") != 0)
                                bTestClassOk = false;
                            break;

                        /*                        
                            case "Cmd5":
                                bFndCmd5 = true;
                                if (string.Compare(ActCommand.Value, "") != 0)
                                    bTestClassOk = false;
                                break;
                        */

                        default:
                            bTestClassOk = false;
                            break;                    
                    }
                }

                if (!bFndCmd1) bTestClassOk = false;
                if (!bFndCmd2) bTestClassOk = false;
                if (!bFndCmd3) bTestClassOk = false;
                if (!bFndCmd4) bTestClassOk = false;
                //if (!bFndCmd5) bTestClassOk = false;

                foreach (InOption ActOption in oTest.Options)
                {
                    switch (ActOption.Name)
                    {
                        case "Opt1":
                            bFndOpt1 = true;
                            if (string.Compare(ActOption.Value, "True") != 0)
                                bTestClassOk = false;
                            break;

                        case "Opt2":
                            bFndOpt2 = true;
                            if (string.Compare(ActOption.Value, "True") != 0)
                                bTestClassOk = false;
                            break;

                        case "Opt3":
                            bFndOpt3 = true;
                            if (string.Compare(ActOption.Value, "On") != 0)
                                bTestClassOk = false;
                            break;

                        case "Opt4":
                            bFndOpt4 = true;
                            if (string.Compare(ActOption.Value, "off") != 0)
                                bTestClassOk = false;
                            break;

                        case "Opt5":
                            bFndOpt5 = true;
                            if (string.Compare(ActOption.Value, "off") != 0)
                                bTestClassOk = false;
                            break;

                        case "Opt6":
                            bFndOpt6 = true;
                            if (string.Compare(ActOption.Value, "'off'") != 0)
                                bTestClassOk = false;
                            break;

                        case "Opt7":
                            bFndOpt7 = true;
                            if (string.Compare(ActOption.Value, "Otherwise") != 0)
                                bTestClassOk = false;
                            break;

/*                        case "Opt8":
                            bFndOpt8 = true;
                            if (string.Compare(ActOption.Value, "") != 0)
                                bTestClassOk = false;
                            break; */

                        default:
                            bTestClassOk = false;
                            break;                    
                    }
                }

                if (!bFndOpt1) bTestClassOk = false;
                if (!bFndOpt2) bTestClassOk = false;
                if (!bFndOpt3) bTestClassOk = false;
                if (!bFndOpt4) bTestClassOk = false;
                if (!bFndOpt5) bTestClassOk = false;
                if (!bFndOpt6) bTestClassOk = false;
                if (!bFndOpt7) bTestClassOk = false;
                //if (!bFndOpt8) bTestClassOk = false;

                /* if (string.Compare(oTest.Commands["cmd2"], "Value2") != 0)
                    bTestClassOk = false;

                if (string.Compare(oTest.Commands ["cmd3"], "Value3") != 0)
                    bTestClassOk = false;

                if (string.Compare(oTest.Commands ["cmd4"], "'Value4'") != 0)
                    bTestClassOk = false;

                if (string.Compare(oTest.Options ["Opt2"], "") != 0)
                    bTestClassOk = false;

                if (string.Compare(oTest.Options ["Opt3"], "On") != 0)
                    bTestClassOk = false;

                if (string.Compare(oTest.Options ["Opt4"], "off") != 0)
                    bTestClassOk = false;

                if (string.Compare(oTest.Options ["Opt5"], "off") != 0)
                    bTestClassOk = false;

                if (string.Compare(oTest.Options ["Opt6"], "'off'") != 0)
                    bTestClassOk = false;

                if (string.Compare(oTest.Options ["Opt7"], "Otherwise") != 0)
                    bTestClassOk = false;

                // ToDo: Test AddCommand , Test addd oiption


/*                oTest.AssignCommand(@"/TestCommand", "TestCommand");
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
                string OutTxt = "Error while testing class clsCommandLineToken: " + ex.Message;
                Global.oDebugLog.MessageBox(OutTxt);
                                    
                bTestClassOk = false;
            }

            return bTestClassOk;
        }
    }
}
