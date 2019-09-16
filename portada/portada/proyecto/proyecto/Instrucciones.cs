using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto
{
    public partial class Instrucciones : Form
    {
        Bitmap instruccionesLogo = (Bitmap)Image.FromFile("instruccionesUno.png");
        public Instrucciones()
        {
            InitializeComponent();
        }

        private void Instrucciones_Paint(object sender, PaintEventArgs e)
        {
            Graphics g;
            g = e.Graphics;
            g.DrawImage(instruccionesLogo, 50, 50);
        }
    }
}
