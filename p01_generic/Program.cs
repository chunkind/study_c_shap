using System;

namespace p01_generic
{
    class Program
    {
        class Program
        {

            //class MyList
            //{
            //    int[] arr = new int[10];
            //}

            //class MyShortList
            //{
            //    short[] arr = new short[10];
            //}

            //class MyFloatList
            //{
            //    float[] arr = new float[10];
            //}

            //class MyMonsterList
            //{
            //    Monster[] arr = new Monster[10];
            //}

            //class Monster{}

            //class MyList<T> where T : struct 
            //class MyList<T> where T : class
            class MyList<T> where T : Monster
            {
                T[] arr = new T[10];

                public T GetItem(int i)
                {
                    return arr[i];
                }
            }

            class Monster
            {

            }

            static void Test<T>(T input)
            {

            }

            static void Test2<T, S>(T input, S input2)
            {

            }

            static void Test3<T, S, J>(T i1, S i2, J i3)
            {

            }

            static void Main(string[] args)
            {
                MyList<int> myIntList = new MyList<int>();
                int item = myIntList.GetItem(0);

                MyList<short> myShortList = new MyList<short>();
                MyList<Monster> myMonsterList = new MyList<Monster>();

            }
        }
    }
}
