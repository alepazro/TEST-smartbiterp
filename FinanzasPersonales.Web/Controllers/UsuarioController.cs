using FinanzasPersonales.Application.Interfaces;
using FinanzasPersonales.Application.Services;
using FinanzasPersonales.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FinanzasPersonales.Web.Controllers
{
    // Se define la ruta para la API
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        // Inyectamos la interfaz IUsuarioService en el constructor
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // Endpoint para obtener todos los usuarios (GET)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _usuarioService.GetAllAsync();
            return Ok(usuarios); // Devolvemos los usuarios con un código HTTP 200
        }

        // Endpoint para obtener un usuario por ID (GET)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _usuarioService.GetByIdAsync(id);

            if (usuario == null)
            {
                return NotFound(); // Si no se encuentra el usuario, devolvemos un 404
            }

            return Ok(usuario); // Si se encuentra, devolvemos el usuario con un 200
        }

        // Endpoint para crear un nuevo usuario (POST)
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UsuarioDTO usuarioDto)
        {
            if (usuarioDto == null)
            {
                return BadRequest("Usuario no puede ser nulo."); // Validación de entrada
            }

            var nuevoUsuario = await _usuarioService.CreateAsync(usuarioDto);

            return CreatedAtAction(nameof(GetById), new { id = nuevoUsuario.Id }, nuevoUsuario);
            // Devuelve un código 201 con la ubicación del nuevo recurso creado
        }

        // Endpoint para actualizar un usuario (PUT)
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioDTO usuarioDto)
        {
            if (id != usuarioDto.Id)
            {
                return BadRequest("El ID del usuario no coincide con el ID del recurso a actualizar.");
            }

            var resultado = await _usuarioService.UpdateAsync(usuarioDto);

            if (resultado==null)
            {
                return NotFound(); // Si no se pudo actualizar, devolvemos un 404
            }

            return Ok(usuarioDto); //return NoContent(); // Si la actualización fue exitosa, devolvemos un 204 sin contenido
        }

        // Endpoint para eliminar un usuario (DELETE)
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _usuarioService.DeleteAsync(id);

            if (!resultado)
            {
                return NotFound(); // Si no se pudo eliminar, devolvemos un 404
            }

            return NoContent(); // Si la eliminación fue exitosa, devolvemos un 204 sin contenido
        }
    }
}
