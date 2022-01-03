using System.Collections.Generic;

namespace DungeonGenerator2d
{
    public class DungeonGenerator : IDungeonGenerator
    {
        private readonly IRandomiser _randomiser;
        private readonly IRoomGenerator _roomGenerator;

        public DungeonGenerator(
            IRandomiser randomiser,
            IRoomGenerator roomGenerator)
        {
            _randomiser = randomiser;
            _roomGenerator = roomGenerator;
        }

        public BoardTile[,] Generate(DungeonGeneratorOptions options)
        {
            var board = new BoardTile[
                options.Width,
                options.Height];

            var rooms = new List<BoardTile[,]?>();
            var startRoomGeneratorOptions = new RoomGeneratorOptions
            {
                Width = options.RoomWidth,
                Height = options.RoomHeight,
                Parts = options.RoomParts,
                PartWidth = options.RoomPartWidth,
                PartHeight = options.RoomPartHeight,
                DoorSize = options.DoorSize,
                DoorCount = new IntRange(1, 1) //options.RoomDoorCount
            };
            var startRoom = _roomGenerator.Generate(startRoomGeneratorOptions);
            rooms.Add(startRoom);



            //var roomCount = _randomiser.GetNext(options.Rooms);
            //var rooms = new List<BoardTile[,]?>();
            //while(rooms.Count < roomCount)
            //{
            //    var roomGeneratorOptions = new RoomGeneratorOptions
            //    {
            //        Width = options.RoomWidth,
            //        Height = options.RoomHeight,
            //        Parts = options.RoomParts,
            //        PartWidth = options.RoomPartWidth,
            //        PartHeight = options.RoomPartHeight,
            //        DoorSize = options.DoorSize,
            //        DoorCount = options.RoomDoorCount
            //    };
            //    var room = _roomGenerator.Generate(roomGeneratorOptions);
            //    rooms.Add(room);
            //}

            return board;
        }
    }
}
