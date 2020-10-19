using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZH_Tankai_Server.Models
{
    public class Storage
    {
        static object thisLock = new object();
        private Storage()
        {
            players = new List<Player>();
        }

        private static Storage singleton;
        public static Storage Get()
        {
            lock (thisLock)
            {
                if (singleton == null)
                    singleton = new Storage();

                return singleton;
            }
        }

        List<Player> players;

        public Player GetByUsername(string username)
        {
            if (players.Where(x => x.Name == username).Any())
                return players.Where(x => x.Name == username).First();

            return null;
        }

        public Player GetByConnectionId(string connectionId)
        {
            if (players.Where(x => x.ConnectionId == connectionId).Any())
                return players.Where(x => x.ConnectionId == connectionId).First();

            return null;
        }

        public void Add(Player player)
        {
            players.Add(player);
        }

        public void Remove(string id)
        {
            players.RemoveAll(x => x.ConnectionId == id);
        }
    }
}
