using System;
using System.Collections.Generic;
using System.Text;

namespace AZH_Tankai_Server.Models.Bullets
{
    interface BulletFactory
    {
        public Bullet createBullet();
    }
}
