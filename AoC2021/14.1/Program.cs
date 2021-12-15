using System.Text;

class Program
{
    static void Main()
    {
        var lines = File.ReadLines("in.txt").ToArray();

        int line = 0;

        string template = lines[line];
        line += 2;

        Dictionary<string, char> map = new();

        while (line < lines.Length)
        {
            var splitted = lines[line].Split("->").Select(x => x.Trim()).ToArray();
            map.Add(splitted[0], splitted[1][0]);
            line++;
        }

        StringBuilder result = new();
        for (int s = 0; s < 10; s++)
        {
            for (int i = 0; i < template.Length - 1; i++)
            {
                result.Append(template[i]);
                result.Append(map[template.Substring(i,2)]);
            }

            result.Append(template.Last());
            template = result.ToString();
            result.Clear();
        }

        var x = template
            .GroupBy(f => f)
            .Select(f => new { letter = f.Key, count = f.Count() })
            .OrderBy(f => f.count)
            .ToList();

        int max = x.Last().count;
        int min = x.First().count;
        int res = max - min;

        Console.WriteLine(res);
        Console.ReadKey();
    }
}