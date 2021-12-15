class Program
{
    static void Main()
    {
        var lines = File.ReadLines("in.txt").ToArray();

        int sx = lines[0].Length;
        int sy = lines.Length;

        Position[,] map = new Position[sx, sy];
        for (int y = 0; y < sy; y++)
        {
            for (int x = 0; x < sx; x++)
            {
                map[x, y] = new();
                map[x, y].Risk = Convert.ToInt32(char.GetNumericValue(lines[y][x]));
            }
        }

        map[0, 0].Risk = 0;
        map[0, 0].Distance = 0;
        DijkstraIsh(new Coordinate(0, 0), 0);

        int xxx = map[sx - 1, sy - 1].Distance;

        Console.WriteLine(xxx);
        Console.ReadKey();



        void DijkstraIsh(Coordinate pos, int risk)
        {
            for (int y = 0; y < sx; y++)
            {
                for (int x = 0; x < sy; x++)
                {
                    var nb = GetNeighbours(x, y);

                    foreach (var item2 in nb)
                    {
                        if (map[item2.X, item2.Y].Visited == false)
                        {
                            int distance = map[x, y].Distance + map[item2.X, item2.Y].Risk;

                            if (map[item2.X, item2.Y].Distance > distance)
                                map[item2.X, item2.Y].Distance = distance;
                        }
                    }

                    map[x, y].Visited = true;
                }
            }

            Console.WriteLine();
            Console.ReadKey();

        }

        List<Coordinate> GetNeighbours(int x, int y)
        {
            List<Coordinate> ret = new();
            //if (TryGetVal(x - 1, y - 1)) ret.Add(new Coordinate(x - 1, y - 1));
            if (TryGetVal(x, y - 1)) ret.Add(new Coordinate(x, y - 1));
            //if (TryGetVal(x + 1, y - 1)) ret.Add(new Coordinate(x + 1, y - 1));

            if (TryGetVal(x - 1, y)) ret.Add(new Coordinate(x - 1, y));
            if (TryGetVal(x + 1, y)) ret.Add(new Coordinate(x + 1, y));

            //if (TryGetVal(x - 1, y + 1)) ret.Add(new Coordinate(x - 1, y + 1));
            if (TryGetVal(x, y + 1)) ret.Add(new Coordinate(x, y + 1));
            //if (TryGetVal(x + 1, y + 1)) ret.Add(new Coordinate(x + 1, y + 1));

            return ret;
        }


        bool TryGetVal(int x, int y)
        {
            if (x < 0 || y < 0 || x > map.GetUpperBound(0) || y > map.GetUpperBound(1))
                return false;
            else
                return true;
        }

    }
}


class Position
{
    public Position()
    {
        Distance = int.MaxValue;
    }

    public int Risk { get; set; }
    public bool Visited { get; set; }

    public int Distance { get; set; }
}

class Coordinate
{
    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X;
    public int Y;
}