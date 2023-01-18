using School.Entities.Contract;

namespace School.Entities
{
    public class ScoreEntity : BaseEntity, IEntity
    {
        public int Value { get; set; }

        public int StudentId { get; set; }

        public StudentEntity Student { get; set; }

        public int SubjectId { get; set; }

        public SubjectEntity Subject { get; set; }
    }
}
