using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderService.Domain.Entities;

namespace OrderService.Infrastructure.Configurations;

public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.CodigoExterno)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(p => p.DataCriacao)
               .IsRequired();

        builder.Property(p => p.Status)
               .IsRequired();
    }
}