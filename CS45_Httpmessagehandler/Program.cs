using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace CS45_Httpmessagehandler
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            await HttpClientHandler();
            await SocketsHttpHandler();
            await DelegatingHandler();
        }

        static async Task HttpClientHandler()
        {
            var url = "https://postman-echo.com/post";
            // Tạo handler
            using HttpClientHandler handler = new HttpClientHandler();

            // Tạo bộ chứa cookie và sử dụng bởi handler
            CookieContainer cookies = new CookieContainer();
            // Thêm các cookie nêu muốn
            // cookies.Add(new Uri(url), new Cookie("name", "value"));

            handler.CookieContainer = cookies;

            // Tạo HttpClient - thiết lập handler cho nó
            using var httpClient = new HttpClient(handler);


            // Tạo HttpRequestMessage
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

            // Thực hiện truy vấn
            var response = await httpClient.SendAsync(httpRequestMessage);

            // Hiện thị các cookie (các cookie trả về có thể sử dụng cho truy vấn tiếp theo)
            cookies.GetCookies(new Uri(url)).ToList().ForEach(cookie =>
            {
                Console.WriteLine($"{cookie.Name} = {cookie.Value}");
            });

            // Đọc chuỗi nội dung trả về (HTML)
            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
        }


        static async Task SocketsHttpHandler()
        {
            var url = "https://postman-echo.com/post";
            // Tạo bộ chứa cookie và sử dụng bởi handler
            CookieContainer cookies = new CookieContainer();
            // Thêm các cookie nêu muốn
            // cookies.Add(new Uri(url), new Cookie("name", "value"));

            // Tạo handler
            using SocketsHttpHandler handler = new SocketsHttpHandler();
            handler.CookieContainer = cookies;     // Thay thế CookieContainer mặc định
            handler.AllowAutoRedirect = false;                // không cho tự động Redirect
            handler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            handler.UseCookies = true;

            // Tạo HttpClient - thiết lập handler cho nó
            using var httpClient = new HttpClient(handler);


            // Tạo HttpRequestMessage
            using var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Post;
            httpRequestMessage.RequestUri = new Uri(url);
            httpRequestMessage.Headers.Add("User-Agent", "Mozilla/5.0");
            httpRequestMessage.Headers.Add("Accept", "text/html,application/xhtml+xml+json");

            var parameters = new List<KeyValuePair<string, string>>()
    {
        new KeyValuePair<string, string>("key1", "value1"),
        new KeyValuePair<string, string>("key2", "value2")

    };
            httpRequestMessage.Content = new FormUrlEncodedContent(parameters);

            // Thực hiện truy vấn
            var response = await httpClient.SendAsync(httpRequestMessage);

            // Hiện thị các cookie (các cookie trả về có thể sử dụng cho truy vấn tiếp theo)
            cookies.GetCookies(new Uri(url)).ToList().ForEach(cookie =>
            {
                Console.WriteLine($"{cookie.Name} = {cookie.Value}");
            });

            // Đọc chuỗi nội dung trả về (HTML)
            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
        }

        static async Task DelegatingHandler()
        {
            string url = "https://www.facebook.com/xuanthulab";

            CookieContainer cookies = new CookieContainer();

            // TẠO CHUỖI HANDLER
            var bottomHandler = new MyHttpClientHandler(cookies);              // handler đáy (cuối)
            var changeUriHandler = new ChangeUri(bottomHandler);
            var denyAccessFacebook = new DenyAccessFacebook(changeUriHandler); // handler đỉnh

            // Khởi tạo HttpCliet với hander đỉnh chuỗi hander
            var httpClient = new HttpClient(denyAccessFacebook);

            // Thực hiện truy vấn
            httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml+json");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
            HttpResponseMessage response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string htmltext = await response.Content.ReadAsStringAsync();

            Console.WriteLine(htmltext);
        }
    }
}
