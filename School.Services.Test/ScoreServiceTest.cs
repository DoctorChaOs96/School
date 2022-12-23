using Moq;
using School.DataAccess;
using School.Entities;
using School.Services.Console;
using static System.Formats.Asn1.AsnWriter;

namespace School.Services.Test
{
    public class ScoreServiceTest
    {
        [Fact]
        public void PrintScoresTest_WriteCorrectStudentData()
        {
            var studetsMock = new Mock<IRepository<StudentEntity>>();
            var scoresMock = new Mock<IRepository<ScoreEntity>>();
            var schoolsMock = new Mock<IRepository<SchoolEntity>>();
            var subjectsMock = new Mock<IRepository<SubjectEntity>>();
            var consoleMock = new Mock<IConsole>();
            string catchedString = null;
            int counter = 1;

            subjectsMock.Setup(subjects => subjects.Get(It.Is((int id) => id == 1))).Returns(new SubjectEntity
            {
                Id = 1,
                Name = "TestSubject 1"
            });
            subjectsMock.Setup(subjects => subjects.Get(It.Is((int id) => id == 2))).Returns(new SubjectEntity
            {
                Id = 2,
                Name = "TestSubject 2"
            });

            scoresMock
                .Setup(scores => scores.GetAll())
                .Returns(new List<ScoreEntity>()
                {
                    new ScoreEntity() { Id = 1, StudentId = 1, SubjectId = 1, Value = 12, CreatedDate = new DateTime(2022, 12, 23)},
                    new ScoreEntity() { Id = 2, StudentId = 1, SubjectId = 2, Value = 10, CreatedDate = new DateTime(2022, 12, 23)},
                    new ScoreEntity() { Id = 3, StudentId = 1, SubjectId = 2, Value = 11, CreatedDate = new DateTime(2022, 12, 23)}
                });

            consoleMock
                .Setup(console => console.WriteLine(It.IsAny<string>()))
                .Callback((string inputStr) =>
                {
                    if(counter == 1) 
                        catchedString = inputStr;

                    counter++;
                });

            var scoreService = new ScoreService(studetsMock.Object, 
                scoresMock.Object, 
                schoolsMock.Object, 
                subjectsMock.Object, 
                consoleMock.Object);



            const string studentFirstName = "FirstName";
            const string studentLastName = "LastName";
            var expectedString = $"{studentFirstName} {studentLastName} scores:";

            scoreService.PrintScores(new StudentEntity { 
                Id = 1, 
                FirstName = studentFirstName, 
                LastName = studentLastName 
            });

            Assert.Equal(expectedString, catchedString);
        }


        [Fact]
        public void PrintScoresTest_WriteCorrectGroupedScores()
        {
            var studetsMock = new Mock<IRepository<StudentEntity>>();
            var scoresMock = new Mock<IRepository<ScoreEntity>>();
            var schoolsMock = new Mock<IRepository<SchoolEntity>>();
            var subjectsMock = new Mock<IRepository<SubjectEntity>>();
            var consoleMock = new Mock<IConsole>();
            string catchedString = null;
            int counter = 1;

            subjectsMock.Setup(subjects => subjects.Get(It.Is((int id) => id == 1))).Returns(new SubjectEntity
            {
                Id = 1,
                Name = "TestSubject 1"
            });
            subjectsMock.Setup(subjects => subjects.Get(It.Is((int id) => id == 2))).Returns(new SubjectEntity
            {
                Id = 2,
                Name = "TestSubject 2"
            });

            scoresMock
                .Setup(scores => scores.GetAll())
                .Returns(new List<ScoreEntity>()
                {
                    new ScoreEntity() { Id = 1, StudentId = 1, SubjectId = 1, Value = 12, CreatedDate = new DateTime(2022, 12, 23)},
                    new ScoreEntity() { Id = 4, StudentId = 1, SubjectId = 1, Value = 10, CreatedDate = new DateTime(2022, 12, 23)},
                    new ScoreEntity() { Id = 2, StudentId = 1, SubjectId = 2, Value = 10, CreatedDate = new DateTime(2022, 12, 23)},
                    new ScoreEntity() { Id = 3, StudentId = 1, SubjectId = 2, Value = 11, CreatedDate = new DateTime(2022, 12, 23)}
                });

            consoleMock
                .Setup(console => console.WriteLine(It.IsAny<string>()))
                .Callback((string inputStr) =>
                {
                    if (counter == 2)
                        catchedString = inputStr;

                    counter++;
                });

            var scoreService = new ScoreService(studetsMock.Object,
                scoresMock.Object,
                schoolsMock.Object,
                subjectsMock.Object,
                consoleMock.Object);

            const string studentFirstName = "FirstName";
            const string studentLastName = "LastName";
            var expectedString = $"TestSubject 1: 12, 10";

            scoreService.PrintScores(new StudentEntity
            {
                Id = 1,
                FirstName = studentFirstName,
                LastName = studentLastName
            });

            Assert.Equal(expectedString, catchedString);
        }
    }
}