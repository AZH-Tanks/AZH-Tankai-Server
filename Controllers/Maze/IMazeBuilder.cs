namespace AZH_Tankai_Server.Controllers.Maze
{
    public interface IMazeBuilder
    {
        public IMazeBuilder SetDimensions(int height, int width);
        public IMazeBuilder AddWalls();
        public IMazeBuilder AddTiles();
        public Models.Maze Create();
        public IMazeBuilder Reset();
    }
}
