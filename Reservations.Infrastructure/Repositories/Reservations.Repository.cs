using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reservations.Domain.IRepositories;

using InfraReservations = Reservations.Infrastructure.Persistence.Models.Reservation;
using DomainReservations = Reservations.Domain.Entities.Reservations;
using InfraDbcontext = Reservations.Infrastructure.Persistence.Models.ApplicationDbContext;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;


namespace Reservations.Infrastructure.Repositories
{
    public class Reservations : IReservationRepository
    {
        private readonly InfraDbcontext _infraDbcontext;

        public Reservations(InfraDbcontext infraDbcontext)
        {
            _infraDbcontext = infraDbcontext;
        }
        public async Task<IEnumerable<DomainReservations?>> GetAllReservationsAsync(int ID)
        {
            return await _infraDbcontext.Reservations
                .Where(x => x.PersonId == ID && x.ReservationState=="A")
                .Select(X => new DomainReservations
                {
                    ReservationId = X.ReservationId,
                    PersonId = X.PersonId,
                    RoomId = X.RoomId,
                    EntryDate = X.EntryDate,
                    DepartureDate = X.DepartureDate,
                    AdultsNumber = X.AdultsNumber,
                    KidsNumber = X.KidsNumber,
                    TotalDaysReservation = X.TotalDaysReservation,
                    PriceForAdult = X.PriceForAdult,
                    PriceForKid = X.PriceForKid,
                    TotalPrice = X.TotalPrice,
                    CreationDate = X.CreationDate,
                    UpdateDate = X.UpdateDate,
                    ReservationState = X.ReservationState,
                }).ToListAsync();
                
        }
    }
}
