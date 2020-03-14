using System;

namespace Inheritance
{
    class Player
    {
        static public int counter = 1;
        public int hp;
        public int id;
        public int attack;


    }

    class Mage : Player
    {

    }

    class Archer : Player
    {

    }

    class Knight : Player
    {
        public Knight()
        {
            Console.WriteLine("Knight 생성자 호출");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
