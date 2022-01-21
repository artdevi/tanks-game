using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП_5
{
    class Ammo
    {
        Tank.Directions dir;
        public float x, y;
        public float w, h;
        int currentWay;
        public int speed { get; private set; }
        public bool burst;

        public Ammo(float _x, float _y, float _w, float _h, Tank.Directions _dir)
        {
            x = _x;
            y = _y;
            w = _w;
            h = _h;
            dir = _dir;
            burst = false;
            speed = 7;
            currentWay = 0;
        }

        public void ChangePosition()
        {
            switch (dir)
            {
                case Tank.Directions.Up:
                    y -= speed;
                    break;
                case Tank.Directions.Down:
                    y += speed;
                    break;
                case Tank.Directions.Left:
                    x -= speed;
                    break;
                case Tank.Directions.Right:
                    x += speed;
                    break;
            }
        }
        
        public void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Black, x, y, w, h);
        }
    }
}