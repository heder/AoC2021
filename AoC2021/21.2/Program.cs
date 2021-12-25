class Program
{
    static void Main()
    {
        var lines = File.ReadLines("in.txt").ToArray();

        List<Player> players = new List<Player>();

        foreach (var line in lines)
        {
            players.Add(new Player() { n = 1, Id = Convert.ToInt32(line[7].ToString()), CurrentPosition = Convert.ToInt32(line[28].ToString()) });
        }


        long boardState[,] = new long[11,]

        //int[] NoOfPlayerOneWithScore = new int[22];
        //int[] NoOfPlayerTwoWithScore = new int[22];

        //int[] NoOfPlayer1OnPosition = new int[11];
        //int[] NoOfPlayer2OnPosition = new int[11];

        //NoOfPlayerOneWithScore[0]++;
        //NoOfPlayerTwoWithScore[0]++;

        //NoOfPlayer1OnPosition[players[0].CurrentPosition]++;
        //NoOfPlayer2OnPosition[players[1].CurrentPosition]++;

        while(true)
        {
            foreach (var player in players)
            {
                player.Step(1);
            }


            // Player 1 throws
            // Multiply all positions in NoOfPlayers with 3


            // Multiply players on board

            // Play
            //int[] newState = new int[11];
            //for (int i = 1; i <= 10; i++)
            //{
            //    NoOfPlayer1OnPosition[i + 1] += NoOfPlayer1OnPosition[i];
            //    NoOfPlayerOneWithScore[]
            //    NoOfPlayer1OnPosition[i + 2] += NoOfPlayer1OnPosition[i];
            //    NoOfPlayer1OnPosition[i + 3] += NoOfPlayer1OnPosition[i];
            //    NoOfPlayer1OnPosition[i] = 0;
            //}


        }


        //Dice d = new Dice();
        //while (true)
        //{
        //    foreach (var player in players)
        //    {
        //        int moves = d.GetNext();
        //        player.Step(moves);

        //        if (player.Score >= 1000)
        //        {
        //            Console.WriteLine($"Player {player.Id} wins with score {player.Score}");
        //            Console.WriteLine($"Dice thrown {d.Throws} times)");
        //            Console.WriteLine($"Losing player has score {players.First(f => f.Id != player.Id).Score})");

        //            int i = d.Throws * players.First(f => f.Id != player.Id).Score;
        //            Console.WriteLine($"{i}");
        //            Console.ReadLine();
        //        }
        //    }
        //}
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
    public long n;

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
