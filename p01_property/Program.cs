using System;

namespace p01_property
{
    // 객체지향 -> 은닉성
    class Program
    {

        class Knight
        {
            protected int hp;

            public int Hp
            {
                get { return hp; }
                set { this.hp = value; }
            }

            public int Mp
            {
                get; set;
            }
        }

        static void Main(string[] args)
        {
            //프로퍼티
            Knight knight = new Knight();
            knight.Hp = 100;

            int hp = knight.Hp;
        }
    }
}
