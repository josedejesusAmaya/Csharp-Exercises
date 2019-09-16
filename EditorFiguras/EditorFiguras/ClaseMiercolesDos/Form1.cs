using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ClaseMiercolesDos
{
    public partial class Form1 : Form
    {
        private int[] relleno; //ARGB del relleno
        private int[] contorno; //ARGB del contorno de la figura
        private int x;
        private int y;
        private int type;
        private int ancho = 30;
        private int alto = 10;
        private bool seleccionar = false;
        private int seleccionado = -1;
        private bool drag = false;
        List<Figura> figuras = new List<Figura>();
        public Form1()
        {
            relleno = new int[4];
            contorno = new int[4];
            InitializeComponent();
            //figuras
            comboBox1.Items.Add("Rectangulo"); //0
            comboBox1.Items.Add("Elipse"); //1
            comboBox1.Items.Add("Cuadrado"); //2
            comboBox1.Items.Add("Circulo"); //3
            comboBox1.Items.Add("Linea"); //4
            //acciones
            comboBox2.Items.Add("Insertar"); //0
            comboBox2.Items.Add("Arrastrar"); //1 
            comboBox2.Items.Add("Seleccionar"); //2
            comboBox2.Items.Add("Pintar"); //3 actulizar
            comboBox2.Items.Add("Eliminar"); //4
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //aqui se manda a llamar el dibujado (solamente)
            Pen pen;
            SolidBrush brush;
            Graphics graphic = null;
            for (int i = 0; i<figuras.Count; i++)
            {
                //rectangulo, cuadrado, elipse, circulo, linea.
                if (figuras[i].gT() == 0 || figuras[i].gT() == 1 || figuras[i].gT() == 2 || figuras[i].gT() == 3 || figuras[i].gT() == 4) 
                {
                    int a = figuras[i].rA();
                    int r = figuras[i].rR();
                    int g = figuras[i].rG();
                    int b = figuras[i].rB();
                    brush = new SolidBrush(Color.FromArgb(a, r, g, b));
                    a = figuras[i].cA();
                    r = figuras[i].cR();
                    g = figuras[i].cG();
                    b = figuras[i].cB();
                    pen = new Pen(Color.FromArgb(a, r, g, b), 5);
                    graphic = e.Graphics;
                    if (figuras[i].gT() == 0) //rectangulo
                    {
                        graphic.DrawRectangle(pen, figuras[i].gX(), figuras[i].gY(), ancho, alto);
                        graphic.FillRectangle(brush, figuras[i].gX(), figuras[i].gY(), ancho, alto);
                    }
                    if (figuras[i].gT() == 1) //elipse
                    {
                        graphic.DrawEllipse(pen, new Rectangle(figuras[i].gX(), figuras[i].gY(), ancho, alto));
                        graphic.FillEllipse(brush, new Rectangle(figuras[i].gX(), figuras[i].gY(), ancho, alto));
                    }
                    if (figuras[i].gT() == 2) //cuadrado
                    {
                        graphic.DrawRectangle(pen, figuras[i].gX(), figuras[i].gY(), alto, alto);
                        graphic.FillRectangle(brush, figuras[i].gX(), figuras[i].gY(), alto, alto);
                    }
                    if (figuras[i].gT() == 3) //circulo
                    {
                        graphic.DrawEllipse(pen, new Rectangle(figuras[i].gX(), figuras[i].gY(), alto, alto));
                        graphic.FillEllipse(brush, new Rectangle(figuras[i].gX(), figuras[i].gY(), alto, alto));
                    }
                    if (figuras[i].gT() == 4) //linea
                    {
                        int pX = figuras[i].gX() + 15;
                        int pY = figuras[i].gY() - 15;
                        graphic.DrawLine(pen, figuras[i].gX(), figuras[i].gY(), pX, pY);
                    }
                }
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            Figura figura = new Figura();
            if (type == 4) //linea 
            {
                figura.setCoord(x, y, type);
                figura.setContorno(contorno);
                figuras.Add(figura);
            }
            if (type == 0 || type == 1 || type == 2 || type == 3) //rectangulo, cuadrado, elipse, circulo
            {
                figura.setCoord(x, y, type);
                figura.setRelleno(relleno);
                figura.setContorno(contorno);
                figuras.Add(figura);
            }
            Invalidate();
            comboBox2.SelectedIndex = -1;
        }
        
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //aqui selecciono el tipo de figura
            type = comboBox1.SelectedIndex;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //aqui van las acciones a realizar
            if (comboBox2.SelectedIndex == 0) //si la accion es insertar entonces obtiene los valores para el relleno y contorno
            {
                tomarColores();
            }

            //si la accion es arrastrar
            if (comboBox2.SelectedIndex == 1)
            {
                if (seleccionado != -1)
                    drag = true;
                else
                    MessageBox.Show("Seleccione una figura primero");

            }

            //si la accion es seleccionar obtiene el indice de la figura que se selecciono 
            if (comboBox2.SelectedIndex == 2)
            {
                seleccionar = true;
            }

            //si la accion es actualizar vuleve a tomar los valores de los colores para la
            if (comboBox2.SelectedIndex == 3) 
            {
                if (seleccionado == -1)
                    MessageBox.Show("Primero selecciona una figura");
                else
                {
                    int z = seleccionado;
                    tomarColores();
                    figuras[z].setRelleno(relleno);
                    figuras[z].setContorno(contorno);
                    Invalidate();
                }
            }

            //si la accion es eliminar
            if (comboBox2.SelectedIndex == 4)
            {
                if (seleccionado == -1)
                    MessageBox.Show("Primero selecciona una figura");
                else
                {
                    figuras.RemoveAt(seleccionado);
                    Invalidate();
                }
            }
        }

        public void tomarColores()
        {
            relleno[0] = Decimal.ToInt32(alpha.Value);
            relleno[1] = Decimal.ToInt32(red.Value);
            relleno[2] = Decimal.ToInt32(green.Value);
            relleno[3] = Decimal.ToInt32(blue.Value);
            //obtiene tambien los valores del contorno.
            contorno[0] = Decimal.ToInt32(alpha2.Value);
            contorno[1] = Decimal.ToInt32(red2.Value);
            contorno[2] = Decimal.ToInt32(green2.Value);
            contorno[3] = Decimal.ToInt32(blue2.Value);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //aqui necesito saber si tome una figura
            if (seleccionar && !drag)
            {
                for(int i = 0; i < figuras.Count; i++)
                {
                    if (figuras[i].gT() == 0 || figuras[i].gT() == 1) //rectangulo o elipse
                    {
                        //dice si el clic enta dentro o fuera
                        if (e.X >= figuras[i].gX() && e.X <= ancho+figuras[i].gX() && e.Y >= figuras[i].gY() && e.Y <= alto+figuras[i].gY())
                            seleccionado = i;
                    }
                    if (figuras[i].gT() == 2 || figuras[i].gT() == 3) //cuadrado o circulo
                    {
                        if (e.X >= figuras[i].gX() && e.X <= alto+figuras[i].gX() && e.Y >= figuras[i].gY() && e.Y <= alto+figuras[i].gY())
                            seleccionado = i;
                    }
                    if (figuras[i].gT() == 4) //linea
                    {
                        int pX = figuras[i].gX() + 15;
                        int pY = figuras[i].gY() - 15;
                        if (e.X >= figuras[i].gX() && e.X <= pX && e.Y <= figuras[i].gY() && e.Y >= pY)
                            seleccionado = i;
                    }
                }
                if (seleccionado == -1)
                    MessageBox.Show("El elemento no existe");
                else
                    MessageBox.Show("figura seleccionada");
            }
            seleccionar = false;
            comboBox2.SelectedIndex = -1;
            /*if (e.X >= x && e.X <= ancho && e.Y >= y && e.Y <= alto) //dice si el clic enta dentro o fuera
                drag = true;*/
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag == false) return;
            int z = seleccionado;
            figuras[z].setX(e.X);
            figuras[z].setY(e.Y);
            Invalidate();   
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
    }
}
