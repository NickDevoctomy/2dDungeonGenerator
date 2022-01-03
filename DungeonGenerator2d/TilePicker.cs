using System;
using System.Collections.Generic;
using System.Drawing;

namespace DungeonGenerator2d
{
    public class TilePicker : ITilePicker
    {
        public Point? PickFirstPointWallFromPoint(
            BoardTile[,] room,
            Point point,
            Direction direction)
        {
            switch(direction)
            {
                case Direction.North:
                    {
                        for(int y = point.Y; y < room.GetLength(1); y++)
                        {
                            if(room[point.X, y] != null)
                            {
                                return new Point(point.X, y);
                            }
                        }

                        break;
                    }

                case Direction.East:
                    {
                        for (int x = point.X; x >= 0; x--)
                        {
                            if (room[x, point.Y] != null)
                            {
                                return new Point(x, point.Y);
                            }
                        }

                        break;
                    }

                case Direction.South:
                    {
                        for (int y = point.Y; y >= 0; y--)
                        {
                            if (room[point.X, y] != null)
                            {
                                return new Point(point.X, y);
                            }
                        }

                        break;
                    }

                case Direction.West:
                    {
                        for (int x = point.X; x < room.GetLength(0); x++)
                        {
                            if (room[x, point.Y] != null)
                            {
                                return new Point(x, point.Y);
                            }
                        }

                        break;
                    }
            }

            return null;
        }
    
        public List<Point> PickWallPoints(
            BoardTile[,] room,
            Direction direction)
        {
            List<Point> points = new List<Point>();

            switch(direction)
            {
                case Direction.North:
                    {
                        for(int x = 0; x < room.GetLength(0); x++)
                        {
                            var point = PickFirstPointWallFromPoint(
                                room,
                                new Point(x, 0),
                                direction);
                            if(point != null)
                            {
                                points.Add(point.GetValueOrDefault());
                            }
                        }

                        break;
                    }

                case Direction.East:
                    {
                        int x = room.GetLength(0) - 1;
                        for (int y = 0; y < room.GetLength(1); y++)
                        {
                            var point = PickFirstPointWallFromPoint(
                                room,
                                new Point(x, y),
                                direction);
                            if (point != null)
                            {
                                points.Add(point.GetValueOrDefault());
                            }
                        }

                        break;
                    }

                case Direction.South:
                    {
                        int y = room.GetLength(1) - 1;
                        for (int x = 0; x < room.GetLength(0); x++)
                        {
                            var point = PickFirstPointWallFromPoint(
                                room,
                                new Point(x, y),
                                direction);
                            if (point != null)
                            {
                                points.Add(point.GetValueOrDefault());
                            }
                        }

                        break;
                    }

                case Direction.West:
                    {
                        for (int y = 0; y < room.GetLength(1); y++)
                        {
                            var point = PickFirstPointWallFromPoint(
                                room,
                                new Point(0, y),
                                direction);
                            if (point != null)
                            {
                                points.Add(point.GetValueOrDefault());
                            }
                        }

                        break;
                    }
            }

            return points;
        }

        public List<List<Point>> PickAdjacentPoints(
            List<Point> points,
            int count,
            Direction direction)
        {
            if(count < 0 || count > 2)  // !!! Limit of door size to 2?
            {
                throw new ArgumentException(nameof(count));
            }

            List<List<Point>> adjacentPoints = new List<List<Point>>();

            switch (direction)
            {
                case Direction.North:
                case Direction.South:
                    {
                        foreach (var point in points)
                        {
                            List<Point> run = new List<Point>();
                            run.Add(point);
                            if (count > 1)
                            {
                                for (int i = 1; i < count; i++)
                                {
                                    var adjacent = new Point(
                                        point.X + i,
                                        point.Y);
                                    if (!points.Contains(adjacent))
                                    {
                                        break;
                                    }

                                    run.Add(adjacent);
                                }
                            }

                            if (run.Count == count)
                            {
                                adjacentPoints.Add(run);
                            }
                        }

                        break;
                    }

                case Direction.East:
                case Direction.West:
                    {
                        foreach (var point in points)
                        {
                            List<Point> run = new List<Point>();
                            run.Add(point);
                            if (count > 1)
                            {
                                for (int i = 1; i < count; i++)
                                {
                                    var adjacent = new Point(
                                        point.X,
                                        point.Y + i);
                                    if (!points.Contains(adjacent))
                                    {
                                        break;
                                    }

                                    run.Add(adjacent);
                                }
                            }

                            if (run.Count == count)
                            {
                                adjacentPoints.Add(run);
                            }
                        }

                        break;
                    }
            }

            return adjacentPoints;
        }
    }
}
