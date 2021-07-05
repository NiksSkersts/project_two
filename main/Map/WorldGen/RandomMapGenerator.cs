using System;
using main.Map.BuildingBlocks;
using SimplexNoise;

namespace main.Map.WorldGen
{
    class RandomMapGenerator : IWorldGen
    {
        public World Generate(int width, int height)
        {
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
            Noise.Seed = random.Next(32123213);
            var scale = 0.01f;
            var noiseValues = Noise.Calc2D(width, height, scale);

            return noiseValues;
        }
    }
}