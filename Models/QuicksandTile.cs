using AZH_Tankai_Shared;
using System.Timers;

namespace AZH_Tankai_Server.Models
{
    public class QuicksandTile : StickyTile
    {
        private readonly Timer sinkTimer;
        private double sinkAmount;
        private int entitiesOnBoard;
        private readonly object syncLock = new object();

        public QuicksandTile(Point location) : base(location)
        {
            sinkAmount = 0;
            entitiesOnBoard = 0;
            sinkTimer = new Timer(1000);
            sinkTimer.Elapsed += OnSink;
        }

        // TODO(MantasGra): Add more types for different sink amounts.
        public override TileType GetTileType()
        {
            return TileType.QuicksandTile;
        }

        public override double GetTileSpeedModifier(double currentSpeed)
        {
            double baseModifier = base.GetTileSpeedModifier(currentSpeed);
            return baseModifier - sinkAmount * 0.01;
        }

        public override void EnterTile(Tile fromTile)
        {
            lock (syncLock)
            {
                if (entitiesOnBoard == 0)
                {
                    sinkTimer.Enabled = true;
                }
                entitiesOnBoard++;
            }
        }

        public override void LeaveTile(Tile toTile)
        {
            lock (syncLock)
            {
                entitiesOnBoard--;
                if (entitiesOnBoard == 0)
                {
                    sinkTimer.Enabled = false;
                }
            }
        }

        private void OnSink(object source, ElapsedEventArgs e)
        {
            sinkAmount++;
        }
    }
}
