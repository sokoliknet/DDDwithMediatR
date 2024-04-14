using DDDwithMediatR.Application_Layer.Contracts;
using DDDwithMediatR.Application_Layer.Dto;
using DDDwithMediatR.Application_Layer.Queries;
using MediatR;

namespace DDDwithMediatR.Application_Layer.Handlers
{
    public class GetPersonByNameHandler : IRequestHandler<GetPersonByNameQuery, PersonDto>
    {
        private readonly IPersonService _personService;
        public GetPersonByNameHandler(IPersonService personService) {
            _personService = personService;
        }

        public async Task<PersonDto> Handle(GetPersonByNameQuery request, CancellationToken cancellationToken)
        {
           return _personService.GetPersonByName(request.firstName);
        }
    }
}
