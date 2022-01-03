using System.Collections.Generic;
using System.Drawing;

namespace DungeonGenerator2d.UnitTests
{
    public static class TestHelpers
    {
        public static List<Point> ParsePoints(this string pointsString, char separator)
        {
            var points = new List<Point>();
            var allPoints = pointsString.Split(separator);
            foreach(var point in allPoints)
            {
                var parts = point.Split(',');
                points.Add(new Point(int.Parse(parts[0]), int.Parse(parts[1])));
            }

            return points;
        }

        public static BoardTile[,]? CreateArrayFromText(string[]? lines)
        {
            if (lines == null)
            {
                return null;
            }

            int rows = lines.Length;
            int cols = lines[0].Length;
            var array = new BoardTile[cols, rows];

            for (int y = lines.Length - 1; y >= 0; y--)
            {
                for (int x = 0; x < cols; x++)
                {               
                    if (int.TryParse(lines[y][x].ToString(), out int tile))
                    {
                        array[x, y] = new BoardTile((BoardTileType)tile, x, y);
                    }
                }
            }

            return array;
        }
    }
}
