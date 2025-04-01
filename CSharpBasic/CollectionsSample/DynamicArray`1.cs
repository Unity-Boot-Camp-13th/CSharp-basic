using System.Collections;

namespace CollectionsSample
{
    class DynamicArray<T> : IEnumerable<T>
    {
        public DynamicArray(int capacity)
        {
            _data = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                if (index >= _count || index < 0)
                    throw new IndexOutOfRangeException();

                return _data[index];
            }
            set
            {
                if (index >= _count || index < 0)
                    throw new IndexOutOfRangeException();

                _data[index] = value;
            }
        }

        public int Count => _count;

        public int Capacity
        {
            get => _data.Length;
            set
            {
                if (_count > value)
                    throw new ArgumentException("현재 아이템 수 보다 작은 용량으로 설정할수 없습니다.");

                T[] temp = new T[value];

                for (int i = 0; i < _count; i++)
                {
                    temp[i] = _data[i];
                }

                _data = temp;
            }
        }

        private T[] _data;
        private int _count;


        public void Add(T item)
        {
            // 용량이 부족할때
            if (_count == _data.Length)
            {
                T[] temp = new T[_count * 2]; // 크기 2배짜리 배열 생성

                // 기존 데이터 복사
                for (int i = 0; i < _count; i++)
                {
                    temp[i] = _data[i];
                }

                _data = temp;
            }

            _data[_count++] = item;
        }

        /// <summary>
        /// index 의 아이템 삭제를 위해 이후 아이템들을 모두 한칸씩 앞으로 당김
        /// </summary>
        /// <param name="index"> 삭제하려는 아이템 위치 </param>
        /// <exception cref="IndexOutOfRangeException"> 인덱스 범위 초과 </exception>
        public void RemoveAt(int index)
        {
            if (index >= _count || index < 0)
                throw new IndexOutOfRangeException();

            for (int i = index; i < _count - 1; i++)
            {
                _data[i] = _data[i + 1];
            }

            _count--;
        }


        public int FindIndex(Predicate<T> match)
        {
            for (int i = 0; i < _count; i++)
            {
                if (match(_data[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public int FindLastIndex(Predicate<T> match)
        {
            for (int i = _count - 1; i >= 0; i--)
            {
                if (match(_data[i]))
                {
                    return i;
                }
            }

            return -1;
        }


        // remove랑 removelast는 삭제 알고리즘이 아닌 탐색 알고리즘임
        // 탐색해서 삭제를 찾는 것임

        public bool Remove(Predicate<T> match)
        {
            int index = FindIndex(match);

            if (index < 0)
                return false;

            RemoveAt(index);
            return true;
        }

        public bool RemoveLast(Predicate<T> match)
        {
            int index = FindLastIndex(match);

            if (index < 0)
                return false;

            RemoveAt(index);
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        struct Enumerator : IEnumerator<T>
        {
            public Enumerator(DynamicArray<T> list)
            {
                _list = list;
                _index = 0;
                _current = default(T); // 타입이 명시되어 있을 때는 타입을 적어주는 것이 좋음
            }

            public T Current => _current;

            object IEnumerator.Current => Current;

            DynamicArray<T> _list;
            int _index;
            T _current;
            

            public bool MoveNext()
            {
                if (_index < _list.Count)
                {
                    _current = _list[_index];
                    _index++;
                    return true;
                }

                _current = default(T);
                return false;
            }

            public void Reset()
            {
                _index = 0;
                _current = default;
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }
    }
}
