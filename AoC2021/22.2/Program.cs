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
                        universe[x, y, z] = rule.action;
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



//int pos = 0;
//var filter = lines[pos].Select(f => Convert.ToBoolean(f == '#' ? 1 : 0)).ToArray();
//pos += 2;

//const int infinity = 100;
//int parsesx = lines[pos].Length;
//int parsesy = lines.Length - 2;

//int sx = lines[pos].Length + (infinity * 2);
//int sy = lines.Length - 2 + (infinity * 2);

//bool[,] array1 = new bool[sx, sy];
//bool[,] array2 = new bool[sx, sy];

////DumpState(ref array1);

//{
//    int x = infinity;
//    int y = infinity;
//    while (pos < lines.Length)
//    {
//        x = infinity;

//        for (int i = 0; i < parsesx; i++)
//        {
//            array1[x, y] = lines[pos][i] == '#' ? true : false;
//            x++;
//        }

//        y++;
//        pos++;
//    }
//}

////DumpState(ref array1);

//bool flip = false;
//int off = 1;

//for (int i = 0; i < 50; i++)
//{
//    if (flip == false)
//    {
//        Enhance(filter, sx, sy, array1, array2, off);
//        //DumpState(ref array2);
//    }
//    else
//    {
//        Enhance(filter, sx, sy, array2, array1, off);
//        //DumpState(ref array1);
//    }

//    flip = !flip;
//    off++;

//}

//if (!flip)
//    Count(ref array1);
//else
//    Count(ref array2);

//Console.ReadKey();


//int GetNeighbours(int x, int y, ref bool[,] image)
//{
//    List<bool> ret = new();
//    if (TryGetVal(ref image, x - 1, y - 1)) ret.Add(image[x - 1, y - 1]);
//    if (TryGetVal(ref image, x, y - 1)) ret.Add(image[x, y - 1]);
//    if (TryGetVal(ref image, x + 1, y - 1)) ret.Add(image[x + 1, y - 1]);

//    if (TryGetVal(ref image, x - 1, y)) ret.Add(image[x - 1, y]);
//    if (TryGetVal(ref image, x, y)) ret.Add(image[x, y]);
//    if (TryGetVal(ref image, x + 1, y)) ret.Add(image[x + 1, y]);

//    if (TryGetVal(ref image, x - 1, y + 1)) ret.Add(image[x - 1, y + 1]);
//    if (TryGetVal(ref image, x, y + 1)) ret.Add(image[x, y + 1]);
//    if (TryGetVal(ref image, x + 1, y + 1)) ret.Add(image[x + 1, y + 1]);

//    string r = "";
//    foreach (var item in ret)
//    {
//        r += (item == true) ? "1" : "0";
//    }

//    return Convert.ToInt32(r, 2);
//}


//bool TryGetVal(ref bool[,] image, int x, int y)
//{
//    if (x < 0 || y < 0 || x > image.GetUpperBound(0) || y > image.GetUpperBound(1))
//        return false;
//    else
//        return true;
//}


//void DumpState(ref bool[,] dump)
//{
//    for (int y = 0; y < sy; y++)
//    {
//        for (int x = 0; x < sx; x++)
//        {
//            Console.Write(dump[x, y] == true ? '#' : '.');
//        }

//        Console.WriteLine();
//    }

//    Console.WriteLine();
//}


//void Count(ref bool[,] dump)
//{
//    int c = 0;
//    for (int y = 0; y < sy; y++)
//    {
//        for (int x = 0; x < sx; x++)
//        {
//            c += dump[x, y] == true ? 1 : 0;
//        }
//    }

//    Console.WriteLine(c);
//}


//void Enhance(bool[] filter, int sx, int sy, bool[,] image, bool[,] destination, int off)
//{
//    for (int y = off; y < sy - off; y++)
//    {
//        for (int x = off; x < sx - off; x++)
//        {
//            var index = GetNeighbours(x, y, ref image);
//            var result = filter[index];
//            destination[x, y] = result;
//        }
//    }
//}
//    }
//}
