class Program
{
    static void Main()
    {
        var lines = File.ReadLines("in.txt").ToArray();
        int tot = 0;

        for (int i = 0; i < lines.Length; i++)
        {
            var splitted = lines[i].Split('|');
            var map = new Dictionary<int, string>();
            var x = splitted[0].Trim().Split(' ').ToList();

            map.Add(1, x.Single(f => f.Length == 2));
            map.Add(4, x.Single(f => f.Length == 4));
            map.Add(7, x.Single(f => f.Length == 3));
            map.Add(8, x.Single(f => f.Length == 7));
            map.Add(2, x.Single(f => f.Length == 5 && f.Count(g => map[4].Contains(g)) == 2));
            map.Add(5, x.Single(f => f.Length == 5 && f.Count(g => map[2].Contains(g)) == 3));
            map.Add(3, x.Single(f => f.Length == 5 && f.Count(g => map[2].Contains(g)) == 4));
            map.Add(0, x.Single(f => f.Length == 6 && f.Count(g => map[5].Contains(g)) == 4));
            map.Add(6, x.Single(f => f.Length == 6 && f.Count(g => map[5].Contains(g)) == 5 && f.Count(g => map[3].Contains(g)) == 4));
            map.Add(9, x.Single(f => f.Length == 6 && f.Count(g => map[5].Contains(g)) == 5 && f.Count(g => map[3].Contains(g)) == 5));

            string s = "";
            foreach (var item in splitted[1].Trim().Split(' '))
            {
                s += map.Single(f => f.Value.All(g => item.Contains(g)) && f.Value.Length == item.Length).Key;
            }

            tot += Convert.ToInt32(s);
        }

        Console.WriteLine(tot);
        Console.ReadKey();
    }
}
