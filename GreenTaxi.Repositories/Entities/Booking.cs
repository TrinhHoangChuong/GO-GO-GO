namespace GreenTaxi.Repositories.Entities
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public int DriverId { get; set; }
        public DateTime? BookingTime { get; set; }
        public string StartLocation { get; set; } = null!;
        public string EndLocation { get; set; } = null!;
        public decimal Fare { get; set; }
        public string? Status { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Driver Driver { get; set; } = null!;
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
