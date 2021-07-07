using System;
using main.Map.BuildingBlocks;
using SimplexNoise;

namespace main.Map.Generation
{
    public class MapGen
    {
        public World Generate(int width, int height)
        {
            //todo add two more arrays for objects and (i forgot the second one).
            //Additional arrays will work the same as layers and will be drawn over the first one.
            //gotta implement collision.
            //todo implement world saving and loading.
            //Should be easy enough, print the array to a file - json? Will see
            var map = new World(width, height);
            var noiseValues = GenerateNoise(width, height);

            for (int x = 0; x < noiseValues.GetLength(0); x++)
            {
                for (int y = 0; y < noiseValues.GetLength(1); y++)
                {
                    map.Tiles[x, y].TerrainType = DetermineTerrain(noiseValues[x, y]);
                }
            }

            return map;
        }

        private TerrainType DetermineTerrain(float noiseValue)
        {
            //todo assign more cases
            // raise noise on Mountain tile
            // add more sand, grass, and so on variations depending on height map.
            // add biome chunks?? Could be neat.
            switch (noiseValue)
            {
                case var noise when noise <= 90:
                    return TerrainType.Water;
                case var noise when noise <= 100:
                    return TerrainType.Sand;
                case var noise when noise >= 200:
                    return TerrainType.Mountain;
                default:
                    return TerrainType.Grass;
            }
        }

        private float[,] GenerateNoise(int width, int height)
        {
            var random = new Random();
            Noise.Seed = random.Next();
            var scale = 0.01f;
            var noiseValues = Noise.Calc2D(width, height, scale);

            return noiseValues;
        }
    }
}