namespace main.Settings
{
    public class Settings : ISettings
    {
        private IWorld _world;

        public Settings(IWorld world)
        {
            _world = world;
        }

        public void LoadSettings()
        {
            _world.X = _world.Y = 64;
            _world.Z = 64;
            _world.TileSize = 64;
        }
    }
}