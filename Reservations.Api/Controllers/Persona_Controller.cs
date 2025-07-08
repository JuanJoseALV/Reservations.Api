
using Microsoft.AspNetCore.Http.HttpResults;
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
    }
}
