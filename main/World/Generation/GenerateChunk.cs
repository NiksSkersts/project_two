using main.World.Enum;
using main.World.Structs;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Collections;
using SimplexNoise;

namespace main.World.Generation
{
    public class GenerateChunk
    {
        private float _height;
        public Tile Create(Point coords) => new Tile(DetermineTerrain(coords),coords,_height);
        private TerrainType DetermineTerrain(Point _coords)
        {
            _height = GenerateHeightMap();
            if (_height<=80)
            {
                return TerrainType.Water;
            } 
            if (_height<=85)
            {
                return TerrainType.Sand;
            }
            if (_height>=220)
            {
                return TerrainType.Mountains;
            }
            return TerrainType.Grass;
            
            float GenerateHeightMap()
            {
                Noise.Seed = Settings.Seed;
                return Noise.CalcPixel2D(_coords.X, _coords.Y, 0.010f);
            }
        }
    }
}