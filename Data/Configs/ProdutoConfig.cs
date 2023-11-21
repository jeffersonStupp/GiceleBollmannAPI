using GiceleBollmannAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GiceleBollmannAPI.Database.Configs
{
    public class ProdutoConfig : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("PRODUTOS");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo).HasMaxLength(15).IsRequired();
            builder.Property(x => x.Descricao).IsRequired();
            builder.Property(x => x.Imagem).IsRequired();
            builder.Property(x => x.Preco).HasColumnType("money").IsRequired();
        }
    }
}