using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using AZH_Tankai_Server.Models;

namespace AZH_Tankai_Server.Controllers.Maze
{
    [TestFixture()]
    class MazeStorageTests
    {  
            private MazeStorage singleton;

            [SetUp()]
            public void setup()
            {
                singleton = MazeStorage.Get();
            }

            [Test]
            public void GetMaze()
            {
                Assert.That(() => singleton.GetMaze(), Throws.Nothing);
            }       
    }
}
