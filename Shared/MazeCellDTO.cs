﻿using AZH_Tankai_Server.Controllers.Maze;
using System;

namespace AZH_Tankai_Shared
{
    public struct MazeCellDTO : IEquatable<MazeCellDTO>
    {
        public TileType TileType { get; set; }
        public TileWallsState WallsState { get; set; }
        public bool Equals(MazeCellDTO other)
        {
            return TileType == other.TileType && WallsState == other.WallsState;
        }
    }
}
