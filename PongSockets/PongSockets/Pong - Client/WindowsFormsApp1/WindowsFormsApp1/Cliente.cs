using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace WindowsFormsApp1
{
    class Cliente
    {
        public void conectar()
        { 
            /*CODIGO PARA SOCKET CLIENTE*/
            Socket clientsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //IPEndPoint mydirection = new IPEndPoint(IPAddress.Loopback, 1234);
            //IPEndPoint mydirection = new IPEndPoint("192.168.1.2", 1234);

            clientsocket.Connect("192.168.1.2", 1234);
            Console.WriteLine("Conectado con exito");
            variables.conectado = true;
            //clientsocket.Listen(2);           
            /*TERMINO DE CODIGO SOCKET CLIENTE*/

            while (true)
            {
                /*ENVIO DE DATOS*/
                string info = variables.p2.r.Y.ToString();
                byte[] infoenvia = Encoding.Default.GetBytes(info);
                clientsocket.Send(infoenvia, 0, infoenvia.Length, 0);
                /*TERMINA ENVIO*/

                /*Recibe datos*/
                //Socket listener = clientsocket.Accept();

                //Jugador 1
                byte[] byrec1 = new byte[255]; 
                int a = clientsocket.Receive(byrec1, 0, byrec1.Length, 0);
                Array.Resize(ref byrec1, a);
                variables.p1.r.Y = int.Parse(Encoding.Default.GetString(byrec1));
                //Console.WriteLine("p1 pos y ->" + variables.p1.r.Y.ToString());

                clientsocket.Send(infoenvia, 0, infoenvia.Length, 0);
                //Pelota x
                byrec1 = new byte[255];
                a = clientsocket.Receive(byrec1, 0, byrec1.Length, 0);
                Array.Resize(ref byrec1, a);
                variables.pelota.e.X = int.Parse(Encoding.Default.GetString(byrec1));
                //Console.WriteLine("pelota X ->" + variables.pelota.e.X.ToString());

                clientsocket.Send(infoenvia, 0, infoenvia.Length, 0);

                //Pelota y
                byrec1 = new byte[255];
                a = clientsocket.Receive(byrec1, 0, byrec1.Length, 0);
                Array.Resize(ref byrec1, a);
                variables.pelota.e.Y = int.Parse(Encoding.Default.GetString(byrec1));
                //Console.WriteLine("pelota Y ->" + variables.pelota.e.Y.ToString());

                clientsocket.Send(infoenvia, 0, infoenvia.Length, 0);

                //Pelota y
                byrec1 = new byte[255];
                a = clientsocket.Receive(byrec1, 0, byrec1.Length, 0);
                Array.Resize(ref byrec1, a);
                variables.ptsJ1 = int.Parse(Encoding.Default.GetString(byrec1));
                //Console.WriteLine("pelota Y ->" + variables.pelota.e.Y.ToString());

                clientsocket.Send(infoenvia, 0, infoenvia.Length, 0);

                //Pelota y
                byrec1 = new byte[255];
                a = clientsocket.Receive(byrec1, 0, byrec1.Length, 0);
                Array.Resize(ref byrec1, a);
                variables.ptsJ2 = int.Parse(Encoding.Default.GetString(byrec1));
                Console.WriteLine("puntos: ->" + variables.ptsJ1.ToString() + " - " + variables.ptsJ2.ToString());

                /*Termino de recibir datos*/

            }
        }
    }
}
