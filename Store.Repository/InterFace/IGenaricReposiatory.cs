using Store.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.InterFace
{
    public interface IGenaricReposiatory<TEntity , TKey> where TEntity : BaseEntity<TKey>
    { 
        Task<TEntity> GetByIDAsync(TKey? id);
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        void UpdateAsync(TEntity entity);
        void DeleteAsync(TEntity entity);
    }
}
