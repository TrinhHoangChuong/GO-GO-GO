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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Customer> RegisterAsync(string phoneNumber, string password, string name)
        {
            try
            {
                var existingCustomer = await _repository.GetCustomerByPhoneNumberAsync(phoneNumber);
                if (existingCustomer != null)
                {
                    throw new Exception("Số điện thoại đã tồn tại.");
                }

                var newCustomer = new Customer
                {
                    PhoneNumber = phoneNumber,
                    Password = password,
                    Name = name
                };

                return await _repository.AddCustomerAsync(newCustomer);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi đăng ký: {ex.Message}");
                throw;
            }
        }

        public async Task<Customer> LoginAsync(string phoneNumber, string password)
        {
            try
            {
                var customer = await _repository.GetCustomerByPhoneNumberAsync(phoneNumber);
                if (customer == null || customer.Password != password)
                {
                    throw new Exception("Sai mật khẩu hoặc số điện thoại.");
                }
                return customer;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi đăng nhập: {ex.Message}");
                throw;
            }
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            try
            {
                return await _repository.GetAllCustomersAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách khách hàng: {ex.Message}");
                throw;
            }
        }
    }
}
