using System.Collections;

namespace CollectionsSample
{
    /// <summary>
    /// 연결리스트의 자료 저장 단위
    /// </summary>
    class MyLinkedListNode<T>
    {
        public MyLinkedListNode(T value)
        {
            Value = value;
        }

        public T Value;
        public MyLinkedListNode<T> Prev; // 이전 노드 참조
        public MyLinkedListNode<T> Next; // 다음 노드 참조
    }

    /// <summary>
    /// 양방향 연결리스트
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class MyLinkedList<T> : IEnumerable<T>
    {
        public MyLinkedListNode<T> First => _first;
        public MyLinkedListNode<T> Last => _last;

        public int Count => _count;

        private MyLinkedListNode<T> _first;
        private MyLinkedListNode<T> _last;
        private int _count;

        // 특정 노드 앞에 추가하려고 함. 따라서 특정 노드 앞이 뭔지는 모르기에 참조 받아야함
        /// <summary>
        /// 아이템을 특정 노드 앞에 삽입
        /// </summary>
        /// <param name="node"> 기준 노드 </param>
        /// <param name="value"> 삽입하려는 값 </param>
        public void AddBefore(MyLinkedListNode<T> node, T value) 
        {
            MyLinkedListNode<T> current = new MyLinkedListNode<T>(value);
            MyLinkedListNode<T> prev = node.Prev;

            // 기준 노드 앞에 다른 노드가 있으면
            // 새 노드 앞에 기준 노드의 앞 노드를 설정한다
            if (node.Prev != null)
            {
                prev.Next = current; // 기준 노드의 앞 노드의 다음 노드는 이제 새로 추가한 노드가 된다
                current.Prev = prev; // 새 노드의 앞 노드는 기준 노드의 앞 노드로 설정한다.
            }
            // First 앞에 삽입한 경우
            else
            {
                _first = current; // 새 노드가 이제 가장 앞
            }

            prev = current; // 기준 노드의 이전 노드를 새 노드로
            current.Next = node; // 새 노드의 다음 노드를 기준 노드로
            _count++;
        }

        public void AddFirst(T value)
        {
            MyLinkedListNode<T> current = new MyLinkedListNode<T>(value);

            // 젤 앞 노드가 존재하는지
            if (_first != null)
            {
                _first.Prev = current;
                current.Next = _first;
            }
            // 이 노드가 최초의 노드라면 last도 갱신해야 함
            else
            {
                _last = current;
            }

            _first = current; // 이제 새 노드가 제일 앞
            _count++;
        }

        /// <summary>
        /// 특정 노드 뒤에 삽입
        /// </summary>
        /// <param name="node"> 기준 노드 </param>
        /// <param name="value"> 삽입할 값 </param>
        public void AddAfter(MyLinkedListNode<T> node, T value)
        {
            MyLinkedListNode<T> current = new MyLinkedListNode<T> (value);

            if (node.Next != null)
            {
                node.Next.Prev = current;
                current.Next = node.Next;
            }
            // 기준 노드가 last인 경우
            else
            {
                _last = current;
            }

            node.Next = current;
            current.Prev = node;
            _count++;
        }

        /// <summary>
        /// 가장 마지막 노드에 삽입
        /// </summary>
        /// <param name="value"> 삽입할 값 </param>
        public void AddLast(T value)
        {
            MyLinkedListNode<T> current = new MyLinkedListNode<T>(value);

            if (_last != null)
            {
                _last.Next = current;
                current.Prev = _last;
            }
            // 한 번도 노드가 생기지 않았을 경우. 
            else
            {
                _first = current;
            }

            _last = current;
            _count++;
        }

        /// <summary>
        /// First부터 끝까지 순회하면서 노드를 찾음
        /// </summary>
        /// <param name="match"> 찾으려는 노드의 값 조건 </param>
        /// <returns> 찾은 노드, 못 찾으면 null </returns>
        public MyLinkedListNode<T> Find(Predicate<T> match)
        {
            // 첫번째 노드부터 시작
            MyLinkedListNode<T> current = _first;

            // 다음 노드가 없을 때까지 계속 다음 노드로 넘어가면서 반복
            while (current != null)
            {
                // 찾으려는 조건 확인
                if (match.Invoke(current.Value))
                    return current;

                current = current.Next;
            }

            return null;
        }

        /// <summary>
        /// Last부터 처음까지 순회하면서 노드를 찾음
        /// </summary>
        /// <param name="match"> 찾으려는 노드의 값 조건 </param>
        /// <returns> 찾은 노드, 못 찾으면 null </returns>
        public MyLinkedListNode<T> FindLast(Predicate<T> match)
        {
            // 마지막 노드부터 시작
            MyLinkedListNode<T> current = _last;

            // 다음 노드가 없을 때까지 계속 다음 노드로 넘어가면서 반복
            while (current != null)
            {
                // 찾으려는 조건 확인
                if (match.Invoke(current.Value)) 
                    return current;

                current = current.Prev;
            }

            return null;
        }

        /// <summary>
        /// 이 노드를 현재 연결 리스트에서 삭제
        /// </summary>
        /// <param name="node"> 삭제하려는 노드 참조 </param>
        public void Remove(MyLinkedListNode<T> node)
        {
            // 1. 지우려는 게 null 이 아닌지 확인
            // 2. 이전 노드가 null 이 아닌지 확인
            //                null 이 아니라면 node 의 prev 의 next 가 node 의 next
            // 3. 이전 노드가 null 이면 first 를 지우는 것이므로 first 를 node 의 next 로.
            // 4. 다음 노드가 null 이 아닌지 확인
            //                null 이 아니라면 node 의 next 의 prev 가 node 의 prev 로.
            // 5. 다음 노드가 null 이면 last 를 지우는 것이므로 last 가 node 의 prev
            // 6. node 삭제 완료하였으므로 size 감소

            if (node == null)
                throw new ArgumentException("지우려는 node 참조가 null 입니다.");

            if (node.Prev != null)
                node.Prev.Next = node.Next;
            else
                _first = node.Next;

            if (node.Next != null)
                node.Next.Prev = node.Prev;
            else
                _last = node.Prev;

            _count--;
        }

        public bool Remove(T value)
        {
            MyLinkedListNode<T> node = Find(x => x.Equals(value));

            if (node != null)
            {
                Remove(node);
                return true;
            }
            
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public struct Enumerator : IEnumerator<T>
        {
            public Enumerator(MyLinkedList<T> list)
            {
                _list = list;
                _next = _list._first;
            }

            public T Current => _current;

            object IEnumerator.Current => Current;

            MyLinkedList<T> _list;
            MyLinkedListNode<T> _next;
            T _current;


            public bool MoveNext()
            {
                if (_next != null)
                {
                    _current = _next.Value;
                    _next = _next.Next;
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                _next = _list._first;
                _current = default;
            }

            public void Dispose()
            {
            }
        }
    }
}

public class Test
{
    public void A()
    {
        Action action;

        action = () => Console.WriteLine("B"); // 인라인 함수
        // 인라인 함수는 이름으로 검색해서 찾는 것이 아니라, 함수 자체가 안에 들어있는 것.
        // 가독성이 좋고, 함수 오버헤드가 없음 (함수 오버헤드 : 함수 호출 시 드는 비용)

        action = B; // 일반 함수

        action.Invoke();
    }

    public void B()
    {
        Console.WriteLine("B");
    }
}