using GreenTaxi.Repositories.Entities;
using GreenTaxi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTaxi.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DbrtContext _dbrtContext;

        public BookingRepository(DbrtContext dbrtContext)
        {
            _dbrtContext = dbrtContext;
        }

        public async Task<Booking> CreateBookingAsync(Booking booking)
        {
            _dbrtContext.Bookings.Add(booking);
            await _dbrtContext.SaveChangesAsync();
            return booking;
        }

        public async Task<List<Booking>> GetBookingsByCustomerIdAsync(int customerId)
        {
            return await _dbrtContext.Bookings
                .Where(b => b.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<Booking> GetBookingByIdAsync(int bookingId)
        {
            return await _dbrtContext.Bookings
                .FirstOrDefaultAsync(b => b.BookingId == bookingId);
        }

        public async Task<List<Booking>> GetBookingsByDriverIdAsync(int driverId)
        {
            return await _dbrtContext.Bookings
                .Where(b => b.DriverId == driverId)
                .ToListAsync();
        }
    }
}

