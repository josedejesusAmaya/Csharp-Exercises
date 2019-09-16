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
        public static Jugador p1 = new Jugador(25, 245);
        public static Jugador p2 = new Jugador(750, 245);
        public static Pelota pelota = new Pelota(100, 245);
        public static int ptsJ1 = 0;
        public static int ptsJ2 = 0;
        public static bool conectado = false;
    }

    public partial class Form1 : Form
    {
        //Timer timer; //timer para la animacion
        bool pressDown2 = false, pressUp2 = false; //bandera para el movimiento del jugador dos
        //Jugador p1 = new Jugador(25, 245); //objeto del jugador uno con las coordenadas como parametro
        //Jugador p1 = variables.p1;
        //Jugador p2 = new Jugador(750, 245); //objeto del jugador dos con las coordenadas como parametro
        //Jugador p2 = variables.p2;
        //Pelota pelota = new Pelota(100, 245); //objeto de la pelota
        //Pelota pelota = variables.pelota;
        //int ptsJ1 = 0; //contador de puntos jugador uno
        //int ptsJ2 = 0; //contador de puntos jugador dos

        bool endGame = false;

        Thread timerThread;
        Thread comunicacionThread;

        public Form1()
        {
            InitializeComponent();
            timerThread = new Thread(Timer_Tick);
            comunicacionThread = new Thread(com);
            timerThread.Start();
            comunicacionThread.Start();
        } 

        private void com()
        {
            Cliente cliente = new Cliente();
            cliente.conectar();
        }

        private void Timer_Tick()
        {
            while (endGame == false)
            {
                if (variables.conectado)
                {
                    Thread.Sleep(1000/60);
                    
                    if (pressDown2)
                        if (variables.p2.r.Y + 60 <= this.ClientSize.Height)

                            variables.p2.mv_abajo(); //metodo para el movimiento hacia abajo del jugador 2

                    if (pressUp2)
                        if (variables.p2.r.Y >= 0)
                            variables.p2.mv_arriba(); //metodo para el movimiento hacia arriba del jugador 1

                    if (variables.ptsJ1 > 3 || variables.ptsJ2 > 3) //el primero que marque mas de tres pts gana
                        endGame = true;

                    actualizaLabel1();
                    actualizaLabel2();

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
            else if (!variables.conectado)
            {
                //Console.WriteLine("CO N E C T A N D O . . .");
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            pressDown2 = false;
            pressUp2 = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) //evento para las teclas del jugador uno
        {
            if (e.KeyValue == 40) //down2
                pressDown2 = true;
            if (e.KeyValue == 38) //up2
                pressUp2 = true;
        }
    }
}
