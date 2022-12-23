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

            var students = new Repository<StudentEntity>();
            var scores = new Repository<ScoreEntity>();
            var schools = new Repository<SchoolEntity>();
            var subjects = new Repository<SubjectEntity>();
            var console = new ConsoleWrapper();

            var service = new ScoreService(students, scores, schools, subjects, console);

            service.AddScore();

            Console.ReadKey();
        }
    }
}