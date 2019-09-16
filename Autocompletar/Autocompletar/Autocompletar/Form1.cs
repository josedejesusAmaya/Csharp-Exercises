using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autocompletar
{
    public partial class Form1 : Form
    {
        List<List<string>> diccionario;
        List<string> a;
        List<string> b;
        List<string> c;
        List<string> d;
        List<string> e;
        List<string> f;
        List<string> g;
        List<string> h;
        List<string> i;
        List<string> j;
        List<string> k;
        List<string> l;
        List<string> m;
        List<string> n;
        List<string> ñ;
        List<string> o;
        List<string> p;
        List<string> q;
        List<string> r;
        List<string> s;
        List<string> t;
        List<string> u;
        List<string> v;
        List<string> w;
        List<string> x;
        List<string> y;
        List<string> z;
        public Form1()
        {
            InitializeComponent();
            cargaDiccionario();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            MessageBox.Show(text);
            char aux = new char();
            char aux2 = new char();
            // Create an instance of the ListBox.
            ListBox listBox1 = new ListBox();
            // Set the size and location of the ListBox.
            listBox1.Size = new System.Drawing.Size(200, 100);
            listBox1.Location = new System.Drawing.Point(25, 130);
            // Add the ListBox to the form.
            this.Controls.Add(listBox1);
            // Set the ListBox to display items in multiple columns.
            listBox1.MultiColumn = true;
            // Set the selection mode to multiple and extended.
            listBox1.SelectionMode = SelectionMode.MultiExtended;
            // Shutdown the painting of the ListBox as items are added.
            listBox1.BeginUpdate();

            if (!string.IsNullOrEmpty(textBox1.Text)) //si no esta vacia
            {                
                aux = text[0]; //obtiene la letra inicial
                for (int u = 0; u < diccionario.Count; u++)
                {
                    aux2 = diccionario[u][0][0]; //primera letra por cada lista
                    if (aux == aux2) //si son la misma letra, sacar la lista completa de esa letra
                    {
                        foreach (string s in diccionario[u])
                        {
                            listBox1.Items.Add(s);
                        }
                    }
                }
            }
            // Allow the ListBox to repaint and display the new items.
            listBox1.EndUpdate();
        }

        private void cargaDiccionario()
        {
            diccionario = new List<List<string>>();
            a = new List<string>();
            b = new List<string>();
            c = new List<string>();
            d = new List<string>();
            e = new List<string>();
            f = new List<string>();
            g = new List<string>();
            h = new List<string>();
            i = new List<string>();
            j = new List<string>();
            k = new List<string>();
            l = new List<string>();
            m = new List<string>();
            n = new List<string>();
            ñ = new List<string>();
            o = new List<string>();
            p = new List<string>();
            q = new List<string>();
            r = new List<string>();
            s = new List<string>();
            t = new List<string>();
            u = new List<string>();
            v = new List<string>();
            w = new List<string>();
            x = new List<string>();
            y = new List<string>();
            z = new List<string>();
            a.Add("arbol");
            a.Add("alma");
            a.Add("avatar");

            b.Add("bebe");
            b.Add("bandera");
            b.Add("botanica");

            c.Add("casa");
            c.Add("carro");
            c.Add("camino");

            d.Add("dedo");
            d.Add("diploma");
            d.Add("dedal");

            e.Add("electronica");
            e.Add("elefante");
            e.Add("estomago");

            f.Add("flauta");
            f.Add("figura");
            f.Add("fiesta");

            g.Add("guerrero");
            g.Add("gato");
            g.Add("gemido");

            h.Add("hijo");
            h.Add("hueso");
            h.Add("higado");

            i.Add("isotopo");
            i.Add("imagen");
            i.Add("insignia");

            j.Add("jirafa");
            j.Add("justicia");
            j.Add("juego");

            k.Add("karaoke");
            k.Add("ketchup");
            k.Add("kiwi");

            l.Add("lana");
            l.Add("loma");
            l.Add("lima");

            m.Add("mama");
            m.Add("mapa");
            m.Add("misa");

            n.Add("navio");
            n.Add("niño");
            n.Add("naranja");

            ñ.Add("ñu");
            
            o.Add("organizacion");
            o.Add("oreja");
            o.Add("oso");

            p.Add("panda");
            p.Add("papa");
            p.Add("pobre");

            q.Add("queso");
            q.Add("quetzal");
            q.Add("quimica");

            r.Add("raton");
            r.Add("rondana");
            r.Add("rimel");

            s.Add("salsa");
            s.Add("sabor");
            s.Add("suero");

            t.Add("tonto");
            t.Add("tio");
            t.Add("taco");

            u.Add("uaslp");
            u.Add("universo");
            u.Add("universidad");

            v.Add("videos");
            v.Add("vodka");
            v.Add("vela");

            w.Add("wikipedia");
            w.Add("waterpolo");
            
            x.Add("xenofobia");
            x.Add("xilofono");
            
            y.Add("yoyo");
            y.Add("yuxtaposicion");
            
            z.Add("zapato");
            z.Add("zoologico");
            z.Add("zorro");

            diccionario.Add(a);
            diccionario.Add(b);
            diccionario.Add(c);
            diccionario.Add(d);
            diccionario.Add(e);
            diccionario.Add(f);
            diccionario.Add(g);
            diccionario.Add(h);
            diccionario.Add(i);
            diccionario.Add(j);
            diccionario.Add(k);
            diccionario.Add(l);
            diccionario.Add(m);
            diccionario.Add(n);
            diccionario.Add(ñ);
            diccionario.Add(o);
            diccionario.Add(p);
            diccionario.Add(q);
            diccionario.Add(r);
            diccionario.Add(s);
            diccionario.Add(t);
            diccionario.Add(u);
            diccionario.Add(v);
            diccionario.Add(w);
            diccionario.Add(x);
            diccionario.Add(y);
            diccionario.Add(z);
            /*
            MessageBox.Show(diccionario[0][0]); //arbol
            MessageBox.Show(diccionario[0][1]); //alma, ciclo interno
            MessageBox.Show(diccionario[1][0]); //bebe, ciclo externo
            */
        }
    }
}
