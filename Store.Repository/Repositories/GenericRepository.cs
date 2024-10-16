using Microsoft.EntityFrameworkCore;
using Store.Data.Context;
using Store.Data.Entity;
using Store.Repository.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenaricReposiatory<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly StoreDbContext _storeDbContext;
        public GenericRepository(StoreDbContext storeDbContext)
        {
            _storeDbContext= storeDbContext;
        }

        public async Task AddAsync(TEntity entity)
        => await _storeDbContext.Set<TEntity>().AddAsync(entity);

        public void DeleteAsync(TEntity entity)
        => _storeDbContext.Set<TEntity>().Remove(entity);

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        =>await _storeDbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        public async Task<TEntity> GetByIDAsync(TKey? id)
        =>await _storeDbContext.Set<TEntity>().FindAsync(id);

        public void UpdateAsync(TEntity entity)
        => _storeDbContext.Set<TEntity>().Update(entity);   
    }
}
