using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace main.World.Structure
{
    public class ChunkMap : IDisposable
    {
        public static SortedList<(int x, int y), Chunk<object>> Map { get; private set; } =
            new SortedList<(int x, int y), Chunk<object>>();
        public static void Enque(Vector2 Pos)
        {
            var newposx =(int) (Pos.X / Settings.X) * Settings.X;
            var newposy =(int) (Pos.Y / Settings.Y) * Settings.Y;
            if (Map.ContainsKey((newposx,newposy))==false)
            {
                Map.Add((newposx,newposy),new Chunk<object>(newposx,newposy));
            }
            
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}