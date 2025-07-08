using System;
using System.Collections.Generic;

namespace Reservations.Infrastructure.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public int HotelId { get; set; }

    public int RoomNumber { get; set; }

    public int RoomCapacity { get; set; }

    public string RoomDescription { get; set; } = null!;

    public string RoomState { get; set; } = null!;

    public virtual Hotel Hotel { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
