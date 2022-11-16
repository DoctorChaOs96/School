using School.DataAccess.Contract;

namespace School.Entities
{
    public class SubjectEntity: BaseEntity, IEntity
    {
        public string Name { get; set; }
    }
}
