using System;

namespace p03_08_right_hand_rule
{
    class Program
    {
        static void Main(string[] args)
        {
            const int WAIT_TIME = 30;
            Board board = new Board();
            Player player = new Player();
            board.Initialize(25, player);
            int lastTick = 0;

            Console.CursorVisible = false;

            while (true)
            {
                #region 프레임 설정
                int currentTick = System.Environment.TickCount;
                if (currentTick - lastTick < WAIT_TIME)
                    continue;
                int deltaTick = currentTick - lastTick;
                lastTick = currentTick;
                #endregion

                //로직
                player.Update(deltaTick);

                //랜더링
                Console.SetCursorPosition(0, 0);
                board.Render();
            }
        }
    }
}
