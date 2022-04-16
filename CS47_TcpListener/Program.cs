using System;
using System.Net;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace TCP
{
    class Program
    {
        public class TpcServerAsyncv {
            readonly int PortNumber;
            public TpcServerAsyncv(int portNumber) => PortNumber = portNumber;

            // Lắng nghe
            public async Task StartLinster()
            {
                try
                {
                    var listener = new TcpListener(IPAddress.Any, PortNumber);
                    Console.WriteLine($"Listener lắng nghe ở cổng {PortNumber}");
                    listener.Start();

                    while (true)
                    {
                        Console.WriteLine("Chờ client kết nối ...");
                        // Một client kết nối đến
                        TcpClient client = await listener.AcceptTcpClientAsync();

                        // Xử lý quá trình giao tiếp giữa Client và Server
                        Task t = RunClientRequestAsync(client);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception of type {ex.GetType().Name}, Message: {ex.Message}");
                }
            }
            private Task RunClientRequestAsync(TcpClient client)
            {
                 // Ham delegate để task thi hành
                 Action action = async () => {
                    try
                    {
                        using (client)
                        {
                            Console.WriteLine("client kết nối");
                            using (NetworkStream stream = client.GetStream())        // tạo các stream
                            using (StreamWriter  writer = new StreamWriter(stream))  // stream để gửi dữ liệu cho client
                            using (StreamReader  reader = new StreamReader(stream))  // stream để đọc dữ liệu từ client
                            {
                                writer.AutoFlush = true;
                                bool exit = false;
                                while (!exit) {
                                    string data = await reader.ReadLineAsync();
                                    switch (data.ToLower())
                                    {
                                        case "time":
                                            await writer.WriteLineAsync(DateTime.Now.ToLongTimeString());
                                        break;
                                        case "exit": // thoát lặp - ngắt kết nối nếu client gửi dòng exit
                                            exit = true;
                                            await writer.WriteLineAsync("exit");
                                        break;
                                        default:
                                            await writer.WriteLineAsync("Không thấy lệnh");
                                        break;
                                    }
                                }

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi {ex.GetType().Name}, Message: {ex.Message}");
                    }
                    Console.WriteLine("Client ngắt kế nối");
                };

                Task task = new Task(action); // tạo task
                task.Start();                 // chạy  task trên thread
                return task;
            }
        }
        static async Task  Main(string[] args)
        {
            await (new TpcServerAsyncv(1950)).StartLinster();
        }

    }
}