using System;
using System.Collections.Generic;
using System.Text;

namespace AZH_Tankai_Server.Models.Bullets
{
    class Shrapnel : Bullet, ICloneable
    {
        public Shrapnel()
        {
            Velocity = 20;
            Random r = new Random();
            int direction = r.Next(0, 360);
            Direction = direction;
            SpawnTime = DateTime.Now.Ticks;
        }

        public Shrapnel(int Velocity, int Direction, long SpawnTime)
        {
            this.Velocity = Velocity;
            this.Direction = Direction;
            this.SpawnTime = SpawnTime;
        }

        public object Clone()
        {
            return new Shrapnel(this.Velocity, this.Direction, this.SpawnTime);
        }
    }
}
