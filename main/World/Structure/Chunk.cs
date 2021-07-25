#nullable enable
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.Linq;
using main.Content;
using main.World.Enum;
using MathNet.Numerics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Texture = main.Content.Texture;

namespace main.World.Structure
{
    public class Chunk
    {
        public (Tile, Texture) this[(int x,int y) pos] => (_chunk[pos], _texture[pos]);

        public Chunk GenerateChunk((int width, int height) size)
        {
            return new Chunk(size);
        }
        private readonly SortedList<(int x, int y), Tile> _chunk;
        private readonly SortedList<(int x, int y), Texture> _texture;

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
            for (var x = size.width;x < size.width+Settings.X; x++)
            {
                for (var y =size.height; y < size.height+Settings.Y; y++)
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
            if (z<50)
                return Textures.Water["water"];
            if (z >= 50)
                return Textures.Grass["grass"];
            return default;
        }
    }
}