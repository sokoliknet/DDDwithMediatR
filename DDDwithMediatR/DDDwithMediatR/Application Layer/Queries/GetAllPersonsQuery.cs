using DDDwithMediatR.Application_Layer.Dto;
using MediatR;

namespace DDDwithMediatR.Application_Layer.Queries
{
    public class GetAllPersonsQuery : IRequest<IEnumerable<PersonDto>>
    {
    }
}
