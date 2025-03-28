namespace DelegateSample
{
    internal class Program
    {
        public delegate int OperationHandler(int a, int b);

        static void Main(string[] args)
        {
            Youtuber youtuber1 = new Youtuber("NG");
            // 인라인 함수 : 현재 라인에 함수구현 그대로 삽입 -> 이름이 필요 없음
            // C# 에서는 인라인함수를 구현할 때 람다식(익명함수)로 구현함
            youtuber1.Subscribe((youtuber, content) => Console.WriteLine($"--- System : {youtuber.Nickname} 이 {content.Title} 업로드함 ---"));
            youtuber1.OnContentUploaded += (youtuber, content) => Console.WriteLine($"--- System : {youtuber.Nickname} 이 {content.Title} 업로드함 ---");
            // 람다식으로 구독한 것은 밑 처럼 구독취소 불가. 이름으로 검색해야하는데 이름이 없기 때문

            Subscriber subscriber1 = new Subscriber("Luke");
            Subscriber subscriber2 = new Subscriber("Carl");
            Subscriber subscriber3 = new Subscriber("Cherry");

            youtuber1.OnContentUploaded += subscriber1.Notification; // 알림 함수 구독
            youtuber1.OnContentUploaded += subscriber2.Notification; 
            youtuber1.OnContentUploaded += subscriber3.Notification;
            
            Content content1 = new Content("에드형과 야생에서 살아남기!!");
            youtuber1.UploadContent(content1);

            youtuber1.OnContentUploaded -= subscriber1.Notification;

            Content content2 = new Content("한시즌 1억 버는 꽃게잡이 신참 브이로그");
            youtuber1.UploadContent(content2);

            OperationHandler operationHandler = delegate (int a, int b)
                                                {
                                                    return a + b;
                                                };
        }      

        // 람다식 표현방법 :
        // 컴파일러가 판단할 수 있는 (즉, 굳이 명시하지 않아도 기정사실화되어 있는 요소)를 다 지우고 '=>' 기호를 파라미터와 구현부 사이에 추가
        // 인라인 함수는, 해당 라인에 직접 삽입하므로, 함수를 이름으로 검색할 필요가 없어서 이름 필요없다.
        // 현재 라인에 삽입하기 때문에 static인지 instance인지는 의미가 없다.
        // 만약 대리자에 구독을 하는 경우 이미 파라미터 타입과 반환타입이 정해져 있기 때문에 파라미터 타입과 반환 타입을 명시할 필요 없다
        // 함수 구현부 코드가 한 줄이라면 반드시 그 라인이 return 문이기 때문에 함수의 구현부를 {}(중괄호)로 구분할 필요가 없다.
        static void SomethingUploaded(Youtuber youtuber,  Content content)
        {
            Console.WriteLine($"--- System : {youtuber.Nickname} 이 {content.Title} 업로드함 ---");
        }
    }
}
