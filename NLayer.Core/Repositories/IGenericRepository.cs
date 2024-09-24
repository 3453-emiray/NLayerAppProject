using System.Linq.Expressions;

namespace NLayer.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        // productRepository.where(x=>x.id>5).OrderBy.TolistAsync();
        //bir metod asenkronsa sonuna mutlaka Async eklen
        IQueryable<T> GetAll();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);  // T,bool =>  Id>5 o zaman true dön gibi  
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

    }
}
