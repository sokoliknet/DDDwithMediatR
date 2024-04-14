using DDDwithMediatR.Application_Layer.Commands;
using DDDwithMediatR.Application_Layer.Dto;

namespace DDDwithMediatR.Application_Layer.Contracts
{
    public interface IPersonService
    {
        IEnumerable<PersonDto> GetPersons();
        PersonDto GetPersonByName(string firstName);
        PersonDto CreatePerson(CreatePersonCommand command);
    }
}
