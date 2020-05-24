using System;

namespace p01_interface
{
    class Program
    {
        abstract class Monster
        {
            public abstract void Shout();
        }

        //abstract class Flyable
        //{
        //    public abstract void Fly();
        //}

        //c++에서는 다중상속이 되지면 c#에서는 안된다.
        //class FlyableOrc : Orc, Flyable { }

        interface IFlyable
        {
            void Fly();
        }

        class FlyableOrc : Orc, IFlyable
        {
            public void Fly()
            {
                Console.WriteLine("난다~~");
            }
        }

        class Orc : Monster
        {
            public override void Shout()
            {
                Console.WriteLine("록타르 오가르!");
            }
        }

        class Skeleton : Monster
        {
            public override void Shout()
            {
                Console.WriteLine("꾸에에엑!");
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
}
