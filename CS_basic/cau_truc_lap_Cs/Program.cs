using System;

namespace cau_truc_lap_Cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Cấu trúc Goto
            int go = 0;

        srartGoto:
            Console.Write("goto; ");
            go += 1;
            switch (go)
            {
                case 1: Console.WriteLine("go = 1; "); goto srartGoto; break;
                case 2: Console.Write("go = 2; "); goto case 1; break;
                default: break;
            }

            //  vòng lặp for
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"i = {i}; ");
            }

            // Vòng lặp While
            int Vertical = 20;
            int Horizontal = 50;
            char drawChar = '*';
            char insideChar = ' ';
            int countLoopVertical = 0;
            int countLoopHorizontal = 0;


            // Vẽ từ trên xuống
            while (countLoopVertical < Vertical)
            {

                // khởi tạo lại giá trị countLoopHorizontal = 0 mỗi lần lặp mới
                countLoopHorizontal = 0;

                // Vẽ từ trái sang
                while (countLoopHorizontal < Horizontal)
                {

                    /*
                     * Nếu đang ở tọa độ là cạnh trên hoặc dưới i % (N - 1) == 0
                     * hoặc đang ở cạnh trái hoặc phải (j % (M - 1) == 0)
                     * mà không nằm ở cạnh trên hoặc dưới (i % (N - 1) != 0)
                     * ((i % (N - 1) != 0) && (j % (M - 1) == 0))
                     * thì vẽ ra ký tự của hình chữ nhật
                     * ngược lại vẽ ra ký tự không thuộc hình chữ nhật
                    */

                    if (countLoopVertical % (Vertical - 1) == 0 || ((countLoopVertical % (Vertical - 1) != 0) && (countLoopHorizontal % (Horizontal - 1) == 0)))
                    {
                        Console.Write(drawChar);    // lúc này là ký tự *
                    }
                    else
                    {
                        Console.Write(insideChar);  // lúc này là ký tự rỗng ' '
                    }


                    // tăng giá trị của countLoopHorizontal lên 1 đơn vị
                    countLoopHorizontal++;
                }

                // mỗi lần vẽ xong một hàng thì xuống dòng
                Console.WriteLine();


                // tăng giá trị của countLoopVertical lên 1 đơn vị
                countLoopVertical++;
            }

            // vòng lặp do while
            int t = 2;
            do
            {
                Console.WriteLine($"t = {t}");
                t--;
            } while (t >= 0);
            Console.ReadKey();
        }
    }
}
