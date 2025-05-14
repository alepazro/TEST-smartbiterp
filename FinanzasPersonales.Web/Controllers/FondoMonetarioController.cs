using Microsoft.AspNetCore.Mvc;
using FinanzasPersonales.Application.Interfaces;
using FinanzasPersonales.Application.DTOs;

namespace FinanzasPersonales.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FondoMonetarioController : ControllerBase
    {
        private readonly IFondoMonetarioService _fondoService;

        public FondoMonetarioController(IFondoMonetarioService fondoService)
        {
            _fondoService = fondoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var fondos = await _fondoService.GetAllAsync();
            return Ok(fondos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var fondo = await _fondoService.GetByIdAsync(id);
            if (fondo == null)
                return NotFound();

            return Ok(fondo);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] FondoMonetarioDTO dto)
        {
            await _fondoService.AddAsync(dto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] FondoMonetarioDTO dto)
        {
            await _fondoService.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _fondoService.DeleteAsync(id);
            return Ok();
        }
    }
}
