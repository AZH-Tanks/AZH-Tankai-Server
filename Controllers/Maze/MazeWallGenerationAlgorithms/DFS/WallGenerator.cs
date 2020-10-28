using AZH_Tankai_Server.Models;
using AZH_Tankai_Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AZH_Tankai_Server.Controllers.Maze.MazeWallGenerationAlgorithms.DFS
{
    public class WallGenerator : IWallGenerator
    {
        private readonly List<List<TileWallsState>> walls;
        private readonly int width;
        private readonly int height;
        private readonly Random rng;

        public WallGenerator(int width, int height)
        {
            this.width = width;
            this.height = height;
            walls = new List<List<TileWallsState>>();
            for (int i = 0; i < height; i++)
            {
                List<TileWallsState> wallRow = new List<TileWallsState>();
                for (int j = 0; j < width; j++)
                {
                    wallRow.Add(TileWallsState.All);
                }
                walls.Add(wallRow);
            }
            rng = new Random();
        }

        private IEnumerable<RemoveWallAction> GetNeighbours(Point point)
        {
            if (point.X > 0)
            {
                yield return new RemoveWallAction { Neighbour = new Point(point.X - 1, point.Y), Wall = TileWallsState.Left };
            }
            if (point.Y > 0)
            {
                yield return new RemoveWallAction { Neighbour = new Point(point.X, point.Y - 1), Wall = TileWallsState.Top };
            }
            if (point.X < width - 1)
            {
                yield return new RemoveWallAction { Neighbour = new Point(point.X + 1, point.Y), Wall = TileWallsState.Right };
            }
            if (point.Y < height - 1)
            {
                yield return new RemoveWallAction { Neighbour = new Point(point.X, point.Y + 1), Wall = TileWallsState.Bottom };
            }
        }

        private void VisitCell(int x, int y)
        {
            walls[y][x] |= TileWallsState.Visited;
            foreach (RemoveWallAction removeAction in
                GetNeighbours(new Point(x, y))
                    .Shuffle(rng)
                    .Where(removeAction =>
                        !walls[(int)removeAction.Neighbour.Y][(int)removeAction.Neighbour.X]
                            .HasFlag(TileWallsState.Visited)))
            {
                walls[y][x] -= removeAction.Wall;
                walls[(int)removeAction.Neighbour.Y][(int)removeAction.Neighbour.X] -= removeAction.Wall.OppositeWall();
                VisitCell((int)removeAction.Neighbour.X, (int)removeAction.Neighbour.Y);
            }
        }

        public List<List<TileWallsState>> GenerateWalls()
        {
            VisitCell(rng.Next(width), rng.Next(height));
            return walls;
        }

    }
}
