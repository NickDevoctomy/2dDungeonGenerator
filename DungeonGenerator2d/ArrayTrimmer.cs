namespace DungeonGenerator2d
{
    public class ArrayTrimmer<T> : IArrayTrimmer<T>
    {
        public T[,] Trim(T[,] array)
        {
            int bottomTrim = 0;
            int topTrim = 0;
            int startRow = 0;
            int endRow = array.GetLength(1) - 1;
            if(IsRowEmpty(array, 0))
            {
                int count = 1;
                for (int i = 1; i < array.GetLength(1); i++)
                {
                    if (IsRowEmpty(array, i))
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                bottomTrim = count;
                startRow = bottomTrim;
            }

            if (IsRowEmpty(array, array.GetLength(1) - 1))
            {
                int count = 1;
                for(int i = array.GetLength(1) - 2; i >= 0; i--)
                {
                    if(IsRowEmpty(array, i))
                    {
                        count++;                        
                    }
                    else
                    {
                        break;
                    }
                }
                topTrim = count;
                endRow = (array.GetLength(1) - 1) - topTrim;
            }

            if(bottomTrim > 0 || topTrim > 0)
            {
                var trimmed = new T[array.GetLength(0), (endRow - startRow) + 1];
                for(int x = 0; x < array.GetLength(0); x++)
                {
                    var curRow = 0;
                    for (int y = startRow; y <= endRow; y++)
                    {
                        trimmed[x, curRow] = array[x, y];
                        curRow++;
                    }
                }

                return trimmed;
            }

            return array;
        }

        private bool IsRowEmpty(T[,] array, int row)
        {
            var emptyRow = true;
            for (int x = 0; x < array.GetLength(0); x++)
            {
                if (array[x, row] != null)
                {
                    emptyRow = false;
                    break;
                }
            }

            return emptyRow;
        }
    }
}
