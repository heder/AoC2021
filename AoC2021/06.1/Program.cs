class Program
{
    static void Main()
    {
        
        List<Fish> fish = File.ReadLines("in.txt").First().Split(',').Select(f => new Fish() { DaysLeft = Convert.ToInt32(f) }).ToList();

        for (int i = 0; i < 256; i++)
        {
            int toAdd = 0;

            Console.WriteLine($"{i} : {fish.Count}");

            foreach (var item in fish)
            {
                if (item.DaysLeft == 0)
                {
                    toAdd++;
                    item.DaysLeft = 6;
                }
                else
                {
                    item.DaysLeft--;
                }
            }

            for (int j = 0; j < toAdd; j++)
            {
                fish.Add(new Fish() { DaysLeft = 8 });
            }

        }

        Console.WriteLine(fish.Count);
        Console.ReadKey();
    }
}


class Fish
{
    public int DaysLeft { get; set; }
}

