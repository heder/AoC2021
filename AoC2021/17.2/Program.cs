class Program
{
    static void Main()
    {
        var line = File.ReadAllText("in.txt");

        var b = line.Split(':')[1].Split(",");

        var d1 = b[0].Split("=")[1].Split("..");
        var d2 = b[1].Split("=")[1].Split("..");

        var xlower = Convert.ToInt32(d1[0]);
        var xupper = Convert.ToInt32(d1[1]);

        var ylower = Convert.ToInt32(d2[0]);
        var yupper = Convert.ToInt32(d2[1]);

        HashSet<string> hit = new();

        
        for (int x = -1000; x < 1000; x++) // Brute force deluxe
        {
            for (int y = -1000; y < 1000; y++)
            {
                Throw(x, y);
            }
        }

        int c = hit.Distinct().Count();
        Console.WriteLine(c);

        void Throw(int x, int y)
        {
            Coordinate currentPosition = new Coordinate() { X = 0, Y = 0 };
            Vector speed = new Vector(x, y);

            while (true)
            {
                currentPosition.Move(speed);
                speed.AdjustSpeed();

                if (currentPosition.X > xupper || currentPosition.Y < ylower)
                    break;

                if (currentPosition.X <= xupper && currentPosition.X >= xlower && currentPosition.Y <= yupper && currentPosition.Y >= ylower)
                {
                    hit.Add($"{x},{y}");
                }
            }

            return;
        }
    }
}

class Vector
{
    public Vector(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X;
    public int Y;

    public void AdjustSpeed()
    {
        if (X > 0)
            X--;
        else if (X < 0)
            X++;

        Y--;
    }
}

class Coordinate
{
    public int X;
    public int Y;

    public void Move(Vector v)
    {
        X += v.X;
        Y += v.Y;
    }
}
