

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
                    from.CanVisitOnce = true;
            }

            if (caves.TryGetValue(t, out Cave? to) == false)
            { 
                caves.Add(t, to = new Cave(t));

                if (t.All(f => char.IsLower(f)))
                    to.CanVisitOnce = true;
            }

            from.Paths.Add(to);
            to.Paths.Add(from);
        }

        var startN = caves["start"];
        var l = new List<string>();
        List<string> paths = new();

        int p = 0;

        TraverseGraph(startN, l);

        Console.WriteLine(p);
        Console.ReadKey();

        
        void TraverseGraph(Cave node, List<string> path)
        {
            path.Add(node.Name);

            if (node.Name == "end")
            {
                Console.WriteLine(string.Join(',', path.ToArray()));
                p++;
                return;
            }
            else
            {
                var dest = node.Paths.Where(f => f.CanVisitOnce == false || f.CanVisitOnce == true && path.Contains(f.Name) == false);

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
    public bool CanVisitOnce { get; set; }
}
