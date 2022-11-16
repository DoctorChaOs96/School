using School.DataAccess.Contract;

namespace School.Entities
{
    public class ScoreEntity : BaseEntity, IEntity
    {
        public int Value { get; set; }

        public int StudentId { get; set; }

        public int SubjectId { get; set; }
    }
}
