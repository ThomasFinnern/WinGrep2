using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NetGrep;

namespace TestListXmlUseBuildUp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdTestClass_Click(object sender, EventArgs e)
        {
            string OutTxt = "";
            bool bErrFound;

            textBoxResult.Text = "";
            Application.DoEvents();

            // --- ----------------------------------------------------------------------------------------------------
            textBoxResult.Text += "TestClass: clsTestClsConfigSpezialBase" + "\r\n";
            OutTxt = "";
            bErrFound = clsTestClsConfigSpezialBase.TestClass(ref OutTxt);
            if (bErrFound)
            {
                OutTxt += "\r\n" + " !!! Error found !!! in clsTestClsConfigSpezialBase " + "\r\n" + "\r\n";
            }
            else
            {
                OutTxt += "-> Class Ok" + "\r\n" ;
            }
            textBoxResult.Text += OutTxt;
            Application.DoEvents();

            // --- ----------------------------------------------------------------------------------------------------
            textBoxResult.Text += "TestClass: clsTestclsGrepTokenListMerge" + "\r\n";
            OutTxt = "";
            bErrFound = clsTestclsGrepTokenListMerge.TestClass(ref OutTxt);
            if (bErrFound)
            {
                OutTxt += "\r\n" + " !!! Error found !!! in clsTestclsGrepTokenListMerge " + "\r\n" + "\r\n";
            }
            else
            {
                OutTxt += "-> Class Ok" + "\r\n";
            }
            textBoxResult.Text += OutTxt;
            Application.DoEvents();

            //// --- ----------------------------------------------------------------------------------------------------
            //textBoxResult.Text += "TestClass: clsTestClsGrepTokenListBase" + "\r\n";
            //OutTxt = "";
            //bErrFound = clsTestClsGrepTokenListBase.TestClass(ref OutTxt);
            //if (bErrFound)
            //{
            //    OutTxt += "\r\n" + " !!! Error found !!! in clsTestClsGrepTokenListBase " + "\r\n" + "\r\n";
            //}
            //else
            //{
            //    OutTxt += "-> Class Ok" + "\r\n";
            //}
            //textBoxResult.Text += OutTxt;
            //Application.DoEvents();

            OutTxt = "Tests done\r\n";
            textBoxResult.Text += OutTxt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmdTestClass_Click(sender, e);
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

