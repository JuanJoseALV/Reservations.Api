using System.ComponentModel;
using Model = Reservations.Domain.Entities;

namespace Reservations.Domain.IRepositories;


public interface IReservationRepository
{
    Task<IEnumerable<Model.Reservations>>GetAllReservationsAsync(int ID);
}