using Microsoft.AspNetCore.Mvc;
using FinanzasPersonales.Application.Interfaces;
using FinanzasPersonales.Application.DTOs;

namespace FinanzasPersonales.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepositoController : ControllerBase
    {
        private readonly IDepositoService _depositoService;

        public DepositoController(IDepositoService depositoService)
        {
            _depositoService = depositoService;
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> GetByUsuario(int usuarioId)
        {
            var depositos = await _depositoService.GetByUsuarioAsync(usuarioId);
            return Ok(depositos);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] DepositoDTO deposito)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _depositoService.AddAsync(deposito);
            return Ok(new { message = "Depósito registrado exitosamente" });
        }
    }
}
