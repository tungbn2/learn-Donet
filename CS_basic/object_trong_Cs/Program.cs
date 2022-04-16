using System;

namespace object_trong_Cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // Boxing
            int value = 10;
            object ObjectValue = value;

            // Unboxing
            int newValue = (int)ObjectValue;

            Console.WriteLine("Value: {0}, newValue:  {1}", value, newValue);

            // từ khóa var
            var str = "C#";
          
        }
    }
}
