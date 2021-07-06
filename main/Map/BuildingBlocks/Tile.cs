using System.Diagnostics;

namespace main.Map.BuildingBlocks
{
    [DebuggerDisplay("{" + nameof(TerrainType) + ", nq}")]
    public class Tile
    {
        public TerrainType TerrainType;
        public Tile() : this(TerrainType.None)
        {
            
        }

        private Tile(TerrainType terrainType)
        {
            TerrainType = terrainType;
            var tileSize = Settings.TileSize;
            
        }
    }
}