class Program
{
    static void Main()
    {
        var lines = File.ReadLines("in.txt").ToArray();
        int pos = 0;
        var filter = lines[pos].Select(f => Convert.ToBoolean(f == '#' ? 1 : 0)).ToArray();
        pos += 2;

        const int infinity = 100;
        int parsesx = lines[pos].Length;
        int parsesy = lines.Length - 2;

        int sx = lines[pos].Length + (infinity * 2);
        int sy = lines.Length - 2 + (infinity * 2);

        bool[,] array1 = new bool[sx, sy];
        bool[,] array2 = new bool[sx, sy];

        //DumpState(ref array1);

        {
            int x = infinity;
            int y = infinity;
            while (pos < lines.Length)
            {
                x = infinity;

                for (int i = 0; i < parsesx; i++)
                {
                    array1[x, y] = lines[pos][i] == '#' ? true : false;
                    x++;
                }

                y++;
                pos++;
            }
        }

        //DumpState(ref array1);

        bool flip = false;
        int off = 1;

        for (int i = 0; i < 50; i++)
        {
            if (flip == false)
            {
                Enhance(filter, sx, sy, array1, array2, off);
                //DumpState(ref array2);
            }
            else
            {
                Enhance(filter, sx, sy, array2, array1, off);
                //DumpState(ref array1);
            }

            flip = !flip;
            off++;

        }

        if (!flip)
            Count(ref array1);
        else
            Count(ref array2);

        Console.ReadKey();


        int GetNeighbours(int x, int y, ref bool[,] image)
        {
            List<bool> ret = new();
            if (TryGetVal(ref image, x - 1, y - 1)) ret.Add(image[x - 1, y - 1]);
            if (TryGetVal(ref image, x, y - 1)) ret.Add(image[x, y - 1]);
            if (TryGetVal(ref image, x + 1, y - 1)) ret.Add(image[x + 1, y - 1]);

            if (TryGetVal(ref image, x - 1, y)) ret.Add(image[x - 1, y]);
            if (TryGetVal(ref image, x, y)) ret.Add(image[x, y]);
            if (TryGetVal(ref image, x + 1, y)) ret.Add(image[x + 1, y]);

            if (TryGetVal(ref image, x - 1, y + 1)) ret.Add(image[x - 1, y + 1]);
            if (TryGetVal(ref image, x, y + 1)) ret.Add(image[x, y + 1]);
            if (TryGetVal(ref image, x + 1, y + 1)) ret.Add(image[x + 1, y + 1]);

            string r = "";
            foreach (var item in ret)
            {
                r += (item == true) ? "1" : "0";
            }

            return Convert.ToInt32(r, 2);
        }


        bool TryGetVal(ref bool[,] image, int x, int y)
        {
            if (x < 0 || y < 0 || x > image.GetUpperBound(0) || y > image.GetUpperBound(1))
                return false;
            else
                return true;
        }


        void DumpState(ref bool[,] dump)
        {
            for (int y = 0; y < sy; y++)
            {
                for (int x = 0; x < sx; x++)
                {
                    Console.Write(dump[x, y] == true ? '#' : '.');
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }


        void Count(ref bool[,] dump)
        {
            int c = 0;
            for (int y = 0; y < sy; y++)
            {
                for (int x = 0; x < sx; x++)
                {
                    c += dump[x, y] == true ? 1 : 0;
                }
            }

            Console.WriteLine(c);
        }


        void Enhance(bool[] filter, int sx, int sy, bool[,] image, bool[,] destination, int off)
        {
            for (int y = off; y < sy - off; y++)
            {
                for (int x = off; x < sx - off; x++)
                {
                    var index = GetNeighbours(x, y, ref image);
                    var result = filter[index];
                    destination[x, y] = result;
                }
            }
        }
    }
}
