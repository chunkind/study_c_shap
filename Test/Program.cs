﻿using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Player player = new Player();
            board.Initialize(25, player);
            player.Initialize(1, 1, board);

            Console.CursorVisible = false;

            const int WAIT_TICK = 1000 / 30;

            int lastTick = 0;
            while (true)
            {
                #region 프레임 설정
                int currentTick = System.Environment.TickCount;
                if (currentTick - lastTick < WAIT_TICK)
                    continue;
                int deltaTick = currentTick - lastTick;
                lastTick = currentTick;
                #endregion

                //입력

                //로직
                player.Update(deltaTick);

                //랜더링
                Console.SetCursorPosition(0, 0);
                board.Render();
            }
        }
    }
}
