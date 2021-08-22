using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TableDepBlazor.Entities;

namespace TableDepBlazor.Data
{
    public delegate void CustomerDelegate(object sender, CustomerChangeEventArgs args);
    public class CustomerChangeEventArgs :EventArgs
    {
        public Customer NewCustomer { get; }
        public Customer OldCustomer { get; }

        public CustomerChangeEventArgs(Customer newCustomer, Customer oldCustomer)
        {
            this.NewCustomer = newCustomer;
            this.OldCustomer = oldCustomer;
        }
    }
}
