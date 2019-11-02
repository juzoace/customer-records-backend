using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerCRUD.WebService.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 1,
                FirstName = "Uncle",
                LastName = "Bob",
                HairColour = "Black",
                Height = (decimal)1.8288,
                Weight = (decimal)50,
                DateOfBirth = new DateTime(1981, 07, 13)

            }, new Customer
            {
                CustomerId = 2,
                FirstName = "Jan",
                LastName = "Kirsten",
                HairColour = "Brown",
                Height = (decimal)1.8288,
                Weight = (decimal)50,
                DateOfBirth = new DateTime(1993, 07, 13)
            });;
        }
    }
}
