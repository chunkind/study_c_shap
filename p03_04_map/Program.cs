using System;

namespace p03_04_map
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.Initialize(25);

            Console.CursorVisible = false; // 커서 없애기.

            const int WAIT_TICK = 1000 / 30;
            
            int lastTick = 0;

            while (true) // FPS 프레임 ( 60프레임 OK 30프레임 이하로 NO )
            {
                #region 프레임 관리
                //만약에 경과한 시간이 1/30초보다 작다면
                int currentTick = System.Environment.TickCount;
                if (currentTick - lastTick < WAIT_TICK)
                    continue;
                int deltaTick = currentTick - lastTick;
                lastTick = currentTick;
                #endregion

                //랜더링
                Console.SetCursorPosition(0, 0); //커서 위치 변경
                board.Render();

            }
        }
    }
}
