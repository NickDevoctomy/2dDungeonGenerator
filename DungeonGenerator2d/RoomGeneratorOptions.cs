﻿namespace DungeonGenerator2d
{
    public class RoomGeneratorOptions
    {
        public IntRange? Width { get; set; }
        public IntRange? Height { get; set; }
        public IntRange? Parts { get; set; }
        public IntRange? PartWidth { get; set; }
        public IntRange? PartHeight { get; set; }
        public IntRange? DoorCount { get; set; }
        public IntRange? DoorSize { get; set; }
        public Direction? MandatoryDoor { get; set; }
    }
}
