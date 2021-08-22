using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TableDepBlazor.Data;
using TableDepBlazor.Entities;
using TableDepBlazor.Repositories;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.EventArgs;
using TableDependency.SqlClient.Base.Enums;
using Microsoft.EntityFrameworkCore;

namespace TableDepBlazor.Services
{
    public class CustomerService : ICustomerService, IDisposable
    {
       

        private const string TableName = "Customer";
        private SqlTableDependency<Customer> _notifier;
        private readonly IConfiguration _configuration;
        public event CustomerDelegate OnCustomerChanged;
        private readonly ICustomerRepository _customerRepository;
      

        public CustomerService(IConfiguration configuration, ICustomerRepository customerRepository)
        {
            _configuration = configuration;
            _customerRepository = customerRepository;
            _notifier = new SqlTableDependency<Customer>(_configuration["ConnectionStrings:DefaultConnection"], TableName);
            _notifier.OnChanged += TableDependency_Changed;
            _notifier.Start();

        }



        private void TableDependency_Changed(object sender, RecordChangedEventArgs<Customer> e)
        {
            if (OnCustomerChanged is not null)
            {
                OnCustomerChanged(this, new CustomerChangeEventArgs(e.Entity, e.EntityOldValues));


            }
            //if (e.ChangeType != ChangeType.None)
            //{
            //    OnCustomerChanged(this, new CustomerChangeEventArgs(e.Entity, e.EntityOldValues));
            //}
        }

  

        public async Task<List<Customer>> GetCustomer()
        {
            var result = await _customerRepository.GetCustomers();
          
            return result;
        }

        public void Dispose()
        {
            _notifier.Stop();
            _notifier.Dispose();
        }
    }
}
