using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AZH_Tankai_Server.Models.Bullets
{
    class Bullet
    {
        public int Velocity { get; set; }
        public int Direction { get; set; }
        public long SpawnTime { get; set; }
    }
}
