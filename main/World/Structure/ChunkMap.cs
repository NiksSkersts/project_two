using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace main.World.Structure
{
    public class ChunkMap : IDisposable
    {
        public static SortedList<(int x,int y),Chunk<object>> Map { get; private set; }
        public struct Chunk
        {
            // Index into Chunks for chunk to the left
            public int Left;
            // Index into Chunks for chunk to the top
            public int Top;
            // Index into Chunks for chunk to the right
            public int Right;
            // Index into Chunks for chunk to the bottom
            public int Bottom;
        }

        public ChunkMap()
        {
            Map = new SortedList<(int x, int y), Chunk<object>>();
        }

        public void Enque(int posX, int posY)
        {
            var newx = (posX / Settings.X) * Settings.X;
            var newy = (posY / Settings.Y) * Settings.Y;
            if (Map.ContainsKey((newx,newy))==false)
            {
                Map.Add((newx,newy),new Chunk<object>(newx,newy));
            }
            
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}