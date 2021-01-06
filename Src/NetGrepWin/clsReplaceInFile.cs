using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Windows.Forms;
using ErrorCapture;


namespace NetGrep
{
    class clsReplaceInFile
    {
        public clsSearchProperties GrepProperties;
        //public clsLineResult FileResultInfo;
        public clsFileResults FileResultInfo;

        public void DoReplaceInFile(
            clsSearchProperties InGrepProperties,
            clsFileResults InFileResultInfo)
        {
            try
            {
                string BakFileName = "";
                string SrcFileName = "";
                string DstFileName = "";
                GrepProperties = InGrepProperties;
                FileResultInfo = InFileResultInfo;

                /*
                ToDo: SearchProperties.bReplaceInSelectedFiles = chkReplaceInSelectedFiles.Checked; ==> Open window with list and then reduce ....
                OK: SearchProperties.bConfirmEachReplace = chkReplaceConfirmEachReplace.Checked;
                ToDo: . SearchProperties.bCreateBackup = chkCreateBackup.Checked;
                ToDo: . SearchProperties.bReplaceOriginalFile = chkReplaceOriginalFile.Checked;
                */

                // Confirm replace if requested
                if (GrepProperties.bConfirmEachReplace)
                {
                    string OutTxt = "Replace in file " + FileResultInfo.FileName + " ?";
                     
                    DialogResult dialogResult = MessageBox.Show (OutTxt, "Confirm replacement", MessageBoxButtons.YesNo);
                    if(dialogResult == DialogResult.No) 
                    {     
                        return;    
                    } 
                }

                // Is seperate folder path given for backup
                if (GrepProperties.bUseBackupFolder)
                {
                    BakFileName = ""
                        + GrepProperties.BackupFolder  + "\\"
                        + Path.GetFileNameWithoutExtension(FileResultInfo.FileName)
                        + ".bk!";
                }
                else
                {

                    BakFileName = ""
                        + Path.GetDirectoryName(FileResultInfo.FileName) + "\\"
                        + Path.GetFileNameWithoutExtension(FileResultInfo.FileName)
                        + ".bk!";

                    // ToDo:: create tempfile for backup when backup is not requested. See below
                    // Einen freien Tempärardateinamen abfragen 
                    // VORSICHT: Der zurückgegebene Dateiname 
                    //' wird (als leere Datei) angelegt! 
                    //strTempFile = IO.Path.GetTempFileName 

                    //' Einen StreamWriter für das Schreiben in die 
                    //' Temporärdatei neu anlegen: 
                    //Dim StreamW As IO.StreamWriter _ 
                    //            = New IO.StreamWriter(strTempFile) 
                    //StreamW.WriteLine("Text, der in der Temporärdatei gespeichert wird.") 
                    //StreamW.Close() 

                    //' Einen StreamReader erzeugen, um die Datei auszulesen: 
                    //Dim StreamR As IO.StreamReader _ 
                    //            = New IO.StreamReader(strTempFile) 
                    //Dim strRead As String = StreamR.ReadToEnd() 
                    //StreamR.Close() 

                    //' Aus der Temporärdatei ausgelesenen Text ausgeben: 
                    //Console.WriteLine("Die Temporärdatei{0}{1}{0}wurde genutzt, " & _ 
                    //                  "um den folgenden Text zwischenzuspeichern:{0}{2}", _ 
                    //                  vbNewLine, strTempFile, strRead) 

                    //' Temporärdatei löschen  
                    //Kill(strTempFile)

                    if (File.Exists(BakFileName))
                    {
                        if (!GrepProperties.bCreateBackup)
                        {
                            BakFileName = ""
                                + Path.GetDirectoryName(FileResultInfo.FileName) + "\\"
                                + Path.GetFileNameWithoutExtension(FileResultInfo.FileName)
                                + ".bk!2";
                            if (File.Exists(BakFileName))
                            {
                                BakFileName = ""
                                    + Path.GetDirectoryName(FileResultInfo.FileName) + "\\"
                                    + Path.GetFileNameWithoutExtension(FileResultInfo.FileName)
                                    + ".bk!3";
                            }
                            if (File.Exists(BakFileName))
                            {
                                BakFileName = ""
                                    + Path.GetDirectoryName(FileResultInfo.FileName) + "\\"
                                    + Path.GetFileNameWithoutExtension(FileResultInfo.FileName)
                                    + ".bk!4";
                            }
                            if (File.Exists(BakFileName))
                            {
                                BakFileName = ""
                                    + Path.GetDirectoryName(FileResultInfo.FileName) + "\\"
                                    + Path.GetFileNameWithoutExtension(FileResultInfo.FileName)
                                    + ".bk!5";
                                if (File.Exists(BakFileName))
                                {
                                    MessageBox.Show("All valid backup file names are already created: '" + BakFileName + "'");
                                }
                            }
                        }
                        else
                        {
                            //  Delete saved one 
                            File.Delete(BakFileName);
                        }
                    }
                }

                DstFileName = FileResultInfo.FileName;
                if (GrepProperties.bReplaceOriginalFile)
                {
                    //  Rename old one 
                    File.Move(DstFileName, BakFileName);
                    // SrcFileName = DstFileName;
                    SrcFileName = BakFileName;
                }
                else
                {
                    SrcFileName = DstFileName; // FileResultInfo.FileName;
                    DstFileName = ""
                        + Path.GetDirectoryName(SrcFileName) + "\\"
                        + Path.GetFileNameWithoutExtension(SrcFileName)
                        + ".New" + Path.GetExtension(SrcFileName);
                }

                // ToDo: open with type from found File 
                // ToDo: Yyyy checked for DateTime as iterator may be changed within . then ignore iterator.

                FileStream OutFile = File.Create(DstFileName);
                StreamWriter LineWriter = new StreamWriter(OutFile, Encoding.Default);

                try
                {
                    long Idx = 0;
                    foreach (string FileLine in File.ReadAllLines(SrcFileName, Encoding.Default))
                    {
                        string OutLine = FileLine;

                        clsLineResult MatchingLineResult = FileResultInfo.MatchingLineResult(Idx+1);
                        if (MatchingLineResult != null)
                        {
                            //--- Line content ------------------------------------------------------
                            string EncodedText;
                            int LastIdx = 0;
                            OutLine = "";
                            foreach (clsResultInfoInLine ResultInfoLine in MatchingLineResult.ResultInfos)
                            {
                                //--- Pre text ------------------------------------------------
                                int StartIdx = ResultInfoLine.StartIdx;
                                EncodedText = MatchingLineResult.Line.Substring(LastIdx, StartIdx - LastIdx);
                                OutLine += EncodedText;
                                LastIdx = StartIdx;

                                //--- Token text ------------------------------------------------
                                OutLine += InGrepProperties.ReplaceString;

                                LastIdx += ResultInfoLine.Length;
                            }

                            // --- Post text ------------------------------------------------
                            if (LastIdx <= MatchingLineResult.Line.Length - 1)
                            {
                                EncodedText = MatchingLineResult.Line.Substring(LastIdx, MatchingLineResult.Line.Length - LastIdx);
                                OutLine += EncodedText;
                            }
                        }

                        Idx++;

                        LineWriter.WriteLine (OutLine);
                    }
                }
                catch (Exception Ex)
                {
                    clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                    ErrCapture.ShowExeption();
                }
                finally
                {
                    LineWriter.Flush();   // Puffer => Disk
                    LineWriter.Close();

                    OutFile.Close();
                }

                // Backup file to delete ?
                // *.Bak file created ?
                if (GrepProperties.bReplaceOriginalFile)
                {
                    // *.Bak not needed ?
                    if (!GrepProperties.bCreateBackup)
                    {
                        //  Delete saved one 
                        File.Delete(BakFileName);
                    }
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }
    }
}
