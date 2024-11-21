using GreenTaxi.Repositories.Entities;
using GreenTaxi.Repositories.Interfaces;
using GreenTaxi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTaxi.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<Booking> CreateBookingAsync(int customerId, int driverId, string startLocation, string endLocation, decimal fare)
        {
            try
            {
                // Tạo một đối tượng Booking mới
                var booking = new Booking
                {
                    CustomerId = customerId,
                    DriverId = driverId,
                    StartLocation = startLocation,
                    EndLocation = endLocation,
                    Fare = fare,
                    BookingTime = DateTime.Now,
                    Status = "Chưa giải quyết" // Trạng thái mặc định khi tạo mới booking
                };

                // Kiểm tra trạng thái có hợp lệ không
                var validStatuses = new List<string> { "Chưa giải quyết", "Đã hoàn thành", "Đã hủy" };
                if (!validStatuses.Contains(booking.Status))
                {
                    throw new Exception("Trạng thái đặt xe không hợp lệ.");
                }

                // Kiểm tra nếu trạng thái trống thì đặt giá trị mặc định
                if (string.IsNullOrWhiteSpace(booking.Status))
                {
                    booking.Status = "Chưa giải quyết";
                }

                // Tạo mới booking thông qua repository
                return await _bookingRepository.CreateBookingAsync(booking);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tạo đặt xe: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
                throw; // Rethrow exception for higher-level handling
            }
        }

        public async Task<List<Booking>> GetBookingsByCustomerIdAsync(int customerId)
        {
            try
            {
                return await _bookingRepository.GetBookingsByCustomerIdAsync(customerId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy thông tin đặt xe: {ex.Message}");
                throw;
            }
        }

        public async Task<List<Booking>> GetBookingsByDriverIdAsync(int driverId)
        {
            try
            {
                return await _bookingRepository.GetBookingsByDriverIdAsync(driverId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy thông tin đặt xe của tài xế: {ex.Message}");
                throw;
            }
        }
    }
}
