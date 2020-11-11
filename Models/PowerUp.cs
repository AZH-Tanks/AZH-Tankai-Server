using AZH_Tankai_Shared;

namespace AZH_Tankai_Server.Models
{
    public class PowerUp
    {
        public PowerUpType Type { get; set; }
        public Point Location { get; set; }

        public PowerUp() { }

        public PowerUp(PowerUpType type, Point point)
        {
            Type = type;
            Location = point;
        }
    }
}