using AZH_Tankai_Shared;
using System.Collections.Generic;

namespace AZH_Tankai_Server.Models
{
    public class Maze
    {
        public List<List<Tile>> Tiles { get; set; }

        public Maze() { }

        public Maze(List<List<Tile>> tiles)
        {
            Tiles = tiles;
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
    }
}
