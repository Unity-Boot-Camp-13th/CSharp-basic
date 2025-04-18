using System.ComponentModel.Design;
using System.Data;

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

        /// <summary>
        /// 삽입 정렬
        /// 현재 탐색 중인 인덱스의 값을 key 로 두고 
        /// 현재 탐색 중인 인덱스보다 앞에 key 값보다 큰 값들이 있다면 전부 오른쪽으로 한 칸씩 밈
        /// 더 이상 밀 수 없을 때 그 위치에 key 값을 쓴다
        /// </summary>
        public static void InsertionSort(this int[] arr)
        {
            int i, j, key;

            for (i = 1; i < arr.Length; i++)
            {
                key = arr[i];

                for (j = i - 1; j >= 0; j--)
                {
                    if (arr[j] > key)
                    {
                        arr[j + 1] = arr[j];
                    }
                    else
                    {
                        break;
                    }
                }
                arr[j + 1] = key; // for 루프 마지막에 j-- 하기 때문에 다시 +1 해서 쓴거임
            }
        }

        public static void MergeSort(this int[] arr)
        {
            int length = arr.Length;

            // 병합 단위
            for (int mergeSize = 1; mergeSize < length; mergeSize *= 2)
            {
                // 병합 범위
                for (int start = 0; start < length; start += mergeSize * 2)
                {
                    // 왼쪽 파티션 : start ~ mergeSize - 1
                    // 오른쪽 파티션 : start ~ 2 * mergeSize - 1
                    int mid = Math.Min(start + mergeSize - 1, length - 1);
                    int end = Math.Min(start + 2 * mergeSize - 1, length - 1);

                    Merge(arr, start, mid, end);
                }
            }
        }

        public static void RecursiveMergeSort(this int[] arr) // 재귀 병합 정렬
        {
            RecursiveMergeSort(arr, 0, arr.Length - 1);
        }

        private static void RecursiveMergeSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                // 정수는 반올림이 아니라 버림임
                int mid = (start + end) / 2; // 코테 : end + (start - end + 1) / 2 - 1
                RecursiveMergeSort(arr, start, mid); // 이진 트리처럼 나눔 -> 시간 복잡도: logn
                RecursiveMergeSort(arr, mid + 1, end);

                Merge(arr, start, mid, end);
            }
        }


        private static void Merge(int[] arr, int start, int mid, int end)
        {
            int length1 = mid - start + 1; // start ~ mid (part1 길이)
            int length2 = end - (mid + 1) + 1; // mid + 1 ~ end (part2 길이)
            int[] copy1 = new int[length1]; // part1(왼쪽) 카피
            int[] copy2 = new int[length2]; // part2(오른쪽) 카피

            for (int i = 0; i < length1; i++)
            {
                copy1[i] = arr[i + start];
            }
            for (int i = 0; i < length2; i++)
            {
                copy2[i] = arr[i + mid + 1];
            }

            int part1 = 0;
            int part2 = 0;
            int index = start; // 현재 정렬하려는 위치

            // 두 파트 중 하나라도 다 소진할 때까지 반복
            while (part1 < length1 && part2 < length2)
            {
                if (copy1[part1] <= copy2[part2])
                {
                    arr[index++] = copy1[part1++];
                }
                else
                {
                    arr[index++] = copy2[part2++];
                }
            }

            // part1 만 남았다면 index 부터 쭉 이어서 붙여넣는다
            while (part1 < length1)
                arr[index++] = copy1[part1++];
        }

        public static void ReculsiveQuickSort(this int[] arr)
        {
            ReculsiveQuickSort(arr, 0, arr.Length - 1);
        }

        private static void ReculsiveQuickSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int p = QuickSortPartition2(arr, start, end);

                ReculsiveQuickSort(arr, start, p); // 왼쪽 파티션 // quicksortpartition2의 p가 p-1일 가능성도 내포하고 있기 때문에 p로 작성
                ReculsiveQuickSort(arr, p + 1, end); // 오른쪽 파티션
            }
        }

        /// <summary>
        /// Quick 정렬 로직에서 Pivot 을 선정하여 Pivot 값 기준 정렬을 수행하고
        /// 고정된 값을 반환해서 상위 함수에서 고정된 인덱스를 기준으로 좌, 우 분할 로직을 수행할 수 있도록 함
        /// </summary>
        /// <returns> 이번 정렬에서 고정될 배열의 인덱스 </returns>
        private static int QuickSortPartition(int[] arr, int start, int end)
        {
            int pivot = arr[(start + end) / 2];

            while (true)
            {
                while (arr[start] < pivot)
                {
                    start++;
                }
                while (arr[end] > pivot)
                {
                    end--;
                }
                if (start < end)
                {
                    if (arr[start] == pivot &&
                        arr[end] == pivot)
                        end--;

                    else
                    {
                        arr.Swap(start, end);
                    }
                }
                else
                    return end;
            }
        }

        private static int QuickSortPartition2(int[] arr, int start, int end)
        {
            int mid = start + ((end - start) >> 1); // (end - start) >> 1 = (end - start) / 2
            int pivot = arr[mid];

            while (true)
            {
                while (arr[start] < pivot)
                    start++;
                while (arr[end] > pivot)
                    end--;
                if (start < end)
                {
                    arr.Swap(start, end);
                    start++;
                    end--;
                }
                else
                {
                    return end;
                }
            }
        }

        public static void HeapSort(this int[] arr)
        {
            HeapifyBottomup(arr);
            InverseHeapify(arr);
        }

        private static void HeapifyBottomup(int[] arr)
        {
            int current = arr.Length - 1;

            while(current >= 0)
            {
                SIFTDown(arr, current--, arr.Length - 1);
            }
        }

        private static void InverseHeapify(int[] arr)
        {
            int end = arr.Length - 1;
            while (end > 0)
            {
                arr.Swap(0, end--);
                SIFTDown(arr, 0, end);
            }
        }

        private static void SIFTDown(int[] arr, int current, int end)
        {
            int leftChild = current * 2 + 1;

            // 더이상 아래로 스왑이 불가능할 때까지 반복
            while (leftChild <= end)
            {
                int rightChild = leftChild + 1;
                int priorityChild = leftChild;

                // 오른쪽 자식이 있으면서, 오른쪽 자식이 왼쪽보다 크면 우선순위 바꿈 
                if (rightChild <= end &&
                    arr[rightChild] > arr[leftChild])
                {
                    priorityChild = rightChild;
                }

                // 자식의 우선순위가 더 높은지 확인 후 스왑
                if (arr[current] < arr[priorityChild])
                {
                    arr.Swap(current, priorityChild);
                    current = priorityChild;
                    leftChild = current * 2 + 1;
                }
                else
                {
                    break;
                }
            }
        }

        static void Swap(this int[] arr, int index1, int index2)
        {
            int tmp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = tmp;
        }
    }
}
