using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media; 

namespace ReproductorMp3
{
    public partial class Form1 : Form
    {
        private SoundPlayer soundPlayer;
        public Form1()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer(@"C:\Users\Owner\Desktop\ZHU_-_Cold_Blooded_Audio.wav");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            soundPlayer.Play();
        }
    }
}
