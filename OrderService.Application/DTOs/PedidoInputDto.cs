using System.ComponentModel.DataAnnotations;

namespace OrderService.Application.DTOs;

public class PedidoInputDto
{
    [Required]
    public string CodigoExterno { get; set; } = string.Empty;

    [Required]
    [MinLength(1)]
    public List<ProdutoDto> Produtos { get; set; } = new();
}