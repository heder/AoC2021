class Program
{
    static void Main()
    {
        var lines = File.ReadLines("in.txt").ToList();

        List<Range3D> rules = new();

        foreach (var line in lines)
        {
            var parts1 = line.Split(',').ToArray();

            var ran = new Range3D();

            ran.action = line[0..2] == "on";

            var x = parts1[0].Split("=");
            var xr = x[1].Split("..");

            var y = parts1[1].Split("=");
            var yr = y[1].Split("..");

            var z = parts1[2].Split("=");
            var zr = z[1].Split("..");

            ran.xmin = Math.Min(Convert.ToInt32(xr[0]), Convert.ToInt32(xr[1]));
            ran.xmax = Math.Max(Convert.ToInt32(xr[0]), Convert.ToInt32(xr[1]));

            ran.ymin = Math.Min(Convert.ToInt32(yr[0]), Convert.ToInt32(yr[1]));
            ran.ymax = Math.Max(Convert.ToInt32(yr[0]), Convert.ToInt32(yr[1]));

            ran.zmin = Math.Min(Convert.ToInt32(zr[0]), Convert.ToInt32(zr[1]));
            ran.zmax = Math.Max(Convert.ToInt32(zr[0]), Convert.ToInt32(zr[1]));

            rules.Add(ran);
        }

        bool[,,] universe = new bool[101, 101, 101];


        foreach (var rule in rules)
        {
            // Shift up
            rule.xmin += 50;
            rule.xmax += 50;
            rule.ymin += 50;
            rule.ymax += 50;
            rule.zmin += 50;
            rule.zmax += 50;

            if (rule.xmin < 0 || rule.xmin > 100 || rule.xmax < 0 || rule.xmax > 100 ||
                rule.ymin < 0 || rule.ymin > 100 || rule.ymax < 0 || rule.ymax > 100 ||
                rule.zmin < 0 || rule.zmin > 100 || rule.zmax < 0 || rule.zmax > 100)
            {
                continue;
            }

            for (int x = rule.xmin; x <= rule.xmax; x++)
            {
                for (int y = rule.ymin; y <= rule.ymax; y++)
                {
                    for (int z = rule.zmin; z <= rule.zmax; z++)
                    {
                        universe[x,y,z] = rule.action;
                    }
                }
            }

        }

        int count = 0;
        for (int x = 0; x < 101; x++)
        {
            for (int y = 0; y < 101; y++)
            {
                for (int z = 0; z < 101; z++)
                {
                    if (universe[x, y, z] == true) count++;
                }
            }
        }

        Console.WriteLine(count);
        Console.ReadKey();

    }
}


class Range3D
{
    public bool action;

    public int xmin;
    public int xmax;

    public int ymin;
    public int ymax;

    public int zmin;
    public int zmax;

}
