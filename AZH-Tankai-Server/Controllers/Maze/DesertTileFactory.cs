using AZH_Tankai_Server.Models;

namespace AZH_Tankai_Server.Controllers.Maze
{
    public class DesertTileFactory : AbstractTileFactory
    {
        public override RegularTile CreateRegularTile(int x, int y)
        {
            return new SandstoneTile(new Point(x, y), 0);
        }

        public override SlipperyTile CreateSlipperyTile(int x, int y)
        {
            return new SandTile(new Point(x, y));
        }

        public override StickyTile CreateStickyTile(int x, int y)
        {
            return new QuicksandTile(new Point(x, y));
        }
    }
}
