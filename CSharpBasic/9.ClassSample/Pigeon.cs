namespace _9.ClassSample
{
    // 구조체는 값을 어느정도 포기하였음

    class Pigeon : Bird
    {
        public Pigeon(string name) : base(name)
        {
        }

        public override int AverageLifespan => 15;

        private string _feature = "평화의 상징";
        public override void Fly()
        {
            Console.WriteLine($"{_name}(비둘기), 날다");
        }

        public override void Walk()
        {
            Console.WriteLine($"{_name}(비둘기), 걷다");
        }

        public override void PrintName()
        {
            base.PrintName();
            Console.WriteLine("구구구...");
        }
    }
}
