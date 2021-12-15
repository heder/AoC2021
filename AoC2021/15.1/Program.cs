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
                map[x, y].Height = Convert.ToInt32(char.GetNumericValue(lines[y][x]));
            }
        }

        int lowestrisk = int.MaxValue;

        //List<int> paths = new();
        TraceBasin(new Coordinate(0, 0), 0, new HashSet<string>());

        //int basinSize;
        //List<int> basins = new();
        //foreach (var item in map)
        //{
        //    basinSize = 1;
        //    TraceBasin(new Coordinate(0,0), 0, new HashSet<Coordinate>());
        //    basins.Add(basinSize);
        //}

        //var sum = basins.OrderByDescending(f => f).Take(3).ToArray();
        //int result = sum[0] * sum[1] * sum[2];

        Console.WriteLine();
        Console.ReadKey();


        
        void TraceBasin(Coordinate pos, int risk, HashSet<string> vis)
        {
            vis.Add($"{pos.X},{pos.Y}");
            //map[x, y].Visited = true;
            risk += map[pos.X, pos.Y].Height;

            if (risk > lowestrisk)
            {
                return;
            }

            if (pos.X == sx - 1 && pos.Y == sy - 1)
            {
                Console.WriteLine($"current risk {risk}");
                lowestrisk = risk;
                return;
            }

            // Get neighbours
            var nb = GetNeighbours(pos.X, pos.Y);

            // Increase neighbours
            //foreach (var item in nb)
            //{
            //    map[item.X, item.Y].Energy++;
            //}


            foreach (var item in nb)
            {
                //if (map[item.X, item.Y].Visited == false)
                if (vis.Contains($"{item.X},{item.Y}") == false)
                {
                    TraceBasin(item, risk, new HashSet<string>(vis));
                }
            }


            //Position up = SafeGetValAt(x, y - 1);
            //if (up.Height > map[x, y].Height && up.Height < 9 && up.Visited == false)
            //{
            //    basinSize++;
            //    TraceBasin(x, y - 1);
            //}

            //Position left = SafeGetValAt(x - 1, y);
            //if (left.Height > map[x, y].Height && left.Height < 9 && left.Visited == false)
            //{
            //    basinSize++;
            //    TraceBasin(x - 1, y);
            //}

            //Position down = SafeGetValAt(x, y + 1);
            //if (down.Height > map[x, y].Height && down.Height < 9 && down.Visited == false)
            //{
            //    basinSize++;
            //    TraceBasin(x, y + 1);
            //}

            //Position right = SafeGetValAt(x + 1, y);
            //if (right.Height > map[x, y].Height && right.Height < 9 && right.Visited == false)
            //{
            //    basinSize++;
            //    TraceBasin(x + 1, y);
            //}
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


        //bool IsLowPoint(int x, int y)
        //{
        //    if (SafeGetValAt(x, y - 1).Height > map[x, y].Height)
        //    {
        //        if (SafeGetValAt(x - 1, y).Height > map[x, y].Height)
        //        {
        //            if (SafeGetValAt(x + 1, y).Height > map[x, y].Height)
        //            {
        //                if (SafeGetValAt(x, y + 1).Height > map[x, y].Height)
        //                {
        //                    return true;
        //                }
        //            }
        //        }
        //    }
        //    return false;
        //}
    }
}


class Position
{
    public int Height { get; set; }
    public bool Visited { get; set; }
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