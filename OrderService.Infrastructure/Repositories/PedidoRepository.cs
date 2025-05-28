using Microsoft.EntityFrameworkCore;
using OrderService.Domain.Entities;
using OrderService.Domain.Interfaces;
using OrderService.Infrastructure.Persistence;

namespace OrderService.Infrastructure.Repositories;

public class PedidoRepository : IPedidoRepository
{
    private readonly OrderDbContext _context;

    public PedidoRepository(OrderDbContext context)
    {
        _context = context;
    }

    public async Task<Pedido?> ObterPorCodigoExternoAsync(string codigoExterno)
    {
        return await _context.Pedidos
            .Include(p => p.Produtos)
            .FirstOrDefaultAsync(p => p.CodigoExterno == codigoExterno);
    }

    public async Task<Pedido?> ObterPorIdAsync(Guid id)
    {
        return await _context.Pedidos
            .Include(p => p.Produtos)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Pedido>> ObterTodosAsync()
    {
        return await _context.Pedidos
            .Include(p => p.Produtos)
            .ToListAsync();
    }

    public async Task AdicionarAsync(Pedido pedido)
    {
        await _context.Pedidos.AddAsync(pedido);
    }

    public async Task<bool> ExisteComCodigoExternoAsync(string codigoExterno)
    {
        return await _context.Pedidos.AnyAsync(p => p.CodigoExterno == codigoExterno);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
