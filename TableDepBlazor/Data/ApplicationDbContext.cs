using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TableDepBlazor.Entities;

namespace TableDepBlazor.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(new Customer {  Id=1, Name="Bahadir", Surname= "Yalcin"});
            modelBuilder.Entity<Customer>().HasData(new Customer { Id = 2, Name = "Marry", Surname = "Runner" });
            base.OnModelCreating(modelBuilder);
        }
    }
}
