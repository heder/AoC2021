class Program
{
    public enum Cucumber
    {
        Empty = 0,
        Right = 1,
        Down = 2
    }

    static void Main()
    {
        var lines = File.ReadLines("in.txt").ToArray();

        int sx = lines[0].Length;
        int sy = lines.Length;

        Cucumber[,] map = new Cucumber[sx, sy];
        for (int y = 0; y < sy; y++)
        {
            for (int x = 0; x < sx; x++)
            {
                switch (lines[y][x])
                {
                    case '>':
                        map[x, y] = Cucumber.Right;
                        break;

                    case 'v':
                        map[x, y] = Cucumber.Down;
                        break;

                    case '.':
                        map[x, y] = Cucumber.Empty;
                        break;
                }
            }
        }

        int iter = 0;
        int moved = 0;
        bool right = true;

        //Console.WriteLine(iter);
        //DumpState();

        while (true)
        {
            moved = 0;
            iter++;
            MoveRight();

            //Console.WriteLine(iter);
            //DumpState();

            MoveDown();

            //Console.WriteLine($"After {iter} steps");
            //DumpState();

            if (moved == 0)
            {
                Console.WriteLine(iter);
                Console.ReadKey();
            }
        }



        void MoveRight()
        {
            for (int y = 0; y < sy; y++)
            {
                // Was current row first pos free
                bool free = (map[0, y] == Cucumber.Empty);

                for (int x = 0; x < sx; x++)
                {
                    if (map[x, y] == Cucumber.Right)
                    {
                        // If we are at right edge
                        if (x == sx - 1)
                        {
                            if (free) //(map[0, y] == Cucumber.Empty)
                            {
                                map[0, y] = Cucumber.Right;
                                map[x, y] = Cucumber.Empty;
                                moved++;
                                //x++; // Skip ahead
                            }
                        }
                        // If right position free, move
                        else if (map[x + 1, y] == Cucumber.Empty)
                        {
                            map[x + 1, y] = Cucumber.Right;
                            map[x, y] = Cucumber.Empty;
                            moved++;
                            x++; // Skip ahead
                        }
                    }
                }
            }
        }

        void MoveDown()
        {
            for (int x = 0; x < sx; x++)
            {
                // Was current col first pos free
                bool free = (map[x, 0] == Cucumber.Empty);

                for (int y = 0; y < sy; y++)
                {
                    if (map[x, y] == Cucumber.Down)
                    {
                        // If we are at bottom edge
                        if (y == sy - 1)
                        {
                            if (free) //(map[x, 0] == Cucumber.Empty)
                            {
                                map[x, 0] = Cucumber.Down;
                                map[x, y] = Cucumber.Empty;
                                moved++;
                                //x++; // Skip ahead
                            }
                        }
                        // If below position free, move
                        else if (map[x, y + 1] == Cucumber.Empty)
                        {
                            map[x, y + 1] = Cucumber.Down;
                            map[x, y] = Cucumber.Empty;
                            moved++;
                            y++; // Skip ahead
                        }
                    }
                }
            }
        }


        void DumpState()
        {
            for (int y = 0; y < sy; y++)
            {
                for (int x = 0; x < sx; x++)
                {
                    switch (map[x, y])
                    {
                        case Cucumber.Right:
                            Console.Write('>');
                            break;

                        case Cucumber.Down:
                            Console.Write('v');
                            break;

                        case Cucumber.Empty:
                            Console.Write('.');
                            break;
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }


        //List<Coordinate> GetNeighbours(int x, int y)
        //{
        //    List<Coordinate> ret = new();
        //    //if (TryGetVal(x - 1, y - 1)) ret.Add(new Coordinate(x - 1, y - 1));
        //    if (TryGetVal(x, y - 1)) ret.Add(new Coordinate(x, y - 1));
        //    //if (TryGetVal(x + 1, y - 1)) ret.Add(new Coordinate(x + 1, y - 1));

        //    if (TryGetVal(x - 1, y)) ret.Add(new Coordinate(x - 1, y));
        //    if (TryGetVal(x + 1, y)) ret.Add(new Coordinate(x + 1, y));

        //    //if (TryGetVal(x - 1, y + 1)) ret.Add(new Coordinate(x - 1, y + 1));
        //    if (TryGetVal(x, y + 1)) ret.Add(new Coordinate(x, y + 1));
        //    //if (TryGetVal(x + 1, y + 1)) ret.Add(new Coordinate(x + 1, y + 1));

        //    return ret;
        //}


        //bool TryGetVal(int x, int y)
        //{
        //    if (x < 0 || y < 0 || x > map.GetUpperBound(0) || y > map.GetUpperBound(1))
        //        return false;
        //    else
        //        return true;
        //}

    }
}
