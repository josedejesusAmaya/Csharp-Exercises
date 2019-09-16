using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NivelUno
{
    class JugadorD
    {
        List<Bitmap> framesDown = new List<Bitmap>();
        List<Bitmap> framesRight = new List<Bitmap>();
        List<Bitmap> framesLefth = new List<Bitmap>();
        List<Bitmap> framesUp = new List<Bitmap>();
        public int x, y;
        public int selected = 1;
        private int current;
        private int cf = 0;
        private int numF = 2;

        public JugadorD()
        {
            AddDown();
            AddRight();
            AddLefth();
            AddUp();
            current = 0;
        }

        private void AddDown()
        {
            framesDown.Add((Bitmap)Image.FromFile("a1-1.png"));
            framesDown.Add((Bitmap)Image.FromFile("a1-2.png"));
            framesDown.Add((Bitmap)Image.FromFile("a1-3.png"));
            framesDown.Add((Bitmap)Image.FromFile("a1-4.png"));
            framesDown.Add((Bitmap)Image.FromFile("a1-5.png"));
            framesDown.Add((Bitmap)Image.FromFile("a1-6.png"));
            framesDown.Add((Bitmap)Image.FromFile("a1-7.png"));
            framesDown.Add((Bitmap)Image.FromFile("a1-8.png"));

        }

        private void AddRight()
        {
            framesRight.Add((Bitmap)Image.FromFile("a2-1.png"));
            framesRight.Add((Bitmap)Image.FromFile("a2-2.png"));
            framesRight.Add((Bitmap)Image.FromFile("a2-3.png"));
            framesRight.Add((Bitmap)Image.FromFile("a2-4.png"));
            framesRight.Add((Bitmap)Image.FromFile("a2-5.png"));
            framesRight.Add((Bitmap)Image.FromFile("a2-6.png"));
            framesRight.Add((Bitmap)Image.FromFile("a2-7.png"));
            framesRight.Add((Bitmap)Image.FromFile("a2-8.png"));
        }

        private void AddLefth()
        {
            framesLefth.Add((Bitmap)Image.FromFile("a4-1.png"));
            framesLefth.Add((Bitmap)Image.FromFile("a4-2.png"));
            framesLefth.Add((Bitmap)Image.FromFile("a4-3.png"));
            framesLefth.Add((Bitmap)Image.FromFile("a4-4.png"));
            framesLefth.Add((Bitmap)Image.FromFile("a4-5.png"));
            framesLefth.Add((Bitmap)Image.FromFile("a4-6.png"));
            framesLefth.Add((Bitmap)Image.FromFile("a4-7.png"));
            framesLefth.Add((Bitmap)Image.FromFile("a4-8.png"));
        }

        private void AddUp()
        {
            framesUp.Add((Bitmap)Image.FromFile("a3-1.png"));
            framesUp.Add((Bitmap)Image.FromFile("a3-2.png"));
            framesUp.Add((Bitmap)Image.FromFile("a3-3.png"));
            framesUp.Add((Bitmap)Image.FromFile("a3-4.png"));
            framesUp.Add((Bitmap)Image.FromFile("a3-5.png"));
            framesUp.Add((Bitmap)Image.FromFile("a3-6.png"));
            framesUp.Add((Bitmap)Image.FromFile("a3-7.png"));
            framesUp.Add((Bitmap)Image.FromFile("a3-8.png"));
        }

        public void Update()
        {
            cf++;
            if (cf != numF)
                return;
            cf = 0;
            current++;
            if (current >= framesDown.Count)
                current = 0;
        }

        public Bitmap getCurFrame()
        {
            if (selected == 1)
                return framesDown[current];
            if (selected == 2)
                return framesRight[current];
            if (selected == 3)
                return framesLefth[current];
            if (selected == 4)
                return framesUp[current];
            return null;
        }
    }
}
