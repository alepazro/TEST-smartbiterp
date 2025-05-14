using Microsoft.AspNetCore.Mvc;
using FinanzasPersonales.Application.Interfaces;
using FinanzasPersonales.Application.DTOs;

namespace FinanzasPersonales.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistroGastoController : ControllerBase
    {
        private readonly IRegistroGastoService _registroGastoService;

        public RegistroGastoController(IRegistroGastoService registroGastoService)
        {
            _registroGastoService = registroGastoService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var registro = await _registroGastoService.GetByIdAsync(id);
            if (registro == null)
                return NotFound();

            return Ok(registro);
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> GetByUsuario(int usuarioId)
        {
            var registros = await _registroGastoService.GetByUsuarioAsync(usuarioId);
            return Ok(registros);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegistroGastoConDetallesDTO dto)
        {
            if (dto.Registro == null || dto.Detalles == null)
                return BadRequest("Registro y Detalles son requeridos");

            await _registroGastoService.AddAsync(dto.Registro, dto.Detalles);
            return Ok();
        }
    }

    // DTO auxiliar para manejar la creación con detalles
    public class RegistroGastoConDetallesDTO
    {
        public RegistroGastoDTO Registro { get; set; }
        public IEnumerable<DetalleGastoDTO> Detalles { get; set; }
    }
}
