namespace AZH_Tankai_Server.Controllers.Maze
{
    public interface IMazeBuilder
    {
        public IMazeBuilder AddTiles(int height, int width);
        public Models.Maze Create();

        public IMazeBuilder Reset();
    }
}
