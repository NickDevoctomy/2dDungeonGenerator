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

var options = new RoomGeneratorOptions
{
    Width = new IntRange(5, 10),
    Height = new IntRange(5, 10),
    Parts = new IntRange(2, 5),
    PartWidth = new IntRange(3, 5),
    PartHeight = new IntRange(3, 5),
    DoorSize = new IntRange(1, 2),
    DoorCount = new IntRange(1, 3)
};

var more = true;
while (more)
{
    Console.Clear();
    var room = roomGenerator.Generate(options);
    var formatted = room.ToFormattedString(false);
    Console.WriteLine(formatted);
    Console.WriteLine("More? (y,n)");
    more = Console.ReadKey(true).Key == ConsoleKey.Y;
}



