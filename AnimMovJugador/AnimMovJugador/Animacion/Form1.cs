using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animacion
{
    public partial class Form1 : Form
    {
        Timer timer;
        Animation anim;
        private int x = 100, y = 100, p = 5;
        private bool pressDown = false, pressRight = false, pressLefth = false, pressUp = false;
  
        public Form1()
        {
            InitializeComponent();
            anim = new Animation();
            anim.x = x;
            anim.y = y;
            timer = new Timer();
            timer.Interval = 1000 / 60;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            
            if (pressDown)
            {
                anim.Update();
                y += p;
            } 
              
            if (pressRight)
            {
                anim.Update();
                x += p;
            }

            if (pressLefth)
            {
                anim.Update();
                x -= p;
            }

            if (pressUp)
            {
                anim.Update();
                y -= p;
            }
            Invalidate();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            pressDown = false;
            pressRight = false;
            pressLefth = false;
            pressUp = false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g;
            g = null;
            g = e.Graphics;
            anim.y = y;
            anim.x = x;
            g.DrawImage(anim.getCurFrame(), anim.x, anim.y);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 40) // down
            {
                pressDown = true;
                anim.selected = 1; 
            }

            if (e.KeyValue == 39) // right
            {
                pressRight = true;
                anim.selected = 2;
            }

            if (e.KeyValue == 37) //lefth
            {
                pressLefth = true;
                anim.selected = 3;
            }

            if (e.KeyValue == 38) //up
            {
                pressUp = true;
                anim.selected = 4;
            }
        }
    }
}
