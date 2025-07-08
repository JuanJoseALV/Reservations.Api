using System;
using System.Collections.Generic;

namespace Reservations.Infrastructure.Models;

public partial class Persona
{
    public int PersonId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordEmail { get; set; } = null!;

    public string Employee { get; set; } = null!;

    public string StatePerson { get; set; } = null!;

    public virtual ICollection<Binnacle> Binnacles { get; set; } = new List<Binnacle>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
