namespace DungeonGenerator2d
{
    public class DungeonGeneratorOptions
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public IntRange? Rooms { get; set; }
        public IntRange? RoomWidth { get; set; }
        public IntRange? RoomHeight { get; set; }
        public IntRange? RoomParts { get; set; }
        public IntRange? RoomPartWidth { get; set; }
        public IntRange? RoomPartHeight { get; set; }
        public IntRange? DoorSize { get; set; }
        public IntRange? RoomDoorCount { get; set; }
    }
}
