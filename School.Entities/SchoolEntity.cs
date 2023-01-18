using School.Entities.Contract;

namespace School.Entities
{
    public class SchoolEntity : BaseEntity
    {
        public int Number { get; set; }

        public ICollection<StudentEntity> Students { get; set; }
    }
}
