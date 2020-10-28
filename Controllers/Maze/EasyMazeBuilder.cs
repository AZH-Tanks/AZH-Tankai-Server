using AZH_Tankai_Server.Controllers.Maze.MazeWallGenerationAlgorithms;
using AZH_Tankai_Server.Controllers.Maze.MazeWallGenerationAlgorithms.DFS;
using AZH_Tankai_Server.Models;
using AZH_Tankai_Shared;
using System;
using System.Collections.Generic;

namespace AZH_Tankai_Server.Controllers.Maze
{
    public class EasyMazeBuilder : IMazeBuilder
    {
        private const double SlipperyTileChance = 0.1;
        private const double StickyTileChance = 0.1;
        private const double SandMazeChance = 0.3;
        private List<List<Tile>> tiles;
        private List<List<Wall>> walls;
        private int height = 10;
        private int width = 10;
        private readonly Random rng;
        private readonly AbstractTileFactory tileFactory;
        public EasyMazeBuilder()
        {
            rng = new Random();
            if (rng.NextDouble() < SandMazeChance)
            {
                tileFactory = new DesertTileFactory();
            }
            else
            {
                tileFactory = new CityTileFactory();
            }
        }

        public IMazeBuilder SetDimensions(int height, int width)
        {
            this.height = height;
            this.width = width;
            return this;
        }

        public IMazeBuilder AddTiles()
        {
            if (tiles == null)
            {
                tiles = new List<List<Tile>>();
            }
            for (int i = 0; i < height; i++)
            {
                List<Tile> tileRow = new List<Tile>();
                for (int j = 0; j < width; j++)
                {
                    double tileTypeRoll = rng.NextDouble();
                    if (tileTypeRoll < SlipperyTileChance)
                    {
                        tileRow.Add(tileFactory.CreateSlipperyTile(i, j));
                    }
                    else if (tileTypeRoll >= SlipperyTileChance && tileTypeRoll < SlipperyTileChance + StickyTileChance)
                    {
                        tileRow.Add(tileFactory.CreateStickyTile(i, j));
                    }
                    else
                    {
                        tileRow.Add(tileFactory.CreateRegularTile(i, j));
                    }
                }
                tiles.Add(tileRow);
            }
            return this;
        }

        public IMazeBuilder AddWalls()
        {
            IWallGenerator wallGenerator = new WallGenerator(width, height);
            List<List<TileWallsState>> mazeWallStates = wallGenerator.GenerateWalls();
            walls = new List<List<Wall>>();
            foreach (List<TileWallsState> wallStateRow in mazeWallStates)
            {
                List<Wall> wallRow = new List<Wall>();
                foreach (TileWallsState wallState in wallStateRow)
                {
                    wallRow.Add(new Wall(wallState, true));
                }
                walls.Add(wallRow);
            }
            return this;
        }

        public Models.Maze Create()
        {
            return new Models.Maze(tiles, walls, width, height);
        }

        public IMazeBuilder Reset()
        {
            tiles = null;
            walls = null;
            width = 10;
            height = 10;
            return this;
        }
    }
}
