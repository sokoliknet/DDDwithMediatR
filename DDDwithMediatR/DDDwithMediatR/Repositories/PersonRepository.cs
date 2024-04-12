using DDDwithMediatR.DataContext;
using DDDwithMediatR.Domain_Layer.Repository.Contracts;
using DDDwithMediatR.Domain_Layer;

namespace DDDwithMediatR.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        private readonly AdventureWorksDataContext _context;
        public PersonRepository(AdventureWorksDataContext context) : base(context)
        {
            _context = context;
        }
    }
}
