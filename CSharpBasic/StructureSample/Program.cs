using System.Xml;

namespace StructureSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector3 velocity = new Vector3(3, 5, 2) ;
            velocity.SetX(velocity.GetX() + 1f);
            velocity.X += 1;

            // Vector3 forward = new Vector3(0, 0, 1) ; // 앞으로 가게 만들 때
            // Vector3 forward = Vector3.Forward;

            Console.WriteLine($"Magnitude : {velocity.Magnitude}");

            Vector3 target1Position = new Vector3(5f, 2f, 3.2f);
            Vector3 target2Position = new Vector3(-5f, 3.4f, 1.2f);

            if (target1Position == target2Position)
            {
                Console.WriteLine("target1과 target2가 동일한 위치에 있음");
            }

            Console.WriteLine($"{Vector3.Distance(target1Position, target2Position)}");

            // -------------------------------
            Console.Clear();
            Console.WriteLine("PreSet Color : White, Black, Blue, Red, Green");

        }

         Color SelectColor()
        {
            string color1 = Console.ReadLine();
            string color2 = Console.ReadLine();

            switch (color1)
            {
                case "white":
                    color1 = Color.White;
                    break;
            }
            
        }


    }
}
