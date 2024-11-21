using GreenTaxi.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenTaxi.Repositories.Entities;

namespace GreenTaxi.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByPhoneNumberAsync(string phoneNumber);
        Task<Customer> AddCustomerAsync(Customer customer);
    }
}

