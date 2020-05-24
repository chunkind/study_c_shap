using System;
using System.Collections.Generic;
using System.Text;

namespace p01_event
{
    //Observer Pattern
    class InputManager
    {
        public delegate void OnInputKey();
        public event OnInputKey InputKey; //콜백 방식

        public void Update()
        {
            //아무키도 입력안하면 리턴
            if (Console.KeyAvailable == false)
                return;

            //유저가 입력한키 받기
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.A)
            {
                // 모두한테 알려준다!
                InputKey();
            }
        }
    }
}
