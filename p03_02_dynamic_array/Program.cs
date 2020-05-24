using System;

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

//동적 배열(dynamic array = list)
namespace p03_02_dynamic_array
{
    class MyList<T>
    {
        const int DEFAULT_SIZE = 1;
        T[] _data = new T[DEFAULT_SIZE];

        public int Count = 0; // 실제로 사용중인 데이터 개수
        public int Capacity { get { return _data.Length; } } // 예약된 데이터 개수

        // O(N)이라고 생각 하겠지만 사실은 O(1)이다 => 예외 케이스 : 이사 비용은 무시한다.
        public void Add(T item)
        {
            // 1.공간이 충분히 남아 있는지 확인.
            if (Count >= Capacity)
            {
                //공간 다시 늘려서 확보한다.
                T[] newArray = new T[Count * 2];
                for (int i = 0; i < Count; i++)
                    newArray[i] = _data[i];
                _data = newArray;
            }

            // 2.공간에다가 데이터를 넣어 준다.
            _data[Count] = item;
            Count++;
        }

        //인덱서 O(1)
        public T this[int index]
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        //O(N)
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count - 1; i++)
                _data[i] = _data[i - 1];
            _data[Count - 1] = default(T); //T라는형식의 초기 값으로 할당
            Count--;
        }
    }

    class Program
    {

        public static MyList<int> list = new MyList<int>(); //동적 배열 - 유동적으로 사이즈 변경 가능

        static void Main(string[] args)
        {
            list.Add(101);
            Console.WriteLine("add!! :: " + list.Count);
            list.Add(102);
            Console.WriteLine("add!! :: " + list.Count);
            list.Add(103);
            Console.WriteLine("add!! :: " + list.Count);
            list.Add(104);
            Console.WriteLine("add!! :: " + list.Count);
            list.Add(105);
            Console.WriteLine("add!! :: " + list.Count);

            int temp = list[2];
            Console.WriteLine("list[2] :: " + temp);

            list.RemoveAt(2);
            Console.WriteLine("RemoveAt(2)!! :: " + list.Count);
        }
    }
}
