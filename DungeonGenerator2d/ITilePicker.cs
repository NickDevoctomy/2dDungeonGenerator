using System.Collections.Generic;
using System.Drawing;

namespace DungeonGenerator2d
{
    public interface ITilePicker
    {
        Point? PickFirstPointWallFromPoint(
            BoardTile[,] room,
            Point point,
            Direction direction);

        List<Point> PickWallPoints(
            BoardTile[,] room,
            Direction direction);

        List<List<Point>> PickAdjacentPoints(
            List<Point> points,
            int count,
            Direction direction);
    }
}
