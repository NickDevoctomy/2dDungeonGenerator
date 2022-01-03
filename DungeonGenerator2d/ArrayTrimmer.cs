namespace DungeonGenerator2d
{
    public class ArrayTrimmer<T> : IArrayTrimmer<T>
    {
        public T[,] Trim(T[,]? array)
        {
            if(array == null)
            {
                throw new System.ArgumentNullException(nameof(array));
            }

            var trimmedV = TrimVertical(array);
            var trimmedHV = TrimHorizontal(trimmedV);
            return trimmedHV;
        }

        public T[,] TrimVertical(T[,]? array)
        {
            if (array == null)
            {
                throw new System.ArgumentNullException(nameof(array));
            }

            int bottomTrim = 0;
            int topTrim = 0;
            int startRow = 0;
            int endRow = array.GetLength(1) - 1;
            if (IsRowEmpty(array, 0))
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
                for (int i = array.GetLength(1) - 2; i >= 0; i--)
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
                topTrim = count;
                endRow = (array.GetLength(1) - 1) - topTrim;
            }

            if (bottomTrim > 0 || topTrim > 0)
            {
                var trimmed = new T[array.GetLength(0), (endRow - startRow) + 1];
                for (int x = 0; x < array.GetLength(0); x++)
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

        public T[,] TrimHorizontal(T[,]? array)
        {
            if (array == null)
            {
                throw new System.ArgumentNullException(nameof(array));
            }

            int leftTrim = 0;
            int rightTrim = 0;
            int startCol = 0;
            int endCol = array.GetLength(0) - 1;
            if (IsColEmpty(array, 0))
            {
                int count = 1;
                for (int i = 1; i < array.GetLength(0); i++)
                {
                    if (IsColEmpty(array, i))
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                leftTrim = count;
                startCol = leftTrim;
            }

            if (IsColEmpty(array, array.GetLength(0) - 1))
            {
                int count = 1;
                for (int i = array.GetLength(0) - 2; i >= 0; i--)
                {
                    if (IsColEmpty(array, i))
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                rightTrim = count;
                endCol = (array.GetLength(0) - 1) - rightTrim;
            }

            if (leftTrim > 0 || rightTrim > 0)
            {
                var trimmed = new T[(endCol - startCol) + 1, array.GetLength(1)];
                for (int y = 0; y < array.GetLength(1); y++)
                {
                    var curCol = 0;
                    for (int x = startCol; x <= endCol; x++)
                    {
                        trimmed[curCol, y] = array[x, y];
                        curCol++;
                    }
                }

                return trimmed;
            }

            return array;
        }

        public bool IsRowEmpty(T[,] array, int row)
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

        public bool IsColEmpty(T[,] array, int col)
        {
            var emptyCol = true;
            for (int y = 0; y < array.GetLength(1); y++)
            {
                if (array[col, y] != null)
                {
                    emptyCol = false;
                    break;
                }
            }

            return emptyCol;
        }
    }
}
