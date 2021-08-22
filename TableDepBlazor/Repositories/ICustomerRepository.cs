using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TableDepBlazor.Data;
using TableDepBlazor.Entities;

namespace TableDepBlazor.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomers();
    }

    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _context.Customer.ToListAsync(); ;
        }
    }
}
