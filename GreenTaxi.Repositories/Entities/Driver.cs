using System;
using System.Collections.Generic;

namespace GreenTaxi.Repositories.Entities;

public partial class Driver
{
    public int DriverId { get; set; }

    public string Name { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public decimal? Rating { get; set; }

    public string VehicleType { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
