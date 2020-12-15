using AZH_Tankai_Server.DTO;
using System;

namespace AZH_Tankai_Server.Models
{
    public class PublicGameRoom : GameRoom
    {
        public short PlayerCap { get; set; }

        public override Chat GetChat()
        {
            return Chat;
        }

        public override void AddMessageToChat(Player player, string message, bool isImage)
        {
            ContentDTO content = new ContentDTO();
            content.Player = player;
            content.Message = message;
            content.IsImage = isImage;
            Chat.AddContect(content);
        }

        public override void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public override void RemovePlayer(Player player)
        {
            Players.Remove(player);
        }

        public override void StartGame()
        {
            throw new NotImplementedException();
        }
    }
}
