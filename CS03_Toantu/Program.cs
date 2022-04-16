using System;

namespace CS03_Toantu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // ! Toán tử số học
            int a = 28;
            int b = 10;
            //Phép cộng
            Console.WriteLine(a + b);  // In ra: 38
            Console.WriteLine(a - b);  // In ra: 18
            // phép chia
            Console.WriteLine(a / b);  // In ra 0.4
            Console.WriteLine(a / (float)b);
            Console.WriteLine(a % b);  // In ra 2

            // ! Toán tử gán +=, -=, *=, /=
            int x = 10;
            x += 2;
            x *= 3;
            x -= 3;
            a /= 2;
            a %= 3;

            // ! toán tử ++ và --
            a = 10;
            a++;    // a là 11 (thêm 1)
            ++a;    // a là 12 (thêm 1)

            a--;    // a là 11 (bớt 1)
            --a;    // a là 10 (bớt 1)

        }
    }
}
