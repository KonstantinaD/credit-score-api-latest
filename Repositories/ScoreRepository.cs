using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq;

namespace Repositories
{
    public class ScoreRepository : IScoreRepository
    {
        private readonly CustomerDbContext dbContext;

        public ScoreRepository(CustomerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Customer customer)
        {
            dbContext.Customers.Add(customer);

            dbContext.SaveChanges();
        }

        public Customer RetrieveByName(string name)
        {
            Customer customer = dbContext.Customers.AsNoTracking().ToList().Find(cmr => cmr.Name == name);

            return customer;
        }

        public void UpdateCustomer(Customer customer)
        {
            dbContext.Update(customer);

            dbContext.SaveChanges();
        }
    }
}
