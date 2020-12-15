using AZH_Tankai_Shared;
using System;
using System.Timers;

namespace AZH_Tankai_Server.Models
{
    public class MudRoadTile : StickyTile
    {
        private const double ChanceToGetStuck = 0.1;
        private const double ChanceToBreakFree = 0.8;
        private readonly Random rng;
        private bool isStuck;

        public MudRoadTile(Point location) : base(location)
        {
            isStuck = false;
            rng = new Random();
            Timer timer = new Timer(500);
            timer.Elapsed += OnTick;
            timer.Enabled = true;
        }

        public override TileType GetTileType()
        {
            return TileType.MudRoadTile;
        }

        public override double GetTileSpeedModifier(double currentSpeed)
        {
            double baseModifier = base.GetTileSpeedModifier(currentSpeed);
            return isStuck ? 0 : baseModifier;
        }

        private void OnTick(object source, ElapsedEventArgs e)
        {
            if (!isStuck && rng.NextDouble() < ChanceToGetStuck)
            {
                isStuck = true;
            }
            else if (isStuck && rng.NextDouble() < ChanceToBreakFree)
            {
                isStuck = false;
            }
        }

    }
}
