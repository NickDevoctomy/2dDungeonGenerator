namespace DungeonGenerator2d
{
    public interface IArrayTrimmer<T>
    {
        public T[,] Trim(T[,] array);
    }
}
