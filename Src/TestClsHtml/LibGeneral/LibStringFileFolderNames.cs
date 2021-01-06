using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Windows.Forms;
// using System.Text.RegularExpressions;

using ErrorCapture;

namespace LibStringFunctions
{
    class LibStringFileFolderNames
    {
        /*
                foreach (string FolderName in mSearchFolders)
                {
                    if (FolderNames.Length > 1)
                        FolderNames += " ";
                    FolderNames += LibStringFunctions.EncloseApostropheOnSpaces(FolderName);
                }
*/

        /// <summary>
        /// Enclose every folder/file from list with "" when string containes spaces
        /// </summary>
        /// <param name="InFolderNames"></param>
        /// <returns>List of file/folder names</returns>
        public static List <string> CreateApostropheOnFolderNameWithSpaces  (List <string> InFolderNames)
        {
            List <string> FolderNames = new List<string> ();
            try
            {
                foreach (string FolderName in InFolderNames)
                {
                    FolderNames.Add (EncloseApostropheOnFolderNameWithSpaces (FolderName));
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            return FolderNames;        
        }

        /// <summary>
        /// Creates one long string containing all folder /file names separated by " " (space) 
        /// Folder / file names containing strings will be enclosed by apostrophes
        /// </summary>
        /// <param name="InFolderNames"></param>
        /// <returns></returns>
        public static string CreateSpaceSeparatedFolderNamesString(List<string> InFolderNames)
        {
            string FolderNames = "";
            try
            {
                foreach (string FolderName in CreateApostropheOnFolderNameWithSpaces(InFolderNames))
                {
                    if (FolderNames.Length > 0)
                        FolderNames += " ";
                    FolderNames += FolderName;
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            return FolderNames;
        }

        /// <summary>
        /// If a space ios found within string it is enclosed within ""
        /// </summary>
        /// <param name="Foldername"></param>
        /// <returns></returns>
        public static string EncloseApostropheOnFolderNameWithSpaces(string FolderName)
        {
            try
            {
                FolderName = FolderName.Trim ();
                if (FolderName.Contains(" "))
                {
                    FolderName = "\"" + FolderName + "\"";
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            return FolderName;
        }


        /// <summary>
        /// A space separated list inside a string is returned as list of strings.
        /// Spaces with in names are permitted as long as the name is endclosed in ""
        /// </summary>
        /// <param name="FolderNamesSpaceSeparated"></param>
        /// <returns></returns>
        public static List<string> ExtractFolderListWithApostrophes(string FolderNamesSpaceSeparated)
        {
            FolderNamesSpaceSeparated = FolderNamesSpaceSeparated.Trim ();

            List<string> FolderNamesList = new List<string>();
            try
            {
                // Special handling for Apostrophe. Remove it 
                if (FolderNamesSpaceSeparated.Contains("\""))
                {
                    int StartIdx = FolderNamesSpaceSeparated.IndexOf ("\"") +1;
                    // Pre folder names
                    if (StartIdx > 1)
                    {
                        string PrePart = FolderNamesSpaceSeparated.Substring (0, StartIdx).Trim ();
                        if (PrePart.Length > 0)
                            FolderNamesList.AddRange (ExtractFolderListNoSpaceInBetween(PrePart));
                    }

                    int EndIdx = FolderNamesSpaceSeparated.IndexOf ("\"", StartIdx);
                    // Not found ?
                    if (EndIdx < StartIdx)
                        EndIdx = FolderNamesSpaceSeparated.Length;                   

                    // Valid single apostroph name 
                    if (EndIdx > StartIdx)
                    {
                        string ActFolderName = FolderNamesSpaceSeparated.Substring (StartIdx, EndIdx-StartIdx).Trim ();
                        if (ActFolderName.Length > 0)
                            FolderNamesList.Add (ActFolderName);
                    }

                    // Post folder names
                    EndIdx ++;
                    if (EndIdx < FolderNamesSpaceSeparated.Length)
                    {
                        // Call itself for the rest of the string
                        string PostPart = FolderNamesSpaceSeparated.Substring(EndIdx, FolderNamesSpaceSeparated.Length - EndIdx).Trim();
                        FolderNamesList.AddRange (ExtractFolderListWithApostrophes(PostPart)); 
                    }
                }
                else
                {
                    FolderNamesList = ExtractFolderListNoSpaceInBetween(FolderNamesSpaceSeparated);
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
            return FolderNamesList;
        }

        /// <summary>
        /// A space separated list inside a string is returned as list of strings.
        /// Spaces with in are prohibited  
        /// </summary>
        /// <param name="FolderNamesSpaceSeparated"></param>
        /// <returns></returns>
        public static List<string> ExtractFolderListNoSpaceInBetween(string FolderNamesSpaceSeparated)
        {
            List<string> FolderNamesList = new List<string>();
            try
            {
                foreach (string InFolder in FolderNamesSpaceSeparated.Split(' '))
                {
                    string Trimmed = InFolder.Trim();
                    if (Trimmed.Length > 0)
                        FolderNamesList.Add(Trimmed);
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            return FolderNamesList;
        }
    } // End class
} // End namespace