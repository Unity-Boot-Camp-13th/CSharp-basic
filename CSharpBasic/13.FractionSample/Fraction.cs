namespace FractionSample
{
    struct Fraction : IPrintable
    {
        public int Numerator; // 분자
        public int Denominator; // 분모

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                Console.WriteLine("분모가 0으로 설정되어 있습니다");
                denominator = 1;
            }

            Numerator = numerator;
            Denominator = denominator;
        }

        public static Fraction Invalid => new Fraction { Numerator = 0, Denominator = 0 };

        /// <summary>
        /// 기약 분수
        /// </summary>
        public Fraction Reduce()
        {
            int gcd = GCD();

            if (gcd != 0)
                return new Fraction(Numerator / gcd, Denominator / gcd);

            return this;
        }

        /// <summary>
        /// 최대공약수
        /// </summary>
        private int GCD()
        {
            int a = Math.Abs(Numerator); // 분자 // Abs는 절대값을 구해줌
            int b = Math.Abs(Denominator); // 분모
            int temp;

            if (a < b)
            {
                temp = b;
                b = a;
                a = temp;
            }

            while (b != 0)
            {
                temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        public void Print()
        {
            Console.WriteLine($"{Numerator}/{Denominator}");
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public static Fraction operator +(Fraction a, Fraction b )
        {
            int numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
            int denominator = a.Denominator * b.Denominator;
            return new Fraction(numerator, denominator);
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            int numerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
            int denominator = a.Denominator * b.Denominator;
            return new Fraction(numerator, denominator);
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            int numerator = a.Numerator * b.Numerator;
            int denominator = a.Denominator * b.Denominator;
            return new Fraction(numerator, denominator);
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.Numerator == 0)
            {
                throw new Exception("분자가 0인 분수로 나누기를 시도했습니다");
            }
            return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        public static bool operator ==(Fraction a, Fraction b)
        {
            a = a.Reduce();
            b = b.Reduce();
            return (a.Numerator == b.Numerator) && (a.Denominator == b.Denominator);
        }

        public static bool operator !=(Fraction a, Fraction b)
            => !(a == b);

        public static Fraction operator ~(Fraction a)
            => new Fraction(~a.Numerator, a.Denominator);
    }
}
