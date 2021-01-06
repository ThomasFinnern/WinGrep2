using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Windows.Forms;
using ErrorCapture;
using MainGlobal;
using LibStdFileDateTime;

//-------------------------------------------------------------------
// Once used commands
// - /?
// - /CmdPath=\"..\\..\\..\\Cmds\\\" CmdFile=\"GrpWCmd.FirstFind.cmd\" /CloseAfterCommandsDone
// - /OutPath=\"..\\..\\..\\Data\\\" /CmdPath=\"..\\..\\..\\Cmds\\\" CmdFile=\"GrpWCmd.FirstFind.cmd\" /CloseAfterCommandsDone
// - 
// - 
// - 
// - 
// - 
// - 
// - 
// - 
// - 
// - 
// - 
//-------------------------------------------------------------------

namespace CmdLine2005
{
    public partial class clsCommandLine    
    {
        public void defineCommands()
        {
            clsCommandsBase nextCmd = null;

            AssignStandardCommandsOptions();

            //---------------------------------------------------------
            // Assign possible options 
            //---------------------------------------------------------

//            AssignOption(@"InPath", @"=""Path"": Defines the path to the input file"); 
//            AssignOption(@"InFile", @"=""Filename"": File to read from");
//            AssignOption(@"OutPath", @"=""Path"": Defines the path for writing the results"); // ToDo: Use OutPath in alll cases
//            AssignOption(@"OutFile", @"=""Filename"": Defines the file for writing the results");
//            AssignOption(@"InOutFile", @"=""Filename"": Exchange file for reading and writing of data");
            AssignOption(@"FolderFilePath", @"=""Path"": Uses the path for file containing folder list"); // 
            AssignOption(@"FolderFile", @"=""File"": Defines the file containing foldernames");
            // prepared: AssignOption(@"BaseFolder", @"=""Path"": Defines the base folder for the folders names inside the file"); 

            //prepared : AssignOption(@"CfgFile", @"=""Filename"": Select config file");
            // prepared : AssignOption(@"CfgPath", @"=""Path"": Defines the path to the config file"); // ToDo: Use OutPath in alll cases
            //AssignOption(@"SearchString", @"=search text. enter whatever it is which should be found",
            //    delegate {
            //        if (ActCmdObject.InOption("SearchString").bIsOptionEnabled)
            //        {
            //            Global.DoCmdGrepProperties.SearchString = ActCmdObject.InOption("SearchString").Value;                
            //        }
            //    }
            //    );
            //AssignOption(@"FileSpecification", @"=""File specifications"". Specifications like '*.cs '.exe' seperated by blanks",
            //    delegate
            //    {
            //        if (ActCmdObject.InOption("FileSpecification").bIsOptionEnabled)
            //        {
            //            Global.DoCmdGrepProperties.SearchFileTypesAsString = ActCmdObject.InOption("FileSpecification").Value;
            //        }
            //    }
            //    );
            //AssignOption(@"Folders", @"=""folders"": List of folders seperated by ',' ",
            //    delegate
            //    {
            //        if (ActCmdObject.InOption("Folders").bIsOptionEnabled)
            //        {
            //            Global.DoCmdGrepProperties.AddSearchFolder(ActCmdObject.InOption("Folders").Value);
            //        }
            //    }
            //    ); // ToDo: check for blanks as seperator ...
            //AssignOption(@"RegularExpressions", @"="true/false". use regular expression (default ?)");
            AssignOption(@"MatchCase", @"=""true/false"". Do match case of search string (default -> false)");
            AssignOption(@"WholeWordsOnly", @"=");
            AssignOption(@"InvertMatch", @"=");
            AssignOption(@"StopAfterFirstMatch", @"=");
            AssignOption(@"SkipTextFiles", @"=");
            AssignOption(@"SkipBinaryFiles", @"=");
            AssignOption(@"LookInZips", @"=");  // RAR 7z ...
            AssignOption(@"RecourseFolders", @"=""true/false"". Search in sub folders (default -> yes)");
            AssignOption(@"CountFilesFirst", @"=");
            AssignOption(@"Skip_vti", @"=");
            AssignOption(@"DelimitedList", @"=""true/false""   ");
            AssignOption(@"DelimitedListSeperator", @"=""Char or string"" which is used to destinguish between columns");
            AssignOption(@"DelimitedListColumnNumber", @"=""Column number"" in which to search");
            AssignOption(@"FixedWithList", @"=""true/false""   ");
            AssignOption(@"FixedWithStart", @"="" "" . Character column where to start search in line");
            AssignOption(@"FixedWithSize", @"=""  "" Width of the fied where to search for in line");
            //AssignOption(@"FilterDate", @"="); // ToDo: filter Date ...
            //AssignOption(@"FilterSize", @"="); // ToDo: Filter Size
            AssignOption(@"MatchAbove", @"=""lines"". 0 shows no line above the found line");
            AssignOption(@"MatchBelow", @"=""lines"". 0 shows no line below the found line");
            AssignOption(@"ShowSearchDialogOnStartup", @"=""true/false""   ");
            AssignOption(@"EditorCommandLine", @"="); // ToDo: EditorCommandLine with options
            //AssignOption(@"DoPopUpSearchOnStart", @"=""true/false"" Do pop up search view on start of program",
            //    delegate
            //    {
            //        if (ActCmdObject.InOption("DoPopUpSearchOnStart").bIsOptionEnabled)
            //        {
            //            Global.Config.bDoPopUpSearchOnStart = ActCmdObject.InOption("DoPopUpSearchOnStart").bValue;
            //        }
            //    });

            //AssignOption(@"bDoRepeatLastSearchOnStart", @"=""true/false"" Do repeat (start) last search on start of program",
            //    delegate
            //    {
            //        if (ActCmdObject.InOption("DoRepeatLastSearchOnStart").bIsOptionEnabled)
            //        {
            //            Global.Config.bDoRepeatLastSearchOnStart = ActCmdObject.InOption("DoRepeatLastSearchOnStart").bValue;
            //        }
            //    });

            //---------------------------------------------------------
            // Assign possible commands 
            //---------------------------------------------------------
            
            nextCmd = new clsCommandsBase(@"Find",
                "Find expression",
                delegate
                {
                    DoCmdFind  (); // ActCmdObject.InOption ("OutFile").Value);
                }
            );
            AssignCommand(nextCmd);

            nextCmd = new clsCommandsBase(@"Replace",
                "Replace found expression",
                delegate
                {
                    DoCmdReplace();
                }
            );
            AssignCommand(nextCmd);

            nextCmd = new clsCommandsBase(@"ShowResult",
                "Shows result in Windows of exe",
                delegate
                {
                    DoCmdShowResult  ();
                }
            );
            AssignCommand(nextCmd);

            /*
            nextCmd = new clsCommandsBase(@"Chain",
                "Use result for further search ? ... ???",
                delegate
                {
                    DoCmd...  (ActCmdObject.InOption ("OutFile").Value);
                }
            );
            AssignCommand(nextCmd);
            */
            
            nextCmd = new clsCommandsBase(@"UseFoldersFromFile",
                "Use folder names from file content and add them to the actual search list",
                delegate
                {
//                    DoCmdUseFoldersFromFile(ActCmdObject.InOption("FolderFilePath").Value, ActCmdObject.InOption("FolderFile").Value);
                }
            );
            AssignCommand(nextCmd);

/* prepared
            nextCmd = new clsCommandsBase(@"ClearFolderList",
                "Clears folder search list (where to look for files)",
                delegate
                {
//                    DoCmdClearFolderList();
                }
            );
            AssignCommand(nextCmd);

            nextCmd = new clsCommandsBase(@"Add2FolderList",
                "<>  Adds one entry to folder search list (where to look for files)",
                delegate
                {
                    DoCmdAdd2FolderList();
                }
            );
            AssignCommand(nextCmd);

            
            nextCmd = new clsCommandsBase(@"UseConfigFile",
                "",
                delegate
                {
                    DoCmdUseConfigFile  (ActCmdObject.InOption ("CfgPath").Value, ActCmdObject.InOption ("CfgFile").Value);
                }
            );
            AssignCommand(nextCmd);
 */

            
            
            
            //nextCmd = new clsCommandsBase(@"WriteResultIntoFile",
            //    "",
            //    delegate
            //    {
            //        DoCmdWriteResultIntoFile(ActCmdObject.InOption("OutPath").Value, ActCmdObject.InOption("OutFile").Value);
            //    }
            //);
            //AssignCommand(nextCmd);            

            //nextCmd = new clsCommandsBase(@"WriteResultIntoFileAsHtml",
            //    "",
            //    delegate
            //    {
            //        DoCmdWriteResultIntoFileAsHtml(ActCmdObject.InOption("OutPath").Value, ActCmdObject.InOption("OutFile").Value);
            //    }
            //);
            //AssignCommand(nextCmd);








            /*
            nextCmd = new clsCommandsBase(@"",
                "",
                delegate
                {
                    DoCmd...  (ActCmdObject.InOption ("OutFile").Value);
                }
            );
            AssignCommand(nextCmd);
            */

/*
            nextCmd = new clsCommandsBase(@"",
                "",
                delegate
                {
                    DoCmd...  (ActCmdObject.InOption ("OutFile").Value);
                }
            );
            AssignCommand(nextCmd);
            */
            /*
            nextCmd = new clsCommandsBase(@"",
                "",
                delegate
                {
                    DoCmd...  (ActCmdObject.InOption ("OutFile").Value);
                }
            );
            AssignCommand(nextCmd);
            */

/*
            nextCmd = new clsCommandsBase(@"",
                "",
                delegate
                {
                    DoCmd...  (ActCmdObject.InOption ("OutFile").Value);
                }
            );
            AssignCommand(nextCmd);
            */
            /*
            nextCmd = new clsCommandsBase(@"",
                "",
                delegate
                {
                    DoCmd...  (ActCmdObject.InOption ("OutFile").Value);
                }
            );
            AssignCommand(nextCmd);
            */

        }
    } // class
} // namespace
