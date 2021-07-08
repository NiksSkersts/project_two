using System;
using main.World.Enum;
using MonoGame.Extended.Collections;

namespace main.World.BuildingBlocks
{
    public class World
    {
        public ObservableCollection<Chunkers> Chunks { get; set; }

        public World()
        {
            Chunks = new ObservableCollection<Chunkers> {new Chunkers(RngBiome(), GetId())};
        }

        private long GetId()
        {
            //todo later
            try
            {
                long i = Chunks.Count;
                return i++;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        private Biome RngBiome()
        {
            //todo later
            return Biome.Grasslands;
        }
    }
}