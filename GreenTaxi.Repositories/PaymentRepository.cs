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
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DbrtContext _dbrtContext;

        public PaymentRepository(DbrtContext dbrtContext)
        {
            _dbrtContext = dbrtContext;
        }

        public async Task<Payment> CreatePaymentAsync(Payment payment)
        {
            _dbrtContext.Payments.Add(payment);
            await _dbrtContext.SaveChangesAsync();
            return payment;
        }

        public async Task<List<Payment>> GetPaymentsByBookingIdAsync(int bookingId)
        {
            return await _dbrtContext.Payments
                .Where(p => p.BookingId == bookingId)
                .ToListAsync();
        }
    }
}

