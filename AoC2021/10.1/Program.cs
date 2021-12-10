class Program
{
    static void Main()
    {
        var lines = File.ReadLines("in.txt").ToArray();

        Dictionary<char, char> tokens = new() { { '(', ')' }, { '[', ']' }, { '{', '}' }, { '<', '>' } };
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
                    var t = stack.Peek();
                    if (tokens[t] == token)
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
        foreach (var item in illegalChars)
        {
            switch (item)
            {
                case ')':
                    score += 3;
                    break;

                case ']':
                    score += 57;
                    break;

                case '}':
                    score += 1197;
                    break;

                case '>':
                    score += 25137;
                    break;

                default:
                    break;
            }

        }

        Console.WriteLine(score);
        Console.ReadKey();
    }
}
