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
    public partial class Forma1 : Form
    {
        Bitmap portadaLogo = (Bitmap)Image.FromFile("logo.png");
        Juego juego;
        Instrucciones instrucciones;
        InstruccionesDos instruccionesDos;
        string nombreArchivo1 = "nivelUno.txt", nombreArchivo2 = "nivelDos.txt", nombreArchivo3 = "nivelTres.txt";
        int contNiveles = 1;

        public Forma1()
        {
            InitializeComponent();
        }

        private void boton_jugar_Click(object sender, EventArgs e)
        {
            if (contNiveles == 1)
            {
                juego = new Juego(nombreArchivo1);
                juego.Show();
                juego.Activate();
                contNiveles++;
            }
            else
            {
                if (contNiveles == 2)
                {
                    juego = new Juego(nombreArchivo2);
                    juego.Show();
                    juego.Activate();
                    contNiveles++;
                }
                else
                {
                    if (contNiveles == 3)
                    {
                        juego = new Juego(nombreArchivo3);
                        juego.Show();
                        juego.Activate();
                        contNiveles++;
                    }
                    else
                    {
                        if (contNiveles == 4)
                            this.Close();
                    }        
                }
            }
        }

        private void boton_instruc_Click(object sender, EventArgs e)
        {
            instrucciones = new Instrucciones();
            instruccionesDos = new InstruccionesDos();
            //instrucciones.Show();
            instruccionesDos.Show();
        }

        private void boton_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Forma1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g;
            g = e.Graphics;
            g.DrawImage(portadaLogo, 50, 50);
        }
    }
}
