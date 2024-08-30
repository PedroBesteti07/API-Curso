using Reservei_API.Repositories.Entities;
using Reservei_API.Repositories.Interfaces;
using Reservei_API.Services.Entities;
using Reservei_API.Services.Interfaces;
using System.Runtime.CompilerServices;

namespace Reservei_API.Services.Server
{
    public static class DependenciesInjection
    {
        public static void AddUserDependencies(this IServiceCollection services)
        {
            //Dependencia : Usuário
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
