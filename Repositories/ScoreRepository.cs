using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class ScoreRepository : IScoreRepository
    {
        private CustomerDbContext dbContext;

        public ScoreRepository(CustomerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Customer customer)
        {
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
        }

        //public Customer RetrieveCustomerById(int id)
        //{
        //    Customer customer = dbContext.Customers.Find(id);

        //    return customer;
        //}

        public Customer RetrieveByName(string name)
        {
            Customer customer = dbContext.Customers.AsNoTracking().ToList().FindLast(cmr => cmr.Name == name); //Find

            return customer;
        }

        public void UpdateCustomer(Customer customer)
        {
            dbContext.Update(customer);
            dbContext.SaveChanges();
        }
    }
}
