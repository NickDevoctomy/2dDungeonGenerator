namespace DungeonGenerator2d
{
    public class DungeonGenerator : IDungeonGenerator
    {
        private readonly IRandomiser _randomiser;

        public DungeonGenerator(IRandomiser randomiser)
        {
            _randomiser = randomiser;
        }

        public BoardTile[,] Generate(DungeonGeneratorOptions options)
        {
            var board = new BoardTile[
                _randomiser.GetNext(options.Width),
                _randomiser.GetNext(options.Height)];



            return board;
        }
    }
}
