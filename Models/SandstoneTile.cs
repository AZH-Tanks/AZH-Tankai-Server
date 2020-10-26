using AZH_Tankai_Shared;

namespace AZH_Tankai_Server.Models
{
    public class SandstoneTile : RegularTile
    {
        private double sandCoverage;
        public SandstoneTile(Point location, double sandCoverage) : base(location)
        {
            this.sandCoverage = sandCoverage;
        }

        // TODO(MantasGra): Add more types for different sand coverage values.
        public override TileType GetTileType()
        {
            return TileType.SandstoneTile;
        }

        public override double GetTileSpeedModifier(double currentSpeed)
        {
            double baseModifier = base.GetTileSpeedModifier(currentSpeed);
            return baseModifier + sandCoverage * 0.01;
        }

        public override void EnterTile(Tile fromTile)
        {
            if (fromTile is SandTile || fromTile is QuicksandTile)
            {
                sandCoverage++;
            }
        }
    }
}
