using System;
using System.Collections.Generic;
using System.Text;

namespace AZH_Tankai_Server.Models.Bullets
{
    abstract class Bullet
    {
        public int Velocity { get; set; }
        public int Direction { get; set; }
        public int SpawnTime { get; set; }
    }
}
