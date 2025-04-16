namespace SortAlgorithms
{
    static class ArrayExtensions
    {
        // 내가 작성한 거품 정렬 로직
        // public static void BubbleSort(this int[] arr)
        // {
        //     for (int round = 0; round < arr.Length - 1; round++)
        //     {
        //         for (int index = 0; index < arr.Length -1 - round; index++)
        //         {
        //             if (arr[index] > arr[index + 1])
        //             {
        //                 arr.Swap(index, index + 1);
        //             }
        //         }
        //     }
        // }

        public static void BubbleSort(this int[] arr)
        {
            // 패싱 반복
            for (int i = 0; i < arr.Length - 1; i++)
            {
                // 패싱.. 패싱 반복 횟수만큼 끝자리 고정되므로 탐색 개수 줄어듦
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                        arr.Swap(j, j + 1);
                }
            }
        }

        static void Swap(this int[] arr, int index1, int index2)
        {
            int tmp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = tmp;
        }

        /// <summary>
        /// 현재 탐색 중인 인덱스 뒤로 가장 작은 값을 가지는 인덱스를 찾아서 걔랑 스왑
        /// 특징 : 한 번 패싱할 때마다 가장 작은 수가 고정
        /// </summary>
        public static void SelectionSort(this int[] arr)
        {
            int minIdx = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIdx])
                        minIdx = j;
                }

                arr.Swap(i, minIdx); // 현재 이렇게까지만 적었으니까 같은 수여도 스왑 가능성이 있음
            }
        }

        public static void InsertSort(this int[] arr)
        {
            int key = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                key = arr[i];
                int j;

                for (j = i - 1; j >= 0; j--)
                {
                    if (arr[j] > key)
                    {
                        arr[j + 1] = arr[j];
                    }
                    else
                        break;
                }
                arr[j + 1] = key;
            }
        }
    }
}
