/*
 * 작성일 : 2025-03-17
 * 작성자 : Sunny
 * 설명 : 첫 프로젝트
 */ //해당 cs를 제 3자가 봐야 할 때 위의 내용을 작성해야 함.

using System; // using 키워드: 특정 namespace를 현재 파일에 사용하겠다. 
// 여러 개발자가 같은 namespace를 사용할 수 없음. namespace가 식별자의 역할을 하기 때문. 자기 이름 쓰면 안 됨. 자의식 과잉.

namespace FirstProject

    ///{summary} 
    ///프로그램 기본 정의
    ///</summary>
    //summary는 내 파일을 굳이 열지 않아도 볼 수 있는 내용이기에 적어야함
{
    internal class Program
    {
        // 키워드(예약어) : 시스템에 사용되기 위해 개발자가 임의로 사용할 수 없는 이름들이다. (파란색 단어)

        // static : 정적 키워드(예약어)
        // 런타임중에 동적으로 할당할 수 없다.
        // 변수를 선언할 때는 얼마만큼의 메모리 공간을 어떤 형태로 할당해서 사용할 것인지 명시를 해줘야 CPU가 연산할 수 있다.

        // 352 = 10^2 * 3 + 10^1 * 5 + 10^0 * 2 = 352_10
        // 4 = 2^2 * 1 + 2^1 * 0 + 2^0 * 0 = 00000100_2
        // 3 =           2^1 * 1 + 2^0 * 1 = 00000011_2
        // 4 + 3                           = 111_2 = 7_10

        // char 'P' = 80_10 = 2^6 * 1 + 2^4 * 1 = 00000000 01010000

        // bit : 0과 1의 2진수 표현 단위
        // byte : 정보 처리의 최소 단위. (8bit)

        // C#의 자료형들 :
        static int _num1; //4byte 부호 있는 정수형. 메모리를 조금 오버하더라도 int사용하는 것이 빠름
        static uint _num2; // 4byte 부호 없는 정수형 
        static short _num3; // 2byte 부호 있는 정수형
        static ushort _num4; // 2byte 부호 없는 정수형
        static long _num5; // 8byte 부호 있는 정수형
        static ulong _num6; // 8byte 부호 없는 정수형
        static float _num7; // 4byte 실수형, 유니티 사용은 float를 가장 많이 하게 될 것임.
        static double _num8; // 8byte 실수형
        static bool _num9; // 1byte 논리형 0은 false이고 0이 아닌 수는 true
        static char _char1; // 2byte 문자형 (ASCII 코드표에 따른 정수 취급)
        static string _string1; // 문자열형, 문자개수 * 2byte + 1byte(null byte, 문자열의 끝을 명시)
        static object _object1; // 객체형, C#의 모든 자료형의 기반 타입

        // 이름 규칙
        // PascalCase 대문자사용
        // camelCase 소문자사용
        // snake_case 언더바사용
        // UPPER_SNAKE_CASE 대문자 언더바사용 -> 대부분 상수를 눈에 띄게 하기 위해 가장 많이 사용

        // 상수 이름 규칙은 공식 문서에서는 보통 PascalCase 권장
        const int MAX_CLIENTS = 10;
        readonly float maxHp;

        /// <summary>
        /// 프로그램실행시 첫 진입점 함수
        /// </summary>
        /// <param name="args"> 프로그램 시작 옵션 </param>
        static void Main(string[] args) //static : 동적으로 할당할 수 없는, 즉 Heap Memory에 할당할 수 없음.
        {
            Console.Write("1\n"); // write는 줄바꿈 없이, writeline 자동으로 줄 바뀜, \n은 줄 띄움
            Console.WriteLine("Hello, World!"); //출력문
            Console.Write("2");
            Console.WriteLine("{1} {3} {2} {0}", "Sunny", "My", "is", "name"); //자리표시자
            Console.WriteLine(@"\'1\'\r"); // Varbatim 문자열 리터럴 (이스케이프시퀀스 무시)
            Console.WriteLine($"Max clients : {MAX_CLIENTS}"); // 문자열 보간 리터럴 (중괄호로 중간에 데이터 삽입)

            // 형변환
            // - 명시적 형변환 : 다른 자료형으로 취급해야 한다고 명시해서 변환 (컴파일러가 안전하지 않다고 판단하는 경우)
            // 취급하는 값 종류는 동일하나 크기가 다를 경우에 큰 값을 작은 공간에 넣으려고 한다면 이것은 데이터 소실 위험이 있으므로 명시적 변환 해야함.
            // 취급하는 값 종류가 다를 경우도 데이터 소실 위험이 있음
            int a = (int)314L; // 8byte 정수 데이터를 4byte 정수 공간에 대입하면 데이터 날아갈 수 있으므로, 사용자가 판단하여 소괄호로 명시.
            int b = (int)3.14f; // 4byte 실수 데이터를 4byte 정수 공간에 대입하려면 소수부분 소실 위험 있음.
            // - 암시적 형변환 : 개발자가 따로 명시하지 않아도 연산과정에서 형변환이 일어나는 변환
            // 취급하는 값 종류가 동일하고, 작은 값을 큰 공간에 넣으려고 할 때 -< 데이터의 승격(Promotion)
            long c = 14;
            double d = 3.14f;
        }
    }
}
