using System;
using System.Net;
using System.Net.NetworkInformation;

using System.Linq;

namespace CS43_Uri_Dns_Ping
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Lớp Uri
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string url = "https://xuanthulab.net/lap-trinh/csharp/?page=3#acff";
            var uri = new Uri(url);
            var uritype = typeof(Uri);
            uritype.GetProperties().ToList().ForEach(property =>
            {
                Console.WriteLine($"{property.Name,15} {property.GetValue(uri)}");
            });
            Console.WriteLine($"Segments: {string.Join(",", uri.Segments)}");
            Console.WriteLine($"----------------------------------------------------");

            // Lớp tĩnh Dns và lớp IPHostEntry
            Console.ForegroundColor = ConsoleColor.DarkRed;
            string url_dns = "https://www.bootstrapcdn.com/";
            var uri_dns = new Uri(url_dns);
            var hostEntry = Dns.GetHostEntry(uri_dns.Host);
            Console.WriteLine($"Host {uri_dns.Host} có các IP");
            hostEntry.AddressList.ToList().ForEach(ip => Console.WriteLine(ip));

            Console.WriteLine($"----------------------------------------------------");

            // lớp Ping
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            var ping = new Ping();
            var pingReply = ping.Send("google.com.vn");
            Console.WriteLine(pingReply.Status);
            if (pingReply.Status == IPStatus.Success)
            {
                Console.WriteLine(pingReply.RoundtripTime);
                Console.WriteLine(pingReply.Address);
            }

            // end
            Console.ResetColor();
        }
    }
}
