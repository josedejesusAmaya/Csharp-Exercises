using System;
using System.Timers;

namespace Ciudad
{
    public class Ciudad
    {
        private Timer timerUno, timerDos;
        private DelPrint delBuild, delDestroy;
        private int casas;

        public Ciudad(DelPrint db, DelPrint dd)
        {
            delBuild = db;
            delDestroy = dd;
            casas = 0;
            timerUno = new Timer();
            timerDos = new Timer();

            timerUno.Interval = 1000;
            timerDos.Interval = 3000;

            timerUno.Elapsed += Build;
            timerDos.Elapsed += Destroy;

            timerUno.Start();
            timerDos.Start();
        }

        public void Build(object o, ElapsedEventArgs args)
        {
            Random r = new Random();
            int n = r.Next(5, 10);
            casas += n;
            delBuild(n); 
        }

        public void Destroy(object o, ElapsedEventArgs args)
        {
            Random r = new Random();
            int n = r.Next(2, 5);
            casas -= n;
            delDestroy(n);
        }
    }
}
