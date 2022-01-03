using System.Collections.Generic;
using System.Drawing;

namespace DungeonGenerator2d
{
    public interface IDoorInserter
    {
        BoardTile[,] Insert(
            BoardTile[,] room,
            DoorInserterOptions options);

        bool DoorExists(
            BoardTile[,] room,
            List<Point> doorPoints);

        bool IsNextToExistingDoor(
            BoardTile[,] room,
            List<Point> doorPoints,
            Direction direction);
    }
}
