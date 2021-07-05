using main.Map.WorldGen;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace main.Map.Drawing
{
    public interface IDraw
    {
        void Draw(World world,SpriteBatch batch,GraphicsDevice device,ContentManager contentManager);
    }
}