using GreenTaxi.Repositories.Entities;

namespace GreenTaxi.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking> CreateBookingAsync(Booking booking); 
        Task<List<Booking>> GetBookingsByCustomerIdAsync(int customerId); 
        Task<Booking> GetBookingByIdAsync(int bookingId); 
        Task<List<Booking>> GetBookingsByDriverIdAsync(int driverId); 
    }
}
