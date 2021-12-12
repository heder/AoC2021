class Program
{
    static void Main()
    {
        var lines = File.ReadLines("in.txt").ToArray();

        int sx = lines[0].Length;
        int sy = lines.Length;
        int flares = 0;

        Octopus[,] map = new Octopus[sx, sy];
        for (int y = 0; y < sy; y++)
        {
            for (int x = 0; x < sx; x++)
            {
                map[x, y] = new Octopus() { Energy = Convert.ToInt32(char.GetNumericValue(lines[y][x])), HasFlared = false };
            }
        }

        int step = 0;
        while (true)
        {
            DumpState();

            // Increase
            for (int y = 0; y < sy; y++)
            {
                for (int x = 0; x < sx; x++)
                {
                    map[x, y].Energy++;
                }
            }

            List<Coordinate> ignoreList = new();
            // Flare mark
            for (int y = 0; y < sy; y++)
            {
                for (int x = 0; x < sx; x++)
                {
                    if (map[x, y].Energy > 9 && map[x, y].HasFlared == false)
                    {
                        Flare(x, y);
                    }
                }
            }

            // Flares to zero 
            int f = 0;
            for (int y = 0; y < sy; y++)
            {
                for (int x = 0; x < sx; x++)
                {
                    if (map[x, y].HasFlared == true)
                    {
                        map[x, y].HasFlared = false;
                        map[x, y].Energy = 0;
                        flares++;
                        f++;
                    }
                }
            }

            step++;
            Console.WriteLine($"After step {step}: {flares} flares");

            if (f == map.Length)
            {
                Console.WriteLine(flares);
                Console.ReadKey();
            }
        }


        void Flare(int x, int y)
        {
            map[x, y].HasFlared = true; // Indicate flash

            // Get neighbours
            var nb = GetNeighbours(x, y);

            // Increase neighbours
            foreach (var item in nb)
            {
                map[item.X, item.Y].Energy++;
            }

            // Check neighbours > 9 that has not already flared
            foreach (var item in nb)
            {
                if (map[item.X, item.Y].Energy > 9 && map[item.X, item.Y].HasFlared == false)
                {
                    Flare(item.X, item.Y);
                }
            }
        }


        List<Coordinate> GetNeighbours(int x, int y)
        {
            List<Coordinate> ret = new();

            if (TryGetVal(x - 1, y - 1)) ret.Add(new Coordinate(x - 1, y - 1));
            if (TryGetVal(x, y - 1)) ret.Add(new Coordinate(x, y - 1));
            if (TryGetVal(x + 1, y - 1)) ret.Add(new Coordinate(x + 1, y - 1));

            if (TryGetVal(x - 1, y)) ret.Add(new Coordinate(x - 1, y));
            if (TryGetVal(x + 1, y)) ret.Add(new Coordinate(x + 1, y));

            if (TryGetVal(x - 1, y + 1)) ret.Add(new Coordinate(x - 1, y + 1));
            if (TryGetVal(x, y + 1)) ret.Add(new Coordinate(x, y + 1));
            if (TryGetVal(x + 1, y + 1)) ret.Add(new Coordinate(x + 1, y + 1));

            return ret;
        }



        bool TryGetVal(int x, int y)
        {
            if (x < 0 || y < 0 || x > map.GetUpperBound(0) || y > map.GetUpperBound(1)) 
                return false;
            else
                return true;
        }


        void DumpState()
        {
            for (int y = 0; y < sy; y++)
            {
                for (int x = 0; x < sx; x++)
                {
                    Console.Write(map[x, y].Energy);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }

    class Octopus
    {
        public int Energy { get; set; }
        public bool HasFlared { get; set; }
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
}
