using System;
using main.Content;
using main.World.Enum;
using Microsoft.Xna.Framework.Graphics;
using SimplexNoise;

namespace main.World.Structure
{
    public class Tile<T>
    {
        public int X { get; }
        public int Y { get; }
        public Texture Terrain { get; }
        private int Temperature { get; }
        private int Humidity { get; }
        private float Height { get; }
        private Biomes Biome { get; }
        public Neighbours Neighbours { get; set; }

        public Tile(int y, int x)
        {
            Y = y;
            X = x;
            Height = DetermineHeight(x, y);
            Temperature = DetermineTemperature(Height);
            Humidity = DetermineHumidity(Height, Temperature);
            Biome = DetermineBiome(Height, Temperature, Humidity);
            Terrain = DetermineTerrain(Height, Biome);
            Neighbours = DetermineNeighbours(x,y);
        }

        private Neighbours DetermineNeighbours(int x, int y)
        {
            var neigh = new Neighbours();
            for (var i = x - 1; i < x + 1; i++)
            for (var j = y - 1; j < y + 1; j++)
            {
                var height = DetermineHeight(i, j);
                var temp = DetermineTemperature(height);
                var humidity = DetermineHumidity(height, temp);
                var biome = DetermineBiome(height,temp,humidity);
                if (i == x - 1 && j == y + 1)
                {
                    neigh.Q1 = DetermineTerrain(height,biome);
                }
                else if (i == x && j == y + 1)
                {
                    neigh.Q2 = DetermineTerrain(height,biome);
                }
                else if (i == x + 1 && j == y + 1)
                {
                    neigh.Q3 = DetermineTerrain(height,biome);
                }
                else if (i == x - 1 && j == y)
                {
                    neigh.Q4 = DetermineTerrain(height,biome);
                }
                else if (i == x + 1 && j == y)
                {
                    neigh.Q6 = DetermineTerrain(height,biome);
                }
                else if (i == x - 1 && j == y - 1)
                {
                    neigh.Q7 = DetermineTerrain(height,biome);
                }
                else if (i == x && j == y - 1)
                {
                    neigh.Q8 = DetermineTerrain(height,biome);
                }
                else if (i == x + 1 && j == y - 1)
                {
                    neigh.Q9 = DetermineTerrain(height,biome);
                }
            }

            return neigh;
        }

        private static int DetermineTemperature(float determineHeight) => (int) (Settings.MaxTemp * Math.Sin(Settings.Period * determineHeight));

        private int DetermineHumidity(float height, int temperature) =>
            (int) (Settings.MaxTemp *
                   Math.Sin(Settings.Period *
                            (height + temperature +
                             Settings.PhaseShiftLeft) +
                            Settings.VerticalShift));

        private Biomes DetermineBiome(float height, int temperature, int humidity)
        {
            if (temperature >= 25 && humidity < 5) return Biomes.Desert;
            if (temperature < 30 && height <= 50) return Biomes.Water;
            if (temperature < 15 && height <= 10) return Biomes.DeepWater;
            if (temperature <= 40 && temperature >= 10 && humidity > 50) return Biomes.Savanna;
            if (temperature <= 40 && temperature >= 10 && humidity > 5) return Biomes.Grassland;
            if (temperature < 10 && temperature >= 0) return Biomes.Hills;
            if (height > 100 && temperature < 0) return Biomes.Mountains;
            return Biomes.Mountains;
        }

        private static Texture DetermineTerrain(float height, Biomes biomes) =>
            biomes switch
            {
                Biomes.Desert => Texture.Sand,
                Biomes.DeepWater => Texture.WaterDeep,
                Biomes.Water => Texture.Water,
                Biomes.Grassland => Texture.Grass,
                Biomes.Beach => Texture.Sand,
                Biomes.Mountains => Texture.Mountain,
                Biomes.Swamp => Texture.Swamp,
                Biomes.Savanna => Texture.GrassSavana,
                Biomes.Forest => default,
                Biomes.Jungle => default,
                Biomes.Hills => Texture.Hill,
                _ => throw new ArgumentOutOfRangeException(nameof(biomes), biomes, null)
            };

        private static float DetermineHeight(int x, int y)
        {
            Noise.Seed = Settings.Seed;
            return Noise.CalcPixel2D(x, y, 0.009f);
        }
    }
}