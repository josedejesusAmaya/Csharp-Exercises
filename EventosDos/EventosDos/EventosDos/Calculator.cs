using System;


namespace EventosDos
{
    public class Calculator
    {
        public void Add(EventHandler method)
        {
            int r = 2 + 3;
            method(r,null);
        }
    }
}
