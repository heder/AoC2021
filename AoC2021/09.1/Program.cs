class Program
{
    static void Main()
    {
        var lines = File.ReadLines("in.txt").ToArray();

        int sx = lines[0].Length;
        int sy = lines.Length;

        int[,] map = new int[sx, sy];
        for (int y = 0; y < sy; y++)
        {
            for (int x = 0; x < sx; x++)
            {
                map[x, y] = Convert.ToInt32(char.GetNumericValue(lines[y][x]));
            }
        }

        List<int> lowPoints = new();
        for (int y = 0; y < sy; y++)
        {
            for (int x = 0; x < sx; x++)
            {
                if (IsLowPoint(x, y))
                    lowPoints.Add(map[x, y]);
            }
        }

        int sum = lowPoints.Sum(f => f + 1);


        Console.WriteLine(sum);
        Console.ReadKey();

        int SafeGetValAt(int x, int y)
        {
            try
            {
                return map[x, y];
            }
            catch (IndexOutOfRangeException)
            {
                return int.MaxValue;
            }
        }

        bool IsLowPoint(int x, int y)
        {
            if (SafeGetValAt(x, y - 1) > map[x, y])
            {
                if (SafeGetValAt(x - 1, y) > map[x, y])
                {
                    if (SafeGetValAt(x + 1, y) > map[x, y])
                    {
                        if (SafeGetValAt(x, y + 1) > map[x, y])
                        {
                            return true;
                        }
                    }
                }
            }


            //if (SafeGetValAt(x - 1, y - 1) > map[x, y])
            //{
            //    if (SafeGetValAt(x, y - 1) > map[x, y])
            //    {
            //        if (SafeGetValAt(x + 1, y - 1) > map[x, y])
            //        {
            //            if (SafeGetValAt(x - 1, y) > map[x, y])
            //            {
            //                if (SafeGetValAt(x + 1, y) > map[x, y])
            //                {
            //                    if (SafeGetValAt(x - 1, y + 1) > map[x, y])
            //                    {
            //                        if (SafeGetValAt(x, y + 1) > map[x, y])
            //                        {
            //                            if (SafeGetValAt(x + 1, y + 1) > map[x, y])
            //                            {
            //                                return true;
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}

            return false;
        }
    }
}
