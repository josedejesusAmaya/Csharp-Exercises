using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Clase09
{
    class Cronometro
    {
        private Timer timer;
        public Cronometro()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += metodoTiempo;
            timer.Start();
        }
        //delegate void ElapsedEventHandler(object o, ElapsedEventArgs args);
        public void metodoTiempo(object o, ElapsedEventArgs args)
        {
            Console.WriteLine("paso un segundo");
        }
    }
}
