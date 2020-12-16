using System;
using System.Collections.Generic;
using System.Text;
using AZH_Tankai_Server.Models;
using AZH_Tankai_Shared;
using AZH_Tankai_Server.Controllers.Collision;
using NUnit.Framework;

namespace AZH_Tankai_Server.Test.Models
{
    class MazeTests
    {
        private Maze maze;

        [SetUp]
        public void Setup()
        {
            List<List<Wall>> walls = new List<List<Wall>>();
            walls.Add(new List<Wall>()
            {
                new Wall((TileWallsState)137, false),
                new Wall((TileWallsState)133, false),
                new Wall((TileWallsState)129, false),
                new Wall((TileWallsState)133, false),
                new Wall((TileWallsState)131, false),
            });
            walls.Add(new List<Wall>()
            {
                new Wall((TileWallsState)140, false),
                new Wall((TileWallsState)135, false),
                new Wall((TileWallsState)138, false),
                new Wall((TileWallsState)137, false),
                new Wall((TileWallsState)134, false),
            });
            walls.Add(new List<Wall>()
            {
                new Wall((TileWallsState)141, false),
                new Wall((TileWallsState)133, false),
                new Wall((TileWallsState)134, false),
                new Wall((TileWallsState)140, false),
                new Wall((TileWallsState)131, false),
            });
            walls.Add(new List<Wall>()
            {
                new Wall((TileWallsState)137, false),
                new Wall((TileWallsState)129, false),
                new Wall((TileWallsState)133, false),
                new Wall((TileWallsState)135, false),
                new Wall((TileWallsState)138, false),
            });
            walls.Add(new List<Wall>()
            {
                new Wall((TileWallsState)142, false),
                new Wall((TileWallsState)140, false),
                new Wall((TileWallsState)133, false),
                new Wall((TileWallsState)133, false),
                new Wall((TileWallsState)134, false),
            });
            maze = new Maze(null, walls, 5, 5);
        }

        [TestCase(0, 0, 3)]
        [TestCase(40, 40, 40)]
        [TestCase(80, 120, 3)]
        public void MazeCollides(double x, double y, double radius)
        {
            CollisionObject collisionObject = new CollisionObject() { X = x, Y = y, Radius = radius };
            Assert.IsFalse(maze.CheckCollisions(collisionObject));
        }

        [TestCase(20, 20, 3)]
        [TestCase(38, 38, 1)]
        [TestCase(125, 125, 4)]
        public void MazeNotCollides(double x, double y, double radius)
        {
            CollisionObject collisionObject = new CollisionObject() { X = x, Y = y, Radius = radius };
            Assert.IsTrue(maze.CheckCollisions(collisionObject));
        }

    }
}
