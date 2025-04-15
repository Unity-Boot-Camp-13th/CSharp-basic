// Trie 작성 스펙

// 1. Root 있어야 함
// 2. 문자열을 추가하는 함수
// 문자열 추가시, 알파벳 하나씩 누적시킨 트리를 자식으로 계속 추가하여
// 단어 전체를 가지는 리프노드를 만들 때까지 지식 계속 추가

// 3. 탐색 함수
// 1) 특정 단어를 찾아서 존재 여부를 반환하는 함수
// 2) 인자로 받은 문자열로 시작하는 모든 단어 (Leaf) 목록을 반환하는 함수

// 4. 삭제 기능
// 1) 특정 단어 삭제 기능
// 2) 전체 삭제 기능

// * 입력 제한
// 입력은 알파벳만 가능하다 (a ~ z, A ~ Z)
// ( 대문자를 소문자로 바꾸는 함수는 string.ToLower() )
// 자동완성은 소문자로만 저장한다.

// * 힌트
// 문자열을 순회하려면
// for 루프로 index 접근하든지 / foreach 문으로 열거하든지

namespace CollectionsSample
{
    class TrieNode
    {
        public TrieNode this[char alphabet]
        {
            get
            {
                return _children[alphabet - 'a'];
            }
            set
            {
                if (value == null)
                {
                    _count--;
                }
                else
                {
                    _count++;
                }

                _children[alphabet - 'a'] = value;
            }
        }

        public bool HasChild => _count == 0;

        const int ALPHABET_TOTAL = 26;

        public bool IsWord;
        private int _count;
        TrieNode[] _children = new TrieNode[ALPHABET_TOTAL];
    }

    class Trie
    {
        const int ALPHABET_TOTAL = 26;
        TrieNode _root = new TrieNode();

        public void Add(string word)
        {
            TrieNode current = _root;

            // 들어온 단어 전체 순회
            foreach (char alphabet in word)
            {
                char c = char.ToLower(alphabet); // 소문자로

                // 현재까지의 Prefix 가 저장된 적 있는지 확인. 저장된 적 없으면 새 노드 생성
                if (current[c] == null)
                {
                    current[c] = new TrieNode();
                }

                current = current[c]; // 다음 자식으로 이동
            }
        }
    }
}
