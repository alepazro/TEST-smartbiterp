using FinanzasPersonales.Application.DTOs;
using FinanzasPersonales.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinanzasPersonales.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoGastoController : ControllerBase
    {
        private readonly ITipoGastoService _tipoGastoService;

        public TipoGastoController(ITipoGastoService tipoGastoService)
        {
            _tipoGastoService = tipoGastoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _tipoGastoService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tipo = await _tipoGastoService.GetByIdAsync(id);
            if (tipo == null)
                return NotFound();

            return Ok(tipo);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TipoGastoDTO dto)
        {
            await _tipoGastoService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TipoGastoDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch");

            await _tipoGastoService.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tipoGastoService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("next-codigo")]
        public async Task<IActionResult> GetNextCodigo()
        {
            var next = await _tipoGastoService.GetNextCodigoAsync();
            return Ok(next);
        }
    }
}
