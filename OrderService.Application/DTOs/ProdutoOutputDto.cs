namespace OrderService.Application.DTOs;

public class ProdutoOutputDto
{
    public string Nome { get; set; } = string.Empty;
    public decimal PrecoUnitario { get; set; }
    public int Quantidade { get; set; }
    public decimal Subtotal { get; set; }
}