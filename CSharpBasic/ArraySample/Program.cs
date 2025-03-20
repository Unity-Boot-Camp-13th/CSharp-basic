namespace ArraySample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // new 키워드 : 새로 어떤 데이터가 초기화가 되었다는 뜻
            // 배열 생성 방법 : new 자료형[크기]
            // 배열은 참조 형식
            // int[] arr = new int[5]; //모든 요소 0 초기화
            // int[] arr = { 3, 4, 2, 7, 1 }; // 요소별 초기값 주고싶을 때
            int[] arr = new int[5] { 3, 4, 2, 7, 1 }; // 몇 개인지 알려주면서 초기값 주고 싶을 때

            // 배열의 인덱서
            // 배열에서 특정 번째 요소에 접근할 수 있도록 하는 기능
            // arr[i] , 배열의 첫번째 주소에서부터
            //          i * 요소의 자료형 크기만큼 뒤로 가서
            //          해당 주소부터 자료형 크기만큼 읽거나 쓰기 함.
            arr[0] = 5;
            arr[1] = 4;
            arr[2] = 3;
            arr[3] = 2; //자료형 크기(4byte) * 3 만큼 띄어서 자료를 읽겠다
            arr[4] = 1;

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]}, ");
            }
            Console.WriteLine();
            // Array 클래스
            // 배열관련 편의 기능들이 있음
            Array.Sort(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]}, ");
            }
            Console.WriteLine();

            Array.Reverse(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]}, ");
            }
            Console.WriteLine();

            int indexOf2 = Array.IndexOf(arr, 2);
            int[] arr2 = { 6, 2, 3, 4, 1, 2 };
            Array.Copy(arr, 2, arr2, 0, 3);

            for (int i = 0; i < arr2.Length; i++)
            {
                Console.Write($"{arr2[i]}, ");
            }

            // 2차원 배열
            // 다차원 배열이라고 해서 힙메모리 영역에 다차원으로 할당하는 것이 아니고,
            // 연속적인 데이터로 할당한 다음, 차원별 인덱서를 통해 알맞는 위치에 접근하는 방식
            // -------------------------------------------------------

            // 0 : 길
            // 1 : 벽
            // 2 : 도착지점
            // 3 : 플레이어

            int[,] map = new int[6, 5] // 0차원이 y축, 1차원이 x축
            {
                { 0, 0, 0, 0, 1},
                { 0, 1, 1, 1, 1},
                { 0, 0, 0, 1, 1},
                { 1, 1, 0, 1, 1},
                { 1, 1, 0, 1, 1},
                { 1, 1, 0, 0, 2},
            };
            // 위의 경우가 가독성이 떨어진다고 판단될 때
            MapNode[,] map2 = new MapNode[6, 5]
            {
                {MapNode.Path, MapNode.Path, MapNode.Path, MapNode.Path, MapNode.Wall },
                {MapNode.Path, MapNode.Wall, MapNode.Wall, MapNode.Wall, MapNode.Wall },
                {MapNode.Path, MapNode.Path, MapNode.Path, MapNode.Wall, MapNode.Wall },
                {MapNode.Wall, MapNode.Wall, MapNode.Path, MapNode.Wall, MapNode.Wall },
                {MapNode.Wall, MapNode.Wall, MapNode.Path, MapNode.Wall, MapNode.Wall },
                {MapNode.Wall, MapNode.Wall, MapNode.Path, MapNode.Path, MapNode.Goal },
            };

        }

        enum MapNode
        {
            None,
            Path,
            Wall,
            Goal,
            User
        }





    }
}
