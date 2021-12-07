class Program
{
    static void Main()
    {
        List<int> crabs = File.ReadLines("in.txt").First().Split(',').Select(f => Convert.ToInt32(f)).ToList();

        var lbound = crabs.Min();
        var rbound = crabs.Max();

        // bf
        int consumption;
        int lowest = int.MaxValue;
        for (int i = lbound; i <= rbound; i++)
        {
            consumption = 0;

            foreach (var crab in crabs)
            {
                int dist = Math.Abs(crab - i);
                for (int c = 1; c <= dist; c++)
                {
                    consumption += c;
                }
            }

            lowest = Math.Min(consumption, lowest);
        }

        Console.WriteLine(lowest);
        Console.ReadKey();
    }
}
