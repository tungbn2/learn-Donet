using System;

namespace cau_truc_ham_Cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Log(Plus(10, 11));

            // ref keyword
            int num = 10;

            changeValue(ref num);

            Console.WriteLine($"change ref number = {num}");

            // out keyword

            changeValueOut(out num);

            Console.WriteLine($"change out number = {num}");
        }

        static int Plus(int a, int b)
        {
            return a + b;
        }

        static void Log(dynamic msg)
        {
            Console.WriteLine(msg);
        }

        // ref keyword
        static void changeValue(ref int a)
        {
            ++a;
        }

        // out keyword
        static void changeValueOut(out int a)
        {
            a = 0;
            ++a;
        }


    }
}
