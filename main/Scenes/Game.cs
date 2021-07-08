using Microsoft.Xna.Framework;
using MonoGame.Extended.Screens;

namespace main.Scenes
{
    //Dunno why, but my FPS increased twofold.
    //Were I over-rendering my scene?
    //It's plausible.
    //Var _obj calls render method as well, so it's possible that I kept rendering it two times.
    //That's the best I can think of, because I just rendered nearly 4 times more rectangles and got twice as much FPS. Fascinating.
    public class Game : GameScreen
    {
        
        public override void Initialize()
        {
            base.Initialize();
            
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(GameTime gameTime)
        {
        }

        public Game(Microsoft.Xna.Framework.Game game) : base(game)
        {
        }
    }
}