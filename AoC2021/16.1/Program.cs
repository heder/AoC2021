﻿using System.Collections;
using System.Globalization;

class Program
{
    static void Main()
    {
        var line = File.ReadAllText("in.txt");

        var ba = ConvertHexToBitArray(line);

        int position = 0;
        long totalVersion = 0;
        DecodePacket();
        Console.WriteLine(totalVersion);
        // ---

        void DecodePacket()
        {
            long version = GetValueFromBitarray(3, position, ba);
            Console.WriteLine($"Packet version: {version}");
            position += 3;
            totalVersion += version;

            long type = GetValueFromBitarray(3, position, ba);
            Console.WriteLine($"Packet id: {type}");
            position += 3;

            if (type == 4)
            {
                // Literal packet
                List<bool> bitsList = new List<bool>();
                while (true)
                {
                    var status = ba[position];
                    position++;

                    for (long i = 0; i < 4; i++)
                    {
                        bitsList.Add(ba[position]);
                        position++;
                    }

                    if (status == false)
                    {
                        var bl = bitsList.ToArray();
                        long val = GetValueFromBitarray(bitsList.Count, 0, new BitArray(bl));
                        Console.WriteLine($"Literal: {val}");
                        break;
                    }
                }
            }
            else
            {
                // Operator packet
                var lengthTypeId = ba[position];
                Console.WriteLine($"Length type ID: {lengthTypeId}");
                position++;

                if (lengthTypeId == false)
                {
                    // 15 bits that represent the total length in bits of the subpackets contained by this packet
                    long totalSubpacketLength = GetValueFromBitarray(15, position, ba);
                    Console.WriteLine($"Total subpacket length: {totalSubpacketLength}");
                    position += 15;

                    long currentpos = position;
                    while (position < currentpos + totalSubpacketLength)
                    {
                        DecodePacket();
                    }
                }
                else if (lengthTypeId == true)
                {
                    // 11 bits that represents the number of sub-packets immediately contained by this packet
                    long totalNoOfSubpackets = GetValueFromBitarray(11, position, ba);
                    Console.WriteLine($"No of subpackets: {totalNoOfSubpackets}");
                    position += 11;

                    for (long i = 0; i < totalNoOfSubpackets; i++)
                    {
                        DecodePacket();
                    }
                }
            }

            long GetValueFromBitarray(int length, int pos, BitArray ba)
            {
                string bits = "";
                for (int i = 0; i < length; i++)
                {
                    bits += (ba[pos + i]) ? "1" : "0";
                }

                return Convert.ToInt64(bits, 2);
            }
        }
    }

    private static BitArray ConvertHexToBitArray(string hexData)
    {
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
