using AZH_Tankai_Server.Models;
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

        public IMazeBuilder AddTiles(int height, int width)
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

        public Models.Maze Create()
        {
            return new Models.Maze(tiles);
        }

        public IMazeBuilder Reset()
        {
            tiles = null;
            return this;
        }
    }
}
