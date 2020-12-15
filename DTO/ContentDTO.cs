using AZH_Tankai_Server.Models;

namespace AZH_Tankai_Server.DTO
{
    public class ContentDTO
    {
        public ContentDTO()
        {
        }
        public Player Player { get; set; }
        public string Message { get; set; }
        public bool IsImage { get; set; }
    }
}
