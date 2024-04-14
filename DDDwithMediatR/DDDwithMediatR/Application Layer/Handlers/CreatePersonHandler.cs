using DDDwithMediatR.Application_Layer.Commands;
using DDDwithMediatR.Application_Layer.Contracts;
using DDDwithMediatR.Application_Layer.Dto;
using DDDwithMediatR.Application_Layer.Queries;
using MediatR;

namespace DDDwithMediatR.Application_Layer.Handlers
{
    public class CreatePersonHandler : IRequestHandler<CreatePersonCommand, PersonDto>
    {
        private readonly IPersonService _personService;
        public CreatePersonHandler(IPersonService personService)
        {
            _personService = personService;
        }

        public async Task<PersonDto> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            return _personService.CreatePerson(request);
        }
    }
}
