using main.World.Enum;
using Microsoft.Xna.Framework;

namespace main.World.Structs
{
    public struct Tile
    {
        public TerrainType TerrainType;
        public Point Coordinates;
        public float Height;
        public Tile(TerrainType terrainType, Point coordinates, float height)
        {
            TerrainType = terrainType;
            Coordinates = coordinates;
            Height = height;
        }
    }
}