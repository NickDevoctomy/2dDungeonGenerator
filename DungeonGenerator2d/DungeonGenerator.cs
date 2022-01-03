using System.Collections.Generic;
using System.Drawing;

namespace DungeonGenerator2d
{
    public class DungeonGenerator : IDungeonGenerator
    {
        private readonly IRandomiser _randomiser;
        private readonly IRoomGenerator _roomGenerator;
        private readonly IArrayTrimmer<BoardTile> _trimmer;

        public DungeonGenerator(
            IRandomiser randomiser,
            IRoomGenerator roomGenerator,
            IArrayTrimmer<BoardTile> trimmer)
        {
            _randomiser = randomiser;
            _roomGenerator = roomGenerator;
            _trimmer = trimmer;
        }

        public BoardTile[,] Generate(DungeonGeneratorOptions options)
        {
            var board = new BoardTile[
                1000,
                1000];

            var rooms = new List<BoardTile[,]?>();
            var startRoomGeneratorOptions = new RoomGeneratorOptions
            {
                Width = options.RoomWidth,
                Height = options.RoomHeight,
                Parts = options.RoomParts,
                PartWidth = options.RoomPartWidth,
                PartHeight = options.RoomPartHeight,
                DoorSize = options.DoorSize,
                DoorCount = new IntRange(1, 1),
                MandatoryDoor = Direction.South
            };
            var startRoom = _roomGenerator.Generate(startRoomGeneratorOptions);
            rooms.Add(startRoom);
            CopyRoomToBoard(
                board,
                startRoom,
                new Point(500, 500));

            return _trimmer.Trim(board);
        }

        //private void CreateRoomOffDoor(
        //    BoardTile[,] board,
        //    Point doorPos)
        //{
        //    var doorDirection = board[]
        //}

        private bool CopyRoomToBoard(
            BoardTile[,] board,
            BoardTile[,] room,
            Point topLeft)
        {
            if (topLeft.X + room.GetLength(0) > board.GetLength(0))
            {
                return false;
            }

            if (topLeft.Y + room.GetLength(1) > board.GetLength(1))
            {
                return false;
            }

            for (int x = topLeft.X; x < topLeft.X + room.GetLength(0); x++)
            {
                for (int y = topLeft.Y; y < topLeft.Y + room.GetLength(1); y++)
                {
                    board[x, y] = room[x - topLeft.X, y - topLeft.Y];
                }
            }

            return true;
        }

        private bool CanRoomFit(
            BoardTile[,] board,
            BoardTile[,] room,
            Point topLeft)
        {
            if(topLeft.X + room.GetLength(0) > board.GetLength(0))
            {
                return false;
            }

            if (topLeft.Y + room.GetLength(1) > board.GetLength(1))
            {
                return false;
            }

            for (int x = topLeft.X; x < topLeft.X + room.GetLength(0); x++)
            {
                for (int y = topLeft.Y; y < topLeft.Y + board.GetLength(1); y++)
                {
                    if(board[x, y] != null)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
