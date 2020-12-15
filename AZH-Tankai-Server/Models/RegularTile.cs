using AZH_Tankai_Shared;

namespace AZH_Tankai_Server.Models
{
    public class RegularTile : Tile
    {
        public RegularTile(Point location)
        {
            Location = location;
        }

        public override TileType GetTileType()
        {
            return TileType.RegularTile;
        }

        public override double GetTileSpeedModifier(double currentSpeed)
        {
            return 1;
        }
    }
}
