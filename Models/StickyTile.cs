using AZH_Tankai_Shared;

namespace AZH_Tankai_Server.Models
{
    public class StickyTile : Tile
    {
        public StickyTile(Point location)
        {
            Location = location;
        }

        public override TileType GetTileType()
        {
            return TileType.StickyTile;
        }

        public override double GetTileSpeedModifier(double currentSpeed)
        {
            return 0.5;
        }
    }
}
