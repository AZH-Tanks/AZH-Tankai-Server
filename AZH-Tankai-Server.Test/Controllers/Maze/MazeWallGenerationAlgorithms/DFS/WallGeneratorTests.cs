using NUnit.Framework;
using AZH_Tankai_Server.Controllers.Maze.MazeWallGenerationAlgorithms.DFS;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZH_Tankai_Server.Controllers.Maze.MazeWallGenerationAlgorithms.DFS.Tests
{
    [TestFixture()]
    public class WallGeneratorTests
    {
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(4, 1)]
        [TestCase(10, 20)]
        [TestCase(100, 100)]
        public void WallGeneratorSizeTest(int xSize, int ySize)
        {
            var generator = new WallGenerator(xSize, ySize);
            var maze = generator.GenerateWalls();
            Assert.AreEqual(ySize, maze.Count);
            for (int i = 0; i < ySize; i++) {
                Assert.AreEqual(xSize, maze[i].Count);
            }
        }

        [Test()]
        public void WallGeneratorTypeTest()
        {
            var generator = new WallGenerator(100, 100);
            var maze = generator.GenerateWalls();
            var seenTypes = new HashSet<AZH_Tankai_Shared.TileWallsState>();
            foreach(var row in maze) {
                foreach(var wall in row) {
                    if (!seenTypes.Contains(wall)) {
                        seenTypes.Add(wall);
                    }
                }
            }

            Assert.True(seenTypes.Count > 4);
        }
    }
}