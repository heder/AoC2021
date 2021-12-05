class Program
{
    static void Main()
    {
        string[] lines = File.ReadLines("in.txt").ToArray();
        int[,] floor = new int[1000, 1000];

        foreach (var line in lines)
        {
            var coords = line.Split("->").Select(f => f.Trim()).ToArray();

            var from = coords[0].Split(',').Select(f => Convert.ToInt32(f)).ToList();
            var to = coords[1].Split(',').Select(f => Convert.ToInt32(f)).ToList();

            if (from[0] == to[0]) // x eq
            {
                int yFrom = Math.Min(from[1], to[1]);
                int yTo = Math.Max(from[1], to[1]);

                for (int i = yFrom; i <= yTo; i++)
                {
                    floor[from[0], i]++;
                }
            }
            else if (from[1] == to[1]) // y eq
            {
                int xFrom = Math.Min(from[0], to[0]);
                int xTo = Math.Max(from[0], to[0]);

                for (int i = xFrom; i <= xTo; i++)
                {
                    floor[i, from[1]]++;
                }
            }
            else if (Math.Abs(from[0] - to[0]) == Math.Abs(from[1] - to[1])) // 45 deg diag
            {
                int dist = Math.Abs(from[0] - to[0]);

                bool xRise = (to[0] >= from[0]);
                bool yRise = (to[1] >= from[1]);

                int xcurrent = from[0];
                int ycurrent = from[1];

                for (int i = 0; i <= dist; i++)
                {
                    floor[xcurrent, ycurrent]++;

                    if (xRise) xcurrent++; else xcurrent--;
                    if (yRise) ycurrent++; else ycurrent--;
                }
            }
        }
        
        var c = floor.Cast<int>().Count(f => f >= 2);

        Console.WriteLine(c);
        Console.ReadKey();
    }
}

