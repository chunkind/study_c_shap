using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace p03_16_heap
{
    /* 
       이진 트리의 개념 ::: 각 노드가 최대 두 개의 자식 노드를 가지는 트리


       * 이진 검색 트리의 특징
                16
               ↙↘
             14    78
           ↙↘   ↙↘
          5   15 31  90
        ↙↘        ↙
        1  10      87
        1) 왼쪽을 타고 가면 현재 값보다 작다.
        2) 오른쪽을 타고 가면 현재 값보다 크다.

       * 이진 검색 트리의 문제
                16
               ↙↘
             14    78
           ↙↘   ↙↘
          5   15 31  90
        ↙↘        ↙↘
        1  10      87  91
                        ↘
                         92
                          ↘
                           93
        그냥 무식하게 추가하면, 한쪽으로 기울어져서 균형이 깨진다.
        트리 재배치를 통해 균형을 유지하는 것이 과제(AVL, Red-Black)
        이럴 경우 검색속도가 빨랐던 이점을 잃게 된다.

        * 힙 트리의 특징
                32
               ↙↘
             26    15
           ↙↘   ↙↘
         19   14  6  13
        ↙↘
        1  10
        힙 트리 1법칙 : [부모 노드]가 가진 값은 항상[자식 노드]가 가진 값보다 크다.
        마지막 레벨을 제외한 모든 레벨에 노드가 꽉 차 있다.
        마지막 레벨에 노드가 있을 때는, 항상 왼쪽부터 순서대로 채워야 한다.

        * 힙 트리의 구조
                ?
               ↙↘
             ?     ?
           ↙↘
          ?   ?
        데이터 개수 5개인 경우의 힙 트리 구조
        힙 트리 2법칙 : 노드 개수를 알면, 트리 구조는 무조건 확정할 수 있다.

        * 힙 트리의 구현
                A[0]
               ↙↘
             A[1] A[2]
           ↙↘ 
         A[3] A[4]
        따라서 배열을 이용해서 힙 구조를 바로 표현할 수 있다.
        1) i번 노드의 왼쪽 자식은 [(2*i) + 1] 번
        2) i번 노드의 오른쪽 자식은 [(2*i) + 2] 번
        3) i번 노드의 부모는 [(i-1) / 2] 번

        * 힙 트리 새로운 값 추가.
        ::: 31이라는 숫자를 추가해 보자.
                32
               ↙↘
             26    15
           ↙↘   ↙↘
         19   14  6  13
        ↙↘
        1 10

        힙 트리 2법칙 :: 노드 개수를 알면, 트리 구조는 무조건 확정할 수 있다.
        1 단계) 우선 트리 구조부터 맞춰준다.
                32
               ↙↘
             26    15
           ↙↘   ↙↘
         19   14  6  13
        ↙↘  ↙
        1 10 31

        힙 트리 1법칙 :: [부모 노드]가 가진 값은 항상 [자식 노드]가 가진 값보다 크다.
        2 단계) 도장 깨기를 시작한다.
        31과 14 비교후 자리바꿈 -> 31과 26 비교후 자리바꿈 -> 31과 32 비교후 자리 못바꿈
                32
               ↙↘
             31    15
           ↙↘   ↙↘
         19   26  6  13
        ↙↘  ↙
        1 10 14

        * 힙트리 최대값 꺼내기 :: 힙트리의 최대값은 무조건 루트 노드에 있는 값이다. 따라서 32가 최대값!!
                32
               ↙↘
             31    15
           ↙↘   ↙↘
         19   26  6  13
        ↙↘  ↙
        1 10 14

        32를 빼면 아래와 같다.

               ↙↘
             31    15
           ↙↘   ↙↘
         19   26  6  13
        ↙↘  ↙
        1 10 14

        젤 아래 14를 올려준다.
                14
               ↙↘
             31    15
           ↙↘   ↙↘
         19   26  6  13
        ↙↘ 
        1 10

        31과 15중 젤큰 31과 비교하여 비교값보다 작으면 자리바꿈
                31
               ↙↘
             14    15
           ↙↘   ↙↘
         19   26  6  13
        ↙↘ 
        1 10

        19와 26중 젤큰 26과 비교하여 자리바꿈
                31
               ↙↘
             26    15
           ↙↘   ↙↘
         19   14  6  13
        ↙↘ 
        1 10
     */


    /**
        바이너리 힙트리로 이용하여 우선순위 큐 구현
                32
               ↙↘
             31    15
           ↙↘   ↙↘
         19   26  6  13
        ↙↘  ↙
        1 10
     */
    class PriorityQueue
    {
        List<int> _heap = new List<int>();

        //O(logN)
        public void Push(int data)
        {
            // 힙의 맨 끝에 새로운 데이터를 삽입한다.
            _heap.Add(data);

            int now = _heap.Count - 1;
            //도장 깨기 시작
            while(now > 0)
            {
                // 도장깨기 시도
                int next = (now - 1) / 2;
                if (_heap[now] < _heap[next])
                    break; //실패

                //두값을 비교한다.
                int temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                //검사 위치를 이동
                now = next;
            }

        }

        //O(logN)
        public int Pop()
        {
            //반환할 데이터를 따로 저장
            int ret = _heap[0];

            //마지막 데이터를 root로 이동
            int lastIndex = _heap.Count - 1;
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);
            lastIndex--;

            //역으로 내려가는 도장깨기 시작
            int now = 0;
            while (true)
            {
                int left = 2 * now + 1; //왼쪽
                int right = 2 * now + 2; //오른쪽

                int next = now;
                //왼쪽 값이 현재값보다 크면, 왼쪽으로 이동
                if (left <= lastIndex && _heap[next] < _heap[left])
                    next = left;

                if (right <= lastIndex && _heap[next] < _heap[right])
                    next = right;

                //왼쪽, 오른쪽 모두 현재값보다 작으면 종료
                if (next == now)
                    break;

                //두값을 비교한다.
                int temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                //검사 위치 이동
                now = next;
            }

            return ret;
        }

        public int Count()
        {
            return _heap.Count;
        }
    }

    class PriorityQueue2<T> where T : IComparable<T>
    {
        List<T> _heap = new List<T>();

        //O(logN)
        public void Push(T data)
        {
            // 힙의 맨 끝에 새로운 데이터를 삽입한다.
            _heap.Add(data);

            int now = _heap.Count - 1;
            //도장 깨기 시작
            while (now > 0)
            {
                // 도장깨기 시도
                int next = (now - 1) / 2;
                if (_heap[now].CompareTo(_heap[next]) < 0)
                    break; //실패

                //두값을 비교한다.
                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                //검사 위치를 이동
                now = next;
            }

        }

        //O(logN)
        public T Pop()
        {
            //반환할 데이터를 따로 저장
            T ret = _heap[0];

            //마지막 데이터를 root로 이동
            int lastIndex = _heap.Count - 1;
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);
            lastIndex--;

            //역으로 내려가는 도장깨기 시작
            int now = 0;
            while (true)
            {
                int left = 2 * now + 1; //왼쪽
                int right = 2 * now + 2; //오른쪽

                int next = now;
                //왼쪽 값이 현재값보다 크면, 왼쪽으로 이동
                if (left <= lastIndex && _heap[next].CompareTo(_heap[left]) < 0)
                    next = left;

                if (right <= lastIndex && _heap[next].CompareTo(_heap[right]) < 0)
                    next = right;

                //왼쪽, 오른쪽 모두 현재값보다 작으면 종료
                if (next == now)
                    break;

                //두값을 비교한다.
                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                //검사 위치 이동
                now = next;
            }

            return ret;
        }

        public int Count()
        {
            return _heap.Count;
        }
    }

    class Knight : IComparable<Knight>
    {
        public int Id { get; set; }

        public int CompareTo(Knight other)
        {
            if (Id == other.Id)
                return 0;
            return Id > other.Id ? 1 : -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*PriorityQueue q = new PriorityQueue();
            q.Push(20);
            q.Push(10);
            q.Push(30);
            q.Push(90);
            q.Push(40);

            while(q.Count() > 0)
            {
                Console.WriteLine(q.Pop());
            }*/

            /*PriorityQueue q = new PriorityQueue();
            q.Push(-20);
            q.Push(-10);
            q.Push(-30);
            q.Push(-90);
            q.Push(-40);

            while (q.Count() > 0)
            {
                Console.WriteLine(-q.Pop());
            }*/

            /*PriorityQueue2<int> q = new PriorityQueue2<int>();
            q.Push(20);
            q.Push(10);
            q.Push(30);
            q.Push(90);
            q.Push(40);

            while (q.Count() > 0)
            {
                Console.WriteLine(q.Pop());
            }*/

            PriorityQueue2<Knight> q = new PriorityQueue2<Knight>();
            q.Push(new Knight() { Id = 20 });
            q.Push(new Knight() { Id = 30 });
            q.Push(new Knight() { Id = 40 });
            q.Push(new Knight() { Id = 10 });
            q.Push(new Knight() { Id = 05 });

            while (q.Count() > 0)
            {
                Console.WriteLine(q.Pop().Id);
            }

        }
    }
}
