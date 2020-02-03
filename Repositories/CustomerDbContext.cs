using Microsoft.EntityFrameworkCore;
using Models;
using System;

namespace Repositories
{
    public class CustomerDbContext : DbContext
    {
        //public CustomerDbContext()
        //{
        //}

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
    }
}
