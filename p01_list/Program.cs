using System;
using System.Collections.Generic;

namespace p01_list
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[100];

            //List <- 동적 배열 [ 0 1 2 3 4 ]
            List<float> list = new List<float>();
            //list[0] = 1;

            for (int i = 0; i < 5; i++)
                list.Add(i);

            // 삽입
            list.Insert(2, 999);
            //[ 0 1 999 2 3 4 ]

            //삭제
            //index로 찝어서 삭제
            //list.RemoveAt(0); 

            //선택 아이템으로 삭제 (만약 999가 여러개 있으면 처음만난 999만 삭제)
            bool success = list.Remove(999);
            if (success) Console.WriteLine("삭제 성공");

            //전체삭제
            //list.Clear(); 

            for (int i = 0; i < list.Count; i++)
                Console.WriteLine(list[i]);

            foreach (int num in list)
            {
                Console.WriteLine(num);
            }
        }
    }
}
