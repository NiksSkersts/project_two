using System;
using System.Linq;
using main.Map.BuildingBlocks;
using main.Map.Generation.Arrays;
using SimplexNoise;

namespace main.Map.Generation
{
    public class MapGen
    {
        public MapArray Generate(int width, int height)
        {
            //todo add two more arrays for objects and (i forgot the second one).
            //Additional arrays will work the same as layers and will be drawn over the first one.
            //gotta implement collision.
            //todo implement world saving and loading.
            //Should be easy enough, print the array to a file - json? Will see
            var map = new MapArray(width, height);
            var noiseValues = GenerateNoise(width, height);

            for (int x = 0; x < noiseValues.GetLength(0); x++)
            {
                for (int y = 0; y < noiseValues.GetLength(1); y++)
                {
                    var terrain = map.Tiles[x, y].TerrainType = DetermineTerrain(noiseValues[x, y]);
                }
            }
            for (int x = 0; x < noiseValues.GetLength(0); x++)
            {
                for (int y = 0; y < noiseValues.GetLength(1); y++)
                {
                    var neigh = map.Tiles[x, y].Neighbours = DetermineNeighbours(x,y,map);
                }
            }
            for (int x = 0; x < noiseValues.GetLength(0); x++)
            {
                for (int y = 0; y < noiseValues.GetLength(1); y++)
                {
                    var terrain = map.Tiles[x, y].TerrainType;
                    map.Tiles[x, y].Biome = DetermineBiome(terrain);
                }
            }

            return map;
        }

        private Neighbours DetermineNeighbours(int x, int y, MapArray map)
        {
            //todo find a better way to check. IEnum?
            return new Neighbours()
            {
                Q1 = Detterrain(x - 1, y + 1),
                Q2 = Detterrain(x, y + 1),
                Q3 = Detterrain(x + 1, y + 1),
                Q4 = Detterrain(x - 1, y),
                Q6 = Detterrain(x + 1, y),
                Q7 = Detterrain(x - 1, y - 1),
                Q8 = Detterrain(x, y - 1),
                Q9 = Detterrain(x + 1, y - 1)

            };

            TerrainType Detterrain(int x, int y)
            {
                try
                {
                    return map.Tiles[x, y].TerrainType;
                }
                catch (Exception e)
                {
                    return TerrainType.OutOfBounds;
                }
            }
        }

        private TerrainType DetermineTerrain(float noiseValue)
        {
            //todo assign more cases
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

        private Biome DetermineBiome(TerrainType terrainType)
        {
            return terrainType switch
            {
                TerrainType.Grass => Biome.Grasslands,
                TerrainType.Mountain => Biome.Mountains,
                TerrainType.Sand => Biome.Desert,
                TerrainType.Water => Biome.Sea,
                _ => Biome.Grasslands
            };
        }
        

        private float[,] GenerateNoise(int width, int height)
        {
            var noiseValues = Noise.Calc2D(width, height, 0.010f);
            Helper(noiseValues);
            return noiseValues;
        }

        private void Helper(float[,] floater)
        {
            float total = 0;
            float min = 300;
            float max = 0;
            float count = Settings.X * Settings.Y;
            foreach (var floaty in floater)
            {
                if (floaty<min)
                {
                    min = floaty;
                }

                if (floaty>max)
                {
                    max = floaty;
                }
                total += floaty;
            }

            Console.WriteLine(total / count);
            Console.WriteLine(min);
            Console.WriteLine(max);
        }
        
    }
}