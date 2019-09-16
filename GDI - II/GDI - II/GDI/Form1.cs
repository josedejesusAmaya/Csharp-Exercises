using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GDI
{
    public partial class Form1 : Form
    {
        List<Nodo> nodos;
        private bool insertaNodo = false;
        private bool activaFlecha = false;
        private bool activaArista = false;

        const int RADIO = 20;

        Nodo selOrig;
        Nodo selNodo;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            nodos = new List<Nodo>();
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!insertaNodo) return;

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                nodos.Add(new Nodo(e.X, e.Y, RADIO));
                Refresh();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Nodo item in nodos)
            {
                item.DibujaArista(e.Graphics);
            }

            foreach (Nodo item in nodos)
            {
                item.DibujaNodo(e.Graphics);
            }

            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //detecta
            Nodo n = null;
            foreach (Nodo item in nodos)
            {
                if (item.Adentro(e.Location))
                {
                    n = item;
                    break;
                }
            }

            if (activaFlecha)
            {
                // conecta dos nodos
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    if (selOrig == null)
                    {
                        selOrig = n;
                    }
                    else
                    {
                        if (n != null) selOrig.ConectarA(n);
                        selOrig = null;
                        Refresh();
                    }
                }
            }
            
            // inicia movimiento del nodo
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                selNodo = n;        
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (selNodo != null)
            {
                // mueve nodo
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    selNodo.Posicion(e.Location);
                    Refresh();
                }
            }
        }

        private void nodoB_Click(object sender, EventArgs e)
        {
            insertaNodo = true;
            activaFlecha = false;
        }

        private void flecha_Click(object sender, EventArgs e)
        {
            activaFlecha = true;
            insertaNodo = false;
        }

        private void arista_Click(object sender, EventArgs e)
        {
            activaArista = true;
            insertaNodo = false;
            activaFlecha = false;
        }

        private void deleteB_Click(object sender, EventArgs e)
        {
            //elimina el nodos seleccionado
            if (selNodo != null)
            {
                nodos.Remove(selNodo);
                foreach (Nodo item in nodos)
                {
                    item.Desconectar(selNodo);
                }
                Refresh();
                selNodo = null;
            }
        }
    }
}
