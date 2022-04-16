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
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var c = await HttpFunc.GetWebContent("https://www.google.com/search?q=xuanthulab");
            Console.WriteLine(c);

            // sử dụng ReadAsByteArrayAsync
            var url = "https://raw.githubusercontent.com/xuanthulabnet/linux-centos/master/docs/samba1.png";
            await HttpFunc.DownloadDataStream(url, "anh2.png");
        }

    }
}
