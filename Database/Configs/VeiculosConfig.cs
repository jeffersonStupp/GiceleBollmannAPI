using ApiCentralPark.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiCentralPark.Database.Configs
{
    public class VeiculosConfig : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("VEICULOS");
            builder.HasKey(x => x.Placa);
            builder.Property(x => x.Placa).HasMaxLength(8);
            builder.Property(x => x.HoraEntrada).IsRequired();
            

        }
    }
}