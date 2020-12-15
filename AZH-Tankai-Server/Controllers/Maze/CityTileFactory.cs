using AZH_Tankai_Server.Models;

namespace AZH_Tankai_Server.Controllers.Maze
{
    public class CityTileFactory : AbstractTileFactory
    {
        public override RegularTile CreateRegularTile(int x, int y)
        {
            return new PavedRoadTile(new Point(x, y));
        }

        public override SlipperyTile CreateSlipperyTile(int x, int y)
        {
            return new StoneRoadTile(new Point(x, y));
        }

        public override StickyTile CreateStickyTile(int x, int y)
        {
            return new MudRoadTile(new Point(x, y));
        }
    }
}
