class Program
{
    static void Main()
    {
        var lines = File.ReadLines("in.txt").ToArray();

        int noOf1 = 0;
        int noOf4 = 0;
        int noOf7 = 0;
        int noOf8 = 0;

        for (int i = 0; i < lines.Length; i++)
        {
            var splitted = lines[i].Split('|');
            var digits = splitted[1].Trim().Split(' ').ToList();

            noOf1 += digits.Count(f => f.Length == 2);
            noOf4 += digits.Count(f => f.Length == 4);
            noOf7 += digits.Count(f => f.Length == 3);
            noOf8 += digits.Count(f => f.Length == 7);
        }

        int tot = noOf1 + noOf4 + noOf7 + noOf8;

        Console.WriteLine(tot);
        Console.ReadKey();
    }
}
