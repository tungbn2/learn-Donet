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
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // ! Uri_DNS_Ping
            // Uri_DNS_Ping.Run();

            //  ! HttpClient
            // ! GET

            // var str = await HttpClientMethod.GET("https://www.google.com/search?q=xuanthulab");
            // Console.WriteLine(str);

            // ! ReadAsByteArrayAsync

            // await HttpClientMethod.ReadAsByteArrayAsync();

            //  ! DownloadDataStream
            // var url = "https://raw.githubusercontent.com/xuanthulabnet/linux-centos/master/docs/samba1.png";
            // await HttpClientMethod.DownloadDataStream(url, "anh2.png");

            // ! SendAsync
            await HttpClientMethod.SendAsync();
        }
    }
}
