using Store.Data.Context;
using Store.Data.Entity;
using Store.Repository.InterFace;
using Store.Repository.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _Context;
        private Hashtable _repositories;
        public UnitOfWork(StoreDbContext storeDbContext)
        {
            _Context= storeDbContext;
        }

        public async Task<int> CompeletedAsync()
        => await _Context.SaveChangesAsync();
        public IGenaricReposiatory<TEntity, TKey> Reposiatory<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            if(_repositories is null)
            {
                _repositories = new Hashtable();
            }
            var EntityKey= typeof(TEntity).Name;   ///"Product"

            if (!_repositories.ContainsKey(EntityKey))
            {
                var repository = typeof(GenericRepository<,>);
                var RepositoryInstance = Activator.CreateInstance(repository.MakeGenericType(typeof(TEntity),typeof(TKey)),_Context);

                _repositories.Add(EntityKey, RepositoryInstance);
            }
            return (IGenaricReposiatory<TEntity, TKey>)_repositories[EntityKey];
        }
    }
}
