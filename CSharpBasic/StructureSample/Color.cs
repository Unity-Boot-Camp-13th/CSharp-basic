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
        // public 프로퍼티는 PASCAL_CASE
        // private 변수이름 _camelCase
        // 함수이름 PASCAL_CASE
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


        public Color(float red, float green, float blue, float alpha)
        {
            _red = red;
            _green = green;
            _blue = blue;
            _alpha = alpha;
        }

        float _red, _green, _blue, _alpha;

        public Color()
        {

        }


        // 색상 설정
        public static Color Minimum => new Color(0f, 0f, 0f, 0f);

        public static Color Max => new Color(255f, 255f, 255f, 255f);

        public static Color White => new Color(255f, 255f, 255f, 255f);

        public static Color Black => new Color(0f, 0f, 0f, 255f);

        public static Color Blue => new Color(0f, 0f, 255f, 255f);

        public static Color Red => new Color(255f, 0f, 0f, 255f);

        public static Color Green => new Color(0f, 255f, 0f, 255f);

        public float Magnitude => (float)Math.Sqrt(_red * _red + _green * _green + _blue * _blue + _alpha * _alpha);


        // 비교 연산자
        public static bool operator == (Color co1, Color co2)
            => (co1._red == co2._red) && (co1._green == co2._green) && (co1._blue == co2._blue) && (co1._alpha == co2._alpha);

        public static bool operator != (Color co1, Color co2)
            => !(co1 == co2);

        // 실수와 나누기, 곱하기 연산자
        public static Color operator /(Color co1, float co2)
            => new Color(co1._red / co2, co1._green / co2, co1._blue / co2, co1._alpha / co2);
        public static Color operator *(Color co1, float co2)
            => new Color(co1._red * co2, co1._green * co2, co1._blue * co2, co1._alpha * co2);

        // 컬러끼리 더하기, 빼기 연산자
        public static Color operator +(Color co1, Color co2)
            => new Color(co1._red + co2._red, co1._green + co2._green, co1._blue + co2._blue, co1._alpha + co2._alpha);

        public static Color operator -(Color co1, Color co2)
            => new Color(co1._red - co2._red, co1._green - co2._green, co1._blue - co2._blue, co1._alpha - co2._alpha);



    }
}
