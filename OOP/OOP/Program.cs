using System;

namespace OOP
{

    //참조
    class Knight
    {
        public int hp;
        public int attack;

        public void Move()
        {
            Console.WriteLine("Knight Move");
        }

        public void Attack()
        {
            Console.WriteLine("Knight Attack");
        }
    }

    //복사
    struct Mage
    {
        public int hp;
        public int attack;
    }

    class Program
    {
        static void KillMage(Mage mage)
        {
            mage.hp = 0;
        }

        static void KillKnight(Knight knight)
        {
            knight.hp = 0;
        }

        static void Main(string[] args)
        {
            Mage mage;
            mage.hp = 100;
            mage.attack = 50;
            KillMage(mage);
            Console.WriteLine("mage hp  : " + mage.hp); //복사

            Knight knight = new Knight();
            knight.hp = 100;
            knight.attack = 10;
            knight.Move();
            knight.Attack();
            KillKnight(knight);
            Console.WriteLine("knight hp  : " + knight.hp); //참조

        }
    }
}
