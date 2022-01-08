using System.Collections;
using System.Collections.Generic;
using Data.admin;
using Domain.Entities;

namespace Application.admin
{
    public class CustomerManager
    {
        private readonly CustomerDal _customerDal;

        public CustomerManager(CustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        
        public IEnumerable<Customer> GetCustomers() => _customerDal.GetCustomers();
        public Customer GetCustomer(int customerId) => _customerDal.GetCustomer(customerId);
        public CustomerOrderMetaData LastOrderHrs(int customerId) => _customerDal.GetCustomerLastOrder(customerId);
    }
}