using main.Content;
using main.Map.Generation;
using main.Scenes;
using Nez;

namespace main
{
    public class Game1 : Core
    {

        public Game1()
        {
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            base.Initialize();
            Defaults();
            Textures.LoadTexture2D();
            Scene = new MainMenu();
        }

        private static void Defaults()
        {
            Settings.TileSize = 32;
            Settings.GridSize = 8; 
            Settings.SubGridCount = 4;
            Settings.X=Settings.Y  = 32;
            Settings.CameraMovementSpeed = 100f;
            Settings.BiomeSize = 32;

        }
    }
}
