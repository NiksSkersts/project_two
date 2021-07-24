using main.World.Enum;

namespace main.World.Structure
{
    public class Object<T>
    {
        public float X { get; set; }
        public float Y { get; set; }
        public ObjectType Type { get; }
        public Object(float x, float y, ObjectType type)
        {
            X = x;
            Y = y;
            Type = type;
        }
    }
}