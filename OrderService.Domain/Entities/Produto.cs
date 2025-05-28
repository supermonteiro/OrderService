namespace OrderService.Domain.Entities;

public class Produto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal PrecoUnitario { get; set; }
    public int Quantidade { get; set; }

    public decimal Subtotal => PrecoUnitario * Quantidade;

    // FK para Pedido
    public Guid PedidoId { get; set; }
    public Pedido Pedido { get; set; } = null!;
}