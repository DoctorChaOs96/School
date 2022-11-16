using School.DataAccess.Contract;

namespace School.Entities
{
    public class SchoolEntity : BaseEntity, IEntity
    {
        public int Number { get; set; }
    }
}
