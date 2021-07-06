using System.Diagnostics;

namespace main.Map.BuildingBlocks
{
    [DebuggerDisplay("{" + nameof(TerrainType) + ", nq}")]
    //todo read
    //Create Tiles that are made out of more tiles?
    //Culled on zoomed out. (?)
    //A very small grid for placing buildings and to do pathfinding on.
    //Current implementation - ~46fps on 256x256. tile - 32x32
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