using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservations.Domain.Entities
{
    public class Reservations
    {
        public int ReservationId { get; set; }

        public int PersonId { get; set; }

        public int RoomId { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime DepartureDate { get; set; }

        public int AdultsNumber { get; set; }

        public int KidsNumber { get; set; }

        public int TotalDaysReservation { get; set; }

        public decimal PriceForAdult { get; set; }

        public decimal PriceForKid { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string ReservationState { get; set; } = null!;

    }
}
