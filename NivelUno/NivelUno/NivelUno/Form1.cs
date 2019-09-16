using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace NivelUno
{
    public partial class nivelUno : Form
    {
        string nombreArchivo1 = "nivelUno.txt", nombreArchivo2 = "nivelDos.txt", nombreArchivo3 = "nivelTres.txt";
        List<Bloque> bloques;
        List<Bomba> bombas;
        List<Explosion> explosiones;
        Explosion explosion;
        Bomba bomba;
        Thread timerThread;
        Jugador jugador;
        JugadorD jugadorD;
        bool bom = false, bom2 = false;
        List<int> xes;
        List<int> yes;

        List<int> xesBomba;
        List<int> yesBomba;

        List<Explosion> explosionesRemotas = new List<Explosion>();
        List<int> xes2;
        List<int> yes2;
        bool bombaRemota = false;
        int xExplo, yExplo;
        int contBb = 0;
        int incBy = 120, incBx = 100, x = 100, y = 100, p = 5, x2 = 750, y2 = 500;
        bool pressDown = false, pressRight = false, pressLefth = false, pressUp = false;
        bool pressDown2 = false, pressRight2 = false, pressLefth2 = false, pressUp2 = false;
        bool conectado = false, endGame = false, bandBomb = false, bandExplo = false;
        int bomb1X, bomb2Y, bomb1X2, bomb2Y2, band = 0, band2 = 0, contBUno = 0, contBDos = 0, b = 0, b2 = 0;
        int contNivel = 1;
        bool bom3 = false;
        int band3 = 0;
        bool bandBomb2 = false; //********

        int incB = 10;

        public nivelUno()
        {
            InitializeComponent();
            xes = new List<int>();
            yes = new List<int>();

            xesBomba = new List<int>();
            yesBomba = new List<int>();


            bloques = new List<Bloque>();
            bombas = new List<Bomba>();
            explosiones = new List<Explosion>();
            jugador = new Jugador();
            jugadorD = new JugadorD();
            jugador.x = x;
            jugador.y = y;
            jugadorD.x = x2;
            jugadorD.y = y2;
            
            timerThread = new Thread(Timer_Tick);
            timerThread.Start();

            this.MaximizeBox = false;
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Width = 895;
            this.Height = 680;
            pintarMapa("prueba.txt");
        }

        private void nivelUno_KeyUp(object sender, KeyEventArgs e)
        {
            pressDown = false; pressRight = false; pressLefth = false; pressUp = false;
            pressDown2 = false; pressRight2 = false; pressLefth2 = false; pressUp2 = false;
        }

        private void nivelUno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 40) // down
            {
                pressDown = true;
                jugador.selected = 1;
            }

            if (e.KeyValue == 39) // right
            {
                pressRight = true;
                jugador.selected = 2;
            }

            if (e.KeyValue == 37) //lefth
            {
                pressLefth = true;
                jugador.selected = 3;
            }

            if (e.KeyValue == 38) //up
            {
                pressUp = true;
                jugador.selected = 4;
            }

            if (e.KeyValue == 32) //space
            {
                //aqui va la bomba simple
                bomba = new Bomba();
                bomba.x = jugador.x;
                bomba.y = jugador.y;
                bomba.tipo = 1;
                bombas.Add(bomba);
                bandBomb = true;
            }

            if (e.KeyValue == 81) //q
            {
                bomba = new Bomba();
                bomba.x = jugador.x;
                bomba.y = jugador.y;
                bomba.tipo = 6;
                bombas.Add(bomba);
                bandBomb = true;
                bombaRemota = true;
                xesBomba.Add(jugador.x);
                yesBomba.Add(jugador.y);
            }

            if (e.KeyValue == 87) //w
            {
                //bomba de gran alcance
                bomba = new Bomba();
                bomba.x = jugador.x;
                bomba.y = jugador.y;

                bomba.tipo = 3;
                bombas.Add(bomba);
                bandBomb = true;
            }

            if (e.KeyValue == 69) //e
            {
                //aqui va la bomba apestosa
                bomba = new Bomba();
                bomba.x = jugador.x;
                bomba.y = jugador.y;

                bomba.tipo = 4;
                bombas.Add(bomba);
                bandBomb = true;
            }

            if (e.KeyValue == 82) //r
            {
                //aqui van las minas
                bomba = new Bomba();
                bomba.x = jugador.x;
                bomba.y = jugador.y;

                bomba.tipo = 5;
                bombas.Add(bomba);
                bandBomb = true;
            }

            if (e.KeyValue == 84) //t
            {
                if (bombaRemota)
                {
                    for (int i = 0; i < bombas.Count; i++)
                    {
                        if (bombas[i].tipo == 6)
                        {
                            explosion = new Explosion();
                            explosion.x = bombas[i].x - 45;
                            explosion.y = bombas[i].y - 45;
                            explosion.tipo = 4;
                            explosionesRemotas.Add(explosion);
                            
                        }
                    }
                    bombaRemota = false;
                    //Invalidate();   
                }
            }
            //******************************************************************************
            if (e.KeyValue == 75) //down jugadorD
            {
                pressDown2 = true;
                jugadorD.selected = 1;
            }

            if (e.KeyValue == 73) //up jugadorD
            {
                pressUp2 = true;
                jugadorD.selected = 4;
            }

            if (e.KeyValue == 76) //right jugadorD
            {
                pressRight2 = true;
                jugadorD.selected = 2;
            }

            if (e.KeyValue == 74)  //lefht jugadorD
            {
                pressLefth2 = true;
                jugadorD.selected = 3;
            }

            if (e.KeyValue == 88) //x
            {
                //aqui va la bomba remota
                if (band2 == 0)
                {
                    bomba = new Bomba();
                    bomba.x = jugadorD.x;
                    bomba.y = jugadorD.y;
                    bomb1X2 = bomba.x - 45;
                    bomb2Y2 = bomba.y - 45;
                    bomba.tipo = 2;
                    bombas.Add(bomba);
                    bandBomb = true;
                    band2 = 1;
                    bom2 = true;
                }
            }

            if (e.KeyValue == 67) //c
            {
                //bomba de gran alcance
                bomba = new Bomba();
                bomba.x = jugadorD.x;
                bomba.y = jugadorD.y;
                bomba.tipo = 3;
                bombas.Add(bomba);
                bandBomb = true;
            }

            if (e.KeyValue == 86) //v
            {
                //aqui va la bomba apestosa
                bomba = new Bomba();
                bomba.x = jugadorD.x;
                bomba.y = jugadorD.y;
                bomba.tipo = 4;
                bombas.Add(bomba);
                bandBomb = true;
            }

            if (e.KeyValue == 66) //b
            {
                //aqui van las minas
                bomba = new Bomba();
                bomba.x = jugadorD.x;
                bomba.y = jugadorD.y;
                bomba.tipo = 5;
                bombas.Add(bomba);
                bandBomb = true;
            }

            if (e.KeyValue == 78) //n
            {
                //aqui va la bomba simple
                bomba = new Bomba();
                bomba.x = jugadorD.x;
                bomba.y = jugadorD.y;
                bomba.tipo = 1;
                bombas.Add(bomba);
                bandBomb = true;
            }

            if (e.KeyValue == 77) //m
            {
                if (bom2)
                {
                    explosion = new Explosion();
                    explosion.x = bomb1X2;
                    explosion.y = bomb2Y2;
                    explosion.tipo = 1;
                    explosiones.Add(explosion);
                    bandExplo = true;
                    band2 = 0;
                    bom2 = false;
                }
            }
        }

        private void Timer_Tick()
        {
            /*while (!conectado)
            {
                Console.WriteLine("C o n e c t a n d o . . .");
            }*/
            while (endGame == false)
            {
                for (int i = 0; i < 220000000 / 60; i++) //un segundo = 220000000
                {

                }

                if (pressDown)
                {
                    jugador.Update();
                    for (int i = 0; i < xes.Count; i++)
                    {
                        if (!((y >= yes[i] && y <= yes[i] + incBy) && (x >= xes[i] && x <= xes[i] + incBx)) && y <= 505)
                            if (b2 == 0)
                            {
                                y += p;
                                b2 = 1;
                            }
                    }
                    b2 = 0;
                }

                if (pressUp)
                {
                    jugador.Update();
                    for (int i = 0; i < xes.Count; i++)
                    {
                        if (!((y >= yes[i] && y <= yes[i] + incBy) && (x >= xes[i] && x <= xes[i] + incBx)) && y >= 80)
                            if (b2 == 0)
                            {
                                y -= p;
                                b2 = 1;
                            }
                    }
                    b2 = 0;
                }


                if (pressRight)
                {
                    jugador.Update();
                    for (int i = 0; i < xes.Count; i++)
                    {
                        if (!((y >= yes[i] && y <= yes[i] + incBy) && (x >= xes[i] && x <= xes[i] + incBx)) && x <= 765)
                            if (b2 == 0)
                            {
                                x += p;
                                b2 = 1;
                            }
                    }
                    b2 = 0;
                }


                if (pressLefth)
                {
                    jugador.Update();
                    for (int i = 0; i < xes.Count; i++)
                    {
                        if (!((y >= yes[i] && y <= yes[i] + incBy) && (x >= xes[i] && x <= xes[i] + incBx)) && x <= 80)
                            if (b2 == 0)
                            {
                                x -= p;
                                b2 = 1;
                            }
                    }
                    b2 = 0;
                }

                /*
                for (int i = 0; i < xes.Count; i++)
                {
                    if (((y >= yes[i] && y <= yes[i] + incBy) && (x >= xes[i] && x <= xes[i] + incBx)))
                    {
                        if (pressDown)
                        {
                            if (b2 == 0)
                            {
                                y -= p;
                                b2 = 1;
                            }
                        }

                        if (pressUp)
                        {
                            if (b2 == 0)
                            {
                                y += p;
                                b2 = 1;
                            }
                        }

                        if (pressRight)
                        {
                            if (b2 == 0)
                            {
                                x -= p;
                                b2 = 1;
                            }
                        }


                        if (pressLefth)
                        {
                            if (b2 == 0)
                            {
                                x += p;
                                b2 = 1;
                            }
                        }
                        b2 = 0;
                    }
                }*/

                //*********************************************************
                

                //***********************************************
                if (pressDown2)
                {
                    jugadorD.Update();
                    for (int i = 0; i < xes.Count; i++)
                    {
                        if (!((y2 >= yes[i] && y2 <= yes[i] + incBy) && (x2 >= xes[i] && x2 <= xes[i] + incBx)) && y2 <= 505)
                            if (b2 == 0)
                            {
                                y2 += p;
                                b2 = 1;
                            }
                    }
                    b2 = 0;
                }

                if (pressUp2)
                {
                    jugadorD.Update();
                    for (int i = 0; i < xes.Count; i++)
                    {
                        if (!((y2 >= yes[i] && y2 <= yes[i] + incBy) && (x2 >= xes[i] && x2 <= xes[i] + incBx)) && y2 >= 80)
                            if (b2 == 0)
                            {
                                y2 -= p;
                                b2 = 1;
                            }
                    }
                    b2 = 0;
                }


                if (pressRight2)
                {
                    jugadorD.Update();
                    for (int i = 0; i < xes.Count; i++)
                    {
                        if (!((y2 >= yes[0] && y2 <= yes[0] + incBy) && (x2 >= xes[0] && x2 <= xes[0] + incBx)) && x2 <= 765)
                            if (b2 == 0)
                            {
                                x2 += p;
                                b2 = 1;
                            }
                    }
                    b2 = 0;
                }


                if (pressLefth2)
                {
                    jugadorD.Update();
                    for (int i = 0; i < xes.Count; i++)
                    {
                        if (!((y2 >= yes[0] && y2 <= yes[0] + incBy) && (x2 >= xes[0] && x2 <= xes[0] + incBx)) && x2 >= 80)
                            if (b2 == 0)
                            {
                                x2 -= p;
                                b2 = 1;
                            }
                    }
                    b2 = 0;
                }

                for (int i = 0; i < xes.Count; i++)
                {
                    if (((y2 >= yes[i] && y2 <= yes[i] + incBy) && (x2 >= xes[i] && x2 <= xes[i] + incBx)))
                    {
                        if (pressDown2)
                        {
                            if (b2 == 0)
                            {
                                y2 -= p;
                                b2 = 1;
                            }
                        }

                        if (pressUp2)
                        {
                            if (b2 == 0)
                            {
                                y2 += p;
                                b2 = 1;
                            }
                        }

                        if (pressRight2)
                        {
                            if (b2 == 0)
                            {
                                x2 -= p;
                                b2 = 1;
                            }
                        }


                        if (pressLefth2)
                        {
                            if (b2 == 0)
                            {
                                x2 += p;
                                b2 = 1;
                            }
                        }
                        b2 = 0;
                    }
                }

                Invalidate();
            }
            gameOver();
        }

        public void gameOver()
        {
            MethodInvoker inv3 = delegate
            {
                this.Close();
            };

            this.Invoke(inv3);
        }
             
        private void pintarMapa(String fichero)
        {
            //declarar los datos a leer desde el fichero
            //int auxX = 0, auxY = 0;
            char aux;
            int auxX = 0;
            int auxY = 0;
            int contX = 0;
            int contY = 1;
            BinaryReader br = null; //flujo entrada de datos
            try
            {
                //verificar si el fichero existe
                if (File.Exists(fichero))
                {
                    //si existe, abrir un flujo desde el mismo para leer 
                    br = new BinaryReader(new FileStream(fichero, FileMode.Open, FileAccess.Read));
                    do
                    {
                        //leer hasta que se alance el final del fichero C#
                        //lanzara una excepcion del tipo EndOfStreamException.
                        aux = br.ReadChar();
                        if (aux != ' ' && aux != '1')
                        {
                            Bloque auxB = new Bloque();
                            if (aux == '0')
                            {
                                auxX = 80 * contX;
                                contX++;
                                auxB.tipo = 0;
                            }
                            if (aux == '*')
                            {
                                auxY = 80 * contY;
                                contY++;
                                auxX = 0;
                                contX = 0;
                            }
                            auxB.x = auxX;
                            auxB.y = auxY;
                            bloques.Add(auxB);
                        }
                        if (aux == ' ')
                            contX++;
                        if (aux == '1')
                        {
                            auxX = 80 * contX;
                            contX++;
                            Bloque auxB = new Bloque();
                            auxB.tipo = 1;
                            auxB.x = auxX;
                            auxB.y = auxY;
                            bloques.Add(auxB);
                        }
                    }
                    while (true);       
                }
                else
                    Console.WriteLine("El fichero no existe");
            }
            catch (EndOfStreamException)
            {
                Console.WriteLine("Fin del listado");
            }
            finally
            {
                //cerrar el flujo
                if (br != null) br.Close();
                //MessageBox.Show("num de blkConcreto " + contConcreto);
            }
            Invalidate();
        }

        private void nivelUno_Paint(object sender, PaintEventArgs e)
        {
            Graphics g;
            g = null;
            g = e.Graphics;
            jugador.y = y;
            jugador.x = x;

            jugadorD.x = x2;
            jugadorD.y = y2;

            g.DrawImage(jugador.getCurFrame(), jugador.x, jugador.y);
            g.DrawImage(jugadorD.getCurFrame(), jugadorD.x, jugadorD.y);

            if (explosionesRemotas.Count != 0)
            {
                
                for (int i = 0; i < explosionesRemotas.Count; i++)
                {
                    if (contBb < 20)
                    {
                        xExplo = explosionesRemotas[i].x - 30;
                        yExplo = explosionesRemotas[i].y - 40;

                        g.DrawImage(explosionesRemotas[i].getImage(), explosionesRemotas[i].x, explosionesRemotas[i].y);
                        for (int w = 0; w < bombas.Count; w++)
                        {
                            if (bombas[w].x == explosionesRemotas[i].x + 45 && bombas[w].y == explosionesRemotas[i].y + 45)
                                bombas.RemoveAt(w);
                        }
                        contBb++;
                    }
                    else
                    {
                        int incY = 155;
                        int incX = 145;

                        explosionesRemotas.RemoveAt(i);
                        contBb = 0;
                        if ((y + 3 >= yExplo + 10 && y + 3 <= yExplo + incY) && (x >= xExplo + 10 && x <= xExplo + incX))
                            this.Close();
                        if ((y2 + 3 >= yExplo && y2 + 3 <= yExplo + incY) && (x2 >= xExplo && x2 <= xExplo + incX))
                            this.Close();
                    }
                }
            }

            if (bandBomb)
            {
                for (int i = 0; i < bombas.Count; i++)
                {
                    if (bombas[i].tipo == 1)
                    {
                        g.DrawImage(bombas[i].getImage(), bombas[i].x, bombas[i].y);
                        bombas[i].cont++;
                        if (bombas[i].cont > 60)
                        {
                            //bombas.RemoveAt(i);
                            explosion = new Explosion();
                            explosion.x = bombas[i].x - 45;
                            explosion.y = bombas[i].y - 45;
                            explosion.tipo = 1;
                            explosiones.Add(explosion);
                            bandExplo = true;
                            band = 0;
                        }
                    }
                }

                for (int y = 0; y < bombas.Count; y++)
                {
                    if (bombas[y].tipo == 2)
                        g.DrawImage(bombas[y].getImage(), bombas[y].x, bombas[y].y);
                }

                for (int w = 0; w < bombas.Count; w++)
                {
                    if (bombas[w].tipo == 3)
                    {
                        g.DrawImage(bombas[w].getImage(), bombas[w].x, bombas[w].y);
                        bombas[w].cont++;
                        if (bombas[w].cont > 50)
                        {
                            //bombas.RemoveAt(w);
                            explosion = new Explosion();
                            explosion.x = bombas[w].x - 65;
                            explosion.y = bombas[w].y - 65;
                            explosion.tipo = 2;
                            explosiones.Add(explosion);
                            bandExplo = true;
                            band = 0;
                        }
                    }
                }

                for (int z = 0; z < bombas.Count; z++)
                {
                    if (bombas[z].tipo == 4)
                    {
                        g.DrawImage(bombas[z].getImage(), bombas[z].x, bombas[z].y);
                        bombas[z].cont++;
                        if (bombas[z].cont > 70)
                        {
                            //bombas.RemoveAt(z);
                            explosion = new Explosion();
                            explosion.x = bombas[z].x - 45;
                            explosion.y = bombas[z].y - 45;
                            explosion.tipo = 3;
                            explosiones.Add(explosion);
                            bandExplo = true;
                            band = 0;
                        }
                    }
                }

                for (int z = 0; z < bombas.Count; z++)
                {
                    if (bombas[z].tipo == 5)
                        g.DrawImage(bombas[z].getImage(), bombas[z].x, bombas[z].y);
                }
                //****************
                for (int i = 0; i < bombas.Count; i++)
                {
                    if (bombas[i].tipo == 6)
                        g.DrawImage(bombas[i].getImage(), bombas[i].x, bombas[i].y);
                }
                //*******************
                if (bandExplo)
                {
                    for (int i = 0; i < explosiones.Count; i++)
                    {
                        if (explosiones[i].tipo == 1)
                        {
                            if (contBUno < 20)
                            {
                                xExplo = explosiones[i].x - 30;
                                yExplo = explosiones[i].y - 40;
                                
                                //Pen p = new Pen(Color.Black);
                                //g.DrawRectangle(p, xExplo, yExplo, incX, incY);

                                g.DrawImage(explosiones[i].getImage(), explosiones[i].x, explosiones[i].y);
                                for (int w = 0; w < bombas.Count; w++)
                                {
                                    if (bombas[w].x == explosiones[i].x + 45 && bombas[w].y == explosiones[i].y + 45)
                                        bombas.RemoveAt(w);
                                }
                                contBUno++;
                            }
                            else
                            {
                                int incY = 155;
                                int incX = 145;

                                explosiones.RemoveAt(i);
                                contBUno = 0;
                                if ((y + 3 >= yExplo + 10 && y + 3 <= yExplo + incY) && (x >= xExplo + 10 && x <= xExplo + incX))
                                    this.Close();
                                if ((y2 + 3 >= yExplo && y2 + 3 <= yExplo + incY) && (x2 >= xExplo && x2 <= xExplo + incX))
                                    this.Close();
                            }
                        }
                        else
                        {
                            if (explosiones[i].tipo == 2)
                            {
                                if (contBUno < 30)
                                {
                                    xExplo = explosiones[i].x - 60;
                                    yExplo = explosiones[i].y - 80;

                                    g.DrawImage(explosiones[i].getImage(), explosiones[i].x, explosiones[i].y);
                                    for (int w = 0; w < bombas.Count; w++)
                                    {
                                        if (bombas[w].x == explosiones[i].x + 65 && bombas[w].y == explosiones[i].y + 65)
                                            bombas.RemoveAt(w);
                                    }

                                    contBUno++;
                                }
                                else
                                {
                                    int incY = 310;
                                    int incX = 290;

                                    explosiones.RemoveAt(i);
                                    contBUno = 0;
                                    if ((y + 3 >= yExplo + 20 && y + 3 <= yExplo + incY) && (x >= xExplo + 20 && x <= xExplo + incX))
                                        this.Close();
                                    if ((y + 3 >= yExplo + 20 && y + 3 <= yExplo + incY) && (x >= xExplo + 20 && x <= xExplo + incX))
                                        this.Close();

                                }
                            }
                            else
                            {
                                if (explosiones[i].tipo == 3)
                                {
                                    if (contBDos < 30)
                                    {
                                        xExplo = explosiones[i].x;
                                        yExplo = explosiones[i].y;

                                        g.DrawImage(explosiones[i].getImage(), explosiones[i].x, explosiones[i].y);
                                        for (int w = 0; w < bombas.Count; w++)
                                        {
                                            if (bombas[w].x == explosiones[i].x + 45 && bombas[w].y == explosiones[i].y + 45)
                                                bombas.RemoveAt(w);
                                        }
                                        contBDos++;
                                    }
                                    else
                                    {
                                        int incY = 155;
                                        int incX = 145;

                                        explosiones.RemoveAt(i);
                                        contBDos = 0;
                                        if ((y + 3 >= yExplo + 10 && y + 3 <= yExplo + incY) && (x >= xExplo + 10 && x <= xExplo + incX))
                                            this.Close();
                                        if ((y2 + 3 >= yExplo && y2 + 3 <= yExplo + incY) && (x2 >= xExplo && x2 <= xExplo + incX))
                                            this.Close();

                                    }
                                }        
                            }
                        }
                    }
                }                
            }
            

            if (b == 0)
            {
                for (int i = 0; i < bloques.Count; i++)
                {
                    if (bloques[i].tipo == 1)
                    {
                        xes.Add(bloques[i].x - 25);
                        yes.Add(bloques[i].y - 43);
                    }
                }            
                b = 1;
            }

            for (int i = 0; i < bloques.Count; i++)
            {
                if (bloques[i].tipo == 0)
                    g.DrawImage(bloques[i].concreto, bloques[i].x, bloques[i].y);
                if (bloques[i].tipo == 1)
                    g.DrawImage(bloques[i].ladrillo, bloques[i].x, bloques[i].y);
            }
        }
    }
}