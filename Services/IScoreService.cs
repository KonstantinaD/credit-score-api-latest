using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IScoreService
    {
        /*int for score*/ void AddCustomer(CustomerDto customerDto);

        CustomerDto RetrieveCustomerByName(string name);

        //CustomerDto RetrieveCustomerById(int id);

        //List<CustomerDto> RetrieveCustomers();

        public CustomerDto SaveCustomer(CustomerDto customerDto);
    }
}
