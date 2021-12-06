class Program
{
    static void Main()
    {
        
        List<Fish> fish = File.ReadLines("in.txt").First().Split(',').Select(f => new Fish() { daysLeft = Convert.ToInt32(f) }).ToList();

        for (int i = 0; i < 256; i++)
        {
            int toAdd = 0;

            Console.WriteLine($"{i} : {fish.Count()}");

            foreach (var item in fish)
            {
                if (item.daysLeft == 0)
                {
                    toAdd++;
                    item.daysLeft = 6;
                }
                else
                {
                    item.daysLeft--;
                }
            }

            for (int j = 0; j < toAdd; j++)
            {
                fish.Add(new Fish() { daysLeft = 8 });
            }

        }

        Console.WriteLine(fish.Count);
        Console.ReadKey();
    }
}


class Fish
{
    public int daysLeft { get; set; }
}

