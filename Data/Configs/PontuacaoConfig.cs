using GiceleBollmannAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GiceleBollmannAPI.Data.Configs
{
    public class PontuacaoConfig:IEntityTypeConfiguration<Pontuacao>
    {
        public void Configure(EntityTypeBuilder<Pontuacao> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.Pontuacao)
                .HasForeignKey(x => x.Usuario);
            builder.HasOne(x => x.Produto)
                .WithMany(x => x.Pontuacao)
                .HasForeignKey(x => x.Produto); 
        }
    }
}
