using System.Text;

class Program
{
    static void Main()
    {
        var lines = File.ReadLines("in.txt").ToArray();

        int line = 0;
        string template = lines[line];
        line += 2;

        Dictionary<string, long> pairs = new();
        Dictionary<string, char> charMap = new();
        Dictionary<char, long> buckets = new();

        var x = template
            .GroupBy(f => f)
            .Select(f => new { letter = f.Key, count = f.Count() })
            .OrderBy(f => f.count)
            .ToList();

        foreach (var item in x)
        {
            buckets.Add(item.letter, item.count);
        }

        for (int i = 0; i < template.Length - 1; i++)
        {
            if (pairs.ContainsKey(template.Substring(i, 2)) == false)
                pairs.Add(template.Substring(i, 2), 1);
            else
                pairs[template.Substring(i, 2)]++;
        }

        while (line < lines.Length)
        {
            var splitted = lines[line].Split("->").Select(x => x.Trim()).ToArray();
            charMap.Add(splitted[0], splitted[1][0]);

            if (buckets.ContainsKey(splitted[1][0]) == false)
                buckets.Add(splitted[1][0], 0);

            line++;
        }

        for (int s = 0; s < 40; s++)
        {
            Dictionary<string, long> workPairs = new(pairs);

            for (int i = 0; i < workPairs.Count; i++)
            {
                var oldPair = workPairs.ElementAt(i);
                var pair = pairs.ElementAt(i);

                var newletter = charMap[pair.Key];
                var newPair1 = $"{pair.Key[0]}{newletter}";
                var newPair2 = $"{newletter}{pair.Key[1]}";

                if (pairs.ContainsKey(newPair1) == false)
                    pairs.Add(newPair1, 0);

                if (pairs.ContainsKey(newPair2) == false)
                    pairs.Add(newPair2, 0);

                pairs[newPair1] += oldPair.Value;
                pairs[newPair2] += oldPair.Value;
                buckets[newletter] += oldPair.Value;
                pairs[pair.Key] -= oldPair.Value;
            }
        }

        long max = buckets.Max(f => f.Value);
        long min = buckets.Min(f => f.Value);

        long res = max - min;

        Console.WriteLine(res);
        Console.ReadKey();
    }
}