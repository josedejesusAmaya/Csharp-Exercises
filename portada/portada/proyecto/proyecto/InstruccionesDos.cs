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
    public partial class InstruccionesDos : Form
    {
        Bitmap instruccionesLogo = (Bitmap)Image.FromFile("instruccionesDos.png");
        public InstruccionesDos()
        {
            InitializeComponent();
        }

        private void InstruccionesDos_Paint(object sender, PaintEventArgs e)
        {
            Graphics g;
            g = e.Graphics;
            g.DrawImage(instruccionesLogo, 50, 50);
        }
    }
}
