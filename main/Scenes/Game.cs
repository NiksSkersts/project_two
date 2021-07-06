using main.Entities;
using main.Map.BuildingBlocks;
using main.Map.Generation;
using Microsoft.Xna.Framework;
using Nez;
using Nez.UI;

namespace main.Scenes
{
    public class Game : BaseScene
    {
        private World world;
        private UICanvas canvas;
        public override void Initialize()
        {
            base.Initialize();
            canvas = CreateEntity("game-canvas").AddComponent(new UICanvas());
            var mapGen = new MapGen();
            world = mapGen.Generate(Settings.X, Settings.Y);
        }
        
        public override void OnStart()
        {
            ClearColor = Color.Black;
            Graphics.Instance.Batcher.Begin();
            var map = CreateEntity("map").AddComponent(new MapRenderer(world));
            map.DebugRender(Graphics.Instance.Batcher);
            Graphics.Instance.Batcher.End();
            base.OnStart();
        }

        public override Table Table { get; set; }
    }
}