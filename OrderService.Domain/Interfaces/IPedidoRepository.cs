using OrderService.Domain.Entities;

namespace OrderService.Domain.Interfaces;

public interface IPedidoRepository
{
    Task<Pedido?> ObterPorCodigoExternoAsync(string codigoExterno);
    Task<Pedido?> ObterPorIdAsync(Guid id);
    Task<List<Pedido>> ObterTodosAsync();
    Task AdicionarAsync(Pedido pedido);
    Task<bool> ExisteComCodigoExternoAsync(string codigoExterno);
    Task SaveChangesAsync();
}