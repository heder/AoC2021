class Program
{
    static void Main()
    {
        List<int> fish = File.ReadLines("in.txt").First().Split(',').Select(f => Convert.ToInt32(f)).ToList();
        long[] buckets = new long[9];

        foreach (var item in fish)
        {
            buckets[item]++;
        }

        Console.WriteLine($"initial : fish: {buckets.Sum()}");

        for (int i = 1; i <= 256; i++)
        {
            Console.WriteLine($"iter: {i} : fish: {buckets.Sum()}");

            long toAdd = 0;

            for (int b = 0; b < 9; b++)
            {
                if (b == 0)
                {
                    toAdd = buckets[0];
                    buckets[0] = 0;
                }
                else
                {
                    buckets[b - 1] += buckets[b];
                    buckets[b] = 0;
                }
            }

            buckets[6] += toAdd;
            buckets[8] += toAdd;
        }

        var c = buckets.Sum(f => f);
        Console.WriteLine(c);
        Console.ReadKey();
    }
}

