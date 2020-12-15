using AZH_Tankai_Server.DTO;

namespace AZH_Tankai_Server.Models
{
    public class SendText : ISendContent
    {
        public Chat Chat { get; set; }
        public SendText(Chat chat)
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
