namespace School.Entities
{
    public class ScoreEntity : IEntity
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public int StudentId { get; set; }

        public int SubjectId { get; set; }
    }
}
