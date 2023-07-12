using ApiCentralPark.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiCentralPark.Database.Configs
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();

            // mapeando as propriedades
            builder.Property(x => x.NomeUsuario)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Senha)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Ativo)
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(x => x.Tipo)
                .HasDefaultValue("usuario")
                .HasMaxLength(30)
                .IsRequired();

            builder.HasData(new List<Usuario>()
        {
            //migrationBuilder.Sql("INSERT INTO Usuarios (NomeUsuario, Email, Senha) VALUES ('admin', 'admin@email.com', 'admin');");
            new Usuario() { Id = 1, NomeUsuario = "usuario", Email = "usuario@email.com", Senha = "usuario", Tipo = "usuario" },
            new Usuario() { Id = 2, NomeUsuario = "Jefferson", Email = "jeffersonstupp@hotmail.com", Senha = "0411vm", Tipo = "administrador" }
        });
        }
    }
}