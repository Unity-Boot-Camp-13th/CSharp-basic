namespace _9.ClassSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 클래스는 참조 타입
            // new 생성자 호출 시 Heap에 객체 동적 할당 후 생성된 객체의 참조 반환

            // 클래스 생성자 오버로드를 따로 정의하지 않으면
            // 멤버 변수를 초기값대로 초기화하는 public한 생성자가 기본값으로 사용된다
            Eagle eagle1 = new Eagle("Luke");

            Pigeon pigeon1 = new Pigeon("Carl");

        }
    }
}
