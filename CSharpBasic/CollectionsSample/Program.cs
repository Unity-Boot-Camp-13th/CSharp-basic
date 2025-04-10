using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace CollectionsSample
{
    internal class Program
    {
        Action<int> action; // 파라미터 0~ 16개 까지, 반환형 void 인 함수 참조 체이닝을 위한 C# 기본 대리자
        Func<int, bool> func; // 파라미터 0~ 16개 까지, 반환형 제네릭타입인 함수 참조 체이닝을 위한 C# 기본 대리자
        Predicate<int> predicate; // 파라미터 1개, 반환형 bool 인 함수 참조체이닝을 위한 C# 기본 대리자 (보통 조건 확인용)

        static void Main(string[] args)
        {
            DynamicArray dynamicArray = new DynamicArray(4);
            dynamicArray.Add(1);
            dynamicArray.Add(4);
            dynamicArray.Add(2);
            dynamicArray.Add(5);
            dynamicArray.Add(3);
            dynamicArray.RemoveAt(4);
            dynamicArray.FindLastIndex(x => (int)x > 3);

            Predicate<object> match = x => (int)x > 3;

            IEnumerator enumerator = dynamicArray.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            enumerator.Reset();

            for (; enumerator.MoveNext(); )
            {
                Console.WriteLine(enumerator.Current);
            }

            DynamicArray<int> numbers1 = new DynamicArray<int>(4);
            numbers1.Add(1);
            numbers1.Add(2);

            DynamicArray<int> numbers2 = new DynamicArray<int>(4);
            numbers2.Add(4);
            numbers2.Add(6);
            numbers2.Add(1);

            DynamicArray<string> rewards = new DynamicArray<string>(4);
            rewards.Add("Hp Potion");
            rewards.Add("Mp Potion");
            rewards.Add("Basic sword");

            TreasureChest treasureChest = new TreasureChest(rewards);
            Console.WriteLine($"보상 받음 : {treasureChest.GetRandomReward()}");

            for (int i = 0; i < rewards.Count; i++)
            {
                Console.Write($"{rewards[i]}, ");
            }

            IEnumerator<int> eNumbers = numbers1.GetEnumerator(); // 책 읽어주는 사람

            // 책 읽어주는 사람에게 현재 페이지 읽고 다음장 넘겨주세요
            // 현재 페이지 읽는데 성공했으면 true. 아니면 false.
            while (eNumbers.MoveNext())
            {
                Console.WriteLine(eNumbers.Current); // 책 읽어주는 사람에게 현재 페이지 나에게 넘겨주세요
            }

            eNumbers.Dispose(); // 이 책을 읽기 위해서 사용했던 관리되지 않는 리소스를 해제

            IEnumerator<int> e1 = numbers1.GetEnumerator();
            IEnumerator<int> e2 = numbers2.GetEnumerator();

            while (e1.MoveNext() && e2.MoveNext())
            {

            }

            // foreach 구문
            // IEnumerable 에 대해서 GetEnumerator() 호출하여
            // Enumeration 을 수행하는 구문
            foreach (int item in numbers1)
            {
                Console.WriteLine(item);
            }

            // List - C# 의 제네릭 동적배열
            //-------------------------------------------------------------
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(4);
            list.Add(2);
            list.RemoveAt(2);

            foreach (int item in list)
            {

            }

            // ArrayList - C# 의 논-제네릭(object 기반) 동적배열 
            //-------------------------------------------------------------
            ArrayList arrayList = new ArrayList();
            arrayList.Add("Hi");
            arrayList.Add(3.5f);
            arrayList.Add('a');

            IEnumerator<int> countRoutineEnumerator = new CountRoutineEnumerator();

            while (countRoutineEnumerator.MoveNext())
            {
                Console.Write($"{countRoutineEnumerator.Current}");
            }

            IEnumerator<int> countRoutineEnumerator2 = CountRoutine();

            while (countRoutineEnumerator2.MoveNext())
            {
                Console.Write($"{countRoutineEnumerator2.Current}");
            }

            IEnumerator dummyEnumerator = DummyRoutinable().GetEnumerator();

            while (dummyEnumerator.MoveNext())
            {
                Console.WriteLine($"{dummyEnumerator.Current}");
            }

            foreach (object item in DummyRoutinable())
            {

            }

            // Stack
            // -----------------------------------------
            MyStack_1<int> myStack = new MyStack_1<int>(5);
            myStack.Push(1);
            myStack.Push(4);
            myStack.Push(1);
            myStack.Pop();
            myStack.Push(5);
            Console.WriteLine(myStack.Peek());

            Stack<int> stack = new Stack<int>(6);
            stack.Push(1);
            stack.Push(4);
            stack.Push(1);
            stack.Pop();
            Console.WriteLine(stack.Peek());
        }

        static IEnumerator<int> CountRoutine()
        {
            yield return 1; // yield 키워드 : IEnumerable 혹은 IEnumerator 의  MoveNext 구현을 작성할 때 사용
            yield return 2;
            yield return 3;
            // yield break;
        }

        static IEnumerable DummyRoutinable()
        {
            yield return "Luke"; // yield 키워드 : IEnumerable 혹은 IEnumerator 의  MoveNext 구현을 작성할 때 사용
            yield return 3.5f;
            yield return 'A';
            // yield break;
        }

        class CountRoutineEnumerator : IEnumerator<int>
        {
            public int Current => _current;

            object IEnumerator.Current => Current;
            int _index;
            int _current;


            public bool MoveNext()
            {
                if (_index == 0)
                    _current = 1;
                else if (_index == 1)
                    _current = 2;
                else if (_index == 2)
                    _current = 3;
                else
                    return false;

                _index++;
                return true;
            }

            public void Reset()
            {
                _index = 0;
                _current = default(int);
            }

            public void Dispose()
            {
            }
        }
    }
}