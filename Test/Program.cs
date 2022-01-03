using DungeonGenerator2d;

var randomiserOptions = new RandomiserOptions
{
    Seed = 100
};
var randomiser = new Randomiser(randomiserOptions);
var roomGenerator = new RoomGenerator(
    randomiser,
    new RoomValidator(),
    new ArrayTrimmer<BoardTile>(),
    new DoorInserter(randomiser, new TilePicker()));
var dungeonGenerator = new DungeonGenerator(
    randomiser,
    roomGenerator,
    new ArrayTrimmer<BoardTile>());

var options = new DungeonGeneratorOptions
{
    Width = 20,
    Height = 20,
    Rooms = new IntRange(2,10),
    RoomWidth = new IntRange(3, 5),
    RoomHeight = new IntRange(3, 5),
    RoomParts = new IntRange(2, 5),
    RoomPartWidth = new IntRange(3, 5),
    RoomPartHeight = new IntRange(3, 5),
    DoorSize = new IntRange(1, 2),
    RoomDoorCount = new IntRange(1, 3),
};

var more = true;
while (more)
{
    Console.Clear();
    var dungeon = dungeonGenerator.Generate(options);
    var formatted = dungeon.ToFormattedString(false);
    Console.WriteLine(formatted);
    Console.WriteLine("More? (y,n)");
    more = Console.ReadKey(true).Key == ConsoleKey.Y;
}



