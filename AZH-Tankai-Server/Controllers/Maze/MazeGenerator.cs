using AZH_Tankai_Server.Controllers.Maze;
using AZH_Tankai_Server.Controllers.Maze.MazeWallGenerationAlgorithms.DFS;
using System;

namespace AZH_Tankai_Server.Controllers
{
    public class MazeGenerator
    {
        private readonly IMazeBuilder mazeBuilder;
        private readonly Random rng;

        public MazeGenerator()
        {
            mazeBuilder = new EasyMazeBuilder();
            rng = new Random();
        }

        public Models.Maze GenerateMaze()
        {
            int width = rng.Next(15, 20);
            int height = rng.Next(15, 20);
            return mazeBuilder.SetDimensions(height, width).AddTiles().AddWalls(new WallGenerator(width, height)).Create();
        }
    }
}
