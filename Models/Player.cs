using AZH_Tankai_Server.DTO;
using System.Collections.Generic;

namespace AZH_Tankai_Server.Models
{
    public class Player
    {

        public Player(string name, string connectionId)
        {
            Name = name;
            ConnectionId = connectionId;
        }

        private List<ISendContent> _commands = new List<ISendContent>();
        public void Send(ISendContent command, ContentDTO content)
        {
            _commands.Add(command);
            command.Send(content);
        }
        public void Undo(ISendContent command, string user)
        {
            _commands.Remove(command);
          
            command.Undo(user);
        }

        public string Name { get; set; }
        public int Score { get; set; }
        public string ConnectionId { get; set; }
    }
}
