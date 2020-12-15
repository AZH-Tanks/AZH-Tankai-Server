using AZH_Tankai_Shared;

namespace AZH_Tankai_Server.Models
{
    public abstract class Tile
    {
        public Point Location { get; set; }
        public abstract double GetTileSpeedModifier(double currentSpeed);

        public abstract TileType GetTileType();

        public virtual void EnterTile(Tile fromTile) { }

        public virtual void LeaveTile(Tile toTile) { }

    }
}
