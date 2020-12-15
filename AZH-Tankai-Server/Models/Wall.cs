using AZH_Tankai_Shared;

namespace AZH_Tankai_Server.Models
{
    public class Wall
    {
        public TileWallsState State { get; set; }
        public bool Breakable { get; set; }

        public Wall(TileWallsState state, bool breakable)
        {
            State = state;
            Breakable = breakable;
        }
    }
}
