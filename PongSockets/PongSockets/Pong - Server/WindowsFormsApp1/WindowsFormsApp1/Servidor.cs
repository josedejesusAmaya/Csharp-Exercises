using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Servidor
    {
        List<Socket> clientSockets;
        Socket serversocket;
        Socket listener;
        IPEndPoint address;


        public Servidor()
        {
            clientSockets = new List<Socket>();
        }

        public void conectar()
        {
            /*CODIGO PARA SOCKET SERVIDOR 192.168.1.65*/
            serversocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            address = new IPEndPoint(IPAddress.Any, 1234);
            serversocket.Bind(address);
            //serversocket.Connect(address);
            serversocket.Listen(2);
            Console.WriteLine("Escuchando.........");
            listener = serversocket.Accept();
            Console.WriteLine("Conectado con exito, SERVIDOR1");
            variables.conectado = true;
            /*TERMINO DE CODIGO SOCKET SERVIDOR*/

            while (true)
            {
                /*IMPRESION*/
                byte[] byrec1 = new byte[255];
                int a = listener.Receive(byrec1, 0, byrec1.Length, 0);
                Array.Resize(ref byrec1, a);
                variables.p2.r.Y = int.Parse(Encoding.Default.GetString(byrec1));
                Console.WriteLine("p2 pos Y -> " + variables.p2.r.Y.ToString());
                /*TERMINA IMPRESION*/

                /*Envia datos*/

                string info = variables.p1.r.Y.ToString(); ;
                byte[] infoenvia = Encoding.Default.GetBytes(info);
                listener.Send(infoenvia, 0, infoenvia.Length, 0);

                listener.Receive(byrec1, 0, byrec1.Length, 0);

                info = variables.pelota.e.X.ToString();
                infoenvia = Encoding.Default.GetBytes(info);
                listener.Send(infoenvia, 0, infoenvia.Length, 0);

                listener.Receive(byrec1, 0, byrec1.Length, 0);

                info = variables.pelota.e.Y.ToString();
                infoenvia = Encoding.Default.GetBytes(info);
                listener.Send(infoenvia, 0, infoenvia.Length, 0);

                listener.Receive(byrec1, 0, byrec1.Length, 0);

                info = variables.ptsJ1.ToString();
                infoenvia = Encoding.Default.GetBytes(info);
                listener.Send(infoenvia, 0, infoenvia.Length, 0);

                listener.Receive(byrec1, 0, byrec1.Length, 0);

                info = variables.ptsJ2.ToString();
                infoenvia = Encoding.Default.GetBytes(info);
                listener.Send(infoenvia, 0, infoenvia.Length, 0);




                /*Termino de enviar datos*/
            }
        }

        public void CloseSockets()
        {
            foreach (Socket sock in clientSockets)
            {
                sock.Shutdown(SocketShutdown.Both);
                sock.Close();
            }

            serversocket.Close();
        }

        public void carga_datos_a_enviar()
        {
            
        }
    }
}
