using ApiCentralPark.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiCentralPark.Database.Configs
{
    public class PessoaConfig : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("PESSOAS");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(200);
            builder.Property(x => x.DataNascimento).IsRequired();
            builder.Property(x => x.Cpf).IsRequired().HasMaxLength(14);
            builder.Property(x => x.Rg).HasMaxLength(12);
            builder.Property(x => x.Email).HasMaxLength(200);
            builder.Property(x => x.Telefone).IsRequired();
            builder.Property(x => x.Rua).IsRequired();
            builder.Property(x => x.Numero).HasMaxLength(10);
            builder.Property(x => x.Bairro).IsRequired();
            builder.Property(x => x.Cidade).IsRequired();
            builder.Property(x => x.Estado).IsRequired();

        }
    }
}