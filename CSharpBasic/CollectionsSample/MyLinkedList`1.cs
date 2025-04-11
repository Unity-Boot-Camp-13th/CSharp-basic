using System.Collections;

namespace CollectionsSample
{
    /// <summary>
    /// 연결리스트의 자료 저장 단위
    /// </summary>
    class Node<T>
    {
        public Node(T value)
        {
            Value = value;
        }

        public T Value;
        public Node<T> Prev; // 이전 노드 참조
        public Node<T> Next; // 다음 노드 참조
    }

    /// <summary>
    /// 양방향 연결리스트
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class MyLinkedList<T> : IEnumerable<T>
    {
        public Node<T> First => _first;
        public Node<T> Last => _last;

        public int Count => _count;

        private Node<T> _first;
        private Node<T> _last;
        private int _count;

        // 특정 노드 앞에 추가하려고 함. 따라서 특정 노드 앞이 뭔지는 모르기에 참조 받아야함
        /// <summary>
        /// 아이템을 특정 노드 앞에 삽입
        /// </summary>
        /// <param name="node"> 기준 노드 </param>
        /// <param name="value"> 삽입하려는 값 </param>
        public void AddBefore(Node<T> node, T value) 
        {
            Node<T> current = new Node<T>(value);
            Node<T> prev = node.Prev;

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
            Node<T> current = new Node<T>(value);

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
        public void AddAfter(Node<T> node, T value)
        {
            Node<T> current = new Node<T> (value);

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
            Node<T> current = new Node<T>(value);

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
        public Node<T> Find(Predicate<T> match)
        {
            Node<T> find = new Predicate<in T>(match);
        }

        /// <summary>
        /// Last부터 처음까지 순회하면서 노드를 찾음
        /// </summary>
        /// <param name="match"> 찾으려는 노드의 값 조건 </param>
        /// <returns> 찾은 노드, 못 찾으면 null </returns>
        public Node<T> FindLast(Predicate<T> match)
        {

        }

        /// <summary>
        /// 이 노드를 현재 연결 리스트에서 삭제
        /// </summary>
        /// <param name="node"> 삭제하려는 노드 참조 </param>
        public void Remove(Node<T> node)
        {
            
        }

        public bool Remove(T value)
        {
            Node<T> node = Find(x => x.Equals(value));

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
            Node<T> _next;
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
