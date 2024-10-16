using Store.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.InterFace
{
    public interface IUnitOfWork
    {
        IGenaricReposiatory<TEntity, TKey> Reposiatory<TEntity,TKey>() where TEntity : BaseEntity<TKey>;
        Task<int> CompeletedAsync();
    }
}
