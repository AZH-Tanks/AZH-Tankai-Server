using System;
using System.Collections.Generic;
using System.Text;

namespace AZH_Tankai_Server.Models.Bullets
{
    class BulletFactory
    {
        public Bullet createBullet(string type)
        { 
            switch(type)
            {
                case "Basic": return new BasicBullet();
                case "Laser": return new Laser();
                case "Shrapnel": return new Shrapnel();
                case "HomingMissile": return new HomingMissile();
                case "Exploding": return new ExplodingBullet();
                case "Machinegun": return new MachinegunBullet();
                default: return new BasicBullet();
            }
        }
    }
}
