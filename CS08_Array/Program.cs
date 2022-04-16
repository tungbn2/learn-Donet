using System;

namespace CS12_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // ! khởi tạo mảng
            bienMang = new int[5];
            string[] productNames = new string[3] { "Iphone", "Samsung", "Nokia" };
            double[] productPrices = { 100, 200.5, 10.1 };

            myArray = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };


            // ! Truy cập phần tử mảng
            int a = myArray[2];

            // ! Duyệt qua các phần tử mảng
            int[] myArray = { 1, 3, 5, 19, 10, 20, 40, 40 };
            int maxIndex = myArray.Length - 1;
            for (int idx = 0; idx <= maxIndex; idx++)
            {
                Console.WriteLine(myArray[idx]);
            }
            // ! sử dụng foreach
            foreach (int element in myArray)
            {
                Console.WriteLine(element);
            }

            // ! Mảng nhiều chiều (rank)
            int[,] myvar = new int[3, 4] { { 1, 2, 3, 4 }, { 0, 3, 1, 3 }, { 4, 2, 3, 4 } };          // khai báo và khởi tạo mảng 2 chiều

            for (int i = 0; i <= 2; i++)                                           // duyệt qua từng hàng
            {
                for (int j = 0; j <= 3; j++)                                          // duyệt qua từng cột
                {
                    Console.Write(myvar[i, j] + " ");
                }
                Console.WriteLine();
            }

            // ! Mảng trong mảng
            int[][] myArray = new int[][]
            {
                new int[] {1,2},
                new int[] {2,5,6},
                new int[] {2,3},
                new int[] {2,3,4,5,5}
            };

            foreach (var arr in myArray)
            {
                foreach (var e in arr)
                {
                    Console.Write(e + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
