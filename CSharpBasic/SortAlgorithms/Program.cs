using System.Diagnostics;

namespace SortAlgorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] arr = Enumerable.Repeat(0, 10000000) // 아이템 10만개짜리 자료를 생성
                                  .Select(x => random.Next(0, 10000000)) // 자료 전체 순회하면서 x 에 대해 0~10만 사이 값 난수를 반환한 값으로 새 자료 생성
                                  .ToArray(); // 배열로 변경

            Stopwatch stopwatch = Stopwatch.StartNew();

            // arr.BubbleSort(); // 10만개, 난수범위 0~10만 에서 39000 ms
            // arr.SelectionSort(); // 10만개, 난수범위 0~10만 에서 11900 ms
            // arr.InsertionSort(); // 10만개, 난수범위 0~10만 에서 7450 ms
            // arr.RecursiveMergeSort(); // 10만개, 난수범위 0~10만 에서 25 ms
            // arr.MergeSort(); // 10만개, 난수범위 0~10만 에서 25 ms
             arr.ReculsiveQuickSort();  // 10만개, 난수범위 0~10만 에서 15 ms
            // arr.HeapSort(); // 10만개, 난수범위 0~10만 에서 30 ms

            stopwatch.Stop();
            Console.WriteLine($"정렬 걸린 시간 : {stopwatch.ElapsedMilliseconds} ms");

            // Console.Write("정렬됨 :");

            // for (int i = 0; i < arr.Length; i++)
            // {
            //     Console.Write($"{arr[i]}, ");
            // }
        }
    }
}
