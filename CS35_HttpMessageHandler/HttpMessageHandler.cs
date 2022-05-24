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

namespace CS35_HttpMessageHandler
{
    public class HttpMessageHandlerMethod
    {
        public static async Task Run()
        {
            var url = "https://postman-echo.com/post";
            // ? Tạo handler
            using HttpClientHandler handler = new HttpClientHandler();

            // ? Tạo bộ chứa cookie và sử dụng bởi handler
            CookieContainer cookies = new CookieContainer();

            // ? Thêm các cookie nêu muốn
            // ? cookies.Add(new Uri(url), new Cookie("name", "value"));

            handler.CookieContainer = cookies;

            // ? Tạo HttpClient - thiết lập handler cho nó
            using var httpClient = new HttpClient(handler);


            // ? Tạo HttpRequestMessage
            using var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Post;
            httpRequestMessage.RequestUri = new Uri(url);
            httpRequestMessage.Headers.Add("User-Agent", "Mozilla/5.0");
            var parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("key1", "value1"),
                    new KeyValuePair<string, string>("key2", "value2")

                };
            httpRequestMessage.Content = new FormUrlEncodedContent(parameters);

            // ? Thực hiện truy vấn
            var response = await httpClient.SendAsync(httpRequestMessage);

            // ? Hiện thị các cookie (các cookie trả về có thể sử dụng cho truy vấn tiếp theo)
            cookies.GetCookies(new Uri(url)).ToList().ForEach(cookie =>
            {
                Console.WriteLine($"{cookie.Name} = {cookie.Value}");
            });

            // ? Đọc chuỗi nội dung trả về (HTML)
            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
        }
    }
}