// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
//long w = 0;
//long x = 0;
//long y = 0;
//long z = 0;
//w = Convert.ToInt32(Console.ReadLine());
//z = z + w;
//z = z % 2;
//w = w / 2;
//y = y + w;
//y = y % 2;
//w = w / 2;
//x = x + w;
//x = x % 2;
//w = w / 2;
//w = w % 2;

long w = 0;
long x = 0;
long y = 0;
long z = 0;

long record = 0;

//for (int a1 = 1; a1 < 10; a1++)
//{
//    Console.WriteLine($"a1: {a1}");

//    for (int a2 = 1; a2 < 10; a2++)
//    {
//        Console.WriteLine($"a2: {a2}");

//        for (int a3 = 1; a3 < 10; a3++)
//        {
//            Console.WriteLine($"a3: {a3}");

//            for (int a4 = 1; a4 < 10; a4++)
//            {
//                Console.WriteLine($"a4: {a4}");

//                for (int a5 = 1; a5 < 10; a5++)
//                {
//                    Console.WriteLine($"a5: {a5}");

//                    for (int a6 = 1; a6 < 10; a6++)
//                    {
//                        Console.WriteLine($"a6: {a6}");

//                        for (int a7 = 1; a7 < 10; a7++)
//                        {
//                            for (int a8 = 1; a8 < 10; a8++)
//                            {
//                                for (int a9 = 1; a9 < 10; a9++)
//                                {
//                                    for (int a10 = 1; a10 < 10; a10++)
//                                    {
//                                        for (int a11 = 1; a11 < 10; a11++)
//                                        {
//                                            for (int a12 = 1; a12 < 10; a12++)
//                                            {
//                                                for (int a13 = 1; a13 < 10; a13++)
//                                                {
//                                                    for (int a14 = 1; a14 < 10; a14++)
//                                                    {

string input = "11111111111111";
w = 0;
x = 0;
y = 0;
z = 0;

// Input 1
w = Convert.ToInt32(input[0].ToString());
x = x * 0; // Sätt x till 0
x = x + z; // plussa på 0
x = x % 26; // x delbart med 26?!
z = z / 1; // dividera 0 med 1
x = x + 12; // x -> 12
x = (x == w) ? 1 : 0; // Alltid 0
x = (x == 0) ? 1 : 0; // Ger x = 1
y = y * 0; // y -> 0
y = y + 25; // y -> 25
y = y * x; // 25 * 1
y = y + 1; // y -> 26
z = z * y; // z -> 0
y = y * 0; // y -> 0
y = y + w; // y = input
y = y + 9; // y = input + 9
y = y * x; // y = input + 9 * 1
z = z + y; // z = input + 9 *************************************

w = Convert.ToInt32(input[1].ToString());
x = x * 0; // x -> 0
x = x + z; // x = z;
x = x % 26; // Är z (resultat från första siffra) delbart med 26
z = z / 1; // dela med 1
x = x + 12; // x -> 12
x = (x == w) ? 1 : 0; // Om input siffra 2 == 12 ->  Alltid 0
x = (x == 0) ? 1 : 0; // Eftersom x alltid 0 ovan -> Alltid 1
y = y * 0;
y = y + 25;
y = y * x;
y = y + 1;
z = z * y;
y = y * 0;
y = y + w;
y = y + 4;
y = y * x;
z = z + y;

w = Convert.ToInt32(input[2].ToString());
x = x * 0;
x = x + z;
x = x % 26;
z = z / 1;
x = x + 12;
x = (x == w) ? 1 : 0;
x = (x == 0) ? 1 : 0;
y = y * 0;
y = y + 25;
y = y * x;
y = y + 1;
z = z * y;
y = y * 0;
y = y + w;
y = y + 2;
y = y * x;
z = z + y;

w = Convert.ToInt32(input[3].ToString());
x = x * 0;
x = x + z;
x = x % 26;
z = z / 26;
x = x + -9;
x = (x == w) ? 1 : 0;
x = (x == 0) ? 1 : 0;
y = y * 0;
y = y + 25;
y = y * x;
y = y + 1;
z = z * y;
y = y * 0;
y = y + w;
y = y + 5;
y = y * x;
z = z + y;

w = Convert.ToInt32(input[4].ToString());
x = x * 0;
x = x + z;
x = x % 26;
z = z / 26;
x = x + -9;
x = (x == w) ? 1 : 0;
x = (x == 0) ? 1 : 0;
y = y * 0;
y = y + 25;
y = y * x;
y = y + 1;
z = z * y;
y = y * 0;
y = y + w;
y = y + 1;
y = y * x;
z = z + y;

