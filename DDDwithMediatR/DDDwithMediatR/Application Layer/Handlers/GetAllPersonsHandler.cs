using DDDwithMediatR.Application_Layer.Contracts;
using DDDwithMediatR.Application_Layer.Dto;
using DDDwithMediatR.Application_Layer.Queries;
using MediatR;

namespace DDDwithMediatR.Application_Layer.Handlers
{
    public class GetAllPersonsHandler : IRequestHandler<GetAllPersonsQuery, IEnumerable<PersonDto>>
    {
        private readonly IPersonService _personService;
        public GetAllPersonsHandler(IPersonService personService) {
            _personService = personService;
        }

        public async Task<IEnumerable<PersonDto>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            return  _personService.GetPersons();
        }
    }
}
