namespace DungeonGenerator2d
{
    public interface IArrayTrimmer<T>
    {
        T[,] Trim(T[,] array);
        T[,] TrimVertical(T[,]? array);
        T[,] TrimHorizontal(T[,]? array);
        bool IsRowEmpty(T[,] array, int row);
        bool IsColEmpty(T[,] array, int row);
    }
}
