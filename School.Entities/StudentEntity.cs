namespace School.Entities
{
    public class StudentEntity: BaseEntity, IEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int SchoolId { get; set; }
    }
}
