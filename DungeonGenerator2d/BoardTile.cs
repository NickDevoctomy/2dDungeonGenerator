namespace DungeonGenerator2d
{
    public class BoardTile
    {
        public BoardTileType TileType { get; set; }
        public Direction? Direction { get; set; }
        public int X { get; set; } 
        public int Y { get; set; }

        public BoardTile(
            int x,
            int y)
        {
            TileType = BoardTileType.None;
            X = x;
            Y = y;
        }

        public BoardTile(
            BoardTileType boardTileType,
            int x,
            int y)
        {
            TileType = boardTileType;
            X = x;
            Y = y;
        }

        public BoardTile(
            BoardTileType boardTileType, 
            int x,
            int y,
            Direction direction)
        {
            TileType = boardTileType;
            X = x;
            Y = y;
            Direction = direction;
        }
    }
}
