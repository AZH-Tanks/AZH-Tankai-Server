using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZH_Tankai_Server.Models
{
    public class Player
    {  
        public Player(string name, string connectionId)
        {
            Name = name;
            ConnectionId = connectionId;
        }

        public string Name { get; set; }
        public int Score { get; set; }
        public string ConnectionId { get; set; }
    }
}
