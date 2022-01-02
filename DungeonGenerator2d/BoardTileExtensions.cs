using System.Text;

namespace DungeonGenerator2d
{
    public static class BoardTileExtensions
    {
        public static string ToFormattedString(this BoardTile[,] board)
        {
            var formatted = new StringBuilder();
            for (int y = board.GetLength(1) - 1; y >= 0; y--)
            {
                for (int x = 0; x < board.GetLength(0); x++)
                {
                    formatted.Append(board[x, y] != null ? "[X]" : "[-]");
                }
                formatted.Append("\r\n");
            }

            if(formatted.Length >= 2)
            {
                formatted.Length -= 2;
            }

            return formatted.ToString();
        }
    }
}
