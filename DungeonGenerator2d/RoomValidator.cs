namespace DungeonGenerator2d
{
    public class RoomValidator : IRoomValidator
    {
        public bool Validate(BoardTile[,]? room)
        {
            if(room == null)
            {
                throw new System.ArgumentNullException(nameof(room));
            }

            for (int x = 0; x < room.GetLength(0); x++)
            {
                var run = false;
                var runCount = 0;

                for (int y = 0; y < room.GetLength(1); y++)
                {
                    if(room[x, y] != null && !run)
                    {
                        run = true;
                        runCount++;
                    }

                    if(room[x, y] == null && run)
                    {
                        run = false;
                    }
                }

                if(runCount != 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
