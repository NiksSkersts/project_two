using Nez;
using Nez.UI;

namespace main.Scenes
{
    public abstract class BaseScene : Scene
    {
        public void SetupBasic()
        {
            AddRenderer(new DefaultRenderer());
            UICanvas canvas = CreateEntity("ui-canvas").AddComponent(new UICanvas());
            Table = canvas.Stage.AddElement(new Table());
            Table.SetFillParent(true).Top().PadLeft(10).PadTop(50);

        }
        public abstract Table Table { get; set; }
    }
}