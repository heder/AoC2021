class Program
{
    static void Main()
    {
        var lines = File.ReadLines("in.txt").ToArray();

        List<Player> players = new List<Player>();

        foreach (var line in lines)
        {
            players.Add(new Player() { Id = Convert.ToInt32(line[7].ToString()), CurrentPosition = Convert.ToInt32(line[28].ToString()) });
        }


        Dice d = new Dice();
        while (true)
        {
            foreach (var player in players)
            {
                int moves = d.GetNext();
                player.Step(moves);

                if (player.Score >= 1000)
                {
                    Console.WriteLine($"Player {player.Id} wins with score {player.Score}");
                    Console.WriteLine($"Dice thrown {d.Throws} times)");
                    Console.WriteLine($"Losing player has score {players.First(f => f.Id != player.Id).Score})");

                    int i = d.Throws * players.First(f => f.Id != player.Id).Score;
                    Console.WriteLine($"{i}");
                    Console.ReadLine();
                }
            }
        }
    }
}

class Dice
{
    public int Throws;
    public int Current;

    public void Step()
    {
        if (Current < 100)
            Current++;
        else
            Current = 1;
    }

    public int GetNext()
    {
        int score = 0;
        for (int i = 0; i < 3; i++)
        {
            Throws++;
            Step();
            score += Current;
        }

        return score;
    }
}

class Player
{
    public int Id;
    public int Score;
    public int CurrentPosition;

    public void Step(int n)
    {
        for (int i = 0; i < n; i++)
        {
            if (CurrentPosition < 10)
                CurrentPosition++;
            else
                CurrentPosition = 1;
        }

        Score += CurrentPosition;
    }
}

class Board
{
}
