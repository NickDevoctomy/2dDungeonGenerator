namespace DungeonGenerator2d
{
    public interface IRoomValidator
    {
        bool Validate(BoardTile[,] room);
    }
}