w = Convert.ToInt32(input[5].ToString());
x = x * 0;
x = x + z;
x = x % 26;
z = z / 1;
x = x + 14;
x = (x == w) ? 1 : 0;
x = (x == 0) ? 1 : 0;
y = y * 0;
y = y + 25;
y = y * x;
y = y + 1;
z = z * y;
y = y * 0;
y = y + w;
y = y + 6;
y = y * x;
z = z + y;

w = Convert.ToInt32(input[6].ToString());
x = x * 0;
x = x + z;
x = x % 26;
z = z / 1;
x = x + 14;
x = (x == w) ? 1 : 0;
x = (x == 0) ? 1 : 0;
y = y * 0;
y = y + 25;
y = y * x;
y = y + 1;
z = z * y;
y = y * 0;
y = y + w;
y = y + 11;
y = y * x;
z = z + y;

w = Convert.ToInt32(input[7].ToString());
x = x * 0;
x = x + z;
x = x % 26;
z = z / 26;
x = x + -10;
x = (x == w) ? 1 : 0;
x = (x == 0) ? 1 : 0;
y = y * 0;
y = y + 25;
y = y * x;
y = y + 1;
z = z * y;
y = y * 0;
y = y + w;
y = y + 15;
y = y * x;
z = z + y;

w = Convert.ToInt32(input[8].ToString());
x = x * 0;
x = x + z;
x = x % 26;
z = z / 1;
x = x + 15;
x = (x == w) ? 1 : 0;
x = (x == 0) ? 1 : 0;
y = y * 0;
y = y + 25;
y = y * x;
y = y + 1;
z = z * y;
y = y * 0;
y = y + w;
y = y + 7;
y = y * x;
z = z + y;

w = Convert.ToInt32(input[9].ToString());
x = x * 0;
x = x + z;
x = x % 26;
z = z / 26;
x = x + -2;
x = (x == w) ? 1 : 0;
x = (x == 0) ? 1 : 0;
y = y * 0;
y = y + 25;
y = y * x;
y = y + 1;
z = z * y;
y = y * 0;
y = y + w;
y = y + 12;
y = y * x;
z = z + y;

w = Convert.ToInt32(input[10].ToString());
x = x * 0;
x = x + z;
x = x % 26;
z = z / 1;
x = x + 11;
x = (x == w) ? 1 : 0;
x = (x == 0) ? 1 : 0;
y = y * 0;
y = y + 25;
y = y * x;
y = y + 1;
z = z * y;
y = y * 0;
y = y + w;
y = y + 15;
y = y * x;
z = z + y;

w = Convert.ToInt32(input[11].ToString());
x = x * 0;
x = x + z;
x = x % 26;
z = z / 26;
x = x + -15;
x = (x == w) ? 1 : 0;
x = (x == 0) ? 1 : 0;
y = y * 0;
y = y + 25;
y = y * x;
y = y + 1;
z = z * y;
y = y * 0;
y = y + w;
y = y + 9;
y = y * x;
z = z + y;



List<int> valid13(List<int> validOuts)
{
    List<int> ret = new();

    for (int i = 1; i < 10; i++)
    {
        w = Convert.ToInt32(input[12].ToString());
        x = x * 0;
        x = x + z;
        x = x % 26;
        z = z / 26;
        x = x + -9;
        x = (x == w) ? 1 : 0;
        x = (x == 0) ? 1 : 0;
        y = y * 0;
        y = y + 25;
        y = y * x;
        y = y + 1;
        z = z * y;
        y = y * 0;
        y = y + w;
        y = y + 12;
        y = y * x;
        z = z + y;

        //if (z)
    }

    return ret;
}


List<int> valid14()
{
    List<int> ret = new();

    for (int i = 1; i < 10; i++)
    {
        w = Convert.ToInt32(input[13].ToString());
        x = x * 0;
        x = x + z;
        x = x % 26;
        z = z / 26;
        x = x + -3;
        x = (x == w) ? 1 : 0;
        x = (x == 0) ? 1 : 0;
        y = y * 0;
        y = y + 25;
        y = y * x;
        y = y + 1;
        z = z * y;
        y = y * 0;
        y = y + w;
        y = y + 12;
        y = y * x;
        z = z + y;

        if (z == 0) ret.Add(i);
    }



    return ret;

}
