
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Reservations.Domain.Entities;
using Reservations.Domain.IRepositories;

namespace Reservations.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Persona_Controller : ControllerBase
    {
      private readonly IPersonasRepository _personasRepository;
      public Persona_Controller(IPersonasRepository personasRepository)
        {
            _personasRepository = personasRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetAllPersonas()
        {
            var personas = await _personasRepository.GetAllPersonasAsync();
            return Ok(personas);
        }
        [HttpPost("login")]
        public async Task<ActionResult<Persona>> LoginPersonas([FromBody] LoginRequest request)
        {
            var persona = await _personasRepository.LoginPersonasAsync(request.Email, request.Password);

            if (persona == null)
                return NotFound("Correo o contraseña incorrectos.");

            return Ok(persona);
        }
        [HttpPost("CreatePersona")]
        public async Task<IActionResult> CrearPersona([FromBody] Persona persona)
        {

            var nuevaPersona = await _personasRepository.CreatePersonaAsync(persona);
            if (nuevaPersona == null)
                return NotFound("No se creo el usuario");

            return Ok(nuevaPersona);

            
        }


    }
}
