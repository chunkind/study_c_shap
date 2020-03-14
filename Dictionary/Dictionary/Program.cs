using System;
using System.Collections.Generic;

namespace Dictionary
{
    class Program
    {
        class Monster
        {
            public int id;
            public Monster(int id) { this.id = id; }
            
        }

        static void Main(string[] args)
        {
            /**
             * List의 단점은 너무 많은 데이터를 서치하는데 느리다.
             * 단점보안 => Dictionary
             * 
             * Dictionary는 어떻게 서치하길래 빠른가?
             * Hashtable을 사용!
             * 
             * 찾는게 리스트 보다 빠르지만 메모리 손해
             */

            Dictionary<int, Monster> dic = new Dictionary<int, Monster>();

            //추가하는 방법은 아래처럼
            //dic.Add(1, new Monster(1));
            //dic[5] = new Monster(5);

            for(int i=0; i<10000; i++)
            {
                dic.Add(i, new Monster(i));
            }

            Monster mon = dic[2000]; //찾는게 없다면 에러가 날것이다.
            bool found = dic.TryGetValue(20000, out mon); //위 로직보다 이것이더 안전!!

            dic.Remove(7777); //해당하는 키 삭제
            dic.Clear(); //모두 삭제

        }
    }
}
