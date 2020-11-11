using System;
using System.Collections.Generic;
using System.Text;

namespace AZH_Tankai_Server.Models.Bullets
{
    class BulletFactory
    {
        public Bullet createBullet(string type, int x, int y)
        {
            switch (type)
            {
                case "Basic":
                    {
                        var bullet = new BasicBullet();
                        bullet.Type = type;
                        bullet.Location = new Point(x, y);
                        bullet.Velocity = 5;
                        bullet.SpawnTime = DateTime.Now.Ticks;
                        return bullet;
                    };
                case "Laser":
                    {
                        var bullet = new Laser();
                        bullet.Type = type;
                        bullet.Location = new Point(x, y);
                        bullet.Velocity = 15;
                        bullet.SpawnTime = DateTime.Now.Ticks;
                        return bullet;
                    };
                case "Shrapnel":
                    {
                        var bullet = new Shrapnel();
                        bullet.Type = type;
                        bullet.Location = new Point(x, y);
                        bullet.Velocity = 10;
                        bullet.SpawnTime = DateTime.Now.Ticks;
                        return bullet;
                    };
                case "HomingMissile": return new HomingMissile();
                case "Exploding": return new ExplodingBullet();
                case "Machinegun": return new MachinegunBullet();
                default: return new BasicBullet();
            }
        }
    }
}
