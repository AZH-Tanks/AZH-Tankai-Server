using AZH_Tankai_Server.Controllers.Maze;
using AZH_Tankai_Server.Models;
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
            int width = rng.Next(30, 50);
            int height = rng.Next(30, 50);
            return mazeBuilder.Reset().AddTiles(height, width).Create();
        }
    }
}
