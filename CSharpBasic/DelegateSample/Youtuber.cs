namespace DelegateSample
{
    class Youtuber
    {
        public Youtuber(string nickname)
        {
            Nickname = nickname;
        }

        public string Nickname { get; set; }

        public delegate void OnContentUploadedHandler(Youtuber youtuber, Content content); // 대리자 정의 (사용자정의자료형)

        // event 한정자
        // 현재 타입 외에는 이 대리자에 접근할 때 +=, -=의 L-Value 로만 사용가능하도록 제한하는 한정자. 즉, 대입연산 안 됨
        public event OnContentUploadedHandler OnContentUploaded; // 대리자 타입 변수
        // {
        //     add
        //     {
        //         Console.WriteLine("구독자 + 1");
        //         _onContentUploaded += value;
        //     }
        //     remove
        //     {
        //         Console.WriteLine("구독자 - 1");
        //         _onContentUploaded -= value;
        //     }
        // }
        // private OnContentUploadedHandler _onContentUploaded;


        private Content[] _contents = new Content[100]; // 컨텐츠 올릴 수 있는 양이 100개
        private int _count;

        public void UploadContent(Content content)
        {
            if (_count >= _contents.Length)
                throw new Exception("컨텐츠 업로드 허용량을 초과하였습니다.");

            _contents[_count++] = content;
            OnContentUploaded(this, content); // 대리자에 구독된 모든 함수 호출 (구독한 순서대로)
        }

        public void Subscribe(OnContentUploadedHandler onContentUploaded)
        {
            OnContentUploaded += onContentUploaded;// 체이닝
        }
    }
}
