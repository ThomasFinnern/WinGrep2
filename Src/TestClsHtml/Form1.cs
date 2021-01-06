using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestClsHtml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdTestClass_Click(object sender, EventArgs e)
        {
            string OutTxt = "";

            textBoxResult.Text = "";
            Application.DoEvents();

            clsHtmlElementTest HtmlElementTest = new clsHtmlElementTest ();

            for (int Idx = 0; Idx <= clsHtmlElementTest.MaxTestNbr; Idx++)
            {
                textBoxResult.Text += ">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>" + "\r\n";
                textBoxResult.Text += "Test Html (" + Idx + ")" + "\r\n";

                bool ErrFound = HtmlElementTest.Test4Error(Idx);
                if (ErrFound)
                {
                    textBoxResult.Text += "Error found: " + "\r\n";
                    textBoxResult.Text += "\tExpected: '" + HtmlElementTest.ExpectetText + "'\r\n";
                    textBoxResult.Text += "\tResulting: '" + HtmlElementTest.ResultingText + "'\r\n";
                }
                else
                {
                    textBoxResult.Text += "Accepted: " + HtmlElementTest.ResultingText + "\r\n";
                }
            }

            // --- ----------------------------------------------------------------------------------------------------
            textBoxResult.Text += ">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>" + "\r\n\r\n";
            OutTxt = "\r\nTests done\r\n";
            textBoxResult.Text += OutTxt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmdTestClass_Click(sender, e);
        }
    }
}