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

        int maxHeight = int.MinValue;

        
        for (int x = 0; x < 500; x++) // Brute force deluxe
        {
            for (int y = 0; y < 500; y++)
            {
                Throw(x, y);
            }
        }

        Console.WriteLine(maxHeight);


        void Throw(int x, int y)
        {
            Coordinate currentPosition = new Coordinate() { X = 0, Y = 0 };
            Vector speed = new Vector(x, y);

            Console.WriteLine($"Init position: {currentPosition.X},{currentPosition.Y}");
            Console.WriteLine($"Init speed: {speed.X},{speed.Y}");

            int height = int.MinValue;
            while (true)
            {
                height = Math.Max(height, currentPosition.Y);

                currentPosition.Move(speed);
                speed.AdjustSpeed();

                //Console.WriteLine($"Current position: {currentPosition.X},{currentPosition.Y}");
                //Console.WriteLine($"Current speed: {speed.X},{speed.Y}");

                if (currentPosition.X > xupper || currentPosition.Y < ylower)
                {
                    Console.WriteLine("miss");
                    break;
                }

                // Is inside
                if (currentPosition.X <= xupper && currentPosition.X >= xlower && currentPosition.Y <= yupper && currentPosition.Y >= ylower)
                {
                    Console.WriteLine($"inside. height {height}");
                    maxHeight = Math.Max(maxHeight, height);
                    Console.WriteLine($"maxheight so far: {maxHeight}");
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
