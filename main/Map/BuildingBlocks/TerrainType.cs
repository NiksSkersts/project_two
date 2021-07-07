namespace main.Map.BuildingBlocks
{
    //Enumerator of all currently available terrain types.
    // Rendered depends on this parameter in Tile class to assign the correct Texture2D texture.
    public enum TerrainType
    {
        None,
        Water,
        Sand,
        Grass,
        Mountain,
        OutOfBounds
    }
}