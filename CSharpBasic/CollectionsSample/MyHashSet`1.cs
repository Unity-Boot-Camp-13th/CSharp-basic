namespace CollectionsSample
{
    class MyHashSet<T>
    {
        const int DEFAULT_SIZE = 5;
        // T[] _data = new T[DEFAULT_SIZE];
        LinkedList<T>[] _data = new LinkedList<T>[DEFAULT_SIZE];

        public bool Add(T item)
        {
            int hashCode = Hash(item);

            // 한번도 이 인덱스에 값이 들어온 적 없다면 체이닝용 자료구조 하나 새로 만듦
            if (_data[hashCode] == null)
            {
                _data[hashCode] = new LinkedList<T>();
                _data[hashCode].AddFirst(item);
                return true;
            }
            // 링크드리스트는 있는데 아이템이 없다면 아이템이 있었다가 지워진 것임
            else if (_data[hashCode].First == null)
            {
                _data[hashCode].AddFirst(item);
                return true;
            }
            // 해시 충돌
            else
            {
                LinkedListNode<T> searchedNode = _data[hashCode].Find(item);

                // 중복값 허용 X
                if (searchedNode != null)
                {
                    return false;
                }
                else
                {
                    _data[hashCode].AddLast(item);
                    return true;
                }
            }
        }

        public bool Contains(T item)
        {
            // 아이템 탐색시 해시코드 뽑고
            // 그걸로 인덱스 계산한 다음
            // 인덱스 접근한 위치에서
            // 처음 노드부터 끝까지 다 탐색해서 원하는 아이템 있는지  보고
            // 있으면 true 없으면 false

            int hashCode = Hash(item);


            // 한 번도 아이템이 들어간 적 없음
            if (_data[hashCode] == null)
            {
                return false;
            }
            else
            {
                LinkedListNode<T> searchedNode = _data[hashCode].Find(item);
                return searchedNode != null;
            }
        }

        public bool Remove(T item)
        {
            int hashCode = Hash(item);

            if (_data[hashCode] == null)
                return false;

            return _data[hashCode].Remove(item);
        }

        /// <summary>
        /// 문자열로 변환 후 각 문자의 ASCII값을 더한 후 크기로 나머지하는 간단한 해시함수
        /// </summary>
        int Hash(T value)
        {
            string str = value.ToString();
            int sum = 0;

            for (int i = 0; i < str.Length; i++)
            {
                sum += str[i]; // int는 4바이트 char은 2바이트
            }

            sum %= DEFAULT_SIZE;
            return sum;
        }
    }
}
