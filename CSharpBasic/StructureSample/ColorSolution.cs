using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructureSample
{
    struct ColorSolution 
    {

        public ColorSolution(float r, float g, float b, float a)
        {
            _r = Clamp(r);
            _g = Clamp(g);
            _b = Clamp(b);
            _a = Clamp(a);
        }

        public ColorSolution(float r, float g, float b, float a, bool use255Scale)
        {   
            float max = use255Scale ? 255f : 1f;
            _r = Clamp(r, 0f, max);
            _g = Clamp(g, 0f, max);
            _b = Clamp(b, 0f, max);
            _a = Clamp(a, 0f, max);
            _use255Scale = use255Scale;
        }

        public bool Use255Scale
        {
            get => _use255Scale;
            set
            {
                if (_use255Scale == value)
                    return;

                if (value)
                    Scale1To255();
                else
                    Scale255To1();

                _use255Scale = value;
            }
        }

        public float R
        {
            get => _r;
            set
            {
                _r = Clamp(value, 0, _use255Scale ? 255f : 1f) ;
            }
        }

        public float G
        {
            get => _g;
            set
            {
                _g = Clamp(value, 0, _use255Scale ? 255f : 1f);
            }
        }

        public float B
        {
            get => _b;
            set
            {
                _b = Clamp(value, 0, _use255Scale ? 255f : 1f);
            }
        }

        public float A
        {
            get => _a;
            set
            {
                _a = Clamp(value, 0, _use255Scale ? 255f : 1f);
            }
        }

        public static ColorSolution White => WhiteColor;
        public static ColorSolution White255 => WhiteColor255;
        
        public static ColorSolution Black => new ColorSolution() { _r = 0.0f, _g = 0.0f, _b = 0.0f , _a = 1.0f };
        public static ColorSolution Red => new(1f, 0f, 0f, 1f);

        static readonly ColorSolution WhiteColor = new ColorSolution(1f, 1f, 1f, 1f);
        static readonly ColorSolution WhiteColor255 = new ColorSolution(255f, 255f, 255f, 255f, true);

        float _r, _g, _b, _a; // 이 예제에서는 멤버 변수가 캡슐화되어 있지만, 구조체는 값을 빠르게 읽고 쓰는 이점때문에
        // 사용하므로 멤버 변수를 public 으로 공개해서 캡슐화하지 않고 사용하는 경우가 많다
        bool _use255Scale; // bool까지 17byte, 그래서 실제로 구조체로 만들고 싶을 경우 구조체를 두 개 만듦 
        const float MAX_255_SCALE = 255f;

        /// <summary>
        /// 값 범위 제한 
        /// </summary>
        /// <param name="value"> 원본 값 </param>
        /// <param name="min"> 범위 최소 값 </param>
        /// <param name="max"> 범위 최대 값</param>
        /// <returns> 제한된 값 </returns>
        private float Clamp(float value, float min = 0f, float max = 1f)
        {
            if (value < min)
                value = min;
            else if (value > max)
                value = max;

            return value;
        }

        private void Scale1To255()
        {
            _r *= MAX_255_SCALE;
            _g *= MAX_255_SCALE;
            _b *= MAX_255_SCALE;
            _a *= MAX_255_SCALE;
        }

        private void Scale255To1()
        {
            _r /= MAX_255_SCALE;
            _g /= MAX_255_SCALE;
            _b /= MAX_255_SCALE;
            _a /= MAX_255_SCALE;
        }

        public static bool operator ==(ColorSolution op1, ColorSolution op2)
        {
            if (op1.Use255Scale != op2.Use255Scale)
                op2.Use255Scale = op1.Use255Scale;
            return (op1._r == op2._r) && (op1._g == op2._g) && (op1._b == op2._b) && (op1._a == op2._a);
        }

        public static bool operator !=(ColorSolution op1, ColorSolution op2)
            => !(op1 == op2);

        public static ColorSolution operator +(ColorSolution op1, ColorSolution op2)
        {
            if (op1.Use255Scale != op2.Use255Scale)
                op2.Use255Scale = op1.Use255Scale;

            return new ColorSolution(op1._r + op2._r, op1._g + op2._g, op1._b + op2._b, op1._a + op2._a);
        }
    }
}
