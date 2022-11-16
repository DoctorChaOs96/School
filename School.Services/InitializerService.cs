using RandomNameGeneratorLibrary;
using School.DataAccess;
using School.Entities;

namespace School.Services
{
    public class InitializerService
    {
        private readonly Repository<StudentEntity> _students;
        private readonly Repository<ScoreEntity> _scores;
        private readonly Repository<SchoolEntity> _schools;
        private readonly Repository<SubjectEntity> _subjects;

        public InitializerService()
        {
            _students = new Repository<StudentEntity>();
            _scores = new Repository<ScoreEntity>();
            _schools = new Repository<SchoolEntity>();
            _subjects = new Repository<SubjectEntity>();
        }

        public void Initialize()
        {
            if (_subjects.GetAll().Any()) return;

            CreateSubjects();
            CreateSchools();
            CreateStudents();
        }

        private void CreateSubjects()
        {
            var subjects = new List<SubjectEntity>
            {
                new SubjectEntity { Name = "Math" },
                new SubjectEntity { Name = "Chemistry" },
                new SubjectEntity { Name = "Biology" },
                new SubjectEntity { Name = "Physics" },
                new SubjectEntity { Name = "Programming" },
                new SubjectEntity { Name = "History" }
            };

            subjects.ForEach(_subjects.Insert);
        }

        private void CreateSchools()
        {
            var subjects = new List<SchoolEntity>
            {
                new SchoolEntity { Number = 1 },
                new SchoolEntity { Number = 2 },
                new SchoolEntity { Number = 3 },
                new SchoolEntity { Number = 4 },
                new SchoolEntity { Number = 5 },
                new SchoolEntity { Number = 6 }
            };

            subjects.ForEach(_schools.Insert);
        }

        private void CreateStudents()
        {
            var placeGenerator = new PersonNameGenerator();

            foreach (var school in _schools.GetAll())
                for (var i = 0; i < 20; i++)
                {
                    var newEntity = new StudentEntity
                    {
                        FirstName = placeGenerator.GenerateRandomFirstName(),
                        LastName = placeGenerator.GenerateRandomLastName(),
                        SchoolId = school.Id
                    };

                    _students.Insert(newEntity);
                }
        }
    }
}
