using System;

/**
 *  테스트 방법 : 실행후 A키를 눌러라
 */
namespace p01_event
{
    class Program
    {
        static void OnInputTest()
        {
            Console.WriteLine("Input Received!");
        }

        static void Main(string[] args)
        {
            InputManager inputManager = new InputManager();
            inputManager.InputKey += OnInputTest; //이벤트 구독 신청!!

            while (true)
            {
                inputManager.Update();
            }
        }
    }
}
