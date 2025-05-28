using OrderService.Application.DTOs;
using OrderService.Application.Interfaces;
using OrderService.Domain.Entities;
using OrderService.Domain.Enums;
using OrderService.Domain.Interfaces;

namespace OrderService.Application.Services;

public class PedidoService : IPedidoService
{
    private readonly IPedidoRepository _pedidoRepository;

    public PedidoService(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    public async Task<bool> CriarPedidoAsync(PedidoInputDto dto)
    {
        // Verifica duplicação
        if (await _pedidoRepository.ExisteComCodigoExternoAsync(dto.CodigoExterno))
            return false;

        // Cria entidade Pedido com produtos
        var pedido = new Pedido
        {
            Id = Guid.NewGuid(),
            CodigoExterno = dto.CodigoExterno,
            Status = PedidoStatus.Recebido,
            Produtos = dto.Produtos.Select(p => new Produto
            {
                Id = Guid.NewGuid(),
                Nome = p.Nome,
                PrecoUnitario = p.PrecoUnitario,
                Quantidade = p.Quantidade
            }).ToList()
        };

        await _pedidoRepository.AdicionarAsync(pedido);
        await _pedidoRepository.SaveChangesAsync();

        return true;
    }

    public async Task<List<PedidoOutputDto>> ObterTodosAsync()
    {
        var pedidos = await _pedidoRepository.ObterTodosAsync();

        return pedidos.Select(p => new PedidoOutputDto
        {
            Id = p.Id,
            CodigoExterno = p.CodigoExterno,
            DataCriacao = p.DataCriacao,
            Status = p.Status.ToString(),
            ValorTotal = p.ValorTotal,
            Produtos = p.Produtos.Select(prod => new ProdutoOutputDto
            {
                Nome = prod.Nome,
                PrecoUnitario = prod.PrecoUnitario,
                Quantidade = prod.Quantidade,
                Subtotal = prod.Subtotal
            }).ToList()
        }).ToList();
    }

    public async Task<PedidoOutputDto?> ObterPorIdAsync(Guid id)
    {
        var pedido = await _pedidoRepository.ObterPorIdAsync(id);
        if (pedido == null) return null;

        return new PedidoOutputDto
        {
            Id = pedido.Id,
            CodigoExterno = pedido.CodigoExterno,
            DataCriacao = pedido.DataCriacao,
            Status = pedido.Status.ToString(),
            ValorTotal = pedido.ValorTotal,
            Produtos = pedido.Produtos.Select(p => new ProdutoOutputDto
            {
                Nome = p.Nome,
                PrecoUnitario = p.PrecoUnitario,
                Quantidade = p.Quantidade,
                Subtotal = p.Subtotal
            }).ToList()
        };
    }
}
