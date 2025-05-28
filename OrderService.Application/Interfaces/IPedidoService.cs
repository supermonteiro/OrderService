using OrderService.Application.DTOs;

namespace OrderService.Application.Interfaces;

public interface IPedidoService
{
    Task<bool> CriarPedidoAsync(PedidoInputDto dto);
    Task<List<PedidoOutputDto>> ObterTodosAsync();
    Task<PedidoOutputDto?> ObterPorIdAsync(Guid id);
}

