using System;

namespace CShap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
        }

        static void HelloWorld()
        {

        }


        enum Choice
        {
            ROCK = 1,
            PAPER = 2,
            SCISSORS = 0
        }
        static void step02(string[] args)
        {

            // 0:가위, 1:바위, 2:보
            //const int ROCK = 1;
            //const int PAPER = 2;
            //const int SCISSORS = 0;

            Random rand = new Random();
            int aiChoice = rand.Next(0, 3); //0~2사이의 랜덤 값
            int choice = Convert.ToInt32(Console.ReadLine()); //콘솔에서 입력값 받기

            switch (choice)
            {
                case (int)Choice.SCISSORS:
                    Console.WriteLine("당신의 선택은 가위입니다");
                    break;
                case (int)Choice.ROCK:
                    Console.WriteLine("당신의 선택은 바위입니다");
                    break;
                case (int)Choice.PAPER:
                    Console.WriteLine("당신의 선택은 보입니다");
                    break;
            }

            switch (aiChoice)
            {
                case (int)Choice.SCISSORS:
                    Console.WriteLine("컴퓨터의 선택은 가위입니다");
                    break;
                case (int)Choice.ROCK:
                    Console.WriteLine("컴퓨터의 선택은 바위입니다");
                    break;
                case (int)Choice.PAPER:
                    Console.WriteLine("컴퓨터의 선택은 보입니다");
                    break;
            }

            if(choice == aiChoice){
                Console.WriteLine("무승부 입니다.");
            }else if( (choice== (int)Choice.SCISSORS && aiChoice== (int)Choice.PAPER) 
                || (choice== (int)Choice.ROCK && aiChoice== (int)Choice.SCISSORS) 
                || (choice == (int)Choice.PAPER && aiChoice == (int)Choice.ROCK)){
                Console.WriteLine("승리 입니다.");
            }else{
                Console.WriteLine("패배 입니다.");
            }
        }


        //main 프로그램 진입하는 함수. 프로그램 전체에서 유일해야 한다.
        static void step01(string[] args)
        {
            /*************** 변수 *******************/
            /*
             * 데이터와 로직은 프로그램을 구성하는 양대 요소
             * 데이터 : 정보
             * 로직 : 정보를 다루는 일종의 연산
             */
            //정수
            //byte(1byte 0~255), short(2byte -3만~3만), int(4byte -21억~21억), long(8byte)
            //sbyte(1byte -128~127), ushort(2byte 0~6만), uint(4byte 0~43억), ulong(8byte)

            //논리값
            //bool(1byte true/false)

            //소수
            //float(4byte) double(8byte)

            //문자
            //char(2byte) string

            byte attack = 0;
            attack--; //underflow가 발생하여 255이 됨. 주의
            
            Console.WriteLine("attack : {0}", attack);

            //소수 연산은 정수연산보다 비용이 비싼 연산이다.
            float f = 3.14f; //7자리넘어가면 오차 생김.
            double d = 3.14;

            string str = "안녕하세요";

            Console.WriteLine(str);

            /**************** 진수 ********************/
            //10진수 0~9
            // 00 01 02 03 04 05 06 07 08 09 10

            //2진수 0~1
            // 0b00 0b01 0b10 0b11 0b100

            //16진수 0~9 a b c d e f
            // 0x00 0x01 0x02 ... 0x0F 0x10

            //2진수에서 16진수로 변환 => 4자리씩 끈는다.
            // 0b10001111 = 0x8F

            /**************** 형변환 ********************/
            //1.바구니 크기가 다른경우
            int a = 1000;
            //short b = a; //암시적 변환은 불가능하지만 명시적 변환이 가능하다고 에러남.
            short b = (short)a;
            Console.WriteLine(b);
            //2.바구니 크기가 같긴한데 부호가 다를 경우
            byte c = 255;
            sbyte sb = (sbyte)c;
            Console.WriteLine(sb);
            //0xFF = 0b11111111 = -1 (0x1111) 

            /**************** 논리 ********************/
            //비트 연산 << >> & | ^(xor) ~

            /**************** 연산 우선순위 ********************/
            //1. ++ --
            //2. * / %
            //3. + -
            //4. << >>
            //5. < >
            //6. == !=
            //7. &
            //8. ^
            //9. |
            //..
        }
    }
}