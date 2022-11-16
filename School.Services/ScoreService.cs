using School.DataAccess;
using School.Entities;
using static System.Formats.Asn1.AsnWriter;

namespace School.Services
{
    public class ScoreService
    {
        private readonly Repository<StudentEntity> _students;
        private readonly Repository<ScoreEntity> _scores;
        private readonly Repository<SchoolEntity> _schools;
        private readonly Repository<SubjectEntity> _subjects;

        public ScoreService()
        {
            _students = new Repository<StudentEntity>();
            _scores = new Repository<ScoreEntity>();
            _schools = new Repository<SchoolEntity>();
            _subjects = new Repository<SubjectEntity>();
        }

        public void AddScore()
        {
            var school = ChooseSchool();
            Console.Clear();

            var student = ChooseStudent(school);
            Console.Clear();

            var subject = ChooseSubject();
            Console.Clear();

            Console.WriteLine("Enter score:");

            var scoreEnity = new ScoreEntity
            {
                StudentId = student.Id,
                SubjectId = subject.Id,
                Value = int.Parse(Console.ReadLine())
            };

            if(scoreEnity.Value <= 0 || scoreEnity.Value > 12)
            {
                throw new Exception("Wrong score value!");
            }

            _scores.Insert(scoreEnity);
            Console.Clear();

            PrintScores(student);
        }

        private SubjectEntity ChooseSubject()
        {
            Console.WriteLine("Choose subject id:");

            foreach (var subject in _subjects.GetAll())
            {
                Console.WriteLine($"Id: {subject.Id}, Name: {subject.Name}");
            }

            return _subjects.Get(int.Parse(Console.ReadLine()));
        }

        public void PrintScores(StudentEntity student)
        {
            var scores = _scores.GetAll().Where(score => score.StudentId == student.Id).ToList();

            Console.WriteLine($"{student.FirstName} {student.LastName} scores:");

            scores.GroupBy(score => score.SubjectId).ToList().ForEach(group => PrintGroup(group.ToArray()));
        }

        private SchoolEntity ChooseSchool()
        {
            Console.WriteLine("Choose school id:");

            foreach (var school in _schools.GetAll())
            {
                Console.WriteLine($"Id: {school.Id}, Number: {school.Number}");
            }

            return _schools.Get(int.Parse(Console.ReadLine()));
        }


        private StudentEntity ChooseStudent(SchoolEntity school)
        {
            Console.WriteLine("Choose schoolStudent id:");

            foreach (var schoolStudent in _students.GetAll().Where(stdnt => stdnt.SchoolId == school.Id))
            {
                Console.WriteLine($"StudentId: {schoolStudent.Id}, Full Name: {schoolStudent.FirstName} {schoolStudent.LastName}");
            }

            var student = _students.Get(int.Parse(Console.ReadLine()));

            if (student.SchoolId != school.Id)
            {
                throw new Exception("Student from external school was choosen!");
            }

            Console.Clear();

            return student;
        }

        private void PrintGroup(ScoreEntity[] scores)
        {
            if (!scores.Any()) return;

            Console.WriteLine($"{_subjects.Get(scores[0].SubjectId).Name}: {string.Join(",", scores.Select(scr => scr.Value))}");
        }
    }
}
