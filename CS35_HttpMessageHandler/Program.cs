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
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // await HttpMessageHandlerMethod.Run();

            // await SocketsHttpHandlerMethod.Run();

            await RunHandlerIntercepter.Run();
        }
    }
}
