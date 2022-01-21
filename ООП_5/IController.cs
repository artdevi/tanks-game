using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП_5
{
    interface IController
    {
        void SetPosition();
        //bool CanIMove();
        //void Shoot(List<Ammo> _ammos);
        void GetHit(int damage);
        void UpdateCooldown();
        void Draw(Graphics g);
    }
}
