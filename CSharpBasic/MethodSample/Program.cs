/*
 * 변수의 형식
 * 값 형식     : 변수 할당한 메모리 공간에 값을 쓰고 읽는 형식
 * 포인터 형식 : 변수 할당한 메모리 공간에 다른 메모리 주소를 쓰고 읽는 형식
 * 참조 형식   : 변수의 별칭을 지정하는 형식,
 *               변수 할당한 메모리 공간에 다른 메모리 주소를 쓰고 읽긴 하지만 개발자가 직접 메모리주소값을 신경쓰지 않고, 해당 메모리 주소의 데이터만 쓰고 읽기함.
 * -> 포인터의 메모리 주소를 마음대로 옮길 수 있는 위험성을 방지하기 위하여 참조 방식을 사용
 * 
 * C#은 개발자 편의를 위해 기본적인 컨셉은 값과 참조형식만 사용하나, 포인터형식도 사용 가능함.
 * 
 * class : 객체를 설계한 사용자정의자료형
 * 객체 : 고유한 데이터와 기능(ex. 달리기 뛰기)을 가진 단위
 */

namespace MethodSample
{


    // 내가 원하는 사람이라는 객체를 만들 때
    class Human
    {
        /*
         * 클래스 내에서
         * 멤버 : 클래스가 포함하고 있는 요소들
         * static이 붙은 멤버 : 정적 멤버
         * static이 안 붙은 멤버 : 인스턴스 멤버
         */

        public Human(string name, int age)
        {
            _name = name;
            _age = age;
        }

        string _name; // 인스턴스 멤버 변수 : 객체 생성시 힘 영역에 할당할 변수
        static int _age; // 정적 멤버 변수 : 힙 영역에 할당하지 않고, 데이터(BSS) 영역에 직접 데이터를 쓰고 읽기 위한 변수

        /// <summary>
        /// Non-Static(instance) method (인스턴스 멤버함수)
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return _name;
        }
    }



    internal class Program
    {
        /// <summary>
        /// Main 함수는 static 함수이므로 instance 멤버를 그냥 사용하지 못 함
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // 함수내 문자열 리터럴은 함수 호출할 때마다 동적할당 되는게 아니고, 어셈블리의 메타데이터와 함께 저장됨
            // CLR이 이 문자열 리터럴을 intern pool에 로드해서 필요할 때마다 참조해서 재사용함
            // intern pool은 Managed heap 영역에 할당됨.

            int num1 = 32341;
            Human human1 = new Human("정하윤", 320);
            string human1Name = human1.GetName();
            Console.WriteLine(human1Name);

            num1 = Add(1, 2);

            // out 키워드 : 변수의 참조 전달, 보통 두 개 이상의 값을 반환해야 하는 경우 사용
            if (TryReinForce(70.0 , 30.0 , 1 , out int result))
            {
                Console.WriteLine($"강화 성공! {result} 을(를) 획득했다..!");
            }
            else
            {
                Console.WriteLine($"강화 실패! 아이템이 파괴되었다..");
            }

            // ref 키워드 : 변수의 참조 전달, 이미 초기화 되어 있는 변수의 값을 업데이트 해야 할 때 사용
            int a = 3;
            int b = 4;
            Swap(ref a, ref b);
            Console.WriteLine($"a : {a}, b : {b}");

            Factorial(5);
        }
        // 함수 내에서 또 다른 함수를 정의할 수 없음. 함수 내에서 다른 함수 호출은 가능
        // 수학처럼 비슷하게 생각하면 됨.
        static int Add(int x, int y)
        {
            return x + y;
        }

        static long Add(long x, long y) //위와 같은 이름이지만 파라미터가 달라서 사용 가능.
        {
            return x + y;
        }

        /// <summary>
        /// 난수 확률 시도 함수
        /// </summary>
        /// <param name="percent"> 강화 성공 확률 0 ~ 100%, 성공시 +1 </param>
        /// <param name="greatPercent"> 강화 대성공 확률, 0 ~ 100%, 대성공시 +2 </param>
        /// <param name="target"> 강화 대성공 확률 </param>
        /// <param name="result"> 강화할 숫자</param>
        /// <returns> 강화 성공여부, 강화실패시 숫자는 0으로 파괴됨 </returns>
        static bool TryReinForce(double percent, double greatPercent, int target, out int result)
        {
            Random random = new Random();

            // 강화 성공
            if (random.NextDouble() * 100 < percent)
            {
                if(random.NextDouble() * 100 < greatPercent)
                {
                    result = target + 2;
                }
                else
                {
                    result = target + 1;
                }

                return true;
            }

            // 강화 실패, 아이템 파괴
            else
            {
                result = 0;
                return false;
            }
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static int Factorial(int n)
        {
            if (n <= 1) return 1;
            return n * Factorial(n - 1);
        }
        
    }
}