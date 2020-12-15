using System.Collections.Generic;

namespace AZH_Tankai_Server.Models
{
    public abstract class GameRoom
    {

        public string JoinLink { get; set; }
        public GameRoom() { }
       
        public List<Player> Players = new List<Player>();
        protected Chat Chat = new Chat();
        public Mode Mode { get; set; }

        public abstract Chat GetChat();
        public abstract void StartGame();

        public abstract void AddPlayer(Player player);

        public abstract void RemovePlayer(Player player);

        public abstract void AddMessageToChat(Player player, string message, bool isImage);
    }
}
