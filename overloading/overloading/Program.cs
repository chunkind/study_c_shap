using System;

namespace overloading
{
    class Program
    {
        static int Add(int a, int b)
        {
            return a + b;
        }
        static void Main(string[] args)
        {
            int ret = Program.Add(2, 3);
            Console.WriteLine(ret);
        }
    }
}
