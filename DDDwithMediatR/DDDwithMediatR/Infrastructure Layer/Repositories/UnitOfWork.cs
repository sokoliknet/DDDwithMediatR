using DDDwithMediatR.DataContext;
using DDDwithMediatR.Domain_Layer.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DDDwithMediatR.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AdventureWorksDataContext _dbContext;
        public UnitOfWork(AdventureWorksDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Repositories
        public IBusinessEntityRepository BusinessEntityRepository => new BusinessEntityRepository(_dbContext);
        public IPersonRepository PersonRepository => new PersonRepository(_dbContext);
        #endregion

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        public void RejectChanges()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries()
                  .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }
}
