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
                consumption += Math.Abs(crab - i);
            }

            lowest = Math.Min(consumption, lowest);
        }

        Console.WriteLine(lowest);
        Console.ReadKey();
    }
}
