using DDDwithMediatR.DataContext;
using DDDwithMediatR.Domain_Layer.Models;
using DDDwithMediatR.Domain_Layer.Repository.Contracts;

namespace DDDwithMediatR.Repositories
{
    public class BusinessEntityRepository : GenericRepository<BusinessEntity>, IBusinessEntityRepository
    {
        private readonly AdventureWorksDataContext _context;
        public BusinessEntityRepository(AdventureWorksDataContext context) : base(context)
        {
            _context = context;
        }
    }
}
