using System;
using System.IO;
using System.Text;

namespace CS28_work_file
{
    class FileStreamClass
    {
        public static void FileStreamFunc()
        {
            string filepath = "/test/test_file_stream.txt";

            using (var stream = new FileStream(path: filepath, mode: FileMode.OpenOrCreate, access: FileAccess.Read, share: FileShare.Read))
            {
                // Lấy thông tin về stream
                Console.WriteLine(stream.Name);
                Console.WriteLine($"Kích thước stream {stream.Length} bytes / Vị trí {stream.Position}");
                Console.WriteLine($"Stream có thể : Đọc {stream.CanRead} -  Ghi {stream.CanWrite} - Seek {stream.CanSeek} - Timeout {stream.CanTimeout} ");

                // code sử dụng stream (System.IO.Stream)


                // Ghi file text bằng stream
                //Write BOM - UTF8
                Encoding encoding = Encoding.UTF8;
                byte[] bom = encoding.GetPreamble();
                stream.Write(bom, 0, bom.Length);

                string s1 = "Xuanthulab.net -  Xin chào các bạn! \n";

                // Encode chuỗi - lưu vào mảng bytes
                byte[] buffer = encoding.GetBytes(s1);
                stream.Write(buffer, 0, buffer.Length);  // lưu vào stream

                // Đọc file text bằng stream
                Encoding encoding = GetEncoding(stream);
                Console.WriteLine(encoding.ToString());
                byte[] buffer = new byte[SIZEBUFFER];
                bool endread = false;
                do
                {
                    int numberRead = stream.Read(buffer, 0, SIZEBUFFER);
                    if (numberRead == 0) endread = true;
                    if (numberRead < SIZEBUFFER)
                    {
                        Array.Clear(buffer, numberRead, SIZEBUFFER - numberRead);
                    }
                    string s = encoding.GetString(buffer, 0, numberRead);
                    Console.WriteLine(s);

                } while (!endread);


            }
        }
    }
}