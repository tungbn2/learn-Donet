using System;

namespace mang_trong_Cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // khai báo mảng 1 chiều
            string[] mangCach1 = new string[10];
            int[] mangCach2 = new int[] { 1, 2, 3, 4, 5 };
            float[] mangCach3 = { 1, 2, 3, 4 };

            for (int i = 0; i < mangCach2.Length; i++)
            {
                Console.Write($"{i} = {mangCach2[i]}; ");
            }

            Console.WriteLine($"{mangCach1.Length} - {mangCach2.LongLength} - {mangCach3.GetLength(0)}");

            //  mảng 2 chiều

            int[,] mang_2_chieu = {
                {1,2},
                {2,3},
                {3,4}
            };

            Console.WriteLine($"so chieu = {mang_2_chieu.Rank}");

            // mảng 3 chiều
            int[,,] mang_3_chieu =  {
                {
                    {1,2},
                    {2,3}
                 },
                 {
                    {1,2},
                    {2,3}
                 },
            };

            Console.WriteLine($"so chieu = {mang_3_chieu.Rank}");

            // Mảng jagged 
            int[][] mang_jagged = {
                new int [] {1,2,3},
                new int [] {1,2}
            };
        }
    }
}
