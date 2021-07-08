using main.World.Enum;

namespace main.World.BuildingBlocks
{
    public class Object
    {
        public ObjectType ObjectType { get; set; }
        public Object(ObjectType objectType)
        {
            ObjectType = objectType;
        }
    }
}