using School.DataAccess;
using School.Entities;
using School.Services;
using School.Services.Console;

namespace SchoolConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var initializer = new InitializerService();

            initializer.Initialize();

            var dbContext = new SchoolDbContext();
            var scores = new Repository<ScoreEntity>(dbContext);
            var schools = new SchoolRepository(dbContext);
            var subjects = new Repository<SubjectEntity>(dbContext);

            var console = new ConsoleWrapper();

            var service = new ScoreService(schools, scores, subjects, console);

            service.AddScore();

            Console.ReadKey();
        }
    }
}