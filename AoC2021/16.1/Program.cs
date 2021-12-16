using System.Collections;
using System.Globalization;

class Program
{
    static void Main()
    {
        var line = File.ReadAllText("in.txt");

        var ba = ConvertHexToBitArray(line);

        int position = 0;
        while (true)
        {

            int version = GetValueFromBitarray(3, position, ba);
            Console.WriteLine($"Packet ID: {version}");

            position+=3;

            int type = GetValueFromBitarray(3, position, ba);
            Console.WriteLine($"Packet Type: {type}");

            position += 3;

            Console.WriteLine($"Packet length type: {ba[position]}");

            position += 1;

            int noOfSubPackets = GetValueFromBitarray(11, position, ba);
            Console.WriteLine($"Packet length: {noOfSubPackets}");
            position += 11;

            for (int i = 0; i < noOfSubPackets; i++)
            {
                int subPacket = GetValueFromBitarray(11, position, ba);
                Console.WriteLine($"Subpacket: {subPacket}");
                position += 11;
            }
        }




        int GetValueFromBitarray(int length, int pos, BitArray ba)
        {
            BitArray b = new BitArray(length);
            for (int i = length - 1; i >= 0; i--)
            {
                b[i] = ba[pos];
                pos++;
            }
            var v = new int[1];
            b.CopyTo(v, 0);

            return v[0];
        }

    }





    public static BitArray ConvertHexToBitArray(string hexData)
    {
        if (hexData == null)
            return null; // or do something else, throw, ...

        BitArray ba = new BitArray(4 * hexData.Length);
        for (int i = 0; i < hexData.Length; i++)
        {
            byte b = byte.Parse(hexData[i].ToString(), NumberStyles.HexNumber);
            for (int j = 0; j < 4; j++)
            {
                ba.Set(i * 4 + j, (b & (1 << (3 - j))) != 0);
            }
        }
        return ba;
    }
}

//        int sx = lines[0].Length;
//        int sy = lines.Length;

//        Position[,] map = new Position[sx, sy];
//        for (int y = 0; y < sy; y++)
//        {
//            for (int x = 0; x < sx; x++)
//            {
//                map[x, y] = new();
//                map[x, y].Risk = Convert.ToInt32(char.GetNumericValue(lines[y][x]));
//            }
//        }

//        map[0, 0].Risk = 0;
//        map[0, 0].Distance = 0;
//        DijkstraIsh(new Coordinate(0, 0), 0);

//        int xxx = map[sx - 1, sy - 1].Distance;

//        Console.WriteLine(xxx);
//        Console.ReadKey();



//        void DijkstraIsh(Coordinate pos, int risk)
//        {
//            for (int y = 0; y < sx; y++)
//            {
//                for (int x = 0; x < sy; x++)
//                {
//                    var nb = GetNeighbours(x, y);

//                    foreach (var item2 in nb)
//                    {
//                        if (map[item2.X, item2.Y].Visited == false)
//                        {
//                            int distance = map[x, y].Distance + map[item2.X, item2.Y].Risk;

//                            if (map[item2.X, item2.Y].Distance > distance)
//                                map[item2.X, item2.Y].Distance = distance;
//                        }
//                    }

//                    map[x, y].Visited = true;
//                }
//            }

//            Console.WriteLine();
//            Console.ReadKey();

//        }

//        List<Coordinate> GetNeighbours(int x, int y)
//        {
//            List<Coordinate> ret = new();
//            //if (TryGetVal(x - 1, y - 1)) ret.Add(new Coordinate(x - 1, y - 1));
//            if (TryGetVal(x, y - 1)) ret.Add(new Coordinate(x, y - 1));
//            //if (TryGetVal(x + 1, y - 1)) ret.Add(new Coordinate(x + 1, y - 1));

//            if (TryGetVal(x - 1, y)) ret.Add(new Coordinate(x - 1, y));
//            if (TryGetVal(x + 1, y)) ret.Add(new Coordinate(x + 1, y));

//            //if (TryGetVal(x - 1, y + 1)) ret.Add(new Coordinate(x - 1, y + 1));
//            if (TryGetVal(x, y + 1)) ret.Add(new Coordinate(x, y + 1));
//            //if (TryGetVal(x + 1, y + 1)) ret.Add(new Coordinate(x + 1, y + 1));

//            return ret;
//        }


//        bool TryGetVal(int x, int y)
//        {
//            if (x < 0 || y < 0 || x > map.GetUpperBound(0) || y > map.GetUpperBound(1))
//                return false;
//            else
//                return true;
//        }

//    }
//}


//class Position
//{
//    public Position()
//    {
//        Distance = int.MaxValue;
//    }

//    public int Risk { get; set; }
//    public bool Visited { get; set; }

//    public int Distance { get; set; }
//}

//class Coordinate
//{
//    public Coordinate(int x, int y)
//    {
//        X = x;
//        Y = y;
//    }

//    public int X;
//    public int Y;
//}