using System;
using System.Collections.Generic;

namespace GreenTaxi.Repositories.Entities;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public decimal? WalletBalance { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
