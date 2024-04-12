using AutoMapper;
using DDDwithMediatR.Application_Layer.Contracts;
using DDDwithMediatR.Application_Layer.Dto;
using DDDwithMediatR.Domain_Layer.Models;
using DDDwithMediatR.Domain_Layer.Repository.Contracts;
using DDDwithMediatR.Domain_Layer;

namespace DDDwithMediatR.Services
{
    public class PersonService : IPersonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<PersonDto> GetPersonByName(string name)
        {
            var result = _unitOfWork.PersonRepository.Find(x => x.FirstName.Contains(name)).ToList();
            return _mapper.Map<List<PersonDto>>(result);
        }

        public PersonDto CreatePerson(PersonDto personDto)
        {
            var businessEntity = new BusinessEntity();
            businessEntity.rowguid = Guid.NewGuid();
            businessEntity.ModifiedDate = DateTime.UtcNow;
            _unitOfWork.BusinessEntityRepository.Add(businessEntity);
            _unitOfWork.Commit();

            personDto.rowguid = Guid.NewGuid();
            personDto.ModifiedDate = DateTime.UtcNow;

            Person person = _mapper.Map<Person>(personDto);
            person.BusinessEntityID = businessEntity.BusinessEntityID;
            _unitOfWork.PersonRepository.Add(person);
            _unitOfWork.Commit();

            return _mapper.Map<PersonDto>(person);
        }
    }
}
