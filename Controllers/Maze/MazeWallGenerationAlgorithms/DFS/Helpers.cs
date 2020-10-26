using AZH_Tankai_Server.Models;
using AZH_Tankai_Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AZH_Tankai_Server.Controllers.Maze.MazeWallGenerationAlgorithms.DFS
{
    public static class Extensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
        {
            List<T> list = source.ToList();
            for (int i = list.Count - 1; i >= 0; i--)
            {
                int swapIndex = rng.Next(i + 1);
                yield return list[swapIndex];
                list[swapIndex] = list[i];
            }
        }

        public static TileWallsState OppositeWall(this TileWallsState origin)
        {
            return (TileWallsState)(((int)origin >> 2) | ((int)origin << 2)) & TileWallsState.All;
        }

        public static bool HasFlag(this TileWallsState tileWallsState, TileWallsState flag)
        {
            return ((int)tileWallsState & (int)flag) != 0;
        }
    }

    public struct RemoveWallAction
    {
        public Point Neighbour;
        public TileWallsState Wall;
    }
}
