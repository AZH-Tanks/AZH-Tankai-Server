using AZH_Tankai_Server.DTO;

namespace AZH_Tankai_Server.Models
{
    public interface ISendContent
    {
        public Chat Chat { get; set; }
        public void Send(ContentDTO content);
        public void Undo(string player);
    }
}
