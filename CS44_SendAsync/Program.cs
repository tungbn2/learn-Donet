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

namespace CS44_SendAsync
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // ----------------------------------------------
            FormUrlEncodedContent();

            // ------------------------------------------------------------------------
            StringContent();
            // ------------------------------------------------------------------------
            MultipartFormDataContent();
        }

        static async Task FormUrlEncodedContent()
        {
            // Sử dụng FormUrlEncodedContent

            var httpClient = new HttpClient();

            var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Post;
            httpRequestMessage.RequestUri = new Uri("https://postman-echo.com/post");

            var parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("key1", "value1"));

            parameters.Add(new KeyValuePair<string, string>("key2", "value2-1"));
            parameters.Add(new KeyValuePair<string, string>("key2", "value2-2"));

            // Thiết lập Content
            var content = new FormUrlEncodedContent(parameters); /* Sử dụng FormUrlEncodedContent*/
            httpRequestMessage.Content = content;

            // Thực hiện Post
            var response = await httpClient.SendAsync(httpRequestMessage);

            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseContent);
            // Khi chạy kết quả trả về cho biết Server đã nhận được dữ liệu Post đến
        }

        static async Task StringContent()
        {
            // Sử dụng StringContent
            // var httpClient = new HttpClient();

            var httpRequestMessage2 = new HttpRequestMessage();
            httpRequestMessage2.Method = HttpMethod.Post;
            httpRequestMessage2.RequestUri = new Uri("https://postman-echo.com/post");

            // Tạo StringContent
            string jsoncontent = "{\"value1\": \"giatri1\", \"value2\": \"giatri2\"}";
            var httpContent = new StringContent(jsoncontent, Encoding.UTF8, "application/json");
            httpRequestMessage2.Content = httpContent;

            var responseData = await httpClient.SendAsync(httpRequestMessage2);
            var responseContentString = await responseData.Content.ReadAsStringAsync();

            Console.WriteLine(responseContentString);
        }

        static async Task MultipartFormDataContent()
        {
            var httpClient = new HttpClient();

            var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Post;
            httpRequestMessage.RequestUri = new Uri("https://postman-echo.com/post");


            // Tạo đối tượng MultipartFormDataContent
            var content = new MultipartFormDataContent();

            // Tạo StreamContent chứa nội dung file upload, sau đó đưa vào content
            Stream fileStream = System.IO.File.OpenRead("Program.cs");
            content.Add(new StreamContent(fileStream), "fileupload", "abc.xyz");

            // Thêm vào MultipartFormDataContent một StringContent
            content.Add(new StringContent("value1"), "key1");
            // Thêm phần tử chứa mạng giá trị (HTML Multi Select)
            content.Add(new StringContent("value2-1"), "key2[]");
            content.Add(new StringContent("value2-2"), "key2[]");


            httpRequestMessage.Content = content;
            var response = await httpClient.SendAsync(httpRequestMessage);
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseContent);
        }
    }
}
