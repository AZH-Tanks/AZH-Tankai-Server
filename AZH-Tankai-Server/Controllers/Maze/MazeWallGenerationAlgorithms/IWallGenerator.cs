using AZH_Tankai_Shared;
using System.Collections.Generic;

namespace AZH_Tankai_Server.Controllers.Maze.MazeWallGenerationAlgorithms
{
    public interface IWallGenerator
    {
        public List<List<TileWallsState>> GenerateWalls();
    }
}
