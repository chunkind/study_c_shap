using System;

namespace MyException
{

    class TestException : Exception
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //1. 0으로 나눌때
                //2. 잘못된 메모리를 참조 (null)
                //3. 오버플로우

                throw new TestException();
            }
            catch (TestException e)
            {
                Console.WriteLine("잡았따!!");
            }
        }
    }
}
