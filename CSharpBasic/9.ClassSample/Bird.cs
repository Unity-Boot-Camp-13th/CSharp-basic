/*
 * abstract class (추상 클래스)
 * 추상화를 위한 클래스 타입을 정의하는 것이므로, 인스턴스화가 불가능하다
 * 
 * 추상화를 할 때에는, 하위에서 해당 멤버를 구현하지 않을 경우를 만들어서는 안 되는 것이 원칙
 */ 

namespace _9.ClassSample
{
    abstract class Bird : object 
    {
        // 추상 클래스에서도 생성자는 정의 가능하지만, 이 생성자를 직접 호출할 수는 없음
        // ( new Bird(string name)  호출 안 됨 )
        public Bird(string name)
        {
            _name = name;
        }

        public abstract int AverageLifespan { get; } // 평균 수명에 대한 멤버 변수 같은 게 꼭 있을 필요는 없는데, 어쨌든 외부에서 평균수명을 읽는 기능은 있어야 함

        public string Name => _name; // 추상클래스라고 해서 모든 기능을 추상화해야 하는 것은 아니다

        protected string _name; // 이 클래스가 추상적이라고 해도, 만약 이름이라는 데이터가 반드시 있어야 한다면 멤버 변수 정의 가능.


        public abstract void Fly(); // abstract 함수는 구현부를 사용 안 함. 어떻게 날지 모르니까

        public abstract void Walk();

        // virtual : 가상 키워드
        // 구현부를 작성했으나, 자식이 재정의할 수 있도록 명시하는 키워드
        public virtual void PrintName()
        {
            Console.WriteLine($"제 이름은 {_name} 입니다");
        }
    }
}
