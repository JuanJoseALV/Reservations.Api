using System;
using System.Collections.Generic;

namespace Reservations.Infrastructure.Models;

public partial class Hotel
{
    public int HotelId { get; set; }

    public string HotelName { get; set; } = null!;

    public string HotelDirection { get; set; } = null!;

    public string? HotelNumber { get; set; }

    public decimal PriceForAdult { get; set; }

    public decimal PriceForKids { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
