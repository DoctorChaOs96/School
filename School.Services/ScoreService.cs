using School.DataAccess;
using School.Entities;
using School.Services.Console;

namespace School.Services
{
    public class ScoreService
    {
        private readonly IRepository<StudentEntity> _students;
        private readonly IRepository<ScoreEntity> _scores;
        private readonly IRepository<SchoolEntity> _schools;
        private readonly IRepository<SubjectEntity> _subjects;
        private readonly IConsole _console;

        public ScoreService(IRepository<StudentEntity> students,
            IRepository<ScoreEntity> scores,
            IRepository<SchoolEntity> schools,
            IRepository<SubjectEntity> subjects,
            IConsole console)
        {
            _students = students;
            _scores = scores;
            _schools = schools;
            _subjects = subjects;
            _console = console;
        }

        public void AddScore()
        {
            var school = ChooseSchool();
            _console.Clear();

            var student = ChooseStudent(school);
            _console.Clear();

            var subject = ChooseSubject();
            _console.Clear();

            _console.WriteLine("Enter score:");

            var scoreEnity = new ScoreEntity
            {
                StudentId = student.Id,
                SubjectId = subject.Id,
                Value = int.Parse(_console.ReadLine())
            };

            if(scoreEnity.Value <= 0 || scoreEnity.Value > 12)
            {
                throw new Exception("Wrong score value!");
            }

            _scores.Insert(scoreEnity);
            _console.Clear();

            PrintScores(student);
        }

        public void PrintScores(StudentEntity student)
        {
            var scores = _scores.GetAll().Where(score => score.StudentId == student.Id).ToList();

            _console.WriteLine($"{student.FirstName} {student.LastName} scores:");

            scores.GroupBy(score => score.SubjectId).ToList().ForEach(group => PrintGroup(group.ToArray()));
        }

        private SubjectEntity ChooseSubject()
        {
            _console.WriteLine("Choose subject id:");

            foreach (var subject in _subjects.GetAll())
            {
                _console.WriteLine($"Id: {subject.Id}, Name: {subject.Name}");
            }

            return _subjects.Get(int.Parse(_console.ReadLine()));
        }

        private SchoolEntity ChooseSchool()
        {
            _console.WriteLine("Choose school id:");

            foreach (var school in _schools.GetAll())
            {
                _console.WriteLine($"Id: {school.Id}, Number: {school.Number}");
            }

            return _schools.Get(int.Parse(_console.ReadLine()));
        }


        private StudentEntity ChooseStudent(SchoolEntity school)
        {
            _console.WriteLine("Choose schoolStudent id:");

            foreach (var schoolStudent in _students.GetAll().Where(stdnt => stdnt.SchoolId == school.Id))
            {
                _console.WriteLine($"StudentId: {schoolStudent.Id}, Full Name: {schoolStudent.FirstName} {schoolStudent.LastName}");
            }

            var student = _students.Get(int.Parse(_console.ReadLine()));

            if (student.SchoolId != school.Id)
            {
                throw new Exception("Student from external school was choosen!");
            }

            _console.Clear();

            return student;
        }

        private void PrintGroup(ScoreEntity[] scores)
        {
            if (!scores.Any()) return;

            _console.WriteLine($"{_subjects.Get(scores[0].SubjectId).Name}: {string.Join(",", scores.Select(scr => scr.Value))}");
        }
    }
}
