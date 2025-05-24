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
            services.AddTransient<IFestivalMasterRepo, FestivalMasterRepo>();
            services.AddTransient<IFestivalMasterService, FestivalMasterService>();
            services.AddTransient<ICeremonyMasterRepo, CeremonyMasterRepo>();
            services.AddTransient<ICeremonyMasterService, CeremonyMasterService>();
            services.AddTransient<IApplicationMasterRepo, ApplicationMasterRepo>();
            services.AddTransient<IApplicationMasterService, ApplicationMasterService>();
            services.AddTransient<IDistrictMasterRepo, DistrictMasterRepo>();
            services.AddTransient<IDistrictMasterService, DistrictMasterService>();
            services.AddTransient<IPolicestationMasterRepo, PolicestationMasterRepo>();
            services.AddTransient<IPolicestationMasterService, PolicestationMasterService>();
            services.AddTransient<IProgramMasterRepo, ProgramMasterRepo>();
            services.AddTransient<IProgramMasterService, ProgramMasterService>();
            services.AddSingleton<DapperContext>();
            services.AddHttpClient<IFetchFriDetails, FetchFriDetails>();
           services.AddScoped(typeof(IGenericServices<>), typeof(GenericServices<>));

            return services;
        }
    }
}
