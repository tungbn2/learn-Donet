using System;
using System.IO;
using System.Text;

namespace CS28_work_file
{
    class Program
    {

        //  drive Info
        // Dirrectory
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // ! class DriveInfo
            DriveInfoClass.ReadDriveInfo();

            // ! class Directory
            DirectoryClass.CreateFolder();
            DirectoryClass.GetAllFile();

            // ! class File
            WorkFile.WriteFile("./test");
            WorkFile.ReadFile("test/test.txt");

            // ! FileStream
            FileStreamClass.FileStreamFunc();
        }
    }
}
