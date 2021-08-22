using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TableDepBlazor.Data;
using TableDepBlazor.Entities;

namespace TableDepBlazor.Services
{
    public interface ICustomerService
    {
        public event CustomerDelegate OnCustomerChanged;
        Task<List<Customer>> GetCustomer();
    }
}
