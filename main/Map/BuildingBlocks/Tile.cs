using System.Diagnostics;

namespace main.Map.BuildingBlocks
{
    //Basic building block of my map generator.
    [DebuggerDisplay("{" + nameof(TerrainType) + ", nq}")]
    //todo read
    //Create Tiles that are made out of more tiles?
    //Culled on zoomed out. (?)
    //A very small grid for placing buildings and to do pathfinding on.
    //Current implementation - ~46fps on 256x256. tile - 32x32
    public class Tile
    {
        public TerrainType TerrainType;
        public Biome Biome;
        public Neighbours Neighbours;
        public Tile() : this(TerrainType.None,Biome.None,new Neighbours())
        {
            
        }

        private Tile(TerrainType terrainType,Biome biomes, Neighbours neighbours)
        {
            TerrainType = terrainType;
            Biome = biomes;
            Neighbours = neighbours;
        }
    }
}