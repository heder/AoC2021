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

        List<Coordinate> lowPoints = new();
        for (int y = 0; y < sy; y++)
        {
            for (int x = 0; x < sx; x++)
            {
                if (IsLowPoint(x, y))
                    lowPoints.Add(new Coordinate() { x = x, y = y });
            }
        }

        int basinSize;
        List<int> basins = new();
        foreach (var item in lowPoints)
        {
            basinSize = 1;
            TraceBasin(item.x, item.y);
            basins.Add(basinSize);
        }

        var sum = basins.OrderByDescending(f => f).Take(3).ToArray();
        int result = sum[0] * sum[1] * sum[2];

        Console.WriteLine(result);
        Console.ReadKey();


        
        void TraceBasin(int x, int y)
        {
            map[x, y].Visited = true;

            Position up = SafeGetValAt(x, y - 1);
            if (up.Height > map[x, y].Height && up.Height < 9 && up.Visited == false)
            {
                basinSize++;
                TraceBasin(x, y - 1);
            }

            Position left = SafeGetValAt(x - 1, y);
            if (left.Height > map[x, y].Height && left.Height < 9 && left.Visited == false)
            {
                basinSize++;
                TraceBasin(x - 1, y);
            }

            Position down = SafeGetValAt(x, y + 1);
            if (down.Height > map[x, y].Height && down.Height < 9 && down.Visited == false)
            {
                basinSize++;
                TraceBasin(x, y + 1);
            }

            Position right = SafeGetValAt(x + 1, y);
            if (right.Height > map[x, y].Height && right.Height < 9 && right.Visited == false)
            {
                basinSize++;
                TraceBasin(x + 1, y);
            }
        }


        Position SafeGetValAt(int x, int y)
        {
            try
            {
                return map[x, y];
            }
            catch (IndexOutOfRangeException)
            {
                return new Position() { Height = int.MaxValue };
            }
        }


        bool IsLowPoint(int x, int y)
        {
            if (SafeGetValAt(x, y - 1).Height > map[x, y].Height)
            {
                if (SafeGetValAt(x - 1, y).Height > map[x, y].Height)
                {
                    if (SafeGetValAt(x + 1, y).Height > map[x, y].Height)
                    {
                        if (SafeGetValAt(x, y + 1).Height > map[x, y].Height)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}


class Position
{
    public int Height { get; set; }
    public bool Visited { get; set; }
}

class Coordinate
{
    public int x { get; set; }
    public int y { get; set; }
}