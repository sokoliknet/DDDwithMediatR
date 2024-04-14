using DDDwithMediatR.Application_Layer.Contracts;
using DDDwithMediatR.Application_Layer.Mapping;
using DDDwithMediatR.Domain_Layer.Repository.Contracts;
using DDDwithMediatR.Repositories;
using DDDwithMediatR.Services;
using MediatR;
using System.Reflection;

namespace DDDwithMediatR.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServiceCollectionExtensions(this IServiceCollection services)
        {
            // AutoMapper
            services.AddAutoMapper(typeof(PersonMapping).GetTypeInfo().Assembly);

            // DI, here need to use the appropriate repository
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // DI, here need to use the appropriate Services
            services.AddTransient<IPersonService, PersonService>();

            // DI, Mediatr
            services.AddMediatR(typeof(Program));
        }
    }
}
