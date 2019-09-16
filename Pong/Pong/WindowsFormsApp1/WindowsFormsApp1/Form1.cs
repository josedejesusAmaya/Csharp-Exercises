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
    public partial class Form1 : Form
    {
        //Timer timer; //timer para la animacion
        bool pressDown1 = false, pressUp1 = false; //bandera para el movimiento del jugador uno
        static Jugador p1 = new Jugador(25, 300); //objeto del jugador uno con las coordenadas como parametro
        static Jugador p2 = new Jugador(750, 245); //objeto del jugador dos con las coordenadas como parametro
        static Pelota pelota = new Pelota(100, 245); //objeto de la pelota
        static int ptsJ1 = 0; //contador de puntos jugador uno
        static int ptsJ2 = 0; //contador de puntos jugador dos
        Thread timerThread;
        Thread comunicacionThread;
        bool endGame = false;


        private static byte[] _buffer = new byte[1024];
        private static List<Socket> _clientsSockets = new List<Socket>();
        private static Socket _serverSocket = new Socket
            (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        static bool conectado = false;

        public Form1()
        {
            InitializeComponent();
            timerThread = new Thread(Timer_Tick);
            comunicacionThread = new Thread(comm);
            timerThread.Start();
            comunicacionThread.Start();
        }


        private void comm()
        {
            //aqui se hace el intercambio de informacion   
            //while (true)
            SetupServer();
        }

        private void Timer_Tick()
        {
            while(!conectado)
            {
                Console.WriteLine("C o n e c t a n d o . . .");
            }
            while (endGame == false)
            {
                for (int i = 0; i < 220000000/60; i++) //un segundo = 220000000
                {
                    
                }

                if (pressDown1)
                    if (p1.r.Y + 60 <= this.ClientSize.Height)
                        p1.mv_abajo(); //metodo para el movimiento hacia abajo del jugador 1

                if (pressUp1)
                    if (p1.r.Y >= 0)
                        p1.mv_arriba(); //metodo para el movimiento hacia arriba del jugador 1
                /*
                if (pressDown2)
                    if (p2.r.Y + 60 <= this.ClientSize.Height)
                        p2.mv_abajo(); //metodo para el movimiento hacia abajo del jugador 2

                if (pressUp2)
                    if (p2.r.Y >= 0)
                        p2.mv_arriba(); //metodo para el movimiento hacia arriba del jugador 1
                */                       
                Random r = new Random();
                pelota.e.X += pelota.dirx * pelota.vel; //movimiento de la pelota con la direccion y velocidad como factores
                pelota.e.Y += pelota.diry * pelota.vel;
                if (pelota.e.X <= p1.r.X + 7 && (pelota.e.Y + 12.5 >= p1.r.Y && pelota.e.Y + 12.5 <= p1.r.Y + 60)) //condiciones para la colosion de la raqueta uno y la pelota
                {
                    int p = r.Next(0, 4);
                    if (p == 0)
                        pelota.diry = -pelota.diry;
                    pelota.dirx = -pelota.dirx;
                    pelota.e.X = p1.r.X + 7;
                    //MessageBox.Show("tocando p1");
                }
                if (pelota.e.X + 25 >= p2.r.X && (pelota.e.Y + 12.5 >= p2.r.Y && pelota.e.Y + 12.5 <= p2.r.Y + 60)) //condiciones para la colision de la raqueta dos y la pelota
                {
                    int p = r.Next(0, 4);
                    if (p == 0)
                        pelota.diry = -pelota.diry;
                    pelota.dirx = -pelota.dirx;
                    pelota.e.X = p2.r.X - 25;
                    //MessageBox.Show("tocando p2");  
                }

                if (pelota.e.Y <= 0)
                {
                    int p = r.Next(0, 4);
                    if (p == 0)
                        pelota.dirx = -pelota.dirx;
                    pelota.diry = -pelota.diry;
                    pelota.e.Y = 0;
                }

                if (pelota.e.Y + 25 >= this.ClientSize.Height)
                {
                    int p = r.Next(0, 4);
                    if (p == 1)
                        pelota.dirx = -pelota.dirx;
                    pelota.diry = -pelota.diry;
                    pelota.e.Y = this.ClientSize.Height - 25;
                }

                if (pelota.e.X + pelota.e.Width >= this.ClientSize.Width)
                {
                    int p = r.Next(0, 4);
                    if (p == 0)
                        pelota.diry = -pelota.diry;
                    pelota.dirx = -pelota.dirx;
                    ptsJ1++;
                    actualizaLabel1();
                    pelota.e.X = this.ClientSize.Width - pelota.e.Width;
                }

                if (pelota.e.X <= 0) //condicion para marcar punto del jugador dos
                {
                    int p = r.Next(0, 4);
                    if (p == 0)
                        pelota.diry = -pelota.diry;
                    pelota.dirx = -pelota.dirx;
                    ptsJ2++;
                    actualizaLabel2();
                    pelota.e.X = 0;
                }
                if (ptsJ1 > 30 || ptsJ2 > 30) //el primero que marque mas de tres pts gana
                    endGame = true;
                
                Invalidate();
            }
            //this.Close();
            gameOver();
        }

        private void actualizaLabel1()
        {
            MethodInvoker inv = delegate
            {
                this.pts1.Text = ptsJ1.ToString();
            };

           this.Invoke(inv);
        }

        private void actualizaLabel2()
        {
            MethodInvoker inv2 = delegate
            {
                this.pts2.Text = ptsJ2.ToString();
            };
            this.Invoke(inv2);
        }

        private void gameOver()
        {
            MethodInvoker inv3 = delegate
            {
                this.Close();
            };

            this.Invoke(inv3);
        }

        private void Form1_Paint(object sender, PaintEventArgs e) //metodo para pintar el escenario
        {
            Pen pe = new Pen(Color.White);
            Brush bru = new SolidBrush(Color.White);
            Graphics gra = e.Graphics;
            Rectangle linea_media = new Rectangle(398, 0, 4, 500);
            gra.FillRectangle(bru, linea_media); //pinta linea divisoria
            gra.FillRectangle(bru, p1.r); //pinta jugador uno
            gra.FillRectangle(bru, p2.r); //pinta jugador dos
            gra.FillEllipse(bru, pelota.e); //pinta pelota
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            pressDown1 = false;
            pressUp1 = false;
            //pressDown2 = false;
            //pressUp2 = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) //evento para las teclas del jugador uno
        {
            if (e.KeyValue == 40) //down
                pressDown1 = true;
            if (e.KeyValue == 38) //up
                pressUp1 = true;
            /*
            if (e.KeyValue == 13) //down2
                pressDown2 = true;
            if (e.KeyValue == 107) //up2
                pressUp2 = true;
            */
        }

        private static void SetupServer()
        {
            Console.WriteLine("Setting the server...");

            _serverSocket.Bind(new IPEndPoint(IPAddress.Any, 8080));
            _serverSocket.Listen(1);
            while (true)
            {
                _serverSocket.BeginAccept(new AsyncCallback(Aceptcallback), null);

            }
        }

        private static void Aceptcallback(IAsyncResult AR)
        {
            Socket socket = _serverSocket.EndAccept(AR);
            _clientsSockets.Add(socket);
            Console.WriteLine("Client Conected");
            conectado = true;
            socket.BeginReceive
                (_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            _serverSocket.BeginAccept(new AsyncCallback(Aceptcallback), null);
        }

        private static void ReceiveCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            int received = socket.EndReceive(AR);
            byte[] dataBuf = new byte[received];
            Array.Copy(_buffer, dataBuf, received);
            string pp2 = Encoding.ASCII.GetString(dataBuf);
            p2.y = int.Parse(pp2);
            string resp = string.Empty;
            Console.WriteLine(Encoding.ASCII.GetString(dataBuf));

            byte[] data = Encoding.ASCII.GetBytes(p1.y.ToString());
            socket.BeginSend
                (data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);

            /*data = Encoding.ASCII.GetBytes(pelota.x.ToString());
            socket.BeginSend
                (data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);

            data = Encoding.ASCII.GetBytes(pelota.y.ToString());
            socket.BeginSend
                (data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
            */
        }

        private static void SendCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
        }

    }
}
