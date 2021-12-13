

class Program
{
    static void Main()
    {
        var lines = File.ReadLines("in.txt").ToArray();

        int xs = 0;
        int ys = 0;

        List<Tuple<char, int>> fold = new();

        int l = 0;
        while (lines[l].Length > 0)
        {
            var path = lines[l].Split(',');
            var x = Convert.ToInt32(path[0]);
            var y = Convert.ToInt32(path[1]);

            xs = Math.Max(xs, x);
            ys = Math.Max(ys, y);
            l++;
        }

        xs++;
        ys++;

        bool[,] paper = new bool[xs, ys];

        int line = 0;
        while (lines[line].Length > 0)
        {
            var path = lines[line].Split(',');
            var x = Convert.ToInt32(path[0]);
            var y = Convert.ToInt32(path[1]);

            paper[x, y] = true;

            line++;
        }

        line++;

        for (int i = line; i < lines.Length; i++)
        {
            // Fold
            var path = lines[i].Split('=');
            fold.Add(new Tuple<char, int>(path[0].Last(), Convert.ToInt32(path[1])));
        }


        foreach (var item in fold)
        {
            int foldalong = item.Item2;

            if (item.Item1 == 'x')
            {
                for (int y = 0; y < ys; y++)
                {
                    for (int x = 1; x <= foldalong; x++)
                    {
                        paper[foldalong - x, y] = paper[foldalong - x, y] || paper[foldalong + x, y];
                    }
                }

                xs = foldalong;
            }

            if (item.Item1 == 'y')
            {
                for (int x = 0; x < xs; x++)
                {
                    for (int y = 1; y <= foldalong; y++)
                    {
                        paper[x, foldalong - y] = paper[x, foldalong - y] || paper[x, foldalong + y];
                    }
                }

                ys = foldalong;
            }
        }

        int dots = 0;
        for (int x = 0; x < xs; x++)
        {
            for (int y = 0; y < ys; y++)
            {
                if (paper[x,y] == true) dots++;
            }
        }
    }
}
