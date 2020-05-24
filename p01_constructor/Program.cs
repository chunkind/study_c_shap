using System;

namespace p01_constructor
{
    class Knight
    {
        public int hp;
        public int attack;
        public Knight()
        {
            hp = 100;
            attack = 10;
            Console.WriteLine("생성자 호출");
        }

        public Knight(int hp) : this()
        {
            this.hp = hp;
            attack = 10;
            Console.WriteLine("int 생성자 호출");
        }

        public Knight(int hp, int attack) : this(hp)
        {
            this.hp = hp;
            this.attack = attack;
            Console.WriteLine("int 생성자 호출");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Knight k01 = new Knight(10, 1);
        }
    }
}
