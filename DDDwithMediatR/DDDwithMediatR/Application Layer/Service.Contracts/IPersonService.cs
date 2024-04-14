using DDDwithMediatR.Application_Layer.Dto;

namespace DDDwithMediatR.Application_Layer.Contracts
{
    public interface IPersonService
    {
        IEnumerable<PersonDto> GetPersonByName(string name);
        PersonDto CreatePerson(PersonDto personDto);
    }
}
