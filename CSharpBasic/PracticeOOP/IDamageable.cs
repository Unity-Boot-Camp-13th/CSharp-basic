/*
 * interface 키워드
 * : 외부 객체와의 상호작용을 위한 기능들을 추상화하기 위해 사용자 정의 자료형을 정의할 때 사용하는 키워드
 * 상호 작용이 목적이기 때문에 접근 제한자는 public이 기본값이다
 * "기능"의 추상화이므로 데이터를 포함할 수 없다 (즉, 멤버 변수 같은 것은 선언할 수 없다)
 * 다중 상속이 가능하다
 * interface를 상속 받은 interface도 가능하다
 */

namespace PracticeOOP
{
    interface IDamageable
    {
        // public 안 썼지만 member들 모두 public임
        int HpMax { get; }

        int Hp { get; }

        void Damage(IAttacker attacker,int amount);
    }
}
