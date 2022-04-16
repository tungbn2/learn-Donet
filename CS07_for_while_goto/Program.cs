using System;

namespace CS07_for_while_goto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

        // ! goto
        L1: Console.Write("Goto: Nhap so le =>  ");
            string inp = Console.ReadLine();
            int a = Int32.Parse(inp);
            if (a % 2 == 0)
            {
                Console.WriteLine("So chan");
                goto L1;
            }

            // ! Vòng lặp for c#
            for (int i = 8; i <= 10; i++)
            {
                Console.WriteLine("Số i = " + i);
            }
            // Số i = 8
            // Số i = 9
            // Số i = 10

            // ! Vòng lặp while c#
            int i = 8;
            while (i <= 10)
            {
                Console.WriteLine("Số i = " + i);
                i++;
            }

            // Số i = 8
            // Số i = 9
            // Số i = 10

            // ! Vòng lặp do ... while c#
            // In ra các số chẵn
            int j = 10;
            do
            {
                Console.WriteLine("Số j = " + j);
                j += 2;
            }
            while (j <= 20);

            // ! Lệnh break và continue trong C#
            //In ra các số chia hết cho 3
            for (int i = 10; i <= 20; i++)
            {
                if (i % 3 != 0)
                    continue;  // Chạy ngay vòng lặp tiếp
                Console.WriteLine("Số i = " + i);
            }

            int i = 0;
            while (true)
            {
                Console.Write(" " + ++i);
                if (i == 10)
                    break;  // Thoát lặp
            }
        }

    }


}
