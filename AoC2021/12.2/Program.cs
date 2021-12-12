

class Program
{
    static void Main()
    {
        var lines = File.ReadLines("in.txt").ToArray();

        Dictionary<string, Cave> caves = new();

        foreach (var line in lines)
        {
            var path = line.Split('-');
            var f = path[0];
            var t = path[1];


            if (caves.TryGetValue(f, out Cave? from) == false)
            {
                caves.Add(f, from = new Cave(f));

                if (f.All(f => char.IsLower(f)))
                    from.MaxVisits = 1;
            }

            if (caves.TryGetValue(t, out Cave? to) == false)
            {
                caves.Add(t, to = new Cave(t));

                if (t.All(f => char.IsLower(f)))
                    to.MaxVisits = 1;
            }

            from.Paths.Add(to);
            to.Paths.Add(from);
        }

        var startN = caves["start"];
        var l = new List<string>();
        
        HashSet<string> paths = new();

        var smallCaves = caves.Where(f => f.Value.MaxVisits == 1 && f.Key != "start" && f.Key != "end");
        foreach (var item in smallCaves) // Adjust small caves one by one. This will produce some duplicate paths.
        {
            item.Value.MaxVisits = 2;
            l.Clear();
            TraverseGraph(startN, l);
            item.Value.MaxVisits = 1;
        }

        Console.WriteLine(paths.Count);
        Console.ReadKey();


        void TraverseGraph(Cave node, List<string> path)
        {
            path.Add(node.Name);

            if (node.Name == "end")
            {
                var p = string.Join(',', path.ToArray());
                Console.WriteLine(p);
                if (paths.Contains(p) == false) paths.Add(p); // ...yes, getting some duplicate paths due to the hacky twice-visit-fixup-thingy
                return;
            }
            else
            {
                var dest = node.Paths.Where(f => f.MaxVisits == 0 || f.MaxVisits > 0 && path.Count(g => g.Contains(f.Name)) < f.MaxVisits);
                foreach (var n in dest)
                {
                    TraverseGraph(n, new List<string>(path));
                }
            }
        }
    }
}

class Cave
{
    public Cave(string name)
    {
        Name = name;
        Paths = new();
    }

    public string Name { get; set; }
    public List<Cave> Paths { get; set; }
    public int MaxVisits { get; set; }
}
