using System.Net.Http;
using System.Net;
using System.Threading;
using System;
using System.Threading.Tasks;

namespace CS29_Async_await
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // !  Thread 
            Program.WaitThread(2);

            // ! Synchronous - Đồng bộ
            // WaitThread(1, "Task 1", ConsoleColor.Cyan);
            // WaitThread(1, "Task 2", ConsoleColor.Yellow);
            // WaitThread(1, "Task 3", ConsoleColor.Magenta);
            Console.WriteLine("--------------------------------------------------");

            // ! Asynchronous - Bất đồng bộ
            // ! => Lớp Task
            Task t2 = new Task(() => { WaitThread(5, "Async Task 2", ConsoleColor.Red); });
            Task t3 = new Task(
                (Object inp) =>
                {
                    String TenTacVu = (String)inp;
                    WaitThread(3, TenTacVu, ConsoleColor.Blue);
                }, "Async Task 3"
            );

            Task t4 = Task_4();

            // todo: run Tasks

            t2.Start();
            t3.Start();
            WaitThread(3, "Sync Task 1", ConsoleColor.Yellow);

            // todo: Wait Tasks
            t2.Wait();
            t3.Wait();
            // --------------
            Console.ResetColor();

            // ! Async/ Await
            //  ! Task có giá trị trả về

            // ?  Task<string> t5 = new Task<string>(Func<string>); // () => { return string;}
            // ? Task<string> t5 = new Task<string>(Func<object,string>, object); // (object obj) => { return string;}

            Task<string> t5 = new Task<string>(() =>
            {
                WaitThread(3, "Task_5", ConsoleColor.DarkGreen);

                return "Return from Task 5";
            });

            t5.Start();
            // await t5;
            // string kq_t5 = t5.Result;
            // ? từ khóa Result sẽ nhận kết quả khi Task hoàn thành, tuy nhiên nó vẫn là bất đồng bộ nên phải đi cùng với Task.Wait(), nếu không sẽ ảnh hưởng

            string kq_t5 = await t5;
            Console.WriteLine($"kq_t5 -  {kq_t5}");

            Console.ReadKey();

            var task = GetWeb("https://xuanthulab.net");
            var content = await task;
            Console.WriteLine(content);
        }

        static void WaitThread(int second, string mgs = "done", ConsoleColor color = ConsoleColor.Yellow)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"Thread Wait Start - {mgs}");
            Console.ResetColor();

            for (int i = 0; i < second; i++)
            {
                lock (Console.Out) // Khóa 1 biến để thực hiện xong công việc trong { } mới đượ truy cập tiếp
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine($"{mgs} - {i}");
                    Console.ResetColor();
                }
                Thread.Sleep(1000);
            }

            Console.ForegroundColor = color;
            Console.WriteLine($"Time out - {mgs,8}");
            Console.ResetColor();
        }


        static async Task Task_4()
        {
            Task t4 = new Task(() => { WaitThread(5, "Async Task 4", ConsoleColor.DarkYellow); });

            t4.Start();

            await t4;
            // ! tự động return Task và không khóa Task chính như Task.Wait()
            // ! ==> đảm bảo Task 4 chạy đồng bộ, mà không khóa đồng bộ Task chính

            Console.WriteLine("Task 4 done!!!");
        }


        static async Task<string> GetResult(Task<string> T)
        {
            T.Start();
            var result = await T;
            return result;
        }

        static async Task<string> GetWeb(string url)
        {
            HttpClient http = new HttpClient();

            HttpResponseMessage kq = await http.GetAsync(url);
            string content = await kq.Content.ReadAsStringAsync();

            return content;
        }
    }
}
