using System;
using main.Content;
using main.World.Enum;
using Microsoft.Xna.Framework.Graphics;
using SimplexNoise;

namespace main.World.Structure
{
    public readonly struct Tile<T>
    {
        public int X { get; }
        public int Y { get; }
        public Texture2D Terrain { get; }
        private int Temperature { get; }
        private int Humidity { get; }
        private float Height { get; }
        private Biomes Biome { get; }

        public Tile(int y, int x) : this()
        {
            Y = y;
            X = x;
            Height = DetermineHeight(x, y);
            Temperature = DetermineTemperature(Height);
            Humidity = DetermineHumidity(Height, Temperature);
            Biome = DetermineBiome(Height, Temperature, Humidity);
            Terrain = DetermineTerrain(Height, Biome);
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
            if (temperature <= 40 && temperature >= 10 && humidity > 5) return Biomes.Grassland;
            if (temperature < 10 && temperature >= 0) return Biomes.Hills;
            if (height > 100 && temperature < 0) return Biomes.Mountains;
            return Biomes.Mountains;
        }

        private static Texture2D DetermineTerrain(float height, Biomes biomes) =>
            biomes switch
            {
                Biomes.Desert => Textures.ASand,
                Biomes.DeepWater => Textures.AWaterDeep,
                Biomes.Water => Textures.AWaterShallow,
                Biomes.Grassland => Textures.AGrass,
                Biomes.Beach => Textures.ASandWhite,
                Biomes.Mountains => Textures.ARockHigh,
                Biomes.Swamp => Textures.AGroundDark,
                Biomes.Forest => default,
                Biomes.Jungle => default,
                Biomes.Hills => Textures.ARock,
                _ => throw new ArgumentOutOfRangeException(nameof(biomes), biomes, null)
            };

        private static float DetermineHeight(int x, int y)
        {
            Noise.Seed = Settings.Seed;
            return Noise.CalcPixel2D(x, y, 0.009f);
        }
    }
}