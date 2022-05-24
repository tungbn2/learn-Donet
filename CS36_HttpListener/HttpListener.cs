using System.Collections.Generic;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Net.Mail;
using System.Net.NetworkInformation;

namespace CS36_HttpListener
{
    class HttpListenerServer
    {
        public static async Task Run()
        {
            // ? Mảng chứa địa chỉ Http lắng nghe
            // ? http =  giao thức http, * = ip bất kỳ, 8080 = cổng lắng nghe

            string[] prefixes = new string[] { "http://*:8080/" };

            HttpListener listener = new HttpListener(); // todo: tạo mới 1 đối tượng Http Listener để lắng nghe

            if (!HttpListener.IsSupported) throw new Exception("Hệ thống không hỗ trợ HttpListener.");

            if (prefixes == null || prefixes.Length == 0) throw new ArgumentException("prefixes");

            foreach (string s in prefixes)
            {
                listener.Prefixes.Add(s);
            }

            Console.WriteLine("Server start ...");

            // ? Http bắt đầu lắng nghe truy vấn gửi đến
            listener.Start();

            listener.Prefixes.ToList().ForEach(i => Console.WriteLine(i));

            // ? Vòng lặp chấp nhận và xử lý các client kết nối
            do
            {
                // ? Chấp nhận khi có client kết nối đế
                HttpListenerContext context = await listener.GetContextAsync();

                // ? ....
                // ? Xử lý context - đọc  thông tin request,  ghi thông tin response
                // ? ... ví dụ như sau:

                var response = context.Response;                                        // ? lấy HttpListenerResponse
                var outputstream = response.OutputStream;                               // ? lấy Stream lưu nội dung gửi cho client

                context.Response.Headers.Add("content-type", "text/html");              // ? thiết lập respone header
                byte[] buffer = Encoding.UTF8.GetBytes("Hello world!");     // ? dữ liệu content
                response.ContentLength64 = buffer.Length;
                await outputstream.WriteAsync(buffer, 0, buffer.Length);                  // ? viết content ra stream
                outputstream.Close();                                                   // ? Đóng stream (gửi về cho cliet)

            }
            while (listener.IsListening);
        }
    }
}