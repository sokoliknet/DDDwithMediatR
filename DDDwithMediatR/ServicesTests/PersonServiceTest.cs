using AutoMapper;
using DDDwithMediatR.Application_Layer.Dto;
using DDDwithMediatR.Application_Layer.Mapping;
using DDDwithMediatR.Domain_Layer;
using DDDwithMediatR.Domain_Layer.Models;
using DDDwithMediatR.Domain_Layer.Repository.Contracts;
using DDDwithMediatR.Services;
using Moq;

namespace ServicesTests
{
    public class PersonServiceTest
    {
        private readonly PersonService _personService;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public MapperConfiguration _mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new PersonMapping());
        });

        public PersonServiceTest()
        {
            var mapper = _mapper.CreateMapper();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _personService = new PersonService(_mockUnitOfWork.Object, mapper);
        }

        [Fact]
        public void Get_Person_by_Name()
        {
            //Arrange
            var personList = new List<Person>()
                    {  new Person { BusinessEntityID = 3,
                                    PersonType = "EM",
                                    NameStyle = true,
                                    Title = "Mr.",
                                    FirstName = "Ken",
                                    MiddleName = "Lee",
                                    LastName = "Duffy",
                                    EmailPromotion = 0,
                                    rowguid = Guid.NewGuid(),
                                    ModifiedDate = DateTime.Now
                                  }
                    };

            _mockUnitOfWork.Setup(p => p.PersonRepository.Find(x => x.FirstName.Contains("Ken"))).Returns(personList);

            //Act
            var result = _personService.GetPersonByName("Ken");

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<PersonDto>>(result);
            var list = Assert.IsAssignableFrom<List<PersonDto>>(result);
            var value = list[0];
            Assert.NotEmpty(result);
            Assert.Collection(list, item => Assert.True(true)); //this lambda verifies the first item
            Assert.Equal(1, (int)list.Count());
            Assert.Equal(3, value.BusinessEntityID);
        }

        [Fact]
        public void Create_Person()
        {
            //Arrange
            var personDto = new PersonDto
            {
                PersonType = "EM",
                NameStyle = true,
                Title = "Mr.",
                FirstName = "Ken",
                MiddleName = "Lee",
                LastName = "Duffy",
                EmailPromotion = 0,
            };

            _mockUnitOfWork.Setup(p => p.BusinessEntityRepository.Add(It.IsAny<BusinessEntity>()));
            _mockUnitOfWork.Setup(p => p.PersonRepository.Add(It.IsAny<Person>()));

            //Act
            var result = _personService.CreatePerson(personDto);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<PersonDto>(result);
            Assert.Equal(result.LastName, personDto.LastName);
        }
    }
}