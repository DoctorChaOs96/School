using Microsoft.EntityFrameworkCore;
using School.Entities.Contract;

namespace School.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly SchoolDbContext _schoolDbContext;

        protected DbSet<T> Table => _schoolDbContext.Set<T>();

        public Repository(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }

        public void Delete(int id)
        {
            var entity = Table.First(entity => entity.Id == id);

            Table.Remove(entity);

            _schoolDbContext.SaveChanges();
        }

        public T? Get(int id)
        {
            var entity = Table.FirstOrDefault(entity => entity.Id == id);

            return entity;
        }

        public IQueryable<T> GetAll()
        {
            return Table;
        }

        public void Insert(T entity)
        {
            Table.Add(entity);

            _schoolDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            Table.Update(entity);

            _schoolDbContext.SaveChanges();
        }
    }
}
