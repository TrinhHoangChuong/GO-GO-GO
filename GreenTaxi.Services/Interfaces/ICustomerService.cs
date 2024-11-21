using GreenTaxi.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GreenTaxi.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> RegisterAsync(string phoneNumber, string password, string name);
        Task<Customer> LoginAsync(string phoneNumber, string password);
        Task<List<Customer>> GetAllCustomersAsync();
    }
}
