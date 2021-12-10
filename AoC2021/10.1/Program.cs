class Program
{
    static void Main()
    {
        var lines = File.ReadLines("in.txt").ToArray();

        Dictionary<char, char> tokens = new() { { '(', ')' }, { '[', ']' }, { '{', '}' }, { '<', '>' } };
        Dictionary<char, int> scoreMap = new() { { ')', 3 }, { ']', 57 }, { '}', 1197 }, { '>', 25137 } };
        List<char> illegalChars = new();

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
                        illegalChars.Add(token);
                        break; ;
                    }
                }
            }
        }

        int score = 0;
        illegalChars.ForEach(f => score += scoreMap[f]);

        Console.WriteLine(score);
        Console.ReadKey();
    }
}
