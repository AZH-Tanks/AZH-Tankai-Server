using AZH_Tankai_Server.Controllers.Maze;
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
            return mazeBuilder.Reset().SetDimensions(height, width).AddTiles().AddWalls().Create();
        }
    }
}
