using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using MainGlobal;
using ErrorCapture;
using CmdLine2005;

namespace NetGrep
{
    public partial class frmTestNetGrepTokenPrg : Form
    {
        public frmTestNetGrepTokenPrg()
        {
            InitializeComponent();

            Global.InitGlobalObjects();
            ExecuteAppCommandsFromCmdLine();
        }


        public void ExecuteAppCommandsFromCmdLine()
        {
            // ToDo: show debug inside form Or at least the actual comnmand
            frmCommandLine CheckCommands = new frmCommandLine();

            CheckCommands.AppReadAndParseCmdLine();
            if (CheckCommands.AppCommands.Args.Count > 0 || CheckCommands.AppCommands.Opts.Count > 0)
            {
                Application.DoEvents();

                CheckCommands.bDoExecuteAppCommands = true;
                //CheckCommands.Show(this);
                CheckCommands.ShowDialog(this);
            }
        }

        private void frmTestNetGrepTokenPrg_Load(object sender, EventArgs e)
        {
            if (Global.bCloseAfterCommandsDone)
                this.Close();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdTestAll_Click(object sender, EventArgs e)
        {
            string OutTxt;
            clsTestAllNetGrepToken.TestAll(out OutTxt);
            textBoxResult.Text = OutTxt;
        }
    }
}