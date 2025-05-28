using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderService.Domain.Entities;

namespace OrderService.Infrastructure.Configurations;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(p => p.PrecoUnitario)
               .HasColumnType("decimal(18,2)");

        builder.Property(p => p.Quantidade)
               .IsRequired();

        builder.HasOne(p => p.Pedido)
               .WithMany(p => p.Produtos)
               .HasForeignKey(p => p.PedidoId);
    }
}