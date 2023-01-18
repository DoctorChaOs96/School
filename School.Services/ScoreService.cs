using School.DataAccess;
using School.Entities;
using School.Services.Console;

namespace School.Services
{
    public class ScoreService
    {
        private readonly IRepository<ScoreEntity> _scoreRepository;
        private readonly IRepository<SubjectEntity> _subjectRepository;
        private readonly IConsole _console;

        private readonly List<SchoolEntity> _schools;

        private SchoolEntity _school;
        private StudentEntity _student;

        public ScoreService(SchoolRepository schoolRepository,
            IRepository<ScoreEntity> scoreRepository,
            IRepository<SubjectEntity> subjectRepository,
            IConsole console)
        {
            _scoreRepository = scoreRepository;
            _subjectRepository = subjectRepository;
            _schools = schoolRepository.GetAllWithStudents().ToList();
            _console = console;
        }

        public void AddScore()
        {
            ChooseSchool();
            _console.Clear();

            ChooseStudent();
            _console.Clear();

            var subject = ChooseSubject();
            _console.Clear();

            _console.WriteLine("Enter score:");

            var scoreEnity = new ScoreEntity
            {
                StudentId = _student.Id,
                SubjectId = subject.Id,
                Value = int.Parse(_console.ReadLine())
            };

            if(scoreEnity.Value <= 0 || scoreEnity.Value > 12)
            {
                throw new Exception("Wrong score value!");
            }

            _scoreRepository.Insert(scoreEnity);
            _console.Clear();

            PrintScores(_student);
        }

        public void PrintScores(StudentEntity student)
        {
            var scores = _scoreRepository.GetAll().Where(score => score.StudentId == student.Id).ToList();

            _console.WriteLine($"{student.FirstName} {student.LastName} scores:");

            scores.GroupBy(score => score.SubjectId).ToList().ForEach(group => PrintGroup(group.ToArray()));
        }

        private SubjectEntity ChooseSubject()
        {
            _console.WriteLine("Choose subject id:");

            foreach (var subject in _subjectRepository.GetAll())
            {
                _console.WriteLine($"Id: {subject.Id}, Name: {subject.Name}");
            }

            return _subjectRepository.Get(int.Parse(_console.ReadLine()));
        }

        private void ChooseSchool()
        {
            _console.WriteLine("Choose school id:");

            foreach (var school in _schools)
            {
                _console.WriteLine($"Id: {school.Id}, Number: {school.Number}");
            }

            _school = _schools.First(s => s.Id == int.Parse(_console.ReadLine()));
        }


        private void ChooseStudent()
        {
            _console.WriteLine("Choose schoolStudent id:");

            foreach (var schoolStudent in _school.Students)
            {
                _console.WriteLine($"StudentId: {schoolStudent.Id}, Full Name: {schoolStudent.FirstName} {schoolStudent.LastName}");
            }

            _student = _school.Students.First(s => s.Id == int.Parse(_console.ReadLine()));

            _console.Clear();
        }

        private void PrintGroup(ScoreEntity[] scores)
        {
            if (!scores.Any()) return;

            _console.WriteLine($"{_subjectRepository.Get(scores[0].SubjectId).Name}: {string.Join(", ", scores.OrderBy(scr => scr.CreatedDate).Select(scr => scr.Value))}");
        }
    }
}
