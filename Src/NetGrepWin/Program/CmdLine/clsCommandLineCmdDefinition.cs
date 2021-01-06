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
// - /CmdPath=\"..\\..\\..\\Cmds\\\" CmdFile=\"RegNetGrep.01.cmd\" /CloseAfterCommandsDone
// - /CmdPath=\"..\..\..\Cmds\\\" CmdFile="RegNetGrep.01.cmd" /CloseAfterCommandsDone
// - /CmdPath=\"..\..\..\..\NetGrepGroup.2005.Regression\" CmdFile="RegNetGrep.01.cmd" /CloseAfterCommandsDone
// - /CmdPath=\"..\\..\\..\\Cmds\\\" CmdFile=\"RegNetGrep.01.cmd\" /CloseAfterCommandsDone
// - CmdFile=\"RegNetGrep.01.cmd\" /CloseAfterCommandsDone 
// - -------------
// - 
// - /SearchString="$rsgConfig" /FileSpecification="*.php" /Folders="f:\Entwickl\Entwickl.2018\NetGrepGroup.2005.Data\RSGallery2_Component.Flat" /NoAutoExit /CloseAfterCommandsDone Search ShowSearchResult
// - 
// - ToDo: CmdLine Do replace with parameters
// - ToDo: CmdLine Show search query
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

            AssignOption(@"InPath", @"=""Path"": Defines the path to the input file"); 
            AssignOption(@"InFile", @"=""Filename"": File to read from");
            AssignOption(@"OutPath", @"=""Path"": Defines the path for writing the results"); // ToDo: Use OutPath in alll cases
            AssignOption(@"OutFile", @"=""Filename"": Defines the file for writing the results");
            //            AssignOption(@"InOutFile", @"=""Filename"": Exchange file for reading and writing of data");
            AssignOption(@"FolderFilePath", @"=""Path"": Uses the path for file containing folder list"); // 
            AssignOption(@"FolderFile", @"=""File"": Defines the file containing foldernames");
            // prepared: AssignOption(@"BaseFolder", @"=""Path"": Defines the base folder for the folders names inside the file"); 

            //prepared : AssignOption(@"CfgFile", @"=""Filename"": Select config file");
            // prepared : AssignOption(@"CfgPath", @"=""Path"": Defines the path to the config file"); // ToDo: Use OutPath in alll cases

            AssignOption(@"DoOpenLastUsedSearch", @"On start the last used search will be opened (default)");
            AssignOption(@"DontOpenLastUsedSearch", @"On start the last used search is prevented from opening");
            AssignOption(@"DoLoadLastOpenSearchesOnStart", @"On start all last used (open) searches will be opened");
            AssignOption(@"DontLoadLastOpenSearchesOnStart", @"On start the last used (open) searches are prevented from opening");

            /*==========================================================
            next definitions follow definitions in clsSearchProperties
            ==========================================================*/

            // ToDo: Mehr Erklärungen ausfüllen;

            AssignOption(@"SearchString", @"=Search text. May not contain blanks",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("SearchString");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.SearchString = ActOption.Value;
                    }
                }
                );
            AssignOption(@"FileSpecification", @"=""File specifications"". Specifications like '*.cs '.exe' seperated by blanks",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("FileSpecification");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.SearchFileTypesAsString = ActOption.Value;
                    }
                }
                );
            AssignOption(@"Folders", @"=""Folders"": List of folders seperated by ','. May contain definition in the form ""folder1"" ""folder2"" ... ",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("Folders");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.SearchFoldersAsString = ActOption.Value;
                    }
                }
                );

            AssignOption(@"RegularExpressions", @"=""true/false"". use regular expression (default ?)",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("RegularExpressions");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.bUseRegularExpression = ActOption.bValue;
                    }
                }
                );
            AssignOption(@"WholeWordsOnly", @"=""true/false"". ",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("WholeWordsOnly");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.bWholeWordsOnly = ActOption.bValue;
                    }
                }
                );
            AssignOption(@"MatchCase", @"=""true/false"". Do match case of search string (default -> false)",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("MatchCase");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.bMatchCase = ActOption.bValue;
                    }
                }
                );
            AssignOption(@"LinesWithNoMatch", @"=""true/false"". ",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("LinesWithNoMatch");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.bLinesWithNoMatch = ActOption.bValue;
                    }
                }
                );
            AssignOption(@"StopAfterFirstMatch", @"=""true/false"". ",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("StopAfterFirstMatch");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.bStopAfterFirstMatch = ActOption.bValue;
                    }
                }
                );
            AssignOption(@"FilesWithNoMatch", @"=""true/false"". ",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("FilesWithNoMatch");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.bFilesWithNoMatch = ActOption.bValue;
                    }
                }
                );
            AssignOption(@"SearchInFoundFiles", @"=""true/false"". ",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("SearchInFoundFiles");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.bSearchInFoundFiles = ActOption.bValue;
                    }
                }
                );
            AssignOption(@"ReplaceString", @"=""Text to replace search string",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("ReplaceString");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.ReplaceString = ActOption.Value;
                    }
                }
                );
            AssignOption(@"NeedsCompleteLine", @"=""true/false"". ",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("NeedsCompleteLine");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.bNeedsCompleteLine = ActOption.bValue;
                    }
                }
                );
            AssignOption(@"UseDelimitedList", @"=""true/false"". ",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("UseDelimitedList");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.bUseDelimitedList = ActOption.bValue;
                    }
                }
                );
            AssignOption(@"UseFixedWidthList", @"=""true/false"". ",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("UseFixedWidthList");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.bUseFixedWidthList = ActOption.bValue;
                    }
                }
                );

            AssignOption(@"DelimitedSeperationChar", @"=",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("DelimitedSeperationChar");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.DelimitedSeperationChar = ActOption.Value;
                    }
                }
                );
            AssignOption(@"DelimitedSearchFieldNbr", @"=",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("DelimitedSearchFieldNbr");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.DelimitedSearchFieldNbr = ActOption.Value;
                    }
                }
                );
            AssignOption(@"FixedWidthBeginPosition", @"=",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("FixedWidthBeginPosition");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.FixedWidthBeginPosition = ActOption.Value;
                    }
                }
                );
            AssignOption(@"FixedWidthSize", @"=",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("FixedWidthSize");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.FixedWidthSize = ActOption.Value;
                    }
                }
                );

            // --- File type options -----------------------------------

            AssignOption(@"UseFileRegularExpression", @"=""true/false"". ",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("UseFileRegularExpression");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.bUseFileRegularExpression = ActOption.bValue;
                    }
                }
                );
            AssignOption(@"SearchInsideZipFiles", @"=""true/false"". ",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("SearchInsideZipFiles");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.bSearchInsideZipFiles = ActOption.bValue;
                    }
                }
                );
            // AssignOption(@"SkipBinaryFiles", @"=""true/false"". ");
            // AssignOption(@"SkipTextFiles", @"=""true/false"". ");
            AssignOption(@"SkipFileTypes", @"=""true/false"". ",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("SkipFileTypes");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.bSkipFileTypes = ActOption.bValue;
                    }
                }
                );
            AssignOption(@"SkipFileTypesString", @"=",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("SkipFileTypesString");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.SkipFileTypesString = ActOption.Value;
                    }
                }
                );

            // --- Folder options -------------------------------------

            AssignOption(@"UseFolderRegularExpression", @"=""true/false"". ",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("UseFolderRegularExpression");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.bUseFolderRegularExpression = ActOption.bValue;
                    }
                }
                );
            AssignOption(@"DoRecourseFolders", @"=",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("DoRecourseFolders");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.bDoRecourseFolders = ActOption.bValue;
                    }
                }
                );

            // --- Replace options ------------------------------------
            AssignOption(@"ReplaceInSelectedFiles", @"=""true/false"". ",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("ReplaceInSelectedFiles");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.bReplaceInSelectedFiles = ActOption.bValue;
                    }
                }
                );
            AssignOption(@"ConfirmEachReplace", @"=""true/false"". ",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("ConfirmEachReplace");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.bConfirmEachReplace = ActOption.bValue;
                    }
                }
                );
            AssignOption(@"CreateBackup", @"=""true/false"". ",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("CreateBackup");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.bCreateBackup = ActOption.bValue;
                    }
                }
                );
            AssignOption(@"ReplaceOriginalFile", @"=""true/false"". ",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("ReplaceOriginalFile");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.bReplaceOriginalFile = ActOption.bValue;
                    }
                }
                );
            AssignOption(@"UseBackupFolder", @"=""true/false"". ",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("UseBackupFolder");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.bUseBackupFolder = ActOption.bValue;
                    }
                }
                );
            AssignOption(@"BackupFolder", @"=",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("BackupFolder");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.BackupFolder = ActOption.Value;
                    }
                }
                );

            // --- View options ------------------------------------
            AssignOption(@"ViewDoShowTitle", @"=""true/false"". ",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("ViewDoShowTitle");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.ViewSetting.bDoShowTitle = ActOption.bValue;
                    }
                }
                );
            AssignOption(@"ViewDoShowLineNumbers", @"=""true/false"". ",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("ViewDoShowLineNumbers");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.ViewSetting.bDoShowLineNumbers = ActOption.bValue;
                    }
                }
                );
            AssignOption(@"ViewDoShowFixedFont", @"=""true/false"". ",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("ViewDoShowFixedFont");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.ViewSetting.bDoShowFixedFont = ActOption.bValue;
                    }
                }
                );
            AssignOption(@"ViewDoShowFileNames", @"=""true/false"". ",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("ViewDoShowFileNames");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.ViewSetting.bDoShowFileNames = ActOption.bValue;
                    }
                }
                );
            AssignOption(@"ViewDoShowFileContents", @"=""true/false"". ",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("ViewDoShowFileContents");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.ViewSetting.bDoShowFileContents = ActOption.bValue;
                    }
                }
                );
            AssignOption(@"ViewDoShowWholeLine", @"=""true/false"". ",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("ViewDoShowWholeLine");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.ViewSetting.bDoShowWholeLine = ActOption.bValue;
                    }
                }
                );

            AssignOption(@"ViewShowLineNbrPreviousToMatch", @"=",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("ViewShowLineNbrPreviousToMatch");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.ViewSetting.Show.LineNbrPreviousToMatch = Convert.ToInt32(ActOption.Value);
                    }
                }
                );
            AssignOption(@"ViewShowLineNbrFollowingMatch", @"=",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("ViewShowLineNbrFollowingMatch");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.ViewSetting.Show.LineNbrFollowingMatch = Convert.ToInt32(ActOption.Value);
                    }
                }
                );
            AssignOption(@"ViewKeepLineNbrPreviousToMatch", @"=",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("ViewKeepLineNbrPreviousToMatch");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.ViewSetting.Keep.LineNbrPreviousToMatch = Convert.ToInt32(ActOption.Value);
                    }
                }
                );
            AssignOption(@"ViewKeepLineNbrFollowingMatch", @"=",
                delegate
                {
                    InOption ActOption = ActCmdObject.InOption("ViewKeepLineNbrFollowingMatch");
                    if (ActOption.bIsOptionEnabled)
                    {
                        Global.DoCmdGrepProperties.ViewSetting.Keep.LineNbrFollowingMatch = Convert.ToInt32(ActOption.Value);
                    }
                }
                );


            /*
                        ShowViewSelection

                        public bool bDoShowTitle;
                        public bool bDoShowLineNumbers;
                        public bool bDoShowFixedFont;
                        public bool bDoShowFileNames;
                        public bool bDoShowFileContents;
                        public bool bDoShowWholeLine;
                        Show
                        public long LineNbrPreviousToMatch;
                        public long LineNbrFollowingMatch;
                        Keep
                        public long LineNbrPreviousToMatch;
                        public long LineNbrFollowingMatch;
            */

            // AssignOption(@"LookInZipFiles", @"=""true/false"". ");

            /*
            AssignOption(@"", @"=");
            AssignOption(@"", @"=");
            AssignOption(@"", @"=");
            AssignOption(@"", @"=");
            AssignOption(@"", @"=");
            AssignOption(@"", @"=");


            //AssignOption(@"FilterDate", @"="); // ToDo: filter Date ...
            //AssignOption(@"FilterSize", @"="); // ToDo: Filter Size
            AssignOption(@"MatchAbove", @"=""lines"". 0 shows no line above the found line");
            AssignOption(@"MatchBelow", @"=""lines"". 0 shows no line below the found line");
            */

            AssignOption(@"ShowSearchDialogOnStartup", @"=""true/false""   ");
            // AssignOption(@"EditorCommandLine", @"="); // ToDo: EditorCommandLine with options
            AssignOption(@"DoPopUpSearchOnStart", @"=""true/false"" Do pop up search view on start of program",
                delegate
                {
                    if (ActCmdObject.InOption("DoPopUpSearchOnStart").bIsOptionEnabled)
                    {
                        Global.Config.bDoPopUpSearchOnStart = ActCmdObject.InOption("DoPopUpSearchOnStart").bValue;
                    }
                });

            AssignOption(@"bDoRepeatLastSearchOnStart", @"=""true/false"" Do repeat (start) last search on start of program",
                delegate
                {
                    if (ActCmdObject.InOption("DoRepeatLastSearchOnStart").bIsOptionEnabled)
                    {
                        Global.Config.bDoRepeatLastSearchOnStart = ActCmdObject.InOption("DoRepeatLastSearchOnStart").bValue;
                    }
                });

            //---------------------------------------------------------
            // Assign possible commands 
            //---------------------------------------------------------

            nextCmd = new clsCommandsBase(@"Search",
                "Search expression",
                delegate
                {
                    DoCmdSearch(); // ActCmdObject.InOption ("OutFile").Value);
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

            nextCmd = new clsCommandsBase(@"ShowSearchResult",
                "Creates Html views of found data and shows result in Windows of exe",
                delegate
                {
                    DoCmdCreateHtmlViewAndShowSearchResult();
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

            /* prepared
            nextCmd = new clsCommandsBase(@"*UseFoldersFromFile",
                "Use folder names from file content and add them to the actual search list",
                delegate
                {
                    DoCmdUseFoldersFromFile(ActCmdObject.InOption("FolderFilePath").Value, ActCmdObject.InOption("FolderFile").Value);
                }
            );
            AssignCommand(nextCmd);

            nextCmd = new clsCommandsBase(@"ClearFolderList",
                "Clears folder search list (where to look for files)",
                delegate
                {
                    DoCmdClearFolderList();
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

            nextCmd = new clsCommandsBase(@"UseFoldersFromFile",
                "Use folder names from file content and add them to the actual search list",
                delegate
                {
//                    DoCmdUseFoldersFromFile(ActCmdObject.InOption("FolderFilePath").Value, ActCmdObject.InOption("FolderFile").Value);
                }
            );
            AssignCommand(nextCmd);

            nextCmd = new clsCommandsBase(@"SaveConfigFile",
                "",
                delegate
                {
                    DoCmdSaveConfigFile(ActCmdObject.InOption("CfgPath").Value, ActCmdObject.InOption("CfgFile").Value);
                }
            );
            AssignCommand(nextCmd);

            nextCmd = new clsCommandsBase(@"ReadConfigFile",
                "",
                delegate
                {
                    DoCmdReadConfigFile(ActCmdObject.InOption("CfgPath").Value, ActCmdObject.InOption("CfgFile").Value);
                }
            );
            AssignCommand(nextCmd);
            //*/

            nextCmd = new clsCommandsBase(@"*ReadSearchQueryFromFile",
                "The  parameters of a search query are read from a file",
                delegate
                {
                    // DoCmdReadSearchQueryFromFile(ActCmdObject.InOption("InPath").Value, ActCmdObject.InOption("InFile").Value);
                }
            );
            AssignCommand(nextCmd);

            nextCmd = new clsCommandsBase(@"*WriteSearchQueryIntoFile",
                "The  parameters of a search query are written to a file",
                delegate
                {
                    // DoCmdWriteSearchQueryIntoFile(ActCmdObject.InOption("OutPath").Value, ActCmdObject.InOption("OutFile").Value);
                }
            );
            AssignCommand(nextCmd);

            nextCmd = new clsCommandsBase(@"WriteSearchResultIntoFile",
                "Writes the comprehensive results as class into a file where it may be retrived and viewed later",
                delegate
                {
                    DoCmdWriteSearchResultIntoFile(ActCmdObject.InOption("OutPath").Value, ActCmdObject.InOption("OutFile").Value);
                }
            );
            AssignCommand(nextCmd);

            nextCmd = new clsCommandsBase(@"*ReadSearchResultFromFile",
                "Read the comprehensive results as class from a file to view it with the next command",
                delegate
                {
                    // DoCmdReadSearchResultFromFile(ActCmdObject.InOption("InPath").Value, ActCmdObject.InOption("InFile").Value);
                }
            );
            AssignCommand(nextCmd);


            nextCmd = new clsCommandsBase(@"*ShowSearchResultsInForm",
                "View seach results in a form in the programm. Data may be read before from file (ReadSearchResultFromFile) or created by search",
                delegate
                {
                    // DoCmdReadSearchResultFromFile(ActCmdObject.InOption("InPath").Value, ActCmdObject.InOption("InFile").Value);
                }
            );
            AssignCommand(nextCmd);

            nextCmd = new clsCommandsBase(@"CreateResultFileListAsHtml",
                "Uses search results to create a found files list view in HTML",
                delegate
                {
                    DoCmdCreateResultFileListAsHtml();
                }
            );
            AssignCommand(nextCmd);

            nextCmd = new clsCommandsBase(@"CreateResultTokenLinesAsHtml",
                "Uses search results to create a token lines view in HTML",
                delegate
                {
                    DoCmdCreateResultTokenLinesAsHtml();
                }
            );
            AssignCommand(nextCmd);

            nextCmd = new clsCommandsBase(@"CreateResultAsHtml",
                "Uses search results to create a found files list view in HTML. Uses search results to create a token lines view in HTML",
                delegate
                {
                    DoCmdCreateResultAsHtml();
                }
            );
            AssignCommand(nextCmd);

            nextCmd = new clsCommandsBase(@"WriteSearchResultIntoFileAsHtml",
                "Writes two seperate HTML files for found files list and token lines view",
                delegate
                {
                    DoCmdWriteSearchResultIntoFileAsHtml(ActCmdObject.InOption("OutPath").Value, ActCmdObject.InOption("OutFile").Value);
                }
            );
            AssignCommand(nextCmd);

            nextCmd = new clsCommandsBase(@"WriteSearchResultFileListIntoFileAsHtml",
                "Writes HTML file for found files list view",
                delegate
                {
                    DoCmdWriteSearchResultFileListIntoFileAsHtml(ActCmdObject.InOption("OutPath").Value, ActCmdObject.InOption("OutFile").Value);
                }
            );
            AssignCommand(nextCmd);

            nextCmd = new clsCommandsBase(@"WriteSearchResultTokenLinesIntoFileAsHtml",
                "Writes HTML files for token lines view",
                delegate
                {
                    DoCmdWriteSearchResultTokenLinesIntoFileAsHtml(ActCmdObject.InOption("OutPath").Value, ActCmdObject.InOption("OutFile").Value);
                }
            );
            AssignCommand(nextCmd);


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
