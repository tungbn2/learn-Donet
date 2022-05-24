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


namespace CS34_HttpClient
{
    public class HttpClientMethod
    {

        public HttpClientMethod()
        {
            // Thiết lập httpClient nếu muốn ở đây
        }

        // Giải phóng tài nguyên
        // public void Dispose()
        // {
        //     if (httpClient != null)
        //     {
        //         httpClient.Dispose();
        //         httpClient = null;
        //     }
        // }
        // ====================================

        public static async Task<string> GET(string url)
        {
            // ? Khởi tạo http client
            using var httpClient = new HttpClient();

            // ? Thiết lập các Header nếu cần
            httpClient.DefaultRequestHeaders.Add("Test", "text/html,application/xhtml+xml+json");


            try
            {
                // ? Thực hiện truy vấn GET
                HttpResponseMessage response = await httpClient.GetAsync(url);

                // ? Hiện thị thông tin HEADER trả về
                ShowHeaders(response.Headers);

                // ? Phát sinh Exception nếu mã trạng thái trả về là lỗi
                response.EnsureSuccessStatusCode();

                Console.WriteLine($"Tải thành công - statusCode {(int)response.StatusCode} {response.ReasonPhrase}");

                Console.WriteLine("Starting read data");

                // ? Đọc nội dung content trả về - ĐỌC CHUỖI NỘI DUNG
                string htmltext = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Nhận được {htmltext.Length} ký tự");
                Console.WriteLine();
                return htmltext;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public static async Task SendAsync()
        {
            using var httpClient = new HttpClient();

            //  ? Tạo message request
            var httpRequestMessage = new HttpRequestMessage();

            // ? Thiết lập thông tin cho request
            httpRequestMessage.Method = HttpMethod.Post;
            httpRequestMessage.RequestUri = new Uri("https://postman-echo.com/post");
            httpRequestMessage.Headers.Add("Test", "test");

            // ? Định nghĩa Body
            // ? httpRequestMessage.Content => HTML Form, FIle,...
            /*  
               data chứa dữ liệu:
                key1 => [value1, value2]
            */

            // ? Định nghĩa kiểu KeyValuePair
            // var dataBody = new List<KeyValuePair<string, string>>();
            // dataBody.Add(new KeyValuePair<string, string>("key1", "value1"));
            // dataBody.Add(new KeyValuePair<string, string>("key1", "value2"));

            // var body = new FormUrlEncodedContent(dataBody);

            // ? Định nghĩa kiểu JSON
            // string data = @"{
            //     ""key1"": ""[""Value1"", ""value2"" ]"",
            // }";

            // var body = new StringContent(data, Encoding.UTF8, "application/json");

            //  ? Ulpoad File

            var body = new MultipartFormDataContent();

            // todo: uploadfile
            Stream fileStream = File.OpenRead("test.txt");
            var fileUpload = new StreamContent(fileStream);

            body.Add(fileUpload, "fileUpload", "fileUpload");

            httpRequestMessage.Content = body;

            // ? Send HttpClient
            Console.WriteLine("Start Send Async");
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            Console.WriteLine("Send Async Done");

            ShowHeaders(httpResponseMessage.Headers);

            // ? Read response
            var html = await httpResponseMessage.Content.ReadAsStringAsync();
            Console.WriteLine(html);
        }

        public static async Task ReadAsByteArrayAsync()
        {
            var url = "https://raw.githubusercontent.com/xuanthulabnet/jekyll-example/master/images/jekyll-01.png";
            byte[] bytes = await DownloadDataBytes(url);

            string filepath = "anh1.png";
            using (var stream = new FileStream(filepath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                stream.Write(bytes, 0, bytes.Length);
                Console.WriteLine("save " + filepath);
            }
        }

        // -------------------------------------------------------------------------
        // In ra thông tin các Header của HTTP Response
        public static void ShowHeaders(HttpHeaders headers)
        {
            Console.WriteLine("CÁC HEADER:");
            foreach (var header in headers)
            {
                foreach (var value in header.Value)
                {
                    Console.WriteLine($"{header.Key,25} : {value}");

                }
            }
            Console.WriteLine();
        }

        // Tải từ url trả về mảng byte dữ liệu
        public static async Task<byte[]> DownloadDataBytes(string url)
        {
            Console.WriteLine($"Starting connect {url}");
            try
            {
                // ? Khởi tạo http client
                using var httpClient = new HttpClient();

                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsByteArrayAsync();
                Console.WriteLine("Received data success");
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        // Tải từ url, trả về stream để đọc dữ liệu (xem bài về stream)
        public static async Task DownloadDataStream(string url, string filename)
        {
            // ? Khởi tạo http client
            using var httpClient = new HttpClient();
            Console.WriteLine($"Starting connect {url}");
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                // ? Lấy Stream để đọc content
                using var stream = await response.Content.ReadAsStreamAsync();

                // ? THỰC HIỆN ĐỌC Content
                int SIZEBUFFER = 500;
                using var streamwrite = File.OpenWrite(filename);  // ? Mở stream để lưu file
                byte[] buffer = new byte[SIZEBUFFER];               // ? tạo bộ nhớ đệm lưu dữ liệu khi đọc stream

                bool endread = false;
                do                                                  // ? thực hiện đọc các byte từ stream và lưu ra streamwrite
                {
                    int numberRead = await stream.ReadAsync(buffer, 0, SIZEBUFFER);
                    Console.WriteLine(numberRead);
                    if (numberRead == 0)
                    {
                        endread = true;
                    }
                    else
                    {
                        await streamwrite.WriteAsync(buffer, 0, numberRead);
                    }

                } while (!endread);
                Console.WriteLine("Download success");


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }


    }
}