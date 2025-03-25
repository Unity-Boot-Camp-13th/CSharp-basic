using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.ClassSample
{
    // 구조체는 값을 어느정도 포기하였음
    // eagle은 bird를 상속받은 것은 맞지만, 엄연히 다른 클래스임
    class Eagle : Bird
    {
        // base 키워드 : 기반 타입 참조 키워드
        // 여기서는 Bird 의 멤버에 접근할 때 사용
        public Eagle(string name) : base(name)
        {
        }

        public override int AverageLifespan => 10;

        public override void Fly()
        {
            Console.WriteLine($"{_name}(매), 날다");
        }

        public override void Walk()
        {
            //throw new NotImplementedException(); // 구현하지 않을 내용을 추상화하는 것을 지양
            Console.WriteLine($"{_name}(매), 걷다");
        }
    }
}
