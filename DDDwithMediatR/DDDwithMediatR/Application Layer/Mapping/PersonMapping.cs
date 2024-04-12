using AutoMapper;
using DDDwithMediatR.Application_Layer.Dto;
using DDDwithMediatR.Domain_Layer;
using System.Net;

namespace DDDwithMediatR.Application_Layer.Mapping
{
    public class PersonMapping : Profile
    {
        public PersonMapping()
        {
            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>();
        }
    }
}
