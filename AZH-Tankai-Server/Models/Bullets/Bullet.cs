using System;
using AZH_Tankai_Shared;

namespace AZH_Tankai_Server.Models.Bullets
{
    public class Bullet
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public Point Location { get; set; }
        public int Velocity { get; set; }
        public int Direction { get; set; }
        public long SpawnTime { get; set; }

        public Bullet()
        {
            Id = Guid.NewGuid().ToString().Replace('-', '_').Insert(0, "_");
        }

        public BulletDTO GetBulletDTO()
        {
            return new BulletDTO
            {
                Id = Id,
                Direction = Direction,
                Type = Type,
                X = Location.X,
                Y = Location.Y
            };
        }
    }
}
