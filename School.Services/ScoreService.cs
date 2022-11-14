using School.DataAccess;
using School.Entities;

namespace School.Services
{
    public class ScoreService
    {
        public int SchoolId => _school.Id;
        public int StudentId => _student.Id;

        private readonly Repository<StudentEntity> _students;
        private readonly Repository<ScoreEntity> _scores;
        private readonly Repository<SchoolEntity> _schools;

        private SchoolEntity _school;
        private StudentEntity _student;

        public ScoreService()
        {
            _students = new Repository<StudentEntity>();
            _scores = new Repository<ScoreEntity>();
            _schools = new Repository<SchoolEntity>();
        }

        public void ChooseSchool(int schoolId)
        {
            _school = _schools.Get(schoolId);
        }


        public void ChooseStudent(int studentId)
        {
            var student = _students.Get(studentId);

            if (student.SchoolId != _school.Id)
            {
                throw new Exception("Student from external school was choosen!");
            
            }

            _student = student;
        }

        public void AddScore(int score)
        {
            var scoreEnity = new ScoreEntity
            {
                StudentId = _student.Id,
                Value = score
            };

            if(score <= 0 || score > 12)
            {
                throw new Exception("Wrong score value!");
            }

            _scores.Insert(scoreEnity);
        }
    }
}
