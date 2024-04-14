using AutoMapper;
using DDDwithMediatR.Application_Layer.Contracts;
using DDDwithMediatR.Application_Layer.Dto;
using DDDwithMediatR.Domain_Layer.Models;
using DDDwithMediatR.Domain_Layer.Repository.Contracts;
using DDDwithMediatR.Domain_Layer;
using DDDwithMediatR.Application_Layer.Commands;

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

        public IEnumerable<PersonDto> GetPersons()
        {
            var result = _unitOfWork.PersonRepository.GetAll().ToList();
            return _mapper.Map<List<PersonDto>>(result);
        }

        public PersonDto GetPersonByName(string name)
        {
            var result = _unitOfWork.PersonRepository.Find(x => x.FirstName.Contains(name)).FirstOrDefault();
            return _mapper.Map<PersonDto>(result);
        }

        public PersonDto CreatePerson(CreatePersonCommand command)
        {
            var businessEntity = new BusinessEntity();
            businessEntity.rowguid = Guid.NewGuid();
            businessEntity.ModifiedDate = DateTime.UtcNow;
            _unitOfWork.BusinessEntityRepository.Add(businessEntity);
            _unitOfWork.Commit();

            Person person = _mapper.Map<Person>(command);

            person.rowguid = Guid.NewGuid();
            person.ModifiedDate = DateTime.UtcNow;
            person.BusinessEntityID = businessEntity.BusinessEntityID;
            _unitOfWork.PersonRepository.Add(person);
            _unitOfWork.Commit();

            return _mapper.Map<PersonDto>(person);
        }
    }
}
