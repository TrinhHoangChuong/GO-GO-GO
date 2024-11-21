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
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<Payment> CreatePaymentAsync(int bookingId, decimal amount)
        {
            var payment = new Payment
            {
                BookingId = bookingId,
                PaymentTime = DateTime.Now,
                Amount = amount
            };

            return await _paymentRepository.CreatePaymentAsync(payment);
        }
    }
}
