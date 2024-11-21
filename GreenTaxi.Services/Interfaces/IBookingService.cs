using GreenTaxi.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTaxi.Services.Interfaces
{
    public interface IBookingService
    {
        Task<Booking> CreateBookingAsync(int customerId, int driverId, string startLocation, string endLocation, decimal fare); 
        Task<List<Booking>> GetBookingsByCustomerIdAsync(int customerId); 
        Task<List<Booking>> GetBookingsByDriverIdAsync(int driverId); 
    }
}

