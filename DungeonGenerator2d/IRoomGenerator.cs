namespace DungeonGenerator2d
{
    public interface IRoomGenerator
    {
        public BoardTile[,] Generate(RoomGeneratorOptions options);
    }
}
