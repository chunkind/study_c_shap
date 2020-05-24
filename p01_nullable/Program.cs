using System;

namespace p01_nullable
{
    class Program
    {

        static void Main(string[] args)
        {
            //Nullable -> Null + able
            int? number = null;

            if (number.HasValue) //  "number != null"와 같다.
            {
                int a = number.Value;
                Console.WriteLine(a);
            }

            int b = number ?? 0; //null 이면 0을 null이 아니면 number를 바인딩.

            Monster monster = null;

            if (monster != null)
            {
                int monsterId = monster.Id;
            }

            int? id = monster?.Id; //monster가 널이 아니면 Id값을 뽑고 null이면 null을 넣는다.

        }

        class Monster
        {
            public int Id { get; set; }
        }
    }
}
