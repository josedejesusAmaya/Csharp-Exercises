using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace WindowsFormsApp1
{
    static class variables
    {
        public static Jugador p1 = new Jugador(25, 145);
        public static Jugador p2 = new Jugador(750, 245);
        public static Pelota pelota = new Pelota(100, 145);
        public static bool conectado = false;
        public static int ptsJ1 = 0;
        public static int ptsJ2 = 0;
    }

    public partial class Form1 : Form
    {
        //Timer timer; //timer para la animacion
        bool pressDown1 = false, pressUp1 = false; //bandera para el movimiento del jugador uno
        //Jugador p1 = new Jugador(25, 245); //objeto del jugador uno con las coordenadas como parametro
        //Jugador p2 = new Jugador(750, 245); //objeto del jugador dos con las coordenadas como parametro
        //Pelota pelota = new Pelota(100, 245); //objeto de la pelota
        //int ptsJ1 = 0; //contador de puntos jugador uno
        //int ptsJ2 = 0; //contador de puntos jugador dos
        Thread timerThread;
        Thread comunicacionThread;

        bool endGame = false;

        public Form1()
        {
            InitializeComponent();
            timerThread = new Thread(Timer_Tick);
            comunicacionThread = new Thread(com);
            timerThread.Start();
            comunicacionThread.Start();
        }

        private static void com()
        {
            //aqui se hace el intercambio de informacion
            Servidor servidor = new Servidor();
            servidor.conectar();
        }

        private void Timer_Tick()
        {
            while (endGame == false)
            {
                if (variables.conectado)
                {
                    Thread.Sleep(1000 / 60);

                    if (pressDown1)
                        if (variables.p1.r.Y + 60 <= this.ClientSize.Height)
                            variables.p1.mv_abajo(); //metodo para el movimiento hacia abajo del jugador 1

                    if (pressUp1)
                        if (variables.p1.r.Y >= 0)
                            variables.p1.mv_arriba(); //metodo para el movimiento hacia arriba del jugador 1
                                            
                    Random r = new Random();
                    variables.pelota.e.X += variables.pelota.dirx * variables.pelota.vel; //movimiento de la pelota con la direccion y velocidad como factores
                    variables.pelota.e.Y += variables.pelota.diry * variables.pelota.vel;
                    if (variables.pelota.e.X <= variables.p1.r.X + 7 
                        && (variables.pelota.e.Y + 12.5 >= variables.p1.r.Y 
                        && variables.pelota.e.Y + 12.5 <= variables.p1.r.Y + 60)) //condiciones para la colosion de la raqueta uno y la pelota
                    {
                        int p = r.Next(0, 4);
                        if (p == 0)
                            variables.pelota.diry = -variables.pelota.diry;
                        variables.pelota.dirx = -variables.pelota.dirx;
                        variables.pelota.e.X = variables.p1.r.X + 7;
                        //MessageBox.Show("tocando p1");
                    }
                    if (variables.pelota.e.X + 25 >= variables.p2.r.X 
                        && (variables.pelota.e.Y + 12.5 >= variables.p2.r.Y 
                        && variables.pelota.e.Y + 12.5 <= variables.p2.r.Y + 60)) //condiciones para la colision de la raqueta dos y la pelota
                    {
                        int p = r.Next(0, 4);
                        if (p == 0)
                            variables.pelota.diry = -variables.pelota.diry;
                        variables.pelota.dirx = -variables.pelota.dirx;
                        variables.pelota.e.X = variables.p2.r.X - 25;
                        //MessageBox.Show("tocando p2");  
                    }

                    if (variables.pelota.e.Y <= 0)
                    {
                        int p = r.Next(0, 4);
                        if (p == 0)
                            variables.pelota.dirx = -variables.pelota.dirx;
                        variables.pelota.diry = -variables.pelota.diry;
                        variables.pelota.e.Y = 0;
                    }

                    if (variables.pelota.e.Y + 25 >= this.ClientSize.Height)
                    {
                        int p = r.Next(0, 4);
                        if (p == 1)
                            variables.pelota.dirx = -variables.pelota.dirx;
                        variables.pelota.diry = -variables.pelota.diry;
                        variables.pelota.e.Y = this.ClientSize.Height - 25;
                    }

                    if (variables.pelota.e.X + variables.pelota.e.Width >= this.ClientSize.Width)
                    {
                        int p = r.Next(0, 4);
                        if (p == 0)
                            variables.pelota.diry = -variables.pelota.diry;
                        variables.pelota.dirx = -variables.pelota.dirx;
                        variables.ptsJ1++;
                        actualizaLabel1();
                        variables.pelota.e.X = this.ClientSize.Width - variables.pelota.e.Width;
                    }

                    if (variables.pelota.e.X <= 0) //condicion para marcar punto del jugador dos
                    {
                        int p = r.Next(0, 4);
                        if (p == 0)
                            variables.pelota.diry = -variables.pelota.diry;
                        variables.pelota.dirx = -variables.pelota.dirx;
                        variables.ptsJ2++;
                        actualizaLabel2();
                        variables.pelota.e.X = 0;
                    }
                    if (variables.ptsJ1 > 3 || variables.ptsJ2 > 3) //el primero que marque mas de tres pts gana
                        endGame = true;

                    Invalidate();

                    //this.Close();
                    gameOver();
                }
                else
                {
                    Invalidate();
                }
            }
        }

        private void actualizaLabel1()
        {
            MethodInvoker inv = delegate
            {
                this.pts1.Text = variables.ptsJ1.ToString();
            };

           this.Invoke(inv);
        }

        private void actualizaLabel2()
        {
            MethodInvoker inv2 = delegate
            {
                this.pts2.Text = variables.ptsJ2.ToString();
            };

            this.Invoke(inv2);
        }

        private void gameOver()
        {
            if (endGame)
            {
                MethodInvoker inv3 = delegate
                {
                    this.Close();
                };

                this.Invoke(inv3);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e) //metodo para pintar el escenario
        {
            Pen pe = new Pen(Color.White);
            Brush bru = new SolidBrush(Color.White);
            Graphics gra = e.Graphics;
            Rectangle linea_media = new Rectangle(398, 0, 4, 500);
            if (variables.conectado)
            {
                gra.FillRectangle(bru, linea_media); //pinta linea divisoria
                gra.FillRectangle(bru, variables.p1.r); //pinta jugador uno
                gra.FillRectangle(bru, variables.p2.r); //pinta jugador dos
                gra.FillEllipse(bru, variables.pelota.e); //pinta pelota
            }
            else
            {
                //Console.WriteLine("C O N E C T A M D O . . . ");
            }
            
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            pressDown1 = false;
            pressUp1 = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) //evento para las teclas del jugador uno
        {
            if (e.KeyValue == 40) //down
                pressDown1 = true;
            if (e.KeyValue == 38) //up
                pressUp1 = true;
        }
    }
}
