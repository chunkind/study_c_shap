using System;
using System.Collections.Generic;

/**
* 
* 선형 vs 비선형
* 
* 선형 구조는 자료를 순차적으로 나열한 형태
* 1.배열
* 2.연결 리스트
* 3.스택/큐
* 
* 비선형 구조는 하나의 자료뒤에 다수의 자료가 올 수 있는 형태
* 1.트리
* 2.그래프
* 
* 
* 배열 vs 동적 배열 vs 연결 리스트
* * 배열
*  - 사용할 length size를 고정해서 생성 (절대 변경 불가)
*  - 연속된 index로 배정 받아 사용
* 장점 : 연속된 index
* 단점 : 배열 싸이즈를 줄이거나 늘릴 수 없다.
* 
* * 동적 배열
*  - 사용할 배열의 size를 유동적으로 늘리거나 줄일 수 있다.
*  - 연속된 index로 배정 받아 사용
*  - 중간에 빈 값이 있으면 안된다.
* 장점 : 배열 사이즈를 유동적으로 늘리거나 줄일 수 있다.
* 단점 : 중간 삽입/삭제가 어렵다
* 동적 배열 할당 적책 :
*  - 실제로 사용할 length보다 많이, 여유분을 두고 (대략 1.5~2배) 생성.
*  - 이사 횟수를 최소화
*  
*  * 연결 리스트
*   - 연속되지 않은 index를 사용
*  장점 : 중간 추가/삭제 이점
*  단점 : N번째 데이터를 바로 찾을 수가 없음(임의 접근 Random Access불가)
* 
*/

//양방향 연결 리스트(Linked List)
namespace p03_03_linked_list
{

    class MyLinkedListNode<T>
    {
        public T Data;
        public MyLinkedListNode<T> Next;
        public MyLinkedListNode<T> Prev;
    }

    class MyLinkedList<T>
    {
        public MyLinkedListNode<T> Head = null; // 첫번째
        public MyLinkedListNode<T> Tail = null; // 마지막
        public int Count = 0;

        //O(1)
        public MyLinkedListNode<T> AddLast(T data)
        {
            MyLinkedListNode<T> newRoom = new MyLinkedListNode<T>();
            newRoom.Data = data;

            // 만약에 아직 방이 아예 없었다면, 새로 추가한 첫번째 방이 곧 Head이다.
            if (Head == null)
                Head = newRoom;

            // 기존의 [마지막 방]과 새로 추가되는 방을 연결 해준다.
            if(Tail != null)
            {
                Tail.Next = newRoom;
                newRoom.Prev = Tail;
            }

            // [새로 추가되는 방]을 [마지막 방]으로 인정한다.
            Tail = newRoom;
            Count++;
            return newRoom;
        }

        //O(1)
        public void Remove(MyLinkedListNode<T> room)
        {
            // [기존의 첫번째 방의 다음 방]을  [첫번째 방으로] 인정한다.
            if (Head == room)
                Head = Head.Next;

            // [기존의 마지막 방의 이전 방]을 [마지막 방으로] 인정한다.
            if (Tail == room)
                Tail = Tail.Prev;

            if (room.Prev != null)
                room.Prev.Next = room.Next;

            if (room.Next != null)
                room.Next.Prev = room.Prev;

            Count--;
        }
    }

    class Program
    {
        //public static LinkedList<int> list = new LinkedList<int>();
        public static MyLinkedList<int> list = new MyLinkedList<int>();

        static void Main(string[] args)
        {
            list.AddLast(101);
            list.AddLast(102);
            //LinkedListNode<int> node = list.AddLast(103);
            MyLinkedListNode<int> node = list.AddLast(103);
            list.AddLast(104);
            list.AddLast(105);

            //list[2]; //인덱서 지원 안함!!

            list.Remove(node);
        }
    }
}
