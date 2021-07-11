using System;
using main.Content;
using main.World.Enum;
using main.World.Generation;
using main.World.Structs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Collections;
using MonoGame.Extended.Entities.Systems;

namespace main.Systems
{
    public class MapRenderer : DrawSystem
    {
        private readonly SpriteBatch _batch;
        private readonly ObservableCollection<Tile>[] _tiles;
        public MapRenderer(SpriteBatch batch)
        {
            _batch = batch;
            _tiles=CoordinateSystem.TilesArray;
            //todo - make textures have smoother transition on texture borders. e.g: water -> sand.
        }


        public override void Draw(GameTime gameTime)
        {
            _batch.GraphicsDevice.Clear(Color.Aqua);
            foreach (var quadrant in _tiles)
            {
                foreach (var tile in quadrant)
                {
                    BeginDraw(tile);
                }
            }
        }

        private void BeginDraw(Tile tile)
        {
            _batch.Draw(
                    tile.Texture,
                    new Rectangle(new Point(Settings.X*tile.Coordinates.X,Settings.Y*tile.Coordinates.Y),new Point(Settings.X)),
                    Color.Aqua);
        }
    }
}