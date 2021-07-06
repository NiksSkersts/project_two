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
        //todo Fix texture mishap
        public override void Initialize()
        {
            base.Initialize();
            var mapGen = new MapGen();
            world = mapGen.Generate(Settings.X, Settings.Y);
            SetDesignResolution(640,368,SceneResolutionPolicy.ShowAllPixelPerfect);
            Screen.SetSize(1280,736);
            

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