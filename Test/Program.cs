using System;

namespace Test
{
    /*
               (15)     (5)
            0   ―   1  ―  2

               (35) (10)
                ＼   ｜
                     3

                    (5)
                     ｜  
                        (5)
                     4  ―  5
    */
    class Program
    {
        int[,] adj = new int [6, 6]{
            { -1, 15, -1, 35, -1, -1 },
            { 15, -1, 05, 10, -1, -1 },
            { -1, 05, -1, -1, -1, -1 },
            { 35, 10, -1, -1, 05, -1 },
            { -1, -1, -1, 05, -1, 05 },
            { -1, -1, -1, -1, 05, -1 },
        };
        static void Main(string[] args)
        {
            
            while (true)
            {
                for(int i=0; i<6; i++)
                {
                    adj
                }
            }
        }
    }
}
