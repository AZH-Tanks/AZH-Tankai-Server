using AZH_Tankai_Shared;
using System;

namespace AZH_Tankai_Server.Models
{
    public class StoneRoadTile : SlipperyTile
    {
        private readonly Random rng;
        public StoneRoadTile(Point location) : base(location)
        {
            rng = new Random();
        }

        public override TileType GetTileType()
        {
            return TileType.StoneRoadTile;
        }

        public override double GetTileSpeedModifier(double currentSpeed)
        {
            double baseModifier = base.GetTileSpeedModifier(currentSpeed);
            return baseModifier + (rng.NextDouble() - 0.5);
        }
    }
}
