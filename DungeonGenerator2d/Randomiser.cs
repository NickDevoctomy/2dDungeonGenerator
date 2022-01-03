using System;

namespace DungeonGenerator2d
{
    public class Randomiser : IRandomiser
    {
        private Random _random;

        public Randomiser(RandomiserOptions options)
        {
            _random = new Random(options.Seed);
        }

        public int GetNext(int minInclusive, int maxExclusive)
        {
            return _random.Next(minInclusive, maxExclusive);
        }

        public int GetNext(IntRange? intRange)
        {
            if (intRange == null)
            {
                throw new ArgumentNullException(nameof(intRange));
            }

            return _random.Next(
                intRange.Min,
                intRange.Max + 1);
        }

        public Direction GetDirection()
        {
            var range = new IntRange((int)Direction.North, (int)Direction.West);
            var random = GetNext(range);
            return (Direction)random;
        }
    }
}
