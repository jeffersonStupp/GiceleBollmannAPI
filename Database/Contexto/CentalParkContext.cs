using ApiCentralPark.Database.Configs;
using ApiCentralPark.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCentralPark.Database.Contexto
{
    public class CentalParkContext : DbContext
    {
        public DbSet<Pessoa> PessoasDatabase { get; set; }
        public DbSet<Usuario> UsuariosDatabase { get; set; }
        public DbSet<Veiculo> VeiculosDatabase { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-SJ1Q4M7\\SQLEXPRESS;Initial catalog=CENTRALPARKBASE;Trusted_connection=true;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new VeiculosConfig());
        }
    }
}