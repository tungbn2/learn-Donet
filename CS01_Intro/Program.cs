using System.Globalization;
using System;

namespace CS01_Intro
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Xinchao user = new Xinchao ("Nam");
            user.SayHello();
        }
    }

    /// <sumary>
    /// tao test class
    class Xinchao
    {
        string name;
        public Xinchao (string _name)
        {
            name = _name;
        }

        public void SayHello()
        {
            Console.Write("Xin chao :) " + name);
        }
    }
}
