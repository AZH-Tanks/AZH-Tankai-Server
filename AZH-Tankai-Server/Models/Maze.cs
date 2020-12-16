using AZH_Tankai_Server.Controllers.Collision;
using AZH_Tankai_Shared;
using System.Collections.Generic;

namespace AZH_Tankai_Server.Models
{
    public class Maze : CollisionComponent
    {
        public List<List<Tile>> Tiles { get; set; }
        public List<List<Wall>> Walls { get; set; }

        public List<PowerUp> PowerUps { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public Maze() { }

        public Maze(List<List<Tile>> tiles, List<List<Wall>> walls, int width, int height)
        {
            Tiles = tiles;
            Walls = walls;
            Width = width;
            Height = height;
        }

        public List<List<TileType>> GetTileTypes()
        {
            List<List<TileType>> tileTypes = new List<List<TileType>>();
            foreach (List<Tile> tileRow in Tiles)
            {
                List<TileType> tileTypesRow = new List<TileType>();
                foreach (Tile tile in tileRow)
                {
                    tileTypesRow.Add(tile.GetTileType());
                }
                tileTypes.Add(tileTypesRow);
            }
            return tileTypes;
        }

        public List<List<MazeCellDTO>> GetMazeDTO()
        {
            List<List<MazeCellDTO>> mazeDTO = new List<List<MazeCellDTO>>();
            for (int i = 0; i < Height; i++)
            {
                List<MazeCellDTO> mazeDTORow = new List<MazeCellDTO>();
                for (int j = 0; j < Width; j++)
                {
                    mazeDTORow.Add(new MazeCellDTO { TileType = Tiles[i][j].GetTileType(), WallsState = Walls[i][j].State });
                }
                mazeDTO.Add(mazeDTORow);
            }
            return mazeDTO;
        }

        public void AddPowerUp(PowerUp powerUp)
        {
            PowerUps.Add(powerUp);
        }

        public void RemovePowerUp(PowerUp powerUp)
        {
            PowerUps.Remove(powerUp);
        }

        public override bool CheckCollisions(CollisionObject collisionObject)
        {
            int i = (int)(collisionObject.Y) / 40;
            int j = (int)(collisionObject.X) / 40;
            double cellPositionX = (collisionObject.X) % 40;
            double cellPositionY = (collisionObject.Y) % 40;
            if (cellPositionX < collisionObject.Radius && Walls[i][j].State.HasFlag(TileWallsState.Left))
            {
                return false;
            }
            if (40 - cellPositionX < collisionObject.Radius && Walls[i][j].State.HasFlag(TileWallsState.Right))
            {
                return false;
            }
            if (cellPositionY < collisionObject.Radius && Walls[i][j].State.HasFlag(TileWallsState.Top))
            {
                return false;
            }
            if (40 - cellPositionY < collisionObject.Radius && Walls[i][j].State.HasFlag(TileWallsState.Bottom))
            {
                return false;
            }
            return true;
        }
    }
}
