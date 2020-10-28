using AZH_Tankai_Shared;

namespace AZH_Tankai_Server.Models
{
    public class SandTile : SlipperyTile
    {
        public SandTile(Point location) : base(location) { }

        public override TileType GetTileType()
        {
            return TileType.SandTile;
        }
    }
}
