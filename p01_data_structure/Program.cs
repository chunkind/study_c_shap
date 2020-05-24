using System;
using System.Collections.Generic;

namespace p01_data_structure
{
    /**
     * 스택 : LIFO(후입선출 Last in First out)
     * 큐 : FIFO(선입선출 First in First out)
     * 
     * [주차장입구] -> [1][2][3][4] => [주차장 출구]
     * 
     * [주차장입구/출구] <= [1][2][3][4]
     */

    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            //if(stack.Count > 0)

            stack.Push(101);
            stack.Push(102);
            stack.Push(103);
            stack.Push(104);
            stack.Push(105);

            int data = stack.Pop();
            int data2 = stack.Peek();


            Queue<int> queue = new Queue<int>();

            queue.Enqueue(101);
            queue.Enqueue(102);
            queue.Enqueue(103);
            queue.Enqueue(104);
            queue.Enqueue(105);

            int data3 = queue.Dequeue(); // 101 사라짐
            int data4 = queue.Peek(); // 102 선택됨.

            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(101);
            list.AddLast(102);
            list.AddLast(103);

            // FIFO
            int value1 = list.First.Value;
            list.RemoveFirst();

            // LIFO
            int value2 = list.Last.Value;
            list.RemoveLast();

        }
    }
}
