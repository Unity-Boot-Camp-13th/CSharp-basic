using System.Drawing;

namespace StructureSample
{
    // 아래 과제가 어려울 것 같다 싶으신 분들은 Vector2 구조체 먼저 만들어보고 이후에 과제 수행 해주세요.

    /// <summary>
    /// RGBA 값을 가짐
    /// RGBA 는 범위가 0f ~ 255.0f 로 제한됨
    /// 현재 RGBA 값을 0f ~ 1.0f 범위로 조정하는 옵션이 있어야 함 (bool useNormalizedScale)
    ///     : 옵션 키면 RGBA 스케일이 0f ~ 1f, 끄면 0f ~ 255.0f 를 외부에 제공해야 함
    ///     생성자 오버로드 두 개 작성해서 하나는 RGBA 초기값만 받고 이 옵션을 끈 채로 객체 할당, 다른 하나는 이 옵션을 생성자에서 파라미터로 받아서 적용
    /// 비교연산자 (같음, 다름) 사용
    /// 실수와 나누기 연산자, 실수와 곱하기 연산자
    /// Color 끼리 더하기 연산자, Color 끼리 빼기 연산자
    /// 색상 프리셋 제공 (흰색, 검은색, 파란색, 빨간색, 녹색)
    /// </summary>
    struct Color
    {
        // public 프로퍼티는 PascalCase
        // private 변수이름 _camelCase
        // 함수이름 PascalCase
        // 지역변수 (및 파라미터) 이름 camelCase
        // 상수 이름 UPPER_SNAKE_CASE

        // 코드 섹터 정렬 순서
        // 1. 생성자
        // 2. 프로퍼티
        // 3. 필드
        // 4. 메서드
        // 5. 연산자

        // 필드를 제외하고는 요소별로 한 라인 띄움
        // 섹터 간에 두 라인 띄움


        float _r, _g, _b, _a;

        // 최소값, 최대값 설정
        public static float Min = 0f;
        public static float Max = 255f;

        // 생성자
        public Color(float R, float G, float B, float A)
        {
            _r = R;
            _g = G;
            _b = B;
            _a = A;

            if (_r < Min)
            { _r = Min; }
            else if (_r > Max)
            { _r = Max; }

            else if (_g < Min)
            { _g = Min; }
            else if (_g > Max)
            { _g = Max; }

            else if (_b < Min)
            { _b = Min; }
            else if (_b > Max)
            { _b = Max; }

            else if (_a < Min)
            { _a = Min; }
            else if (_a > Max)
            { _a = Max; }

        }


        // 프로퍼티
        public float R
        {
            get
            {
                return _r;
            }
            private set
            {
                _r = value;
            }
        }


        // 메서드



        // 색상 설정
        public static Color White => new Color(Max, Max, Max, Max);

        public static Color Black => new Color(Min, Min, Min, Max);

        public static Color Blue => new Color(Min, Min, Max, Max);

        public static Color Red => new Color(Max, Min, Min, Max);

        public static Color Green => new Color(Min, Max, Min, Max);


        // 연산자
        // 비교 연산자
        public static bool operator == (Color co1, Color co2)
            => (co1._r == co2._r) && (co1._g == co2._g) && (co1._b == co2._b) && (co1._a == co2._a);

        public static bool operator != (Color co1, Color co2)
            => !(co1 == co2);

        // 실수와 나누기, 곱하기 연산자
        public static Color operator /(Color co1, float co2)
            => new Color(co1._r / co2, co1._g / co2, co1._b / co2, co1._a / co2);
        public static Color operator *(Color co1, float co2)
            => new Color(co1._r * co2, co1._g * co2, co1._b * co2, co1._a * co2);

        // 컬러끼리 더하기, 빼기 연산자
        public static Color operator +(Color co1, Color co2)
            => new Color(co1._r + co2._r, co1._g + co2._g, co1._b + co2._b, co1._a + co2._a);

        public static Color operator -(Color co1, Color co2)
            => new Color(co1._r - co2._r, co1._g - co2._g, co1._b - co2._b, co1._a - co2._a);
    }
}
