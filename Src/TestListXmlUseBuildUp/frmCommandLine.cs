using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using DebugLog;
using ErrorCapture;
using MainGlobal;
using LibStdFileDateTime;
//using NcsErosionPostProzessor;

namespace CmdLine2005
{
    public partial class frmCommandLine : Form
    {
        // ToDo: Remove and write into a demo exe
        // Keep track what form interrupt is started when 
        List<string> EventOrder = new List<string>();

        public clsCommandLine AppCommands = null;
        public bool bDoExecuteAppCommands = false;
        
        public frmCommandLine()
        {
            InitializeComponent();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCommandLine_Load(object sender, EventArgs e)
        {
            EventOrder.Add("Load");
        }

        private void frmCommandLine_Shown(object sender, EventArgs e)
        {
            try
            {
                EventOrder.Add("Shown");
                if (bDoExecuteAppCommands)
                    DoExecuteAppCommands();

                Global.oDebugLog.WriteUserInfoLine("\r\n\r\nCommandLine: Commands done");
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        public void AppReadAndParseCmdLine()
        {
            try
            {
                AppCommands = new clsCommandLine();
                // AppCommands.CommandLineInfo = this;
                Global.oDebugLog.CommandLineInfo = this;

                AppCommands.ParseProgrammCmdLine();
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        public void AppCmdLineDoCommands()
        {
            try
            {
                Global.oDebugLog.CommandLineInfo = this;
                AppCommands.CmdLineDoCommands();
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        /// <summary>
        /// Executes all found commands on application command line
        /// ReadAndParseAppCmdLine has to be done before
        /// </summary>
        private void DoExecuteAppCommands()
        {
            try
            {
                Global.oDebugLog.CommandLineInfo = this;
                Global.oDebugLog.DPrint("\r\n" + "CommandlineParameter: " + AppCommands.DebText("   "));
                if (AppCommands != null)
                {
                    // Any character found on command line ?
                    if (AppCommands.Args.Count > 0 || AppCommands.Opts.Count > 0)
                    {
                        // Show Form
                        Application.DoEvents();

                        // AppCommands.CommandLineInfo = this;
                        AppCommands.CmdLineDoCommands();

                        Global.bNoAutoExit = AppCommands.InOption("NoAutoExit").bValue | AppCommands.InOption("?").bIsOptionEnabled | AppCommands.InOption("h").bIsOptionEnabled;
                        Global.bCloseAfterCommandsDone = AppCommands.InOption("CloseAfterCommandsDone").bValue;
                        Global.bDoCheckClasses = AppCommands.InOption("CheckClasses").bValue;

                        if (!Global.bNoAutoExit)
                            this.Close();
                    }
                }
                else
                {
                    string OutTxt = "Error: No commanline read and parsed: ";
                    System.Windows.Forms.MessageBox.Show(OutTxt);
                }

                //            Global.oDebugLog.DPrint("ActiveLangIds: " + Global.oActLangNameSet.Text("   "));

                //---------------------------------------------------------------------------------
                // Show input
                //---------------------------------------------------------------------------------

                // MainForm.Show vbModeless // vbModal

            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        private void frmCommandLine_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.oDebugLog.CommandLineInfo = null;
        }


        public void SetTitle(string NewTitle)
        {
            try
            {
                lblTitle.Text = NewTitle;

                string OutTxt = "--------------------------------------------------" + "\r\n";
                OutTxt += NewTitle + "\r\n" + OutTxt;
                AddInfo(OutTxt);
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        public void AddInfo(string NewInfo)
        {
            try
            {
                InfoBox.Text += NewInfo;
                InfoBox.SelectionStart = InfoBox.TextLength;
                InfoBox.SelectionLength = 1;
                InfoBox.ScrollToCaret();

                Application.DoEvents();
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

    } // form
}


