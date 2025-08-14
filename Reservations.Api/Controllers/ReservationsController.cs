using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Reservations.Domain.IRepositories;
using Domain=Reservations.Domain.Entities;

namespace Reservations.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController:ControllerBase
    {
        private readonly IReservationRepository _reservationRepository;
        public ReservationsController (IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        [HttpGet("{ID}")]
        public async Task<ActionResult<IEnumerable<Domain.Entities.Reservations>>> GetAllReservations(int ID)
        {
            var reservations = await _reservationRepository.GetAllReservationsAsync(ID);
            if (reservations == null)
            
                return NotFound("El usuario no tiene reservaciones");
                return Ok(reservations);
            
            
        }
    }
}
