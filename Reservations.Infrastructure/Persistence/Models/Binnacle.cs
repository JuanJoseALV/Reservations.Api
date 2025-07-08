using System;
using System.Collections.Generic;

namespace Reservations.Infrastructure.Persistence.Models;

public partial class Binnacle
{
    public int BinnacleId { get; set; }

    public int PersonId { get; set; }

    public string ActionPerformed { get; set; } = null!;

    public DateTime ActionDate { get; set; }

    public virtual Persona Person { get; set; } = null!;
}
