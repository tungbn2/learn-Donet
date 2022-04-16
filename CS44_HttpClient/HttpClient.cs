using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace CS44_HttpClient
{
    class HttpFunc
    {

        /// In ra thông tin các Header của HTTP Response
        public static void ShowHeaders(HttpHeaders headers)
        {
            Console.WriteLine("CAC HEADER:");
            foreach (var header in headers)
            {
                foreach (var value in header.Value)
                {
                    Console.WriteLine($"{header.Key,25} : {value}");

                }
            }
            Console.WriteLine();
        }

        // -------------------------------------------------------------------------
        // Tải về trang web và trả về chuỗi nội dung
        public static async Task<string> GetWebContent(string url)
        {
            // Khởi tạo http client
            using var httpClient = new HttpClient();

            // Thiết lập các Header nếu cần
            httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml+json");
            try
            {
                // Thực hiện truy vấn GET
                HttpResponseMessage response = await httpClient.GetAsync(url);

                // Hiện thị thông tin header trả về
                ShowHeaders(response.Headers);

                // Phát sinh Exception nếu mã trạng thái trả về là lỗi
                response.EnsureSuccessStatusCode();

                Console.WriteLine($"Tải thành công - statusCode {(int)response.StatusCode} {response.ReasonPhrase}");

                Console.WriteLine("Starting read data");

                // Đọc nội dung content trả về - ĐỌC CHUỖI NỘI DUNG
                string htmltext = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Nhận được {htmltext.Length} ký tự");
                Console.WriteLine();
                return htmltext;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        //    --------------------------------------------------------------------------
        // Tải từ url, trả về stream để đọc dữ liệu (xem bài về stream)
        public static async Task DownloadDataStream(string url, string filename)
        {
            var httpClient = new HttpClient();
            Console.WriteLine($"Starting connect {url}");
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                // Lấy Stream để đọc content
                using var stream = await response.Content.ReadAsStreamAsync();

                // THỰC HIỆN ĐỌC Content
                int SIZEBUFFER = 500;
                using var streamwrite = File.OpenWrite(filename);  // Mở stream để lưu file
                byte[] buffer = new byte[SIZEBUFFER];               // tạo bộ nhớ đệm lưu dữ liệu khi đọc stream

                bool endread = false;
                do                                                  // thực hiện đọc các byte từ stream và lưu ra streamwrite
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