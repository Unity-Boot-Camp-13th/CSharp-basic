using System.Drawing;
using System.Security;

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
    public struct RGBA
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

        // 색상값 0~1f로 조정하는 옵션
        private static bool useNormalizedScale;

        // 최소값, 최대값 설정
        public static float Min = 0f;
        public static float Max = 255f;

        // 생성자
        // RGBA 초기값, 범위 조정 옵션 끔
        public RGBA(float R, float G, float B, float A)
        {
            useNormalizedScale = false;
            _r = Ranged(R);
            _g = Ranged(G);
            _b = Ranged(B);
            _a = Ranged(A);
        }

        public RGBA(float R, float G, float B, float A, bool useNormalizedScale)
        {
            RGBA.useNormalizedScale = useNormalizedScale;

            if (useNormalizedScale )
            {
                _r = NormalizedScale(R);
                _g = NormalizedScale(G);
                _b = NormalizedScale(B);
                _a = NormalizedScale(A);
            }
            else
            {
                _r = Ranged(R);
                _g = Ranged(G);
                _b = Ranged(B);
                _a = Ranged(A);
            }
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
                _r = value ;
            }
        }

        public float G
        {
            get
            {
                return _g;
            }
            private set
            {
                _g = value;
            }
        }

        public float B
        {
            get
            {
                return _b;
            }
            private set
            {
                _b = value;
            }
        }

        public float A
        {
            get
            {
                return _a;
            }
            private set
            {
                _a = value;
            }
        }

        // 색상 설정 
        //(질문) 필드(=)가 아니라 프로퍼티(=>)를 사용하는 이유는 옵션에서 255f로 나눠주기 위함
        /* public static Color White
         * {
         *  get {return new Color(Max, Max, Max, Max)}
         * }
         */
        public static RGBA White => new RGBA(Max, Max, Max, Max);

        public static RGBA Black => new RGBA(Min, Min, Min, Max);

        public static RGBA Blue => new RGBA(Min, Min, Max, Max);

        public static RGBA Red => new RGBA(Max, Min, Min, Max);

        public static RGBA Gree => new RGBA(Min, Max, Min, Max);
        

        // 메서드
        // 색상 값을 0 ~ 255f로 제한
        public static float Ranged(float colorValue)
        {
            if (colorValue < Min)
            {
                colorValue = Min;
            }
            else if (colorValue > Max)
            {
                colorValue = Max;
            }
            return colorValue;
        }

        // 정규화 옵션 활성시 0 ~ 1f로 제한
        public static float NormalizedScale(float scale)
        {
            if(useNormalizedScale)
            {
                return scale / 255f;
            }
            return scale;
        }


        // 연산자
        // 비교 연산자
        public static bool operator == (RGBA co1, RGBA co2)
            => (co1._r == co2._r) && (co1._g == co2._g) && (co1._b == co2._b) && (co1._a == co2._a);

        public static bool operator != (RGBA co1, RGBA co2)
            => !(co1 == co2);

        // 실수와 나누기, 곱하기 연산자
        public static RGBA operator /(RGBA co1, float co2)
            => new RGBA(co1._r / co2, co1._g / co2, co1._b / co2, co1._a / co2);
        public static RGBA operator *(RGBA co1, float co2)
            => new RGBA(co1._r * co2, co1._g * co2, co1._b * co2, co1._a * co2);

        // 컬러끼리 더하기, 빼기 연산자
        public static RGBA operator +(RGBA co1, RGBA co2)
            => new RGBA(co1._r + co2._r, co1._g + co2._g, co1._b + co2._b, co1._a + co2._a);

        public static RGBA operator -(RGBA co1, RGBA co2)
            => new RGBA(co1._r - co2._r, co1._g - co2._g, co1._b - co2._b, co1._a - co2._a);
    }
}
