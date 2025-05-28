using System.ComponentModel.DataAnnotations;

namespace OrderService.Application.DTOs;

public class ProdutoDto
{
    [Required]
    public string Nome { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue)]
    public decimal PrecoUnitario { get; set; }

    [Range(1, int.MaxValue)]
    public int Quantidade { get; set; }
}
