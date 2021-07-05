using main.Map.WorldGen;
using main.Settings;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace main.Map.Drawing
{
    public interface IDraw
    {
        void Draw(World world, ContentManager contentManager, IWorld worldSettings);
    }
}