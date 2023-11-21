
using GiceleBollmannAPI.Data.Configs;
using GiceleBollmannAPI.Database.Configs;
using GiceleBollmannAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GiceleBollmannAPI.Database.Contexto
{
    public class GBcontexto : DbContext
    {
        public DbSet<Usuario> USUARIOS { get; set; }
        public DbSet<Produto> PRODUTOS { get; set; }
        public DbSet<Pontuacao> PONTUACAO { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-SJ1Q4M7\\SQLEXPRESS;Initial catalog=GICELEBOLLMANNAPI;Trusted_connection=true;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new ProdutoConfig());
            modelBuilder.ApplyConfiguration(new PontuacaoConfig());
        }
    }
}