using AZH_Tankai_Server.DTO;

namespace AZH_Tankai_Server.Models
{
    public class SendImage : ISendContent
    {
        public Chat Chat { get; set; }
        public SendImage(Chat chat)
        {
            Chat = chat;
        }
        public void Send(ContentDTO content)
        {
            Chat.AddContect(content);
        }

        public void Undo(string player)
        {
            Chat.UndoContent(player);
        }
    }
}
