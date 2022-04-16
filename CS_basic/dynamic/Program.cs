
using System;

namespace dynamic
{
    class Program
    {
        static void Main(string[] args)
        {

            dynamic d1 = 7;
            dynamic d2 = "a string";


            int i = d1;
            string str = d2;

            Console.Write($"{i} - {str}");
        }
    }
}
