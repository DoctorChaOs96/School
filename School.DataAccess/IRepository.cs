
namespace School.DataAccess
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();

        TEntity? Get(int id);

        void Delete(int id);

        void Insert(TEntity entity);

        void Update(TEntity entity);
    }
}
