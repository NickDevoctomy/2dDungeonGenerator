using System.Collections.Generic;
using System.Drawing;

namespace DungeonGenerator2d
{
    public class DoorInserter : IDoorInserter
    {
        private readonly IRandomiser _randomiser;
        private readonly ITilePicker _tilePicker;

        public DoorInserter(
            IRandomiser randomiser,
            ITilePicker tilePicker)
        {
            _randomiser = randomiser;
            _tilePicker = tilePicker;
        }

        public int Insert(
            BoardTile[,] room,
            DoorInserterOptions options)
        {
            var doorCount = 0;
            int doorsToInsert = _randomiser.GetNext(options.Count);
            for (int i = 0; i < doorsToInsert; i++)
            {
                var direction = _randomiser.GetDirection();
                int size = _randomiser.GetNext(options.Size);
                var wallPoints = _tilePicker.PickWallPoints(
                    room,
                    direction);

                var possibleDoorPoints = _tilePicker.PickAdjacentPoints(
                    wallPoints,
                    size,
                    direction);
                if (possibleDoorPoints.Count > 0)
                {
                    do
                    {
                        var randomDoorPointsIndex = _randomiser.GetNext(0, possibleDoorPoints.Count);
                        var doorPoints = possibleDoorPoints[randomDoorPointsIndex];
                        possibleDoorPoints.RemoveAt(randomDoorPointsIndex);
                        if (!DoorExists(room, doorPoints) &&
                            !IsNextToExistingDoor(room, doorPoints, direction))
                        {
                            doorCount += 1;
                            doorPoints.ForEach(curPoint =>
                            {
                                room[curPoint.X, curPoint.Y].TileType = BoardTileType.Door;
                            });
                            possibleDoorPoints.Clear();
                        }
                        else
                        {
                            //do we retry?
                        }
                    } while (possibleDoorPoints.Count > 0);
                }
            }

            return doorCount;
        }

        public bool DoorExists(
            BoardTile[,] room,
            List<Point> doorPoints)
        {
            foreach (var curPoint in doorPoints)
            {
                if(room[curPoint.X, curPoint.Y].TileType == BoardTileType.Door)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsNextToExistingDoor(
            BoardTile[,] room,
            List<Point> doorPoints,
            Direction direction)
        {
            bool nextToExisting = false;
            switch(direction)
            {
                case Direction.North:
                case Direction.South:
                    {
                        foreach(var curPoint in doorPoints)
                        {
                            if(curPoint.X > 0)
                            {
                                if(room[curPoint.X - 1, curPoint.Y] != null && room[curPoint.X - 1, curPoint.Y].TileType == BoardTileType.Door)
                                {
                                    return true;
                                }
                            }

                            if (curPoint.X < room.GetLength(0) - 1)
                            {
                                if (room[curPoint.X + 1, curPoint.Y] != null && room[curPoint.X + 1, curPoint.Y].TileType == BoardTileType.Door)
                                {
                                    return true;
                                }
                            }
                        }

                        break;
                    }

                case Direction.East:
                case Direction.West:
                    {
                        foreach (var curPoint in doorPoints)
                        {
                            if (curPoint.Y > 0)
                            {
                                if (room[curPoint.X, curPoint.Y - 1] != null && room[curPoint.X, curPoint.Y - 1].TileType == BoardTileType.Door)
                                {
                                    return true;
                                }
                            }

                            if (curPoint.Y < room.GetLength(0) - 1)
                            {
                                if (room[curPoint.X, curPoint.Y + 1] != null && room[curPoint.X, curPoint.Y + 1].TileType == BoardTileType.Door)
                                {
                                    return true;
                                }
                            }
                        }

                        break;
                    }
            }

            return nextToExisting;
        }
    }
}
