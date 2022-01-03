namespace DungeonGenerator2d
{
    public interface IRandomiser
    {
        int GetNext(int minInclusive, int maxExclusive);
        int GetNext(IntRange? intRange);
        Direction GetDirection();
    }
}
