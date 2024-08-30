using Microsoft.EntityFrameworkCore;

namespace Reservei_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //Configuração do banco de dados
            services.AddDbContext<AppDbContext>(options => 
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection");
        }

    }
    
}
