namespace OrderService.Application.DTOs;

public class PedidoOutputDto
{
    public Guid Id { get; set; }
    public string CodigoExterno { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; }
    public string Status { get; set; } = string.Empty;
    public decimal ValorTotal { get; set; }

    public List<ProdutoOutputDto> Produtos { get; set; } = new();
}