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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DbrtContext _dbrtContext;

        public CustomerRepository(DbrtContext dbrtContext)
        {
            _dbrtContext = dbrtContext;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _dbrtContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerByPhoneNumberAsync(string phoneNumber)
        {
            return await _dbrtContext.Customers.FirstOrDefaultAsync(c => c.PhoneNumber == phoneNumber);
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            _dbrtContext.Customers.Add(customer);
            await _dbrtContext.SaveChangesAsync();
            return customer;
        }
    }
}
