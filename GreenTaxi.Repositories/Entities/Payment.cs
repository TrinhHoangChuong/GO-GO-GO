namespace GreenTaxi.Repositories.Entities
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int BookingId { get; set; }
        public DateTime? PaymentTime { get; set; }
        public decimal Amount { get; set; }

        public virtual Booking Booking { get; set; } = null!;
    }
}
