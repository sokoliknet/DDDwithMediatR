using DDDwithMediatR.Application_Layer.Dto;
using MediatR;

namespace DDDwithMediatR.Application_Layer.Queries
{
    public class GetPersonByNameQuery: IRequest<PersonDto>
    {
       public string firstName { get; }

        public GetPersonByNameQuery(string firstName)
        {
            this.firstName = firstName;
        }
    }
}
