class Program
{
    static void Main()
    {
        var lines = File.ReadLines("in.txt").ToArray();

        Dictionary<char, char> tokens = new() { { '(', ')' }, { '[', ']' }, { '{', '}' }, { '<', '>' } };
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
                    var t = stack.Peek();
                    if (tokens[t] == token)
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

            foreach (var item in i)
            {
                var x = tokens[item];
                score *= 5;
                switch (x)
                {
                    case ')':
                        score += 1;
                        break;

                    case ']':
                        score += 2;
                        break;

                    case '}':
                        score += 3;
                        break;

                    case '>':
                        score += 4;
                        break;

                    default:
                        break;
                }
            }

            scores.Add(score);
        }

        var s = scores.OrderBy(x => x).ToList()[scores.Count / 2];

        Console.WriteLine(s);
        Console.ReadKey();
    }
}
