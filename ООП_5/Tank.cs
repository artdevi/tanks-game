using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ООП_5
{
    class Tank
    {

        public enum Directions { Up, Down, Left, Right }
        public Directions dir;
        public float x, y;
        public int hp { get; private set; }
        public float w = 30;
        public float h = 30;
        public int speed = 2;
        public bool allowShoot;
        public int cooldown;
        int cdtime = 2;

        public static Directions GetRandomDirection()
        {
            Random rnd = new Random();
            switch (rnd.Next() % 4)
            {
                case 0:
                    return Directions.Up;
                case 1:
                    return Directions.Down;
                case 2:
                    return Directions.Left;
                case 3:
                    return Directions.Right;
            }
            return Directions.Up;
        }

        public void SetRandomDirection()
        {
            dir = GetRandomDirection();
        }

        public Tank(float _x, float _y)
        {
            x = _x;
            y = _y;
            hp = 100;
            dir = Directions.Up;
            cooldown = 0;
            allowShoot = true;
        }

        public Tank(float _x, float _y, int _hp)
        {
            x = _x;
            y = _y;
            hp = _hp;
            dir = Directions.Up;
            cooldown = 0;
            allowShoot = true;
        }

        public Tank(float _x, float _y, int _hp, int _cdtime)
        {
            x = _x;
            y = _y;
            hp = _hp;
            dir = Directions.Up;
            cooldown = 0;
            allowShoot = true;
            cdtime = _cdtime;
        }

        public Ammo Shoot()
        {
            float ax = x, ay = y;
            float aw, ah;
            aw = w / 5;
            ah = h / 5;

            switch (dir)
            {
                case Directions.Up:
                    ax = x + w / 2 - w / 10;
                    ay = y - ah - 1;
                    break;
                case Directions.Down:
                    ax = x + w / 2 - w / 10;
                    ay = y + h + 1;
                    break;
                case Directions.Left:
                    ax = x - aw - 1;
                    ay = y + w / 2 - w / 10 ;
                    break;
                case Directions.Right:
                    ax = x + w + 1;
                    ay = y + w / 2 - w / 10;
                    break;
            }
            allowShoot = false;
            cooldown = cdtime;
            return new Ammo(ax, ay, aw, ah, dir);
            //return new Ammo(100, 100, aw, ah, dir);
        }

        public void GetHit(int damage)
        {
            hp -= damage;
        }

        public void Move()
        {
            switch (dir)
            {
                case Directions.Up:
                    if (y > 0)
                        y -= speed;
                    break;
                case Directions.Down:
                    if (y + h < 600)
                        y += speed;
                    break;
                case Directions.Left:
                    if (x > 0)
                        x -= speed;
                    break;
                case Directions.Right:
                    if (x + w < 600)
                        x += speed;
                    break;
            }
        }

        public void Draw(Graphics g, Brush br)
        {
            switch (dir)
            {
                case Directions.Up:
                    g.FillRectangle(br, x, y + h * 1 / 4, w / 4, h * 3 / 4);
                    g.FillRectangle(br, x + w * 3 / 4, y + h * 1 / 4, w / 4, h * 3 / 4);
                    g.FillRectangle(br, x, y + (h * 1 / 4) + ((h * 3 / 4) * 1 / 8), w, (h * 3 / 4) * 3 / 4);
                    g.FillRectangle(br, x + w / 2 - w / 10, y, w / 5, h / 2);
                    break;
                case Directions.Down:
                    g.FillRectangle(br, x, y, w / 4, h * 3 / 4);
                    g.FillRectangle(br, x + w * 3 / 4, y, w / 4, h * 3 / 4);
                    g.FillRectangle(br, x, y + ((h * 3 / 4) * 1 / 8), w, (h * 3 / 4) * 3 / 4);
                    g.FillRectangle(br, x + w / 2 - w / 10, y + h / 2, w / 5, h / 2);
                    break;
                case Directions.Left:
                    g.FillRectangle(br, x + h * 1 / 4, y, h * 3 / 4, w / 4);
                    g.FillRectangle(br, x + h * 1 / 4, y + w * 3 / 4, h * 3 / 4, w / 4);
                    g.FillRectangle(br, x + (h * 1 / 4) + ((h * 3 / 4) * 1 / 8), y, (h * 3 / 4) * 3 / 4, w);
                    g.FillRectangle(br, x, y + w / 2 - w / 10, h / 2, w / 5);
                    break;
                case Directions.Right:
                    g.FillRectangle(br, x, y, h * 3 / 4, w / 4);
                    g.FillRectangle(br, x, y + w * 3 / 4, h * 3 / 4, w / 4);
                    g.FillRectangle(br, x + ((h * 3 / 4) * 1 / 8), y, (h * 3 / 4) * 3 / 4, w);
                    g.FillRectangle(br, x + h / 2, y + w / 2 - w / 10, h / 2, w / 5);
                    break;
                default:
                    break;
            }
        }
    }
}
