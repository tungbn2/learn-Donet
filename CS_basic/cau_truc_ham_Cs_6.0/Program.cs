// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

void Plus(int a, int b)
{
    Console.Write($"a + b = {a + b}");
}

Plus(10, 11);

// từ khóa ref
int refNum = 10;

void changeNum(ref int a) { a++; }

changeNum( refNum);

Console.WriteLine($"Số ref mới là {refNum}");
