using System.Linq;
using main.World.Structure;
using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.Collections;
using MonoGame.Extended.Entities.Systems;
using SD.Tools.BCLExtensions.CollectionsRelated;
using Point = System.Drawing.Point;

namespace main.Systems
{
    public class CoordinateSystem : UpdateSystem
    {
        private readonly OrthographicCamera _camera;
        public CoordinateSystem(OrthographicCamera _camera)
        {
            this._camera = _camera;
            _camera.Position = Vector2.Zero;
        }
        public override void Update(GameTime gameTime)
        {
            Grid.Create(new World.Structure.Point(_camera.Position.ToPoint().X,_camera.Position.ToPoint().Y));
        }
        
    }
}