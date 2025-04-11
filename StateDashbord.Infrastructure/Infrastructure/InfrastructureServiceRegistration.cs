using Microsoft.Extensions.DependencyInjection;
using StateDashbord.Application.IRepository;
using StateDashbord.Application.IService;
using StateDashbord.Application.Service;
using StateDashbord.Infrastructure.Persistence;
using StateDashbord.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Infrastructure.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
           services.AddTransient<IFriDetailsRepo, FriDetailsRepo>();
           services.AddTransient<IFetchFriDetails, FetchFriDetails>();
           services.AddTransient<IFriDetailsService, FriDetailsService>();
           services.AddTransient<IUserMasterRepo, UserMasterRepo>();
           services.AddTransient<IJwtTokenGenerator, JwtTokenGenerator>();
           services.AddTransient<IUserService, UserService>();
           services.AddTransient<IDashboardRepo, DashboardRepo>();
           services.AddTransient<IDashboardService, DashboardService>();
           services.AddSingleton<DapperContext>();
           services.AddHttpClient<IFetchFriDetails, FetchFriDetails>();
           services.AddScoped(typeof(IGenericServices<>), typeof(GenericServices<>));

            return services;
        }
    }
}
