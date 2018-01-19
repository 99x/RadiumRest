using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RadiumRest;

namespace RadiumRest.Sample.Resources.Customer
{

    [RestResource("customers")]
    public class CustomerService : RestResourceHandler
    {

        [RestPath("GET", "/@id")]
        public CustomerModel GetCustomer(int id)
        {
            var customerRepository = new CustomerRepository();
            return customerRepository.GetCustomerById(id);
        }

        [RestPath("GET")]
        public List<CustomerModel> GetAllCustomers()
        {
            var customerRepository = new CustomerRepository();
            return customerRepository.GetAlCustomers();
        }

    }
}
