using Microsoft.AspNetCore.Mvc;
using OrderService.Application.DTOs;
using OrderService.Application.Interfaces;

namespace OrderService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidoController : ControllerBase
{
    private readonly IPedidoService _pedidoService;

    public PedidoController(IPedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }

    /// <summary>
    /// Recebe um novo pedido do sistema externo A.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CriarPedido([FromBody] PedidoInputDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var criado = await _pedidoService.CriarPedidoAsync(dto);

        if (!criado)
            return Conflict(new { mensagem = "Pedido já existe com esse CódigoExterno." });

        return CreatedAtAction(nameof(ObterPorCodigoExterno), new { codigoExterno = dto.CodigoExterno }, null);
    }

    /// <summary>
    /// Consulta um pedido pelo código externo.
    /// </summary>
    [HttpGet("{codigoExterno}")]
    public async Task<IActionResult> ObterPorCodigoExterno(string codigoExterno)
    {
        var pedido = await _pedidoService.ObterTodosAsync();
        var resultado = pedido.FirstOrDefault(p => p.CodigoExterno == codigoExterno);

        if (resultado == null)
            return NotFound();

        return Ok(resultado);
    }
}
