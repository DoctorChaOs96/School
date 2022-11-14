using School.DataAccess;
using School.Entities;
using School.Services;

namespace SchoolConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var service = new ScoreService();

            Console.WriteLine("Choose school id:");

            foreach(var school in new Repository<SchoolEntity>().GetAll())
            {
                Console.WriteLine($"Id: {school.Id}, Number: {school.Number}");
            }

            service.ChooseSchool(int.Parse(Console.ReadLine()));

            Console.Clear();

            Console.WriteLine("Choose student id:");

            foreach (var student in new Repository<StudentEntity>().GetAll().Where(stdnt => stdnt.SchoolId == service.SchoolId))
            {
                Console.WriteLine($"StudentId: {student.Id}, Full Name: {student.FirstName} {student.LastName}");
            }

            service.ChooseStudent(int.Parse(Console.ReadLine()));


            Console.Clear();

            Console.WriteLine("Enter score:");
            service.AddScore(int.Parse(Console.ReadLine()));
        }
    }
}