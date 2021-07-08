using System;
using main.World.Enum;
using SimplexNoise;

namespace main.World.BuildingBlocks
{
    public class Chunkers
    {
        public Tile[,] ChunkTiles { get; set; }
        public Object[,] ObjArray { get; set; } 
        public long Id { get; set; }
        public Biome Biome { get; set; }
        public Chunkers(Biome biome, long id)
        {
            Biome = biome; // For better map gen.
            Id = id; // ID will be used to Identify neighbouring chunks;
            GenerateChunk(Settings.X,Settings.Y,Settings.Layers.Length);
        }

        private void GenerateChunk(int x, int y, int z)
        {
            //todo add two more arrays for objects and (i forgot the second one).
            //Additional arrays will work the same as layers and will be drawn over the first one.
            //gotta implement collision.
            //todo implement world saving and loading.
            //Should be easy enough, print the array to a file - json? Will see
            ChunkTiles = GenerateMapTiles(x,y);
            ObjArray = GenerateObjectLayer(x,y);

        }

        private Object[,] GenerateObjectLayer(int x, int y)
        {
            var objs = new Object[x,y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    objs[i, j] = new Object(ObjectType.Empty);
                }
            }

            return objs;
        }

        private Tile[,] GenerateMapTiles(int width, int height)
        {
            var tiles = new Tile[width,height];
            var noiseValues = GenerateNoise(width, height);
            for (int x = 0; x < noiseValues.GetLength(0); x++)
            {
                for (int y = 0; y < noiseValues.GetLength(1); y++)
                {
                    tiles[x, y] = new Tile {TerrainType = DetermineTerrain(noiseValues[x, y])};
                }
            }
            return tiles;
        }
        private TerrainType DetermineTerrain(float noiseValue)
        {
            //todo assign more cases
            //todo fine tune chunk based on biomes!
            // add more sand, grass, and so on variations depending on height map.
            // add biome chunks?? Could be neat.
            return noiseValue switch
            {
                var noise when noise <= 80 => TerrainType.Water,
                var noise when noise <= 85 => TerrainType.Sand,
                var noise when noise >= 215 => TerrainType.Mountain,
                _ => TerrainType.Grass
            };
        }
        private float[,] GenerateNoise(int width, int height)
        {
            Noise.Seed = 1;
            var noiseValues = Noise.Calc2D(width, height, 0.010f); 
            HelperClassStorage.MaxAvgMinFromArray(noiseValues);
            return noiseValues;
        }
        
    }
}