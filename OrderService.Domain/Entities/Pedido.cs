using OrderService.Domain.Enums;

namespace OrderService.Domain.Entities;

public class Pedido
{
    public Guid Id { get; set; }
    public string CodigoExterno { get; set; } = string.Empty; // Ex: código vindo do sistema A
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

    public PedidoStatus Status { get; set; } = PedidoStatus.Recebido;

    public ICollection<Produto> Produtos { get; set; } = new List<Produto>();

    public decimal ValorTotal => Produtos.Sum(p => p.Subtotal);
}