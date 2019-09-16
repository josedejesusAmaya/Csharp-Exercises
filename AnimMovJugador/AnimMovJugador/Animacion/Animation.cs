using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Animacion
{
    class Animation
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
        public Animation()
        {
            AddDown();
            AddRight();
            AddLefth();
            AddUp();
            current = 0;
        }

        private void AddDown()
        {
            framesDown.Add((Bitmap)Image.FromFile("r1-1B.png"));
            framesDown.Add((Bitmap)Image.FromFile("r1-2B.png"));
            framesDown.Add((Bitmap)Image.FromFile("r1-3B.png"));
            framesDown.Add((Bitmap)Image.FromFile("r1-4B.png"));
            framesDown.Add((Bitmap)Image.FromFile("r1-5B.png"));
            framesDown.Add((Bitmap)Image.FromFile("r1-6B.png"));
            framesDown.Add((Bitmap)Image.FromFile("r1-7B.png"));
            framesDown.Add((Bitmap)Image.FromFile("r1-8B.png"));
            
        }

        private void AddRight()
        {
            framesRight.Add((Bitmap)Image.FromFile("r2-1B.png"));
            framesRight.Add((Bitmap)Image.FromFile("r2-2B.png"));
            framesRight.Add((Bitmap)Image.FromFile("r2-3B.png"));
            framesRight.Add((Bitmap)Image.FromFile("r2-4B.png"));
            framesRight.Add((Bitmap)Image.FromFile("r2-5B.png"));
            framesRight.Add((Bitmap)Image.FromFile("r2-6B.png"));
            framesRight.Add((Bitmap)Image.FromFile("r2-7B.png"));
            framesRight.Add((Bitmap)Image.FromFile("r2-8B.png"));
        }

        private void AddLefth()
        {
            framesLefth.Add((Bitmap)Image.FromFile("r3-1B.png"));
            framesLefth.Add((Bitmap)Image.FromFile("r3-2B.png"));
            framesLefth.Add((Bitmap)Image.FromFile("r3-3B.png"));
            framesLefth.Add((Bitmap)Image.FromFile("r3-4B.png"));
            framesLefth.Add((Bitmap)Image.FromFile("r3-5B.png"));
            framesLefth.Add((Bitmap)Image.FromFile("r3-6B.png"));
            framesLefth.Add((Bitmap)Image.FromFile("r3-7B.png"));
            framesLefth.Add((Bitmap)Image.FromFile("r3-8B.png"));
        }

        private void AddUp()
        {
            framesUp.Add((Bitmap)Image.FromFile("r4-1B.png"));
            framesUp.Add((Bitmap)Image.FromFile("r4-2B.png"));
            framesUp.Add((Bitmap)Image.FromFile("r4-3B.png"));
            framesUp.Add((Bitmap)Image.FromFile("r4-4B.png"));
            framesUp.Add((Bitmap)Image.FromFile("r4-5B.png"));
            framesUp.Add((Bitmap)Image.FromFile("r4-6B.png"));
            framesUp.Add((Bitmap)Image.FromFile("r4-7B.png"));
            framesUp.Add((Bitmap)Image.FromFile("r4-8B.png"));
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
