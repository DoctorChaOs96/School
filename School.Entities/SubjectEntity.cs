using School.Entities.Contract;
using System.ComponentModel.DataAnnotations;

namespace School.Entities
{
    public class SubjectEntity: BaseEntity, IEntity
    {
        [MaxLength(64)]
        public string Name { get; set; }

        public ICollection<ScoreEntity> Scores { get; set; }
    }
}
