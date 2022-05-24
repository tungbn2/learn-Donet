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
    public class Uri_DNS_Ping
    {
        public static void Run()
        {
            // ! Lớp Uri
            string url = "https://xuanthulab.net/lap-trinh/csharp/?page=3#acff";
            var uri = new Uri(url);
            var uritype = typeof(Uri);

            foreach (var property in uritype.GetProperties())
            {
                Console.WriteLine($"{property.Name,15} {property.GetValue(uri)}");
            };
            Console.WriteLine($"Segments: {string.Join(",", uri.Segments)}");

            Console.WriteLine("---------------------------------------------");

            // ! Lớp tĩnh Dns và lớp IPHostEntry
            Console.WriteLine("Lớp tĩnh Dns và lớp IPHostEntry");

            var hostEntry = Dns.GetHostEntry(uri.Host);
            Console.WriteLine($"Host {uri.Host} có các IP");
            hostEntry.AddressList.ToList().ForEach(ip => Console.WriteLine(ip));

            Console.WriteLine("---------------------------------------------");

            // ! Lớp Ping

            Console.WriteLine(" Lớp Ping");
            var ping = new Ping();
            var pingReply = ping.Send("google.com.vn");
            Console.WriteLine(pingReply.Status);
            if (pingReply.Status == IPStatus.Success)
            {
                Console.WriteLine(pingReply.RoundtripTime);
                Console.WriteLine(pingReply.Address);
            }

            Console.WriteLine("---------------------------------------------");
        }
    }
}