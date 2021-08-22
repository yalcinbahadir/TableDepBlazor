using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TableDepBlazor.Entities;
using TableDepBlazor.Repositories;
using TableDepBlazor.Services;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Enums;
using Microsoft.EntityFrameworkCore;

namespace TableDepBlazor.Pages
{
    public partial class Index
    {
        [Inject]
        public ICustomerService CustomerService { get; set; }
        public IList<Customer> Customers { get; set; } = new List<Customer>();
        protected override async Task OnInitializedAsync()
        {
            CustomerService.OnCustomerChanged += CustomerService_OnCustomerChanged;
            Customers =  await CustomerService.GetCustomer();
        }





        private async void CustomerService_OnCustomerChanged(object sender, Data.CustomerChangeEventArgs args)
        {
            var recordToupdate = this.Customers.FirstOrDefault(x => x.Id == args.NewCustomer.Id);
           
            if (recordToupdate is null)
            {
                this.Customers.Add(args.NewCustomer);
            }
            else
            {
                recordToupdate = args.NewCustomer;
            }
            Customers = await CustomerService.GetCustomer();
            await InvokeAsync(() => { base.StateHasChanged(); });
        }

        public void Dispose()
        {
            this.CustomerService.OnCustomerChanged += this.CustomerService_OnCustomerChanged;
        }
    }
}
