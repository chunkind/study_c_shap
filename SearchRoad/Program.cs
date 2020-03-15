using System;

namespace SearchRoad
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Board board = new Board();
            board.Initialize(25);
            Console.CursorVisible = false; // 커서 없애기.
            while (true)
            {
                board.Render();
            }
        }
        
    }
}
