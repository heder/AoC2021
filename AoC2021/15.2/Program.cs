class Program
{
    static void Main()
    {
        var lines = File.ReadLines("in.txt").ToArray();

        int sx = lines[0].Length;
        int sy = lines.Length;

        Position[,] map = new Position[sx * 5, sy * 5];
        for (int y = 0; y < sy; y++)
        {
            for (int x = 0; x < sx; x++)
            {
                map[x, y] = new();
                map[x, y].Risk = Convert.ToInt32(char.GetNumericValue(lines[y][x]));
            }
        }

        //Dump();


        // Repl first row
        for (int xx = 0; xx < 4; xx++)
        {

            for (int y = 0; y < sy; y++)
            {
                for (int x = 0; x < sx; x++)
                {
                    int sourceX = (xx * sx) + x;
                    int destX = (xx + 1) * sx + x;

                    map[destX, y] = new();
                    map[destX, y].Risk = (map[sourceX, y].Risk == 9) ? 1 : map[sourceX, y].Risk + 1;
                }
            }


        }

        sx *= 5;

        //Dump();

        // Repl first row down
        for (int yy = 0; yy < 4; yy++)
        {
            for (int x = 0; x < sx; x++)
            {
                for (int y = 0; y < sy; y++)
                {
                    int sourceY = (yy * sy) + y;
                    int destY = (yy + 1) * sy + y;

                    map[x, destY] = new();
                    map[x, destY].Risk = (map[x, sourceY].Risk == 9) ? 1 : map[x, sourceY].Risk + 1;
                }
            }
        }


        sy *= 5;
        // Dump();

        //map[0, 0].Risk = 0;
        map[0, 0].Distance = 0;

        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        sw.Start();
        long res = DijkstraIsh(new Coordinate(0, 0), 0);
        sw.Stop();
        Console.WriteLine(sw.ElapsedMilliseconds);

        Console.WriteLine(res);
        Console.ReadKey();



        long DijkstraIsh(Coordinate pos, int risk)
        {
            for (int y = 0; y < sy; y++)
            {
                for (int x = 0; x < sx; x++)
                {
                    var nb = GetNeighbours(x, y);

                    if (x == 499 && y == 499)
                    {
                        var lastmin = nb.Min(f => map[f.X, f.Y].Distance + map[f.X, f.Y].Risk);
                        return lastmin;
                    }

                    foreach (var item2 in nb)
                    {
                        if (map[item2.X, item2.Y].Visited == false)
                        {
                            long distance = map[x, y].Distance + map[item2.X, item2.Y].Risk;

                            if (map[item2.X, item2.Y].Distance > distance)
                                map[item2.X, item2.Y].Distance = distance;
                        }
                    }

                    map[x, y].Visited = true;
                }
            }

            return -1;

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


        void Dump()
        {
            for (int y = 0; y < sy; y++)
            {
                for (int x = 0; x < sx; x++)
                {
                    Console.Write(map[x, y].Risk);
                }

                Console.WriteLine();
            }
        }

    }
}


class Position
{
    public Position()
    {
        Distance = int.MaxValue;
    }

    public long Risk { get; set; }
    public bool Visited { get; set; }

    public long Distance { get; set; }
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