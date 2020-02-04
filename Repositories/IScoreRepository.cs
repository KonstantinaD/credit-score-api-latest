using Models;

namespace Repositories
{
    public interface IScoreRepository
    {
        void Add(Customer customer);

        Customer RetrieveByName(string name);

        public void UpdateCustomer(Customer customer);
    }
}
