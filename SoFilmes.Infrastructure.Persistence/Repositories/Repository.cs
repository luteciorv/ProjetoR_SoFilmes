using Microsoft.EntityFrameworkCore;
using SoFilmes.Application.Interfaces.Repositories;
using SoFilmes.Infrastructure.Persistence.Context;

namespace SoFilmes.Infrastructure.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DataContext _dataContext;

        public Repository(DataContext dataContext) =>
            _dataContext = dataContext;

        public async Task<IReadOnlyCollection<TEntity>> GetAllAsync(int skip = 0, int take = 25) =>
            await _dataContext.Set<TEntity>().Skip(skip).Take(take).AsNoTracking().ToListAsync();

        public IQueryable<TEntity> GetAll() =>
            _dataContext.Set<TEntity>().AsNoTracking();

        public async Task<TEntity?> GetByIdAsync(Guid id) =>
            await _dataContext.Set<TEntity>().FindAsync(id);


        public async Task AddAsync(TEntity entity) =>
            await _dataContext.Set<TEntity>().AddAsync(entity);

        public void Update(TEntity entity) =>
            _dataContext.Set<TEntity>().Update(entity);

        public void Delete(TEntity entity) =>
            _dataContext.Set<TEntity>().Remove(entity);
    }
}
