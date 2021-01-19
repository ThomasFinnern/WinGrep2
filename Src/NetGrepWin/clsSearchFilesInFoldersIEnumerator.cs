using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ErrorCapture;

using MainGlobal;

namespace NetGrep
{
    //public class clsFileIEnumerable : IEnumerable<string>

    /// <summary>
    /// Yields through all possible file selections 
    /// Skips over given file types
    /// </summary>
    public class clsSearchFilesInFoldersIEnumerator  
    {
        protected List<string> NotPermittedFiles = new List<string>();
        // protected List<string> PermittedFiles = new List<string>();
        public List<string> UseFileList = new List<string>();

        // File 
        public List<string> FileTypes = new List<string>();
        public List<string> SearchFolders = new List<string>();
        public bool bUseFileRegularExpression = false;
        public bool bRegExFileMatchCase;


        // Folder
        public bool bCancelSearch = false;
        public bool bDoRecourseFolders = true;
        public bool bUseFolderRegularExpression = false;
        public bool bMatchFileCase = false;
        public bool bRegExFolderMatchCase = false;
        public bool bRegExPathLastPart = false;
        public string RegExPathLastPartText = "";

        public int FolderNbr;
        public int FileNbr;

        // protected List<IEnumerable<string>> ieSpecFiles = new List<IEnumerable<string>>();
        
        public IEnumerable<string> IenumFiles()
        {
            bCancelSearch = false;
            FolderNbr = 1;
            FileNbr = 0;

            //try
            {

                // Example: Search in found files
                if (UseFileList.Count > 0)
                {
                    foreach (string FileName in UseFileList)
                    {
                        FileNbr++;
                        yield return FileName;
                    }
                }
                else
                {
                    // All file types
                    foreach (string FileSearchPattern in FileTypes)
                    {
                        // All start folders 
                        foreach (string Folder in SearchFolders)
                        {
                            // ToDo Call subroutine
                                // ... there: call function for all files
                                // ... there call itself for all folders 


                            if (!Directory.Exists(Folder))
                            {
                                string OutTxt = "Wrong folder : '" + Folder + "'"; // Use debug or log file !!
                                MessageBox.Show(OutTxt);
                            }
                            else
                            {
                                // Will be called recursively
                                DirectoryInfo Dir = new DirectoryInfo(Folder);
                                foreach (string FileName in enumFilesFoundInFolders(Dir, FileSearchPattern))
                                {
                                    string PathPart = Path.GetDirectoryName(FileName);
                                    string NamePart = Path.GetFileName(FileName);

/*
                RegexOptions RegexOptions = new RegexOptions();
                if (GrepProperties.bMatchCase)
                    RegexOptions &= ~RegexOptions.IgnoreCase; // löschen
                else
                    RegexOptions |= RegexOptions.IgnoreCase;  // setzen

                // Test regular expession for errors
                try
                {
                    RegExSearch = new Regex(SearchString, RegexOptions);
*/



                                    // debug dummy
                                    if (NamePart.Contains("cs"))
                                    {


                                    }

                                    yield return FileName;

                                    if (bCancelSearch)
                                        break;
                                }
                            }

                            if (bCancelSearch)
                                break;

                        } // All start folders 

                        if (bCancelSearch)
                            break;
                    } // all file pattern types

                    yield break;
                }
            }
            //catch (Exception Ex)
            //{
            //    clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
            //    ErrCapture.ShowExeption();
            //}
        }

        private IEnumerable<string> enumFilesFoundInFolders(DirectoryInfo Dir, string FileSearchPattern)
        {
            // ToDo: replace each FileSpecification with FileSearchPattern or FilePattern
            //try
            {

                /*
                FileInfo[] DirFiles;
                // Standard : Files with given patterns
                if (!bUseFileRegularExpression)
                    DirFiles = );
                else
                    // For regex use all files
                    DirFiles = Dir.GetFiles();
                
                foreach (FileInfo ActFileInfo in DirFiles)
                ...
                */
                if (!bUseFileRegularExpression)
                {
                    foreach (FileInfo ActFileInfo in Dir.GetFiles(FileSearchPattern))
                    {
                        FileNbr++;

                        yield return ActFileInfo.FullName;
                        if (bCancelSearch)
                            break;
                    }
                }
                else
                {
                    RegexOptions RegexOptions = new RegexOptions();
                    if (bRegExFileMatchCase)
                        RegexOptions &= ~RegexOptions.IgnoreCase; // löschen
                    else
                        RegexOptions |= RegexOptions.IgnoreCase;  // setzen
                    Regex RegExSearch = new Regex(FileSearchPattern, RegexOptions);


                    // For regex use all files
                    foreach (FileInfo ActFileInfo in Dir.GetFiles())
                    {
                        Match MatchFile = RegExSearch.Match(ActFileInfo.Name);
                        if (MatchFile.Success)
                        {
                            FileNbr++;                        

                            yield return ActFileInfo.FullName;
                            if (bCancelSearch)
                                break;
                        }
                    }
                }


                if (!bCancelSearch && bDoRecourseFolders)
                {
                    // Process each directory
                    foreach (DirectoryInfo SubDir in Dir.GetDirectories())
                    {
                        FolderNbr++;

//                        YYYXXXX regex foldernames
                        ;

                        foreach (string FileName in enumFilesFoundInFolders(SubDir, FileSearchPattern))
                        {
                            yield return FileName;

                            if (bCancelSearch)
                                break;
                        }

                        if (bCancelSearch)
                            break;
                    }
                }
            }
            //catch (Exception Ex)
            //{
            //    clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
            //    ErrCapture.ShowExeption();
            //}
        }

/*
//                            yield return Directory.GetFiles(Folder, FileSpecification, SearchOption.AllDirectories);
                        IEnumerable<string> ActFolderIter = Directory.GetFiles(Folder, FileSpecification, SearchOption.AllDirectories);
                        // yield return ActFolderIter;
                        foreach (string FileName in ActFolderIter)
                        {
                            yield return FileName;
                        }

                    google: c# Directory.GetFiles view

http://stackoverflow.com/questions/6061957/get-all-files-and-directories-in-specific-path-fast

                        try,  catch, 
http://www.informit.com/guides/content.aspx?g=dotnet&seqNum=159

static

private void enumFilesFoundInFolders(DirectoryInfo Dir,string FileSpecification)
{
 	throw new Exception("The method or operation is not implemented.");
} 
        
        
 void FullDirList(DirectoryInfo dir, string searchPattern)
{
  Console.WriteLine("Directory {0}", dir.FullName);
  // list the files
  foreach (FileInfo f in dir.GetFiles(searchPattern))
  {
    Console.WriteLine("File {0}", f.FullName);
  }
  // process each directory
  foreach (DirectoryInfo d in dir.GetDirectories())
  {
    FullDirList(d, searchPattern);
  }
}



        }
*/
        public IEnumerable<string []> IenumFiles2()
        {
            //try
            //{
            // Example: Search in found files
            if (UseFileList.Count > 0)
            {
                 yield return UseFileList.ToArray ();
            }

            foreach (string FileSpecification in FileTypes)
            {
                foreach (string Folder in SearchFolders)
                {
                    if (!Directory.Exists(Folder))
                    {
                        string OutTxt = "Wrong folder : '" + Folder + "'"; // Use debug or log file !!
                        MessageBox.Show(OutTxt);
                    }
                    else
                    {
                        yield return Directory.GetFiles(Folder, FileSpecification, SearchOption.AllDirectories);
                    }
                }
            }            //}
            //catch (Exception Ex)
            //{
            //    clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
            //    ErrCapture.ShowExeption();
            //}
        }

    }
}
