namespace RaycastSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // layers -> 적이면 0100, 적이지만 상호작용하면 0101
            // 1 = ground
            // 2 = enemy
            // 3 = player
            // 4 = interactable

            // bit flags : 필요한 비트들만 올려서 검출하기 편한 값을 할당할 때 사용
            int layerFlags = 1 << 2 | 1 << 4; // interactable enemy  
            // 00010100

            // 총을 쐈을 때 충돌할 수 있는 대상을 검출하기 위한 검출기
            // 이런 것을 BitFlags에서 검출할 때 사용하는 것이 Bit Mask
            // 예시로, 총알이 충돌할 수 있는 대상을 ground, enemy 로 정했다면 충돌 bit mask는 :
            int collisionMask = 1 << 1 | 1 << 2;
            // 00000110

            // 충동 대상이 맞음
            if ((layerFlags & collisionMask) > 0)
            {

            }
            // 충돌할 수 없는 대상
            else
            {
                return;
            }



            float rayOriginX = 2f; // 선을 쏘는 시작점 X
            float rayOriginY = 3.1f; // 선을 쏘는 시작점 Y
            float rayDirectionX = 1f; // 선을 쏘는 방향 X
            float rayDirectionY = 0f; // 선을 쏘는 방향 Y

            float circleColliderCenterX = 10.2f; // 원충돌체 중심점 X
            float circleColliderCenterY = 5.2f; // 원충돌체 중심점 Y
            float circleColliderRadius = 4f; // 원충돌체 반지름

            // ray 상의 임의의 점 (x, y)
            // x = rayOriginX + rayDirectionX * t (0 <= t)
            // y = rayOriginY + rayDirectionY * t (0 <= t)

            // 원의 방정식
            // (x - circleColliderCenterX)^2 + (y - circleColliderCenterY)^2 = circleColliderRadius^2

            // 두 식을 대입하면 t에 대한 방정식은:
            // (rayOriginX + rayDirectionX * t - circleColliderCenterX)^2 + (rayOriginY + rayDirectionY * t - circleColliderCenterY)^2 = circleColliderRadius^2

            // 이를 전개하면:
            // (rayDirectionX^2 + rayDirectionY^2) * t^2 +
            // 2 * [rayDirectionX * (rayOriginX - circleColliderCenterX) + rayDirectionY * (rayOriginY - circleColliderCenterY)] * t +
            // [(rayOriginX - circleColliderCenterX)^2 + (rayOriginY - circleColliderCenterY)^2 - circleColliderRadius^2] = 0

            // 교차 여부를 판단하기 위한 판별식 계산에 사용할 수 있음
            float a = rayDirectionX * rayDirectionX + rayDirectionY * rayDirectionY;
            float b = 2 * (rayDirectionX * (rayOriginX - circleColliderCenterX) + rayDirectionY * (rayOriginY - circleColliderCenterY));
            float c = (rayOriginX - circleColliderCenterX) * (rayOriginX - circleColliderCenterX) +
                      (rayOriginY - circleColliderCenterY) * (rayOriginY - circleColliderCenterY) -
                      circleColliderRadius * circleColliderRadius;
            float discriminant = b * b - 4 * a * c;

            // 해가 없음 (충돌 안 함)
            if (discriminant < 0)
            {
                Console.WriteLine("Miss");
            }
            // 해가 있음
            else
            {
                float sqrtOfDiscriminant = (float)Math.Sqrt(discriminant);
                float t1 = (-b + sqrtOfDiscriminant) / (2f * a);
                float t2 = (-b - sqrtOfDiscriminant) / (2f * a);
                float t = 0;

                if (t1 >= 0 && t2 >= 0)
                {
                    t = Math.Min(t1, t2);
                }
                else if (t1 >= 0)
                {
                    t = t1;
                }
                else if (t2 >= 0)
                {
                    t = t2;
                }
                else
                {
                    Console.WriteLine("Miss");
                    return; // 반환, 코드를 여기까지 실행하고 함수 종료
                }

                float hitX = rayOriginX + rayDirectionX * t;
                float hitY = rayOriginY + rayDirectionY * t;
                Console.WriteLine($"Hit ({hitX},{hitY})");
            }
            // 조건문 if
            // if (조건)
            // {
            //     // 조건 1이 참일 때 실행할 내용
            // }
            // else if (조건)
            // {
            //     // 조건 1일 거짓이고 조건 2가 참일 때 실행할 내용
            // }
            // else
            // {
            //     // 상위 조건들이 모두 거짓일 때 실행
            // }

        }
    }
}