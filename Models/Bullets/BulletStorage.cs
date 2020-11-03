using System;
using System.Collections.Generic;
using System.Text;

namespace AZH_Tankai_Server.Models.Bullets
{
    class BulletStorage
    {
        static object thisLock = new object();
        private BulletStorage()
        {
            bullets = new List<Bullet>();
        }

        private static BulletStorage singleton;
        public static BulletStorage Get()
        {
            lock (thisLock)
            {
                if (singleton == null)
                {
                    singleton = new BulletStorage();
                }
                return singleton;
            }
        }

        readonly List<Bullet> bullets;

        public void Add(Bullet bullet)
        {
            bullets.Add(bullet);
        }
    }
}
