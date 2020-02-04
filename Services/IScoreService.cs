using System.Threading.Tasks;

namespace Services
{
    public interface IScoreService
    {
        public CustomerDto SaveCustomer(CustomerDto customerDto, Task<string> weather);

        CustomerDto RetrieveCustomerByName(string name);

        void AddCustomer(CustomerDto customerDto);

        public void EditCustomer(CustomerDto customerDto, Task<string> weather);      
    }
}
