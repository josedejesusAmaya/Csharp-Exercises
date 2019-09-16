using System;

namespace Timer
{
    class Contador
    {
        private int r = 0;
        private int cont = 0;
        public void Count(EventHandler method)
        {
            while(true)
            {
                if(r != 0 && r % 100 == 0)
                    method(cont++, null);
                r++;
            }
        }
    }
}
