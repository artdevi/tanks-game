using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ООП_5
{
    class Game
    {
        Random rnd = new Random();
        public List<TankController> tanks;
        public List<Wall> walls;
        public List<Ammo> ammos;
        public Player player;

        ProgressBar progressHP;

        public bool isGameActive;

        public Game(ProgressBar _progressHP)
        {
            progressHP = _progressHP;
            isGameActive = false;
        }

        public void Init()
        {
            tanks = new List<TankController>();
            walls = new List<Wall>();
            player = new Player(285, 500, tanks, walls, progressHP);
            ammos = new List<Ammo>();
            CreateWalls();
            CreateBots(5);
        }

        private void CreateBots(int count)
        {
            for (int i = 0; i < count; i++)
            {
                TankController newBot = new TankController(rnd.Next() % 570, rnd.Next() % 570);

                bool isThereCollision = false;

                /*foreach (Wall wall in walls)
                {
                    if (wall.x <= newBot.x && newBot.x <= wall.x + wall.w && wall.y <= newBot.y && newBot.y <= wall.y + wall.h)
                        isThereCollision = true;
                    if (wall.x <= newBot.x + newBot.w && newBot.x + newBot.w <= wall.x + wall.w && wall.y <= newBot.y && newBot.y <= wall.y + wall.h)
                        isThereCollision = true;
                    if (wall.x <= newBot.x && newBot.x <= wall.x + wall.w && wall.y <= newBot.y + newBot.h && newBot.y + newBot.h <= wall.y + wall.h)
                        isThereCollision = true;
                    if (wall.x <= newBot.x + newBot.w && newBot.x + newBot.w <= wall.x + wall.w && wall.y <= newBot.y + newBot.h && newBot.y + newBot.h <= wall.y + wall.h)
                        isThereCollision = true;
                }

                /*foreach (TankController tc in tanks)
                {
                    if (tc.x <= newBot.x && newBot.x <= tc.x + tc.w && tc.y <= newBot.y && newBot.y <= tc.y + tc.h)
                        isThereCollision = true;
                    if (tc.x <= newBot.x + newBot.w && newBot.x + newBot.w <= tc.x + tc.w && tc.y <= newBot.y && newBot.y <= tc.y + tc.h)
                        isThereCollision = true;
                    if (tc.x <= newBot.x && newBot.x <= tc.x + tc.w && tc.y <= newBot.y + newBot.h && newBot.y + newBot.h <= tc.y + tc.h)
                        isThereCollision = true;
                    if (tc.x <= newBot.x + newBot.w && newBot.x + newBot.w <= tc.x + tc.w && tc.y <= newBot.y + newBot.h && newBot.y + newBot.h <= tc.y + tc.h)
                        isThereCollision = true;
                }
                    
                if (player.x <= newBot.x && newBot.x <= player.x + player.w && player.y <= newBot.y && newBot.y <= player.y + player.h)
                    isThereCollision = true;
                if (player.x <= newBot.x + newBot.w && newBot.x + newBot.w <= player.x + player.w && player.y <= newBot.y && newBot.y <= player.y + player.h)
                    isThereCollision = true;
                if (player.x <= newBot.x && newBot.x <= player.x + player.w && player.y <= newBot.y + newBot.h && newBot.y + newBot.h <= player.y + player.h)
                    isThereCollision = true;
                if (player.x <= newBot.x + newBot.w && newBot.x + newBot.w <= player.x + player.w && player.y <= newBot.y + newBot.h && newBot.y + newBot.h <= player.y + player.h)
                    isThereCollision = true;*/

                /*while (isThereCollision)
                {
                    newBot = new TankController(rnd.Next() % 570, rnd.Next() % 570);
                    isThereCollision = false;

                    foreach (Wall wall in walls)
                    {
                        if (wall.x <= newBot.x && newBot.x <= wall.x + wall.w && wall.y <= newBot.y && newBot.y <= wall.y + wall.h)
                            isThereCollision = true;
                        if (wall.x <= newBot.x + newBot.w && newBot.x + newBot.w <= wall.x + wall.w && wall.y <= newBot.y && newBot.y <= wall.y + wall.h)
                            isThereCollision = true;
                        if (wall.x <= newBot.x && newBot.x <= wall.x + wall.w && wall.y <= newBot.y + newBot.h && newBot.y + newBot.h <= wall.y + wall.h)
                            isThereCollision = true;
                        if (wall.x <= newBot.x + newBot.w && newBot.x + newBot.w <= wall.x + wall.w && wall.y <= newBot.y + newBot.h && newBot.y + newBot.h <= wall.y + wall.h)
                            isThereCollision = true;
                    }
                    foreach (TankController tc in tanks)
                    {
                        if (tc.x <= newBot.x && newBot.x <= tc.x + tc.w && tc.y <= newBot.y && newBot.y <= tc.y + tc.h)
                            isThereCollision = true;
                        if (tc.x <= newBot.x + newBot.w && newBot.x + newBot.w <= tc.x + tc.w && tc.y <= newBot.y && newBot.y <= tc.y + tc.h)
                            isThereCollision = true;
                        if (tc.x <= newBot.x && newBot.x <= tc.x + tc.w && tc.y <= newBot.y + newBot.h && newBot.y + newBot.h <= tc.y + tc.h)
                            isThereCollision = true;
                        if (tc.x <= newBot.x + newBot.w && newBot.x + newBot.w <= tc.x + tc.w && tc.y <= newBot.y + newBot.h && newBot.y + newBot.h <= tc.y + tc.h)
                            isThereCollision = true;
                    }
                    if (player.x <= newBot.x && newBot.x <= player.x + player.w && player.y <= newBot.y && newBot.y <= player.y + player.h)
                        isThereCollision = true;
                    if (player.x <= newBot.x + newBot.w && newBot.x + newBot.w <= player.x + player.w && player.y <= newBot.y && newBot.y <= player.y + player.h)
                        isThereCollision = true;
                    if (player.x <= newBot.x && newBot.x <= player.x + player.w && player.y <= newBot.y + newBot.h && newBot.y + newBot.h <= player.y + player.h)
                        isThereCollision = true;
                    if (player.x <= newBot.x + newBot.w && newBot.x + newBot.w <= player.x + player.w && player.y <= newBot.y + newBot.h && newBot.y + newBot.h <= player.y + player.h)
                        isThereCollision = true;
                }*/
                //if (!isThereCollision)
                tanks.Add(newBot);
                Thread.Sleep(50);
            }
        }

        private void CreateWalls()
        {
            walls.Add(new Wall(80, 300, 100, 100));
        }

        private void CheckHit()
        {
            foreach (Ammo ammo in ammos)
            {
                if (!ammo.burst)
                {
                    foreach (TankController tc in tanks)
                    {
                        if (tc.alive)
                            if ((ammo.x + ammo.speed > tc.x && ammo.x < tc.x + tc.w) && (ammo.y + ammo.speed > tc.y && ammo.y + ammo.speed < tc.y + tc.h))
                            {
                                tc.GetHit(30);
                                ammo.burst = true;
                            }
                    }

                    foreach (Wall wall in walls)
                    {
                        if ((ammo.x > wall.x && ammo.x < wall.x + wall.w) && (ammo.y > wall.y && ammo.y < wall.y + wall.h))
                            ammo.burst = true;
                    }

                    if ((ammo.x + ammo.speed > player.x && ammo.x < player.x + player.w) && (ammo.y + ammo.speed > player.y && ammo.y + ammo.speed < player.y + player.h))
                    {
                        player.GetHit(10);
                        ammo.burst = true;
                    }

                    if (ammo.x < 0 || ammo.y < 0 || ammo.x > 600 || ammo.y > 600) ammo.burst = true;
                }
            }
        }

        public void Pursuit()
        {
            foreach (TankController tc in tanks)
                if (tc.alive)
                {
                    //if (tc.IsPlayerVisible(player))
                    tc.Pursuit(player);
                }
        }

        public void GameControl()
        {
            CheckHit();

            foreach (TankController tc in tanks)
                if (tc.alive)
                {
                    tc.TryShoot(ammos, player);
                    tc.Move(walls, tanks, player);
                }

            foreach (Ammo ammo in ammos)
                if (!ammo.burst)
                    ammo.ChangePosition();
        }

        public void DrawObjects(Graphics g)
        {
            player.Draw(g);

            foreach (TankController tc in tanks)
                if (tc.alive)
                    tc.Draw(g);

            foreach (Wall wall in walls)
                wall.Draw(g, Brushes.SaddleBrown);

            foreach (Ammo ammo in ammos)
                if (!ammo.burst)
                    ammo.Draw(g);
        }

        public void UpdateCooldowns()
        {
            foreach (TankController tc in tanks)
                tc.UpdateCooldown();
            player.UpdateCooldown();
        }

        public bool isOver()
        {
            if (isGameActive)
            {
                if (!player.alive) return true;
                int tanksCount = 0;
                foreach (TankController tc in tanks)
                    if (tc.alive) tanksCount++;
                if (tanksCount == 0) return true;
            }
            return false;
        }
    }
}
