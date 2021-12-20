class Program
{
    static void Main()
    {
        var lines = File.ReadAllLines("in.txt");

        int largest = 0;

        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < lines.Length; j++)
            {
                string sum = Add(lines[i], lines[j]);
                Reduce(ref sum);
                var x = CalculateMagnitude(sum, 0);
                largest = Math.Max(x, largest);
            }
        }

        Console.WriteLine(largest);
        Console.ReadKey();

        string Add(string num1, string num2)
        {
            return $"[{num1},{num2}]";
        }

        void Reduce(ref string no)
        {
            int explodeactions = 1;
            int splitactions = 1;

            while (explodeactions > 0 || splitactions > 0)
            {
                explodeactions = 0;
                splitactions = 0;

                if (Explode(ref no) == true)
                {
                    explodeactions++;
                }
                else
                if (Split(ref no) == true)
                {
                    splitactions++;
                }

                Console.WriteLine(no);
            }
        }



        bool Split(ref string no)
        {
            bool action = false;
            for (int i = 0; i < no.Length; i++)
            {
                if (char.IsNumber(no[i]))
                {
                    // Find , or ]
                    int to = no.IndexOfAny(new char[] { ',', ']' }, i);
                    int check = Convert.ToInt32(no[(i)..(to)]);
                    if (check >= 10)
                    {
                        var t = GenPair(check);
                        no = no.Remove(i, to - (i));
                        no = no.Insert(i, $"[{t.Item1},{t.Item2}]");
                        action = true;
                        break;
                    }
                }
            }

            if (action) return true; else return false;
        }


        Tuple<int, int> GenPair(int n)
        {
            int L = (int)Math.Floor((decimal)n / (decimal)2);
            int R = (int)Math.Ceiling((decimal)n / (decimal)2);

            return new Tuple<int, int>(L, R);
        }



        bool Explode(ref string no)
        {
            bool action = false;
            int level = 0;
            for (int i = 0; i < no.Length; i++)
            {
                if (no[i] == '[')
                {
                    level++;
                }
                else
                if (no[i] == ']')
                {
                    level--;
                }

                if (level == 5)
                {
                    int startPos = i;
                    int commapos = no.IndexOf(',', startPos);
                    int endpos = no.IndexOf(']', startPos);

                    int L = Convert.ToInt32(no[(i + 1)..(commapos)].ToString());
                    int R = Convert.ToInt32(no[(commapos + 1)..(endpos)].ToString());

                    no = no.Remove(startPos, (endpos - startPos) + 1);
                    no = no.Insert(startPos, "0");

                    int rDest = startPos + 1;
                    while (rDest < no.Length && char.IsNumber(no[rDest]) == false) rDest++;
                    if (rDest < no.Length)
                    {
                        int rComma = rDest;
                        while (no[rComma] != ',' && no[rComma] != ']') rComma++;
                        int rno = Convert.ToInt32(no[rDest..(rComma)]);

                        int destR = R + rno;
                        no = no.Remove(rDest, (rComma) - rDest);
                        no = no.Insert(rDest, destR.ToString());

                        action = true;
                    }

                    int lDest = startPos - 1;
                    while (lDest > 0 && char.IsNumber(no[lDest]) == false) lDest--;
                    if (lDest > 0)
                    {

                        int lComma = lDest;
                        while (no[lComma] != ',' && no[lComma] != '[') lComma--;
                        int lno = Convert.ToInt32(no[(lComma + 1)..(lDest + 1)]);

                        int destL = L + lno;
                        no = no.Remove(lComma + 1, lDest - (lComma));
                        no = no.Insert(lComma + 1, destL.ToString());

                        action = true;
                    }
                }

                if (action) break;

            }

            if (action) return true; else return false;
        }


        int CalculateMagnitude(string sum, int pos)
        {
            if (sum[pos] == '[')
            {
                //find comma when paran bal
                int paran = 0;
                int seek = pos + 1;
                int comma;
                while (true)
                {
                    if (sum[seek] == '[') paran++;
                    if (sum[seek] == ']') paran--;
                    if (sum[seek] == ',' && paran == 0)
                    {
                        comma = seek;
                        break;
                    }

                    seek++;
                }

                var L = CalculateMagnitude(sum, pos + 1);
                var R = CalculateMagnitude(sum, comma + 1);

                return (3 * L) + (2 * R);
            }

            // If we are at number, return number
            if (char.IsNumber(sum[pos]))
            {
                var end = sum.IndexOfAny(new char[] { ',', ']' }, pos);
                var val1 = sum[pos..end];
                return Convert.ToInt32(val1);
            }

            return -1;
        }
    }
}
