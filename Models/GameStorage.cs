using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZH_Tankai_Server.Models
{
    public class GameStorage
    {
        static object thisLock = new object();
        private GameStorage()
        {
            gameRooms = new List<GameRoom>();
        }

        private static GameStorage singleton;
        public static GameStorage Get()
        {
            lock (thisLock)
            {
                if (singleton == null)
                {
                    singleton = new GameStorage();
                }
                return singleton;
            }
        }

        readonly List<GameRoom> gameRooms;

        public GameRoom GetByCredentials(string password, string connectionCode)
        {
            if (gameRooms.Where(x => x.JoinLink == connectionCode).Any())
            {
                return gameRooms.Where(x => x.JoinLink == connectionCode).First();
            }
            return null;
        }

        public GameRoom GetByConnectionCode(string connectionCode)
        {
            if (gameRooms.Where(x => x.JoinLink == connectionCode).Any())
            {
                return gameRooms.Where(x => x.JoinLink == connectionCode).First();
            }
            return null;
        }

        public void Add(GameRoom gameRoom)
        {
            gameRooms.Add(gameRoom);
        }

        public void Remove(GameRoom gameRoom)
        {
            gameRooms.Remove(gameRoom);
        }
    }
}
