using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservations.Domain.Entities
{
    public class Persona
    {
        public int PersonId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PasswordEmail { get; set; } = null!;

        public string Employee { get; set; } = null!;

        public string StatePerson { get; set; } = null!;
    }
}
