using Microsoft.EntityFrameworkCore;
using OrderService.Domain.Entities;

namespace OrderService.Infrastructure.Persistence;

public class OrderDbContext : DbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
    {
    }

    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.CodigoExterno).IsRequired();
            entity.Property(p => p.DataCriacao).IsRequired();

            entity.HasMany(p => p.Produtos)
                  .WithOne(p => p.Pedido)
                  .HasForeignKey(p => p.PedidoId);
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Nome).IsRequired();
            entity.Property(p => p.PrecoUnitario).HasColumnType("decimal(18,2)");
            entity.Property(p => p.Quantidade).IsRequired();
        });
    }
}