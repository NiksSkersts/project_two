#nullable enable
using System.Collections.Generic;
using main.Content;
using Texture = main.Content.Texture;

namespace main.World.Structure
{
    public class Chunk
    {
        private readonly SortedList<(int x, int y), Tile> _chunk;
        private readonly SortedList<(int x, int y), Texture> _texture;
        public (Tile, Texture) this[(int x,int y) pos]
        {
            get => (_chunk[pos], _texture[pos]);
            set => (_chunk[pos], _texture[pos]) = value;
        }

        internal Chunk((int width, int height) size)
        {
            var (sortedList, texture2Ds) = Generate(size);
            _chunk = sortedList;
            _texture = texture2Ds;
        }

        private (SortedList<(int x, int y), Tile>, SortedList<(int x, int y), Texture>) Generate((int width, int height) size)
        {
            var tiles = new SortedList<(int x, int y), Tile>();
            var textures = new SortedList<(int x, int y),Texture>();
            for (var x = size.width;x < size.width+Settings.RenderSize; x++)
            {
                for (var y =size.height; y < size.height+Settings.RenderSize; y++)
                {
                    tiles.Add((x,y),new Tile(x,y));
                    textures.Add((x,y),DetermineTexture(tiles[(x,y)]));
                }
            }
            return (tiles, textures);
        }

        private Texture DetermineTexture(Tile tile)
        {
            var temp = tile.Temperature;
            var hum = tile.Humidity;
            var (x, y, z) = tile.Coordinates;
            if (z < 50) return Textures.Water["water"];
            if (hum>5 && temp>20 && z>70&& z<=75) Map.ObjMap.Add(((int)tile.Coordinates.X,(int)tile.Coordinates.Y),new Object(Textures.Tree));
            if (hum>5 && temp>20 && z>75) Map.ObjMap.Add(((int)tile.Coordinates.X,(int)tile.Coordinates.Y),new Object(Textures.Forest));
                if (z > 200) Map.ObjMap.Add(((int)tile.Coordinates.X,(int)tile.Coordinates.Y),new Object(Textures.Mountain)) ;
            return Textures.Grass["grass"];
        }
    }
}