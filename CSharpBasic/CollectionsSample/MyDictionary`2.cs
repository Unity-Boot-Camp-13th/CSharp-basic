namespace CollectionsSample
{
    /// <summary>
    /// C# 의 Hashtable 클래스 - object 타입 key / value 쌍을 저장하기 위해 구현한 클래스 (object 타입으로 관리하는 HashMap)
    /// - 충돌해결 : 오픈 어드레싱 (충돌 시 일정 규칙을 따라 다음 인덱스 탐색)
    /// 
    /// C# 의 Dictionary`2 클래스 - 제네릭한 HashMap / HashTable 자료구조 를 구현한 클래스
    /// - 충돌해결 : 체이닝 (충돌 시 연결된다음 인덱스 탐색)
    /// 
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    class MyDictionary<TKey, TValue>
    {
        public MyDictionary(int capacity)
        {
            _buckets = new int[capacity];

            for (int i = 0; i < _buckets.Length; i++)
            {
                _buckets[i] = EMPTY;
            }

            _entries = new Entry[capacity];

            for (int i = 0; i < _entries.Length; i++)
            {
                _entries[i].HashCode = EMPTY;
            }
        }

        struct Entry
        {
            public bool IsValid => HashCode >= 0;

            public int HashCode;
            public TKey Key;
            public TValue Value;
            public int NextIndex;
        }

        public TValue this[TKey key]
        {
            get
            {
                int hashCode = key.GetHashCode();
                int bucketIndex = hashCode % _buckets.Length;

                // buckets 에서 첫 진입점 인덱스부터 탐색
                // 유효한 entry 가 있으면 계속 탐색 반복
                // 순회할 때마다 충돌이 있다면 현재 Entry 의 Next 로 이동
                // * 이 for 루프 때문에 Hashtable 의 시간 복잡도 최악은 O(N) 이 된다. (평균 O(1))
                for (int entryIndex = _buckets[bucketIndex]; entryIndex >= 0; entryIndex = _entries[entryIndex].NextIndex)
                {
                    // HashCode 가 동일하다면 내가 찾는 Key 일 확률이 엄청 높으나 어쨌든 이론적으로 충돌날 수도 있기 때문에
                    // HashCode 비교 이후에 Key끼리도 비교를 한다.
                    // 바로 Key 끼리 비교를 하는 것은 HashCode 끼리 비교하는 것보다 비용이 높을 가능성이 높기 때문에
                    // 일단 HashCode 끼리 먼저 비교하고 같을 때만 확실하게 Key 비교를 한다.
                    if (_entries[entryIndex].HashCode == hashCode &&
                        _entries[entryIndex].Key.Equals(key))

                    {
                        return _entries[entryIndex].Value;
                    }
                }

                throw new KeyNotFoundException();
            }
            set
            {
                int hashCode = key.GetHashCode();
                int bucketIndex = hashCode % _buckets.Length;

                for (int entryIndex = _buckets[bucketIndex]; entryIndex >= 0; entryIndex = _entries[entryIndex].NextIndex)
                {
                    if (_entries[entryIndex].HashCode == hashCode &&
                        _entries[entryIndex].Key.Equals(key))
                    {
                        throw new ArgumentException($"{key} 는 이미 등록되어 있음");
                    }
                }

                int availableEntryIndex = EMPTY;

                // 구멍 난 Entry 가 있다면 거기부터 채워 넣음
                if (_freeCount > 0)
                {
                    availableEntryIndex = _freeFirstEntryIndex;
                    _freeFirstEntryIndex = _entries[_freeFirstEntryIndex].NextIndex;
                    _freeCount--;
                }
                else
                {
                    availableEntryIndex = _count++;
                }


                _entries[availableEntryIndex] = new Entry()
                {
                    HashCode = hashCode,
                    Key = key,
                    Value = value,
                    NextIndex = _buckets[bucketIndex]
                };

                _buckets[bucketIndex] = availableEntryIndex;
            }
        }

        const int EMPTY = -1;

        int[] _buckets; // Entry 를 가리키기 위한 인덱스를 담고 있는 배열
        Entry[] _entries; // 실제 Key-Value 쌍을 저장하며 다음 Key-Value 쌍을 체이닝할 수 있는 진입점 배열
        int _count;
        int _freeFirstEntryIndex; // 구멍이 난 Entry 배열 중 첫 번째 Entry 의 인덱스
        int _freeCount; // 구멍 난 Entry 개수

        public bool Remove(TKey key)
        {
            int hashCode = key.GetHashCode();
            int bucketIndex = hashCode % _buckets.Length;
            int prevEntryIndex = EMPTY;

            for (int entryIndex = _buckets[bucketIndex]; entryIndex >= 0; entryIndex = _entries[entryIndex].NextIndex)
            {
                if (_entries[entryIndex].HashCode == hashCode &&
                    _entries[entryIndex].Key.Equals(key))
                {
                    // 가리키는 이전 진입점이 있으면 연결을 갱신
                    if (prevEntryIndex == EMPTY)
                    {
                        _buckets[bucketIndex] = _entries[entryIndex].NextIndex;
                    }
                    else
                    {
                        _entries[prevEntryIndex].NextIndex = _entries[entryIndex].NextIndex;
                    }

                    _entries[entryIndex].HashCode = EMPTY;
                    _entries[entryIndex].Key = default;
                    _entries[entryIndex].Value = default;
                    _entries[entryIndex].NextIndex = _freeFirstEntryIndex;
                    _freeCount++;

                    return true;
                }

                prevEntryIndex = entryIndex;
            }

            return false;
        }
    }
}
