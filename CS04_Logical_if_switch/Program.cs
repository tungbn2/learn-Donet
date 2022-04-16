using System;

namespace CS04_Logical_if_switch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // ! Các toán tử so sánh trong C#
            int a = 10;
            int b = 12;
            Console.WriteLine($"a >= b: {a >= b}");
            Console.WriteLine($"a == b: {a == b}");
            Console.WriteLine($"a != b: {a != b}");

            bool c = (a && b);
            bool d = (a || b);

            //! Câu lệnh If
            int number = 1990;
            if ((number % 2) == 0)
                Console.WriteLine($"{number} là số chẵn");
            // In ra: 1990 là số chẵn

            int a = 10;
            int b = 10;
            if (a > b)
            {
                Console.WriteLine("Số a lớn hơn hoặc bằng số b");
            }
            else if (a < b)
            {
                Console.WriteLine("Số a nhỏ hơn số b");
            }
            else
            {
                Console.WriteLine("Hai số a, b bằng nhau");

            }

            // ! toán tử 3 ngôi
            int age = 18;
            var mgs = (age >= 18) ? "Đủ điều kiện" : "Không đủ điều kiện";

            // ! Câu lệnh rẽ nhánh switch
            int number = 2;
            switch (number)
            {
                case 1:
                    Console.WriteLine("number có giá trị một");
                    break;
                case 2:
                    Console.WriteLine("number có giá trị hai");
                    break;
                default:
                    Console.WriteLine("number khác một và hai");
                    break;

            }
            //In ra : number có giá trị hai
        }
    }
}
