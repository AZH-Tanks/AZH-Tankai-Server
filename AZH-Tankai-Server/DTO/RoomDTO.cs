using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZH_Tankai_Server.DTO
{
    public class RoomDTO
    {
        public bool IsPublic { get; set; }
        public string Password { get; set; }
        public short SizeLimit { get; set; }
        public bool IsSurvival { get; set; }
        public short Duration { get; set; }
    }
}
