using System;
using System.Linq;
using System.Runtime.CompilerServices;
using main.Content;
using main.World.BuildingBlocks;
using main.World.Enum;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Entities.Systems;
using Object = main.World.BuildingBlocks.Object;

namespace main.Systems
{
    public class MapRenderer : DrawSystem
    {
        private World.BuildingBlocks.World _world;
        private readonly SpriteBatch _batch;

        public MapRenderer(World.BuildingBlocks.World world, SpriteBatch batch)
        {
            _world = world;
            _batch = batch;
            //todo - make textures have smoother transition on texture borders. e.g: water -> sand.
        }


        public override void Draw(GameTime gameTime)
        {
            foreach (var Chunkers in _world.Chunks)
            {
                CycleThroughChunk(Chunkers);
            }

            void CycleThroughChunk(Chunkers chunkers)
            {
                for (int z = 0; z < Settings.Layers.Length; z++)
                {
                    for (int x = 0; x < Settings.X ; x++)
                    {
                        for (int y = 0 ; y < Settings.Y ; y++)
                        {
                            if (x>=32 || y>=32 || x<0 || y<0)
                                return;
                            ApplyTexturesMapLayer(chunkers.ChunkTiles[x,y],x,y);
                            ApplyObjLayer(chunkers.ObjArray[x,y],x,y);

                        }
                    }
                }
            }
            void ApplyTexturesMapLayer(Tile chunkersChunkTile,int x, int y)
            {
                var terrainType = chunkersChunkTile.TerrainType;
                switch (terrainType)
                {
                    case TerrainType.None:
                        break;
                    case TerrainType.Water:
                        DrawFunc(Textures.AWaterShallow,x,y);
                        break;
                    case TerrainType.Sand:
                        DrawFunc(Textures.ASand,x,y);
                        break;
                    case TerrainType.Grass:
                        DrawFunc(Textures.AGrass,x,y);
                        break;
                    case TerrainType.Mountain:
                        DrawFunc(Textures.ARock,x,y);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        private void DrawFunc(Texture2D texture2D,int x,int y)
        {
            _batch.Draw(texture2D, 
                new Rectangle(new Point(x*Settings.TileSize,Settings.TileSize*y), new Point(Settings.TileSize,Settings.TileSize)),Color.Aqua);
        }

        private void ApplyObjLayer(Object chunkersObj, int x, int y)
        {
            var objtype = chunkersObj.ObjectType;
            Texture2D texture2D = Textures.RectangleH;
            switch (objtype)
            {
                case ObjectType.Trees:
                    break;
                case ObjectType.Buildings:
                    break;
                case ObjectType.Grass:
                    break;
                case ObjectType.NPC:
                    break;
                case ObjectType.Empty:
                    DrawFunc(texture2D,x,y);
                    break;
                case ObjectType.NaturalBlock:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}