using AZH_Tankai_Shared;
using System;

namespace AZH_Tankai_Server.Models
{
    public class PavedRoadTile : RegularTile
    {
        private const double PotholeChance = 0.2;
        private readonly bool hasPothole;

        public PavedRoadTile(Point location) : base(location)
        {
            Random rng = new Random();
            hasPothole = rng.NextDouble() < PotholeChance;
        }

        // TODO(MantasGra): Add new type for when a tile is with pothole
        public override TileType GetTileType()
        {
            return TileType.PavedRoadTile;
        }

        public override double GetTileSpeedModifier(double currentSpeed = 0)
        {
            double baseModifier = base.GetTileSpeedModifier(currentSpeed);
            return baseModifier - (hasPothole ? 0.3 : 0);
        }
    }
}
