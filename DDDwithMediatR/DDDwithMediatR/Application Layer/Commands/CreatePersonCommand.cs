using DDDwithMediatR.Application_Layer.Dto;
using MediatR;

namespace DDDwithMediatR.Application_Layer.Commands
{
    public class CreatePersonCommand : IRequest<PersonDto>
    {
        public string PersonType { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
