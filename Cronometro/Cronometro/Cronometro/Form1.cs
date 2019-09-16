using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Diagnostics;

namespace Cronometro
{
    public partial class Form1 : Form
    {
        private int milseg = 0;
        private int seg = 0;
        private int min = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
            timer.Start();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            min = seg = milseg = 0;
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            min = seg = milseg = 0;
            timer.Enabled = true;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            reloj.Visible = true;
            if (milseg == 61)
            {
                seg++;
                milseg = 0;
            }
            if (seg == 61)
            {
                min++;
                seg = 0;
            }
            milseg++;    
            string milsegS = String.Format("{0:00}", milseg);
            string segS = String.Format("{0:00}", seg);
            string minS = String.Format("{0:00}", min);
            reloj.Text = minS + " : " + segS + " : " + milsegS;
        }
    }
}
