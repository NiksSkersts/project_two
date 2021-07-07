namespace main.Map.BuildingBlocks
{
    public class Object
    {
        public ObjectType _objectType;

        public Object() : this(ObjectType.Empty)
        {
            
        }
        private Object(ObjectType objectType)
        {
            _objectType = objectType;
        }
    }
}