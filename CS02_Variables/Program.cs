using System;

namespace CS002_Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int seconds = 60;                    //khai báo biến số nguyên
            double so_pi = 3.14;                 //khai báo biến số thực
            bool deltaIsSezo = true;             //Khai báo biến logic
            char chooseAction = 'S';            //Khai báo biến kiểu ký tự
            string msgResult = "Kết quả giải:"; // khai báo biến chuỗi

            // ! ép kiểu
            float convert = (float)seconds;

            // ! Xuất dữ liệu ra màn hình Console
            Console.WriteLine();                                                //Xuống dòng
            Console.WriteLine();                                                //Xuống dòng

            Console.ForegroundColor = ConsoleColor.DarkMagenta;                 //Đặt màu chữ
            Console.WriteLine("XIN CHÀO - CHƯƠNG TRÌNH NHẬP XUẤT DỮ LIỆU");     //In dòng chữ
            Console.ResetColor();                                               //Reset màu

            Console.Write("Giá trị biến so_pi là : ");                          //In dòng chữ
            Console.WriteLine(so_pi);                                           //In giá trị biến
            Console.WriteLine();                                                //Xuống dòng

            int a = 123;
            double b = 567.123;

            Console.WriteLine("Biến a = {0}, biến b = {1}", a, b);

            // ! Nhập dữ liệu trong C#
            string userLogin;
            Console.Write("Nhập username : ");
            userLogin = Console.ReadLine();
            Console.WriteLine($"Tên nhập vào là: {userLogin}");

            // ! chuyển kiểu dữ liệu
            Console.Write("Nhập một số thức : ");
            // Nhập chuỗi - chuyển ngay chuỗi đó thành số thực
            double dinput = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Số đã nhập là: {dinput}");

            int parse = Int16.Parse(dinput);
            int tryparse = Int64.TryParse(dinput);

            // ! Khai báo biến kiểu ngầm định với var
            var bien1 = 3.14;                                           // biến sẽ có kiểu double
            var bien2 = 3;                                              // biến sẽ có kiểu int
            var bien3 = "Biến khai báo với var phải khởi tạo ngay";     // string
            var bien4 = (5 < 4);                                        // bool

            // ! Hằng số
            const string MON = "THỨ HAI";
            Console.WriteLine(MON);
        }
    }
}
