using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ООП_5
{
    class Wall
    {
        public float x, y;
        public float w, h;

        public Wall(float _x, float _y, float _w, float _h)
        {
            x = _x;
            y = _y;
            w = _w;
            h = _h;
        }

        public void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Black, x, y, w, h);
        }

        public void Draw(Graphics g, Brush br)
        {
            g.FillRectangle(br, x, y, w, h);
        }
    }
}
