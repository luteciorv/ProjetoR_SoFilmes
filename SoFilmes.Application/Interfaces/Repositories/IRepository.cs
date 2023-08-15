namespace SoFilmes.Application.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IReadOnlyCollection<TEntity>> GetAllAsync(int skip = 0, int take = 25);
        IQueryable<TEntity> GetAll();
        Task<TEntity?> GetByIdAsync(Guid id);

        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
