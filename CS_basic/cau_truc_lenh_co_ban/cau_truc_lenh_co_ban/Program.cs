using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau_Truc_Lenh_Co_Ban
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            Console.Write("HowKteam.com xin chào ");
            Console.Write(a);
            Console.WriteLine("--------------------");

            Console.Write("Tên: ");
            string ten = Console.ReadLine();

            Console.Write("Tuổi: ");
            string tuoi = Console.ReadLine();

            Console.Write("Địa Chỉ: ");
            string add = Console.ReadLine();

            Console.WriteLine("Bạn tên " + ten + ", " + tuoi + " tuổi, ở " + add);
        }
    }
}
