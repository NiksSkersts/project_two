using System;
using MathNet.Numerics;
using Microsoft.Xna.Framework;
using SimplexNoise;

namespace main.World.Structure
{
    public readonly struct Tile
    {
        public Vector3 Coordinates { get; }
        public int Temperature { get; }
        public int Humidity { get; }

        public Tile(int x, int y)
        {
            Coordinates = new Vector3(x, y,DetermineHeight(x,y));
            Temperature = DetermineTemperature(Coordinates.Z);
            Humidity = DetermineHumidity(Coordinates.Z,Temperature);
        }
        private static int DetermineTemperature(float determineHeight) => (int)(Settings.MaxTemp * Math.Sin(Settings.Period * determineHeight));

        private static int DetermineHumidity(float height, int temperature) =>
            (int) (Settings.MaxTemp *
                   Math.Sin(Settings.Period *
                            (height + temperature +
                             Settings.PhaseShiftLeft) +
                            Settings.VerticalShift));

        private static int DetermineHeight(int x, int y)
        {
            Noise.Seed = Settings.Seed;
            return (int) Noise.CalcPixel2D(x, y, 0.009f).Round(3);
        }
    }
}