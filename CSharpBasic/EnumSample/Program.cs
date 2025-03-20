/*
 * enum : 열거형 사용자정의 자료형을 정의하기 위한 키워드
 */

namespace EnumSample
{
    /*
     * C#의 enum 타입은 기본적으로 int 값으로 취급 
     * enum 정의시 0 값 자리는 의미없는 default로 설정함 (Idle, None, Nothing, Default .. 등등)
     */

    //enum은 class 안쪽에 정의해도 되고, 바깥쪽에 정의해도 됨
    enum State 
    {
        None,
        Move,
        InAir,
        Attack =100,
        Skill1,
        Skill2,
    }

    [Flags] // 현재 enum의 ToString()으로 문자열 반환하는 함수에서 모든 플래그의 요소들을 문자열로 바꿔주는 특성을 부여
    enum Layers
    {
        Nothing           = 0 << 0, // 0b... 00000000  // 0b... 00000000 (shift 사용 안 하면)
        Ground            = 1 << 0, // 0b... 00000001  // 0b... 00000001
        Enenmy            = 1 << 1, // 0b... 00000010  // 0b... 00000010
        Player            = 1 << 2, // 0b... 00000100  // 0b... 00000011
        Interactable      = 1 << 3, // 0b... 00001000  // 0b... 00000100
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Layers targetLayer = Layers.Enenmy | Layers.Interactable;
            Layers collisionLayerMask = Layers.Ground | Layers.Enenmy;

            // 충돌 가능
            if ((targetLayer & collisionLayerMask) > 0)
            {
                // 충돌 처리
            }

            Console.WriteLine((Layers.Ground | Layers.Enenmy).ToString());

            while (true)
            { 
                State currentState = (State)Enum.Parse(typeof(State), Console.ReadLine()); // Enum 클래스 : enum 타입 관련 편의 기능들을 가지고 있음

                //switch내의 조건에 enum을 입력하면 case 알아서 생성
                switch (currentState)
                {
                    case State.None:
                        Console.WriteLine("암것도안하는중...");
                        break;
                    case State.Move:
                        Console.WriteLine("이동중...");
                        break;
                    case State.InAir:
                        Console.WriteLine("공중에뜸...");
                        break;
                    case State.Attack:
                        Console.WriteLine("공격중...");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
