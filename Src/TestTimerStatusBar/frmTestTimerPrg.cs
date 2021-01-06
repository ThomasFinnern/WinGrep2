using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestTimerStatusBar
{
    public partial class frmTestTimerPrg : Form
    {
        public frmTestTimerPrg()
        {
            InitializeComponent();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            timer1.Tick += new EventHandler(TimerTick);
            timer1.Enabled = true;
        }
        // http://www.csharphelp.com/2006/05/simply-use-progressbar-statusbar-timer-in-vs-net/

        public void TimerTick (object sender, EventArgs eArgs)
        {
            if (sender == timer1)
            {
                lblTimer.Text = GetTime ();
            }
        }

        public string GetTime()
        {
        string TimeInString="";
        int hour=DateTime.Now.Hour;
        int min=DateTime.Now.Minute;
        int sec=DateTime.Now.Second;

        TimeInString=(hour < 10)?"0" + hour.ToString() :hour.ToString();
        TimeInString+=":" + ((min<10)?"0" + min.ToString() :min.ToString());
        TimeInString+=":" + ((sec<10)?"0" + sec.ToString() :sec.ToString());
        return TimeInString;
        }





    }
}