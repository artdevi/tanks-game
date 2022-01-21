using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ООП_5
{
    class Player : IController
    {
        Tank tank;
        public float x, y;
        public float cx, cy;
        public bool alive;
        public float w { get; private set; }
        public float h { get; private set; }
        

        List<Wall> walls;
        List<TankController> tanks;
        ProgressBar progressHP;

        public Player(float _x, float _y, List<TankController> _tanks, List<Wall> _walls, ProgressBar _pb)
        {
            tank = new Tank(_x, _y, 300, 1);
            alive = true;
            walls = _walls;
            tanks = _tanks;
            SetPosition();
            w = tank.w;
            h = tank.h;
            progressHP = _pb;
            progressHP.Maximum = tank.hp;
        }

        public void SetPosition()
        {
            x = tank.x;
            y = tank.y;
            cx = x + tank.w / 2;
            cy = y + tank.h / 2;
        }

        public bool CanIMove()
        {
            switch (tank.dir)
            {
                case Tank.Directions.Up:
                    if (tank.y <= 0)
                        return false;

                    foreach (Wall wall in walls)
                    {
                        if (wall.y + wall.h >= tank.y - tank.speed && wall.y <= tank.y && (wall.x <= tank.x && tank.x <= wall.x + wall.w || wall.x <= tank.x + tank.w && tank.x + tank.w <= wall.x + wall.w))
                            return false;
                    }

                    foreach (TankController tc in tanks)
                    {
                        if (tc.alive)
                            if (tc.y + tc.h >= tank.y - tank.speed && tc.y <= tank.y && (tc.x <= tank.x && tank.x <= tc.x + tc.w || tc.x <= tank.x + tank.w && tank.x + tank.w <= tc.x + tc.w))
                                return false;
                    }

                    break;

                case Tank.Directions.Down:
                    if (tank.y + tank.h >= 600 - tank.speed)
                        return false;
                    
                    foreach (Wall wall in walls)
                    {
                        if (wall.y <= tank.y + tank.h + tank.speed  && wall.y + wall.h >= tank.y && (wall.x <= tank.x && tank.x <= wall.x + wall.w || wall.x <= tank.x + tank.w && tank.x + tank.w <= wall.x + wall.w))
                            return false;
                    }

                    foreach (TankController tc in tanks)
                    {
                        if (tc.alive)
                            if (tc.y <= tank.y + tank.h + tank.speed && tc.y + tc.h >= tank.y && (tc.x <= tank.x && tank.x <= tc.x + tc.w || tc.x <= tank.x + tank.w && tank.x + tank.w <= tc.x + tc.w))
                                return false;
                    }

                    break;

                case Tank.Directions.Left:
                    if (tank.x <= 0)
                        return false;

                    foreach (Wall wall in walls)
                    {
                        if (wall.x <= tank.x + tank.speed && wall.x + wall.w >= tank.x - tank.speed && (wall.y <= tank.y && tank.y <= wall.y + wall.h || wall.y <= tank.y + tank.h && tank.y + tank.h <= wall.y + wall.h))
                            return false;
                    }

                    foreach (TankController tc in tanks)
                    {
                        if (tc.alive)
                            if (tc.x <= tank.x + tank.speed && tc.x + tc.w >= tank.x - tank.speed && (tc.y <= tank.y && tank.y <= tc.y + tc.h || tc.y <= tank.y + tank.h && tank.y + tank.h <= tc.y + tc.h))
                                return false;
                    }

                    break;

                case Tank.Directions.Right:
                    if (tank.x + tank.w >= 600 - tank.speed)
                        return false;
                    foreach (Wall wall in walls)
                    {
                        if (wall.x <= tank.x + tank.w + tank.speed && wall.x + wall.w >= tank.x && (wall.y <= tank.y && tank.y <= wall.y + wall.h || wall.y <= tank.y + tank.h && tank.y + tank.h <= wall.y + wall.h))
                            return false;
                    }

                    foreach (TankController tc in tanks)
                    {
                        if (tc.alive)
                            if (tc.x <= tank.x + tank.w + tank.speed && tc.x + tc.w >= tank.x && (tc.y <= tank.y && tank.y <= tc.y + tc.h || tc.y <= tank.y + tank.h && tank.y + tank.h <= tc.y + tc.h))
                                return false;
                    }
                    break;
            }
            return true;
        }

        public void Move(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    tank.dir = Tank.Directions.Up;
                    break;
                case Keys.S:
                    tank.dir = Tank.Directions.Down;
                    break;
                case Keys.A:
                    tank.dir = Tank.Directions.Left;
                    break;
                case Keys.D:
                    tank.dir = Tank.Directions.Right;
                    break;
            }

            if (CanIMove())
            {
                tank.Move();
                SetPosition();
            }
        }

        public void GetHit(int damage)
        {
            tank.GetHit(damage);
            if (tank.hp <= 0)
                alive = false;
            if (tank.hp >= 0)
                progressHP.Value = tank.hp;
            else
                progressHP.Value = 0;
        }

        public void Shoot(List<Ammo> _ammos)
        {
            if (tank.allowShoot == true)
                _ammos.Add(tank.Shoot());
        }

        public void UpdateCooldown()
        {
            if (tank.allowShoot == false)
            {
                if (tank.cooldown > 0)
                {
                    tank.cooldown--;
                    if (tank.cooldown == 0)
                        tank.allowShoot = true;
                }
            }
        }

        public void Draw(Graphics g)
        {
            tank.Draw(g, Brushes.Black);
        }
    }
}
