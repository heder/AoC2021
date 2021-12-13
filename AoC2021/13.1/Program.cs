

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

                ys = foldalong - 1;
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

                xs = foldalong - 1;
            }

            break;
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


//        if (caves.TryGetValue(f, out Cave? from) == false)
//        {
//            caves.Add(f, from = new Cave(f));

//            if (f.All(f => char.IsLower(f)))
//                from.CanVisitOnce = true;
//        }

//        if (caves.TryGetValue(t, out Cave? to) == false)
//        {
//            caves.Add(t, to = new Cave(t));

//            if (t.All(f => char.IsLower(f)))
//                to.CanVisitOnce = true;
//        }

//        from.Paths.Add(to);
//        to.Paths.Add(from);
//    }

//    var startN = caves["start"];
//    var l = new List<string>();
//    List<string> paths = new();

//    int p = 0;

//    TraverseGraph(startN, l);

//    Console.WriteLine(p);
//        Console.ReadKey();


//        void TraverseGraph(Cave node, List<string> path)
//    {
//        path.Add(node.Name);

//        if (node.Name == "end")
//        {
//            Console.WriteLine(string.Join(',', path.ToArray()));
//            p++;
//            return;
//        }
//        else
//        {
//            var dest = node.Paths.Where(f => f.CanVisitOnce == false || f.CanVisitOnce == true && path.Contains(f.Name) == false);

//            foreach (var n in dest)
//            {
//                TraverseGraph(n, new List<string>(path));
//            }
//        }
//    }
//}
//}

//class Cave
//{
//    public Cave(string name)
//    {
//        Name = name;
//        Paths = new();
//    }

//    public string Name { get; set; }
//    public List<Cave> Paths { get; set; }
//    public bool CanVisitOnce { get; set; }
//}
