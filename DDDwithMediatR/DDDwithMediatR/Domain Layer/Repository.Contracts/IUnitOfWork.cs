namespace DDDwithMediatR.Domain_Layer.Repository.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IBusinessEntityRepository BusinessEntityRepository { get; }
        IPersonRepository PersonRepository { get; }

        /// <summary>
        /// Commit all changes
        /// </summary>
        void Commit();
        /// <summary>
        /// Discards all changes that has not been commited
        /// </summary>
        void RejectChanges();
    }
}
