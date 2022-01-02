namespace DungeonGenerator2d
{
    public interface IDungeonGenerator
    {
        BoardTile[,] Generate(DungeonGeneratorOptions options);
    }
}
