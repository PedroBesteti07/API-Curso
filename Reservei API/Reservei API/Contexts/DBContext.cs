using Microsoft.EntityFrameworkCore;
using Reservei_API.Objects.Models.Entities;
using Reservei_API.Contexts.Builders;

namespace Reservei_API.Contexts
{
    public class AppDBContext : DbContext 
    {
        //Mapeamento relacional dos objetos no Banco de Dados
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        //Conjunto : Usuário
        public DbSet<UserModel> Users { get; set; }

        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Entidades de Usuário
            UserBuilder.Build(modelBuilder);
        }

    }
}
