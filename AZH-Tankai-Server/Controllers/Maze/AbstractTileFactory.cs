using AZH_Tankai_Server.Models;

namespace AZH_Tankai_Server.Controllers.Maze
{
    public abstract class AbstractTileFactory
    {
        public abstract SlipperyTile CreateSlipperyTile(int x, int y);
        public abstract RegularTile CreateRegularTile(int x, int y);
        public abstract StickyTile CreateStickyTile(int x, int y);
    }
}
