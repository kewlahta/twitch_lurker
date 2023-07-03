using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// 6-3 @ 0737: 2 months, 10 days, 11 hours
//6-5 @ 2032: 2 months, 10 days, 18 hours
// 6-12 @ 0715 2 months, 11 days, 13 hours

namespace LumiLurker
{
    public partial class Form1 : Form
    {
        public int sleepTimeMillis = 1000 * 60 * 5; // last number being minutes to sleep.
        public int secondsToRefresh = 0;

        public Form1()
        {
            InitializeComponent();

            backgroundWorker1.RunWorkerAsync();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                foreach (System.Diagnostics.Process pr in System.Diagnostics.Process.GetProcesses())
                {
                    if (pr.ProcessName == "chrome" || pr.ProcessName == "firefox")
                    {
                        "a.".ToArray();
                        //pr.Close();
                        pr.Kill();
                    }
                }

                System.Diagnostics.Process.Start("https://player.twitch.tv/?volume=0.0000001&channel=lumi");
                secondsToRefresh = sleepTimeMillis / 1000;
                System.Threading.Thread.Sleep(sleepTimeMillis);
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            lblRefreshTime.Text = secondsToRefresh.ToString();
            secondsToRefresh -= 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.CancelAsync();

            backgroundWorker1 = null;

            backgroundWorker1 = new BackgroundWorker();
            System.GC.Collect();

            backgroundWorker1.DoWork -= backgroundWorker1_DoWork;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;

            backgroundWorker1.RunWorkerAsync();
        }
    }
}
