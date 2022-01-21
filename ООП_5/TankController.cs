using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ООП_5
{
    class TankController : IController
    {
        Tank tank;
        public bool alive;
        public float x, y;
        public float cx, cy;
        int currentWay;
        int maxWay;
        int visibleRange;
        Random rnd = new Random();

        public float w { get; private set; }
        public float h { get; private set; }

        public TankController(float _x, float _y)
        {
            tank = new Tank(_x, _y);
            tank.SetRandomDirection();
            alive = true;
            SetNewMaxWay();
            currentWay = 0;
            w = h = 30;
            visibleRange = 150;
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

        public void SetPosition()
        {
            x = tank.x;
            y = tank.y;
            cx = x + w / 2;
            cy = y + w / 2;
        }

        public void SetNewMaxWay()
        {
            maxWay = 100 + rnd.Next() % 500;
        }

        public bool CanIMove(List<Wall> _walls, List<TankController> _tanks, Player _pl)
        {
            switch (tank.dir)
            {
                case Tank.Directions.Up:
                    if (tank.y <= 0)
                        return false;

                    foreach (Wall wall in _walls)
                    {
                        if (wall.y + wall.h >= tank.y - tank.speed && wall.y <= tank.y && (wall.x <= tank.x && tank.x <= wall.x + wall.w || wall.x <= tank.x + tank.w && tank.x + tank.w <= wall.x + wall.w))
                            return false;
                    }

                    foreach (TankController tc in _tanks)
                    {
                        if (tc != this)
                            if (tc.y + tc.h >= tank.y - tank.speed && tc.y <= tank.y && (tc.x <= tank.x && tank.x <= tc.x + tc.w || tc.x <= tank.x + tank.w && tank.x + tank.w <= tc.x + tc.w))
                                return false;
                    }

                    if (_pl.y + _pl.h >= tank.y - tank.speed && _pl.y <= tank.y && (_pl.x <= tank.x && tank.x <= _pl.x + _pl.w || _pl.x <= tank.x + tank.w && tank.x + tank.w <= _pl.x + _pl.w))
                        return false;

                    break;

                case Tank.Directions.Down:
                    if (tank.y + tank.h >= 600 - tank.speed)
                        return false;

                    foreach (Wall wall in _walls)
                    {
                        if (wall.y <= tank.y + tank.h + tank.speed && wall.y + wall.h >= tank.y && (wall.x <= tank.x && tank.x <= wall.x + wall.w || wall.x <= tank.x + tank.w && tank.x + tank.w <= wall.x + wall.w))
                            return false;
                    }

                    foreach (TankController tc in _tanks)
                    {
                        if (tc != this)
                            if (tc.y <= tank.y + tank.h + tank.speed && tc.y + tc.h >= tank.y && (tc.x <= tank.x && tank.x <= tc.x + tc.w || tc.x <= tank.x + tank.w && tank.x + tank.w <= tc.x + tc.w))
                                return false;
                    }

                    if (_pl.y <= tank.y + tank.h + tank.speed && _pl.y + _pl.h >= tank.y && (_pl.x <= tank.x && tank.x <= _pl.x + _pl.w || _pl.x <= tank.x + tank.w && tank.x + tank.w <= _pl.x + _pl.w))
                        return false;

                    break;

                case Tank.Directions.Left:
                    if (tank.x <= 0)
                        return false;

                    foreach (Wall wall in _walls)
                    {
                        if (wall.x <= tank.x + tank.speed && wall.x + wall.w >= tank.x - tank.speed && (wall.y <= tank.y && tank.y <= wall.y + wall.h || wall.y <= tank.y + tank.h && tank.y + tank.h <= wall.y + wall.h))
                            return false;
                    }

                    foreach (TankController tc in _tanks)
                    {
                        if (tc != this)
                            if (tc.x <= tank.x + tank.speed && tc.x + tc.w >= tank.x - tank.speed && (tc.y <= tank.y && tank.y <= tc.y + tc.h || tc.y <= tank.y + tank.h && tank.y + tank.h <= tc.y + tc.h))
                                return false;
                    }

                    if (_pl.x <= tank.x + tank.speed && _pl.x + _pl.w >= tank.x - tank.speed && (_pl.y <= tank.y && tank.y <= _pl.y + _pl.h || _pl.y <= tank.y + tank.h && tank.y + tank.h <= _pl.y + _pl.h))
                        return false;

                    break;

                case Tank.Directions.Right:
                    if (tank.x + tank.w >= 600 - tank.speed)
                        return false;
                    foreach (Wall wall in _walls)
                    {
                        if (wall.x <= tank.x + tank.w + tank.speed && wall.x + wall.w >= tank.x && (wall.y <= tank.y && tank.y <= wall.y + wall.h || wall.y <= tank.y + tank.h && tank.y + tank.h <= wall.y + wall.h))
                            return false;
                    }

                    foreach (TankController tc in _tanks)
                    {
                        if (tc != this)
                            if (tc.x <= tank.x + tank.w + tank.speed && tc.x + tc.w >= tank.x && (tc.y <= tank.y && tank.y <= tc.y + tc.h || tc.y <= tank.y + tank.h && tank.y + tank.h <= tc.y + tc.h))
                                return false;
                    }

                    if (_pl.x <= tank.x + tank.w + tank.speed && _pl.x + _pl.w >= tank.x && (_pl.y <= tank.y && tank.y <= _pl.y + _pl.h || _pl.y <= tank.y + tank.h && tank.y + tank.h <= _pl.y + _pl.h))
                        return false;

                    break;
            }
            return true;
        }

        public void Move(List<Wall> _walls, List<TankController> _tanks, Player _pl)
        {
            rnd = new Random();
            if (currentWay > maxWay)
            {
                currentWay = 0;
                tank.SetRandomDirection();
                SetNewMaxWay();
            }

            while (!CanIMove(_walls, _tanks, _pl))
            {
                currentWay = 0;
                tank.SetRandomDirection();
                SetNewMaxWay();
            }

            tank.Move();
            SetPosition();
            currentWay += tank.speed;
        }

        public bool IsPlayerVisible(Player _pl)
        {
            if (Math.Abs(cx - _pl.cx) < 150 || Math.Abs(cy - _pl.cy) < 150)
                return true;
            else return false;
        }
        
        public void Pursuit(Player _pl)
        {
            if (Math.Abs(cx - _pl.cx) < 100 && Math.Abs(cy - _pl.cy) < 100)
            {
                if (Math.Abs(cx - _pl.cx) > Math.Abs(cy - _pl.cy))
                {
                    if (cx > _pl.cx)
                    {
                        tank.dir = Tank.Directions.Left;
                    }
                    else
                    {
                        tank.dir = Tank.Directions.Right;
                    }
                    //tank.Move();
                }
                else
                {
                    if (cy > _pl.cy)
                    {
                        tank.dir = Tank.Directions.Up;
                    }
                    else
                    {
                        tank.dir = Tank.Directions.Down;
                    }
                    //tank.Move();
                }

            }
        }

        public bool ShouldIShoot(Player _pl)
        {
            if (tank.allowShoot)
            {
                if (Math.Abs(_pl.cx - cx) <= visibleRange && Math.Abs(_pl.cy - cy) <= visibleRange)
                {
                    if (_pl.x < cx && cx < _pl.x + _pl.w)
                    {
                        if (_pl.y < cy)
                        {
                            tank.dir = Tank.Directions.Up;
                            return true;
                        }
                        else if (_pl.y > cy)
                        {
                            tank.dir = Tank.Directions.Down;
                            return true;
                        }
                    }

                    if (_pl.y < cy && cy < _pl.y + _pl.h)
                    {
                        if (_pl.x < cx)
                        {
                            tank.dir = Tank.Directions.Left;
                            return true;
                        }
                        else if (_pl.x > cx)
                        {
                            tank.dir = Tank.Directions.Right;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void TryShoot(List<Ammo> _ammos, Player _pl)
        {
            if (ShouldIShoot(_pl))
                _ammos.Add(tank.Shoot());
        }

        public void GetHit(int damage)
        {
            tank.GetHit(damage);
            if (tank.hp <= 0)
                alive = false;
        }

        public void Draw(Graphics g)
        {
            tank.Draw(g, Brushes.DarkGreen);
        }
    }
}
