
namespace School.DataAccess
{
    internal interface IRepository<TEntity>
    {
        IList<TEntity> GetAll();

        TEntity Get(int id);

        void Delete(int id);

        void Insert(TEntity entity);

        void Update(TEntity entity);
    }
}
