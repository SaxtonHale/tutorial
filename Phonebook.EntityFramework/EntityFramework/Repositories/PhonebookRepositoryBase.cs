using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Phonebook.EntityFramework.Repositories
{
    public abstract class PhonebookRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<PhonebookDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected PhonebookRepositoryBase(IDbContextProvider<PhonebookDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class PhonebookRepositoryBase<TEntity> : PhonebookRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected PhonebookRepositoryBase(IDbContextProvider<PhonebookDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
