using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZH_Tankai_Server.Controllers.Maze
{
    public class MazeStorage
    {

        private Models.Maze maze;

        private MazeStorage()
        {
            MazeGenerator generator = new MazeGenerator();
            maze = generator.GenerateMaze();
        }

        static object thisLock = new object();

        private static MazeStorage singleton;
        public static MazeStorage Get()
        {
            lock (thisLock)
            {
                if (singleton == null)
                {
                    singleton = new MazeStorage();
                }
                return singleton;
            }
        }

        public Models.Maze GetMaze()
        {
            return maze;
        }
    }
}
