using GiceleBollmannAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GiceleBollmannAPI.Database.Configs
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIOS");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();

            // mapeando as propriedades
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(150);


            builder.Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(150);


            builder.Property(x => x.Telefone)
                .IsRequired()
                .HasMaxLength(15);

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
            new Usuario() { Id = 1, Nome = "usuario", Email = "usuario@email.com",UserName= "usuario",Telefone="(00)00000-0000", Senha = "usuario", Tipo = "usuario" },
            new Usuario() { Id = 2, Nome = "Jefferson Stupp", Email = "jeffersonstupp@hotmail.com",UserName= "stupp",Telefone="(47)98811-9538", Senha = "0411vm", Tipo = "administrador" }
        });
        }
    }
}