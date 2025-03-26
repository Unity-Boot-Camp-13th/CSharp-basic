namespace PracticeOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GamePlayManager gamePlayManager = new GamePlayManager();

            Console.WriteLine("Press any key to start the game ...");
            Console.ReadKey();
            Console.Clear();


            gamePlayManager.PlayGame();
        }
    }
}
