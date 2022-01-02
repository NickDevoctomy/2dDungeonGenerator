namespace DungeonGenerator2d.UnitTests
{
    public static class TestHelpers
    {
        public static BoardTile[,]? CreateArrayFromText(string[]? lines)
        {
            if (lines == null)
            {
                return null;
            }

            int rows = lines.Length;
            int cols = lines[0].Length;
            var array = new BoardTile[cols, rows];

            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    if (lines[y][x] == '1')
                    {
                        array[x, y] = new BoardTile(x, y);
                    }
                }
            }

            return array;
        }
    }
}
