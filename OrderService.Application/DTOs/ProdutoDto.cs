namespace OrderService.Application.DTOs;

public class ProdutoDto
{
    public string Nome { get; set; } = string.Empty;
    public decimal PrecoUnitario { get; set; }
    public int Quantidade { get; set; }
}
