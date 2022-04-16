using System;

namespace bien_trong_Cs
{
    class Program
    {
        static void Main(string[] args)
        {
            int tuoi;
            Console.WriteLine("nhap tuoi:");
            tuoi = Convert.ToInt32(Console.ReadLine());
            Console.Write("ban " + tuoi);

            if (tuoi < 16) { Console.WriteLine(", tuoi vi thanh nien"); }
            else if (tuoi < 18)
            {
                Console.WriteLine(", tuoi truong thanh");
            }
            else { Console.WriteLine(", gia roi"); }

            int i = tuoi < 16 ? 1 : 0;

            switch (1)
            {
                case (i):
                    break;
                default:
                    break;
            }

        }
    }
}
