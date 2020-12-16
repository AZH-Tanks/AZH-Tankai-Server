using AZH_Tankai_Server.DTO;
using System.Collections.Generic;

namespace AZH_Tankai_Server.Models
{
    public class Chat
    {
        private List<ContentDTO> contents;

        public void AddContect(ContentDTO content)
        {
            if (contents == null)
            {
                contents = new List<ContentDTO>();
            }
            contents.Add(content);
        }
        
        public List<ContentDTO> GetContents()
        {
            return contents;
        }

        public void UndoContent(string user)
        {
            int index = 0;
            if (contents == null)
            {
                contents = new List<ContentDTO>();
            }
            for (int i = contents.Count-1; i >= 0; i--)
            {
                if (contents[i].Player.Name == user)
                {
                    index = i;                 
                    break;
                }
            }
            if (index >= 0)
            { 
                contents.RemoveAt(index);
            }
           
        }

    }
}
