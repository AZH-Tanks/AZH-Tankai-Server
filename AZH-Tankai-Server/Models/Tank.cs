using AZH_Tankai_Server.Controllers.Collision;

namespace AZH_Tankai_Server.Models
{
    public class Tank : CollisionComponent
    {
        public string Color { get; set; }
        public int BulletCount { get; set; }
        public int BaseSpeed { get; set; }

        public double X { get; set; }
        public double Y { get; set; }

        public Tank(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override bool CheckCollisions(CollisionObject collisionObject)
        {
            return false;
        }
    }
}
