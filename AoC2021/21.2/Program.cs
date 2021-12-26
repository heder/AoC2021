class Program
{
    static void Main()
    {
        var lines = File.ReadLines("in.txt").ToArray();

        //List<Player> players = new List<Player>();
        Dictionary<string, Game> games = new Dictionary<string, Game>();

        var g = new Game();
        g.ActiveGames = 1;
        g.p1 = new Player() { CurrentPosition = Convert.ToInt32(lines[0][28].ToString()) };
        g.p2 = new Player() { CurrentPosition = Convert.ToInt32(lines[1][28].ToString()) };

        long p1w = 0;
        long p2w = 0;

        games.Add(g.GameState(), g);

        while (games.Any(f => f.Value.ActiveGames > 0))
        {
            Console.WriteLine(games.Count());

            //games = games.Where(f => f.Value.ActiveGames > 0).ToDictionary(f => f.Key, f => f.Value);

            var gc1 = games.Count;
            for (int i = 0; i < gc1; i++)
            {
                var game = games.ElementAt(i);
                if (game.Value.ActiveGames > 0)
                {

                    {
                        // Play P1
                        var g1 = new Game(game.Value);
                        g1.p1.Step(1);
                        if (games.TryAdd(g1.GameState(), g1))
                            games[g1.GameState()].ActiveGames = game.Value.ActiveGames;
                        else
                            games[g1.GameState()].NewActiveGames += game.Value.ActiveGames;

                        var g2 = new Game(game.Value);
                        g2.p1.Step(2);

                        if (games.TryAdd(g2.GameState(), g2))
                            games[g2.GameState()].ActiveGames = game.Value.ActiveGames;
                        else
                            games[g2.GameState()].NewActiveGames += (game.Value.ActiveGames);

                        var g3 = new Game(game.Value);
                        g3.p1.Step(3);

                        if (games.TryAdd(g3.GameState(), g3))
                            games[g3.GameState()].ActiveGames = game.Value.ActiveGames;
                        else
                            games[g3.GameState()].NewActiveGames += (game.Value.ActiveGames);

                        game.Value.ActiveGames = 0;
                    }
                }
            }

            foreach (var item in games)
            {
                item.Value.ActiveGames += item.Value.NewActiveGames;
                item.Value.NewActiveGames = 0;
            }
            foreach (var item in games)
            {
                if (item.Value.p1.Score >= 21)
                {
                    p1w += item.Value.ActiveGames;
                    item.Value.ActiveGames = 0;
                }
            }




            var gc2 = games.Count;
            for (int i = 0; i < gc2; i++)
            {
                var game = games.ElementAt(i);
                if (game.Value.ActiveGames > 0)
                {

                    {
                        // Play P2
                        var g1 = new Game(game.Value);
                        g1.p2.Step(1);

                        if (games.TryAdd(g1.GameState(), g1))
                            games[g1.GameState()].ActiveGames = game.Value.ActiveGames;
                        else
                            games[g1.GameState()].NewActiveGames += (game.Value.ActiveGames);


                        var g2 = new Game(game.Value);
                        g2.p2.Step(2);

                        if (games.TryAdd(g2.GameState(), g2))
                            games[g2.GameState()].ActiveGames = game.Value.ActiveGames;
                        else
                            games[g2.GameState()].NewActiveGames += (game.Value.ActiveGames);

                        var g3 = new Game(game.Value);
                        g3.p2.Step(3);

                        if (games.TryAdd(g3.GameState(), g3))
                            games[g3.GameState()].ActiveGames = game.Value.ActiveGames;
                        else
                            games[g3.GameState()].NewActiveGames += (game.Value.ActiveGames);

                        game.Value.ActiveGames = 0;
                    }
                }
            }

            foreach (var item in games)
            {
                item.Value.ActiveGames += item.Value.NewActiveGames;
                item.Value.NewActiveGames = 0;
            }
            foreach (var item in games)
            {
                if (item.Value.p2.Score >= 21)
                {
                    p2w += item.Value.ActiveGames;
                    item.Value.ActiveGames = 0;
                }
            }

            Console.WriteLine($"p1w: {p1w} : p2w: {p2w}");

        }

        Console.WriteLine(p1w);
        Console.WriteLine(p2w);
        Console.ReadKey();
    }
}



class Game
{

    public Game(Game c)
    {
        p1 = new Player(c.p1);
        p2 = new Player(c.p2);
        //ActiveGames = c.ActiveGames;
    }

    public Game()
    {
        p1 = new Player();
        p2 = new Player();
    }

    public long ActiveGames { get; set; }

    public long NewActiveGames { get; set; }

    public string GameState()
    {
        return $"{p1.CurrentPosition},{p1.Score},{p2.CurrentPosition},{p2.Score}";
    }

    public Player p1 { get; set; }
    public Player p2 { get; set; }
}


class Player
{
    public Player()
    {
    }

    public Player(Player c)
    {
        Score = c.Score;
        CurrentPosition = c.CurrentPosition;
    }

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
