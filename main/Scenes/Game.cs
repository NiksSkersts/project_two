using main.Components;
using main.Map.BuildingBlocks;
using main.Map.Generation;
using main.Map.Generation.Arrays;
using Microsoft.Xna.Framework;
using Nez;
using Nez.UI;

namespace main.Scenes
{
    //Dunno why, but my FPS increased twofold.
    //Were I over-rendering my scene?
    //It's plausible.
    //Var _obj calls render method as well, so it's possible that I kept rendering it two times.
    //That's the best I can think of, because I just rendered nearly 4 times more rectangles and got twice as much FPS. Fascinating.
    public class Game : BaseScene
    {
        private Map.BuildingBlocks.Map Map;
        private CameraMovement _cameraMovement;
        public override void Initialize()
        {
            var renderer = AddRenderer(new DefaultRenderer());
            base.Initialize();
            Map = new Map.BuildingBlocks.Map();
            var _obj = CreateEntity("obj").AddComponent(new ObjLayerRenderer(Map));
            var _map = CreateEntity("map").AddComponent(new MapRenderer(Map));
            _obj.RenderLayer = 0;
            _map.RenderLayer = 1;
            _cameraMovement = CreateEntity("character").AddComponent(new CameraMovement());
            Camera.Entity.AddComponent(new FollowCamera(_cameraMovement.Entity));

        }
        public override void OnStart()
        {
            ClearColor = Color.Black;
            base.OnStart();
        }

        public override void Update()
        {
            _cameraMovement.Entity.Position = _cameraMovement.Movement();
            Camera.ZoomIn(_cameraMovement.Zoom());
            base.Update();
        }
        public override Table Table { get; set; }
    }
}