using Microsoft.EntityFrameworkCore;
using School.Entities;

namespace School.DataAccess
{
    public class SchoolRepository : Repository<SchoolEntity>
    {
        public SchoolRepository(SchoolDbContext schoolDbContext) : base(schoolDbContext)
        {
        }
        public IQueryable<SchoolEntity> GetAllWithStudents()
        {
            return Table.Include(x => x.Students);
        }
    }
}
