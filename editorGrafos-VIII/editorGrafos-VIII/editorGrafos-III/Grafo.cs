using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace editorGrafos_III
{
    class Grafo
    {
        List<List<Nodo>> nodoLista;
        List<Nodo> nodos;
        int ord = 65;
        Nodo selNodo;
        const int RADIO = 20;
        int tipo = 2; //0 = simple y 1 = dirigido y 2 = no tiene aristas 
        List<int> coords;
        Color color;

        public Grafo(Color c)
        {
            color = c;
            nodoLista = new List<List<Nodo>>();
            nodos = new List<Nodo>();
            coords = new List<int>();
        }

        public Grafo()
        {

        }
        
        public void creaNodo(Point p)
        {
            nodos.Add(new Nodo(p.X, p.Y, ord++));
        }

        public void pintaGrafo(Graphics g)
        {
            foreach (Nodo item in nodos)
                item.dibujaAristas(g, color, tipo);

            foreach (Nodo item in nodos)
                item.dibujaNodos(g, color, tipo);
        }

        public bool nodoInicial(Point punto)
        {
            bool resp = false;
            foreach (Nodo item in nodos)
                if (item.adentro(punto))
                {
                    selNodo = item;
                    resp = true;
                }
                    
            return resp;
        }

        public void nodoFinal(Point punto)
        {
            foreach (Nodo item in nodos)
                if (item.adentro(punto) && selNodo != null)
                    selNodo.creaArista(item);
        }

        public bool dNodo(Point punto)
        {
            bool resp = false;
            foreach (Nodo item in nodos)
                if (item.adentro(punto))
                    resp = true;
            return resp;
        }

        public int Tipo
        {
            get
            {
                return tipo;
            }
            set
            {
                this.tipo = value;
            } 
        }

        public void eliminaNodo(Point punto)
        {
            Nodo sel = new Nodo();
            foreach (Nodo item in nodos)
                if (item.adentro(punto))
                    sel = item;
            if (sel != null)
            {
                foreach (Nodo item in nodos)
                    item.nDestino(sel);

                nodos.Remove(sel);
            }
        }

        public void mueveNodo(Point punto)
        {
            foreach (Nodo item in nodos)
                if (item.adentro(punto))
                    selNodo = item;

            if (selNodo != null)
                selNodo.centro = punto;
        }

        public void mueve(bool m)
        {
            if (selNodo != null)
                selNodo.vMueve(m);
        }
    }
}
