class Program
{
    static void Main()
    {
        var lines = File.ReadLines("in.txt").ToArray();

        Dictionary<char, char> tokens = new() { { '(', ')' }, { '[', ']' }, { '{', '}' }, { '<', '>' } };
        Dictionary<char, int> scoreMap = new() { { ')', 1 }, { ']', 2 }, { '}', 3 }, { '>', 4 } };
        List<List<char>> autoCompletes = new();

        foreach (var line in lines)
        {
            Stack<char> stack = new();
            for (int i = 0; i < line.Length; i++)
            {
                char token = line[i];
                if (tokens.Keys.Contains(token))
                {
                    stack.Push(token);
                }
                else if (tokens.Values.Contains(token))
                {
                    if (tokens[stack.Peek()] == token)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        // Syntax error
                        break;
                    }
                }

                // Incomplete row, unwind stack
                if (i == line.Length - 1)
                {
                    autoCompletes.Add(stack.ToList());
                }
            }
        }

        List<long> scores = new();
        foreach (var i in autoCompletes)
        {
            long score = 0;
            i.ForEach(f => score = (score * 5) + scoreMap[tokens[f]]);
            scores.Add(score);
        }

        var s = scores.OrderBy(x => x).ToList()[scores.Count / 2];

        Console.WriteLine(s);
        Console.ReadKey();
    }
}
