using System.Linq.Expressions;
using app.DataAccess.Contracts;
using app.DataAccess.DBContexts;

namespace app.DataAccess.Repositories
{
    public class GenericRepository<T>(ApplicationContext context, IConfiguration configuration) : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationContext Context = context;
        protected readonly IConfiguration Configuration = configuration;

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().Where(expression);
        }
        public List<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }
        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }
        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}