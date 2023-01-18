using School.Entities.Contract;
using System.ComponentModel.DataAnnotations;

namespace School.Entities
{
    public class StudentEntity: BaseEntity, IEntity
    {
        [MaxLength(128)]
        public string FirstName { get; set; }

        [MaxLength(128)]
        public string LastName { get; set; }

        public int SchoolId { get; set; }

        public SchoolEntity School { get; set; }

        public ICollection<ScoreEntity> Scores { get; set; }
    }
}
