namespace DungeonGenerator2d
{
    public class RoomGenerator : IRoomGenerator
    {
        private readonly IRandomiser _randomiser;
        private readonly IRoomValidator _roomValidator;
        private readonly IArrayTrimmer<BoardTile> _trimmer;
        private readonly IDoorInserter _doorInserter;

        public RoomGenerator(
            IRandomiser randomiser,
            IRoomValidator roomValidator,
            IArrayTrimmer<BoardTile> trimmer,
            IDoorInserter doorInserter)
        {
            _randomiser = randomiser;
            _roomValidator = roomValidator;
            _trimmer = trimmer;
            _doorInserter = doorInserter;
        }

        public BoardTile[,] Generate(RoomGeneratorOptions options)
        {
            var trimmedRoom = default(BoardTile[,]);
            var roomValid = false;
            do
            {
                BoardTile[,] room;
                do
                {
                    var roomWidth = _randomiser.GetNext(options.Width);
                    var roomHeight = _randomiser.GetNext(options.Height);
                    room = new BoardTile[roomWidth, roomHeight];
                    var roomParts = _randomiser.GetNext(options.Parts);
                    for (var i = 1; i <= roomParts; i++)
                    {
                        var partWidth = _randomiser.GetNext(options.PartWidth);
                        if (partWidth > roomWidth)
                        {
                            partWidth = roomWidth;
                        }

                        var partHeight = _randomiser.GetNext(options.PartHeight);
                        if (partHeight > roomHeight)
                        {
                            partHeight = roomHeight;
                        }

                        var xPos = _randomiser.GetNext(new IntRange(0, roomWidth - partWidth));
                        var yPos = _randomiser.GetNext(new IntRange(0, roomHeight - partHeight));
                        for (int x = xPos; x < xPos + partWidth; x++)
                        {
                            for (int y = yPos; y < yPos + partHeight; y++)
                            {
                                room[x, y] = new BoardTile(x, y);
                            }
                        }
                    }
                } while (!_roomValidator.Validate(room));

                trimmedRoom = _trimmer.Trim(room);
                var doorInserterOptions = new DoorInserterOptions
                {
                    Count = options.DoorCount,
                    Size = options.DoorSize,
                    MandatoryDoor = options.MandatoryDoor
                };
                var doorCount = _doorInserter.Insert(trimmedRoom, doorInserterOptions);
                roomValid = (doorCount > 0);
            } while (!roomValid);
            
            return trimmedRoom;
        }
    }
}
