namespace Operators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 14;
            int b = 6;
            int c = 0;

            // 산술 연산자
            // ----------------------------------------------
            // a와 b를 피연산자로 사용해서 c에 넣을 예정

            c = a + b; // 덧셈
            Console.WriteLine($"{a} + {b} = {c}");
            c = a - b; // 뺄셈
            Console.WriteLine($"{a} - {b} = {c}");
            c = a * b; // 곱셈
            Console.WriteLine($"{a} * {b} = {c}");
            c = a / b; // 나눗셈, 정수끼리 나누기할 경우 몫만 반환
            Console.WriteLine($"{a} / {b} = {c}");
            c = a % b; // 나머지셈
            Console.WriteLine($"{a} % {b} = {c}");

            // 복합 대입 연산자
            // ------------------------------------------------
            int tempC = c;            
            c += a; //c = c + a;
            Console.WriteLine($"{tempC} + {a} = {c}");
            c -= a;
            Console.WriteLine($"{tempC} - {a} = {c}");
            c *= a;
            Console.WriteLine($"{tempC} * {a} = {c}");
            c /= a;
            Console.WriteLine($"{tempC} / {a} = {c}");
            c %= a;
            Console.WriteLine($"{tempC} % {a} = {c}");

            // 증감 연산자
            // ------------------------------------------------

            c = 0;
            ++c; // 1증가, c = c + 1, 결과값 반환, 여기서 c가 1이 됨
            c++; // c = c + 1, 원래값 반환, 여기서 c는 2가 되지만 1값을 출력함.
            /* c++ 과정 풀이
             tempC = c;
             c = c + 1
             console.writeline(tempC);
            코드에는 우선순위가 있음
            */
            --c; // c = c - 1
            c--; // c = c - 1

            // 관계 연산자
            // 논리값을 반환 (true or false)
            // --------------------------------------------------------

            bool result;
            result = a == b; // a와 b가 같으면 true, 다르면 false
            Console.WriteLine($"{a} = {b} : {result}");
            result = a != b; // a와 b가 다르면 true, 같으면 false
            result = a > b; // a가 b보다 크면 true, 아니면 false
            result = a >= b; // a가 b보다 크거나 같으면 true, 아니면 false
            result = a < b; // a가 b보다 작으면 true, 아니면 false
            result = a <= b; // a가 b보다 작거나 같으면 true, 아니면 false

            // 논리 연산자
            // -------------------------------------------------------------

            bool x1 = true;
            bool x2 = false;

            result = x1 & x2; // and 논리 연산
            result = x1 | x2; // or 논리 연산
            result = x1 ^ x2; // xor 논리 연산
            result = !x1; // not 논리 연산
            result = x1 == false; // not 논리 연산자가 가독성이 떨어져, false 비교연산으로 대체할 수 있음


            // 조건부 논리 연산자
            // -------------------------------------------------------------

            result = x1 && x2; // 왼쪽 피연산자 결과가 false라면 바로 false반환
            result = x1 || x2; //  왼쪽 피연산자 결과가 true 라면 바로 true 반환

            // 비트 연산자
            // -------------------------------------------------------------
            // 메모리 사용을 최소화하기 위해 사용, 유니티에서는 충돌감지할 때 가장 많이 사용

            // a == 14 == 0b... 00001110
            // b == 6 == 0b...00000110

            // bit and
            // a & b == 0b... 00000110 = 6
            c = a & b;

            // bit or
            // a | b == 0b... 00001110 = 14
            c = a | b;

            // bit xor
            // a ^ b == 0b... 00001000 = 8
            c = a ^ b;

            // bit not, 모든 연산자 반전
            // ~a    == 0b11111111_11111111_11111111_11110001 = 4294967281
            c = ~a;

            // 2의 보수
            // 2진법 숫자 모두 반전후 + 1
            // 16 - 14 = 2
            // 0b00000000_00000000_00000000_00010000 = 16
            // 0b00000000_00000000_00000000_00001110 = 14
            // 0b10000000_00000000_00000000_00001110 = -14 // 그냥 젤 뒤에 것 1로 부호 표현했을 때
            // 0b10000000_00000000_00000000_00011110 = -30 // 16과 위의 -14를 덧셈 했을 때
            // 0b11111111_11111111_11111111_11110010 = -14 // 2의 보수로 음수표현 했을 때
            // 0b00000000_00000000_00000000_00000010 = 2 // 16과 덧셈을 했을 때

            // bit left shift 모든 비트를 왼쪽으로 N칸 밀기
            c = a << 2; // 0b... 00111000 = 56
            // bit right shift 모든 비트를 오른쪽으로 N칸 밀기
            c = a >> 3; // 0b... 00000001 = 1

            // 삼항 연산자
            // '?' 왼쪽 값이 true면, ':' 왼쪽 값 반환, 아니면 ':' 오른쪽 값 반환
            // 아주 간단한 if문 대용으로 쓸 수 있지만 
            // 아주아주 간단한 내용 아니면 가독성이 오히려 안 좋아지기 때문에 남용하지 말 것
            // --------------------------------------
            
            if (c > 3)
            {
                c = 10;
            }
            else
            {
                c = 0;
            }

            c = c > 3 ? 10 : 0;

            // Null 병합 연산자
            // '??' 왼쪽 값이 null이 아닐 경우 왼쪽 값 반환, 아니면 오른쪽 값 반환
            // -----------------------------------------

            string name = null;
            string label = name ?? "(Unknown)";
            Console.WriteLine(label);

            // Null Check 연산자
            // 대상이 Null일 경우 참조 호출하지 않고 Null 반환
            // ------------------------------------

            Console.WriteLine($"Length of name is {name?.Length ?? 0}");
        }
    }
}
