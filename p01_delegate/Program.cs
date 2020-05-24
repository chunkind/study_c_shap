using System;

namespace p01_delegate
{
    class Program
    {
        // 업체 사장 - 사장님의 비서
        // 우리의 연락처 용건 거꾸로 연락을 주세요 요청

        delegate int OnClicked();
        // delegate => 형식은 형식인데, 함수 자체를 인자로 넘겨주는 그런 형식
        // 반환:int 입력:void
        // OnClicked 이 delegate 형식의 이름이다!

        //대표적인 프로그래밍 상황 UI 작업
        static void ButtonPressed(OnClicked clickedFunction)
        {
            clickedFunction();
        }

        static int TestDelegate()
        {
            Console.WriteLine("Hello Delegate");
            return 0;
        }

        static int TestDelegate2()
        {
            Console.WriteLine("Hello Delegate2");
            return 0;
        }

        static void Main(string[] args)
        {
            // delegate(대리자)
            //Console.WriteLine();
            //ButtonPressed(TestDelegate);

            OnClicked clicked = new OnClicked(TestDelegate);
            clicked += TestDelegate2;

            clicked();
            //ButtonPressed(clicked);

        }
    }
}
