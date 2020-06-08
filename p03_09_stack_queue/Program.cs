using System;

namespace p03_09_stack_queue
{
    // 선형 구조 [1] [2] [3] [4]

    // 스택(stack) : LIFO(후입선출 Last In First Out)
    // 큐(queue) : FIFO(선입선출 First In First Out)

    //주차장 예시
    // 스택 : [1] [2] [3] [4] <= 사고
    // 큐 : [1] [2] [3] [4] => 주차장입구

    class Program
    {
        static void Main(string[] args)
        {
            //Stack();
            //Queue();
            LinkedList();
        }

        static void Stack()
        {
            Stack<int> stack = new Stack<int>();

            stack.Push(101);
            stack.Push(102);
            stack.Push(103);
            stack.Push(104);
            stack.Push(105);

            ///안하면 크레쉬 남.
            if (stack.Count > 0)
            {
                //데이터 꺼내면서 삭제됨
                int popData = stack.Pop(); // 105
                //데이터 꺼내기만함
                int peckData = stack.Peek(); //104
            }
        }

        static void Queue()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(101);
            queue.Enqueue(102);
            queue.Enqueue(103);
            queue.Enqueue(104);
            queue.Enqueue(105);

            if (queue.Count > 0)
            {
                //데이터 꺼내면서 삭제됨
                int dequeueData = queue.Dequeue(); // 101
                //데이터 꺼내기만함
                int peekData = queue.Peek(); // 102
            }
        }

        static void LinkedList()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(101);
            list.AddLast(102);
            list.AddLast(103);
            list.AddLast(104);
            list.AddLast(105);

            if (list.Count > 0)
            {
                //FIFO
                int firstData = list.First.Value;
                list.RemoveFirst();

                //LIFO
                int lastData = list.Last.Value;
                list.RemoveLast();
            }
        }
    }
}
