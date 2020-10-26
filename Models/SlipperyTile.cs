using AZH_Tankai_Shared;

namespace AZH_Tankai_Server.Models
{
    public class SlipperyTile : Tile
    {
        public SlipperyTile(Point location)
        {
            Location = location;
        }

        public override TileType GetTileType()
        {
            return TileType.SlipperyTile;
        }

        public override double GetTileSpeedModifier(double currentSpeed)
        {
            return 2;
        }
    }
}
