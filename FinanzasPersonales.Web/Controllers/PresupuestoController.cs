using Microsoft.AspNetCore.Mvc;
using FinanzasPersonales.Application.Interfaces;
using FinanzasPersonales.Application.DTOs;

namespace FinanzasPersonales.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PresupuestoController : ControllerBase
    {
        private readonly IPresupuestoService _presupuestoService;

        public PresupuestoController(IPresupuestoService presupuestoService)
        {
            _presupuestoService = presupuestoService;
        }

        [HttpGet("{usuarioId}/{mes}")]
        public async Task<IActionResult> GetByUsuarioYMes(int usuarioId, int mes)
        {
            var presupuestos = await _presupuestoService.GetByUsuarioYMesAsync(usuarioId, mes);

            return Ok(presupuestos);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PresupuestoDTO dto)
        {
            await _presupuestoService.AddAsync(dto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PresupuestoDTO dto)
        {
            await _presupuestoService.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _presupuestoService.DeleteAsync(id);
            return Ok();
        }
    }
}
