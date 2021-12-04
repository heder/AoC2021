class Program
{
    static void Main()
    {
        string[] lines = File.ReadLines("in.txt").ToArray();

        var boards = new List<Board>();
        var random = lines[0].Split(',').Select(f => Convert.ToInt32(f)).ToList();
        int line = 2;

        while (line < lines.Length)
        {
            var b = new Board();
            for (int i = 0; i < 5; i++)
            {
                var l = lines[line].Split(' ').Where(f => f != "").Select(f => new Cell() { Value = Convert.ToInt32(f), Marked = false }).ToList();
                b.lines.Add(l);
                line++;
            }

            boards.Add(b);
            line++;
        }

        // Play
        foreach (var num in random)
        {
            foreach (var board in boards)
            {
                if (board.IsComplete == false)
                {
                    board.Mark(num);

                    if (board.IsWinner() == true)
                    {
                        board.IsComplete = true;

                        if (boards.All(f => f.IsComplete))
                        {
                            board.CalculateScore(num);
                        }
                    }
                }
            }
        }
    }
}

class Board
{
    public bool IsComplete;
    public List<List<Cell>> lines = new();

    public void Mark(int val)
    {
        foreach (var item in lines)
        {
            var found = item.FirstOrDefault(f => f.Value == val);
            if (found != null)
            {
                found.Marked = true;
            }
        }
    }

    public bool IsWinner()
    {
        for (int i = 0; i < lines[0].Count; i++)
        {
            if (lines.Select(f => f.ElementAt(i)).All(f => f.Marked))
            {
                return true;
            }
        }

        foreach (var item in lines)
        {
            if (item.All(f => f.Marked))
            {
                return true;
            }
        }

        return false;
    }

    public void CalculateScore(int num)
    {
        int sum = 0;
        foreach (var line in lines)
        {
            sum += line.Where(f => f.Marked == false).Select(f => f.Value).Sum();
        }

        int score = sum * num;

        Console.WriteLine(score);
        Console.ReadKey();
    }
}

class Cell
{
    public int Value { get; set; }
    public bool Marked { get; set; }
}