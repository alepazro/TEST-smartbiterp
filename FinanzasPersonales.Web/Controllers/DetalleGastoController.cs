using Microsoft.AspNetCore.Mvc;
using FinanzasPersonales.Application.Interfaces;
using FinanzasPersonales.Application.DTOs;

namespace FinanzasPersonales.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetalleGastoController : ControllerBase
    {
        private readonly IDetalleGastoService _detalleService;

        public DetalleGastoController(IDetalleGastoService detalleService)
        {
            _detalleService = detalleService;
        }

        [HttpGet("registro/{registroId}")]
        public async Task<IActionResult> GetByRegistroId(int registroId)
        {
            var detalles = await _detalleService.GetByRegistroIdAsync(registroId);
            return Ok(detalles);
        }
    }
}
