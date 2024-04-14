using AutoMapper;
using DDDwithMediatR.Application_Layer.Commands;
using DDDwithMediatR.Application_Layer.Dto;
using DDDwithMediatR.Application_Layer.Mapping;
using DDDwithMediatR.Domain_Layer;
using DDDwithMediatR.Domain_Layer.Models;
using DDDwithMediatR.Domain_Layer.Repository.Contracts;
using DDDwithMediatR.Services;
using Moq;
using System.Collections.Generic;

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
        public void Get_All_Persons()
        {
            //Arrange
            var personList = new List<Person>()
                              {  
                                new Person { 
                                    BusinessEntityID = 3,
                                    PersonType = "EM",
                                    Title = "Mr.",
                                    FirstName = "Ken",
                                    MiddleName = "Lee",
                                    LastName = "Duffy",
                                    rowguid = Guid.NewGuid(),
                                    ModifiedDate = DateTime.Now
                                  },
                                 new Person { 
                                    BusinessEntityID = 4,
                                    PersonType = "EM",
                                    Title = "Ms.",
                                    FirstName = "Sofia",
                                    MiddleName = "Gonzales",
                                    LastName = "Ortega",
                                    rowguid = Guid.NewGuid(),
                                    ModifiedDate = DateTime.Now
                                  }
                                };

            _mockUnitOfWork.Setup(p => p.PersonRepository.GetAll()).Returns(personList);

            //Act
            var result = _personService.GetPersons();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<PersonDto>>(result);
            var list = Assert.IsAssignableFrom<List<PersonDto>>(result);
            var value = list[0];
            Assert.NotEmpty(result);
            Assert.Equal(2, list.Count());
            Assert.Equal(3, value.BusinessEntityID);
        }

        [Fact]
        public void Get_Person_by_Name()
        {
            //Arrange
            var personList = new List<Person>()
                    {  new Person { BusinessEntityID = 3,
                                    PersonType = "EM",
                                    Title = "Mr.",
                                    FirstName = "Ken",
                                    MiddleName = "Lee",
                                    LastName = "Duffy",
                                    rowguid = Guid.NewGuid(),
                                    ModifiedDate = DateTime.Now
                                  }
                    };

            _mockUnitOfWork.Setup(p => p.PersonRepository.Find(x => x.FirstName.Contains("Ken"))).Returns(personList);

            //Act
            var result = _personService.GetPersonByName("Ken");

            //Assert
            Assert.NotNull(result);
            Assert.IsType<PersonDto>(result);
            Assert.Equal(3, result.BusinessEntityID);
            Assert.Equal("Mr.", result.Title);
        }

        [Fact]
        public void Create_Person()
        {
            //Arrange
            var person = new CreatePersonCommand
            {
                PersonType = "EM",
                Title = "Mr.",
                FirstName = "Ken",
                MiddleName = "Lee",
                LastName = "Duffy",
            };

            _mockUnitOfWork.Setup(p => p.BusinessEntityRepository.Add(It.IsAny<BusinessEntity>()));
            _mockUnitOfWork.Setup(p => p.PersonRepository.Add(It.IsAny<Person>()));

            //Act
            var result = _personService.CreatePerson(person);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<PersonDto>(result);
            Assert.Equal(result.LastName, person.LastName);
        }

    }
}