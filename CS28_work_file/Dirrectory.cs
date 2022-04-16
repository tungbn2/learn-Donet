using System;
using System.IO;

namespace CS28_work_file
{
    public class DirectoryClass
    {
        static string path = "test";
        public static void CreateFolder()
        {

            if (Directory.Exists(DirectoryClass.path))
            {
                Console.WriteLine($"{DirectoryClass.path} - ton tai");
            }
            else
            {
                Console.WriteLine($"{DirectoryClass.path} - khong ton tai -> tao moi");
                Directory.CreateDirectory(DirectoryClass.path);
            }


        }

        public static void GetAllFile()
        {
            var files = Directory.GetFiles("./");

            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }


        
    }
}