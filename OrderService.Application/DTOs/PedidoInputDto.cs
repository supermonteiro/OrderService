namespace OrderService.Application.DTOs;

public class PedidoInputDto
{
    public string CodigoExterno { get; set; } = string.Empty;
    public List<ProdutoDto> Produtos { get; set; } = new();
}