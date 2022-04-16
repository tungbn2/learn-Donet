using System;
using System.IO;

namespace CS28_work_file
{
    public class WorkFile
    {
        public static void WriteFile(string path)
        {
            var filename = "test.txt";
            string contentfile = "Xin chào! xuanthulab.net";

            // ! Lấy thư mục Document của User trên hệ thống
            // var directory_mydoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            var fullpath = Path.Combine(path, filename);

            if (File.Exists(fullpath))
            {
                // File đã tồn tại - nối thêm nội dung
                File.AppendAllText(fullpath, contentfile);
            }
            else
            {
                // tạo mới vì chưa tồn tại file
                File.WriteAllText(fullpath, contentfile);
            }

            Console.WriteLine($"File lưu tại {fullpath}{filename}");
        }

        public static void ReadFile(string path)
        {
            string s = File.ReadAllText(path);
            Console.Write(s);
        }
    }
}