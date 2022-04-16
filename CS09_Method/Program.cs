using System;

namespace CS09_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // ! gọi method
            double bp = BinhPhuong(5); // Gọi hàm
            Console.WriteLine("Bình phương của 5 là: " + bp);

            // default params
            double thetich;

            thetich = TheTich(2);              // ~ TheTich(2,1,1)
            Console.WriteLine(thetich);             // 2

            thetich = TheTich(2, 10);           // ~ TheTich(2,10,1)
            Console.WriteLine(thetich);             // 20

            thetich = TheTich(1, 2, 3);
            Console.WriteLine(thetich);             // 6

            // Truyền tham số với tên
            String fullname;
            fullname = FullName(ten: "A", ho: "Nguyễn");              // Nguyễn A
            Console.WriteLine(fullname);
            fullname = FullName(tendem: "VĂN", ten: "B", ho: "PHẠM"); // PHẠM VĂN B
            Console.WriteLine(fullname);
            fullname = FullName(tendem: "VĂN", ho: "PHẠM", ten: "B"); // PHẠM VĂN B
            Console.WriteLine(fullname);
            fullname = FullName(ho: "PHẠM", tendem: "VĂN", ten: "B"); // PHẠM VĂN B
            Console.WriteLine(fullname);


            // ! Truyền tham số tham chiếu và tham trị C#
            int a = 2;
            ThamChieuThamTri(a);
            Console.WriteLine(a);

            ThamChieuThamTri(ref a);
            Console.WriteLine(a);

            int d;             // biến d chưa khởi tạo
            OutExample(out d); // Giờ d = 100;
            Console.WriteLine(d);
        }

        // ! Khai báo phương thức trong C#
        static double BinhPhuong(double number)
        {
            double ketqua = number * number;
            return ketqua;
        }

        // ! Tham số có giá trị mặc định
        // Phương thức khai báo có 3 tham số, hai tham số cuối mặc định
        // Nếu gọi hàm không có chỉ ra tham số cuỗi thì nó lấy giá trị mặc định này
        public static double TheTich(double cao, double dai = 1, double rong = 1)
        {
            return cao * dai * rong;
        }

        // ! Truyền tham số với tên
        public static string FullName(string ho, string ten, string tendem = "")
        {
            return ho + (tendem != "" ? " " + tendem : "") + " " + ten;
        }


        // ! Truyền tham số tham trị
        public static void ThamChieuThamTri(int x)
        {
            x = x * x;
            Console.WriteLine(x);
        }

        // ! Truyền tham số tham chiếu
        public static void ThamChieuThamTri(ref int x)
        {
            x = x * x;
            Console.WriteLine(x);
        }

        // ! Tham chiếu với out
        public static void OutExample(out int x)
        {
            x = 100;
        }
    }
}
