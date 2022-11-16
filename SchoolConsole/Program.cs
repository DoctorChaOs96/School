using School.Services;

namespace SchoolConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var initializer = new InitializerService();

            initializer.Initialize();

            var service = new ScoreService();

            service.AddScore();

            Console.ReadKey();
        }
    }
}