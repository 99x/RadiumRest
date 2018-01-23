using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiumRest.Sample.CustomerMicroservice.Resources.Customer
{
    public class CustomerRepository
    {
        private List<CustomerModel> customers;

        public CustomerRepository()
        {
            this.customers = new List<CustomerModel>();
            loadDummyCustomers();
        }

        public List<CustomerModel> GetAlCustomers()
        {
            return this.customers;
        }

        public CustomerModel GetCustomerById(int id)
        {
            return this.customers.FirstOrDefault(c => c.Id == id);
        }

        private void loadDummyCustomers()
        {
            this.customers.Add(new CustomerModel(){
                Name = "A Regular Customer",
                Address = "600 Galle Road, Colombo",
                Age = 23,
                Id = 1
            });

            this.customers.Add(new CustomerModel()
            {
                Name = "A Regular Customer",
                Address = "600 Galle Road, Colombo",
                Age = 23,
                Id = 2
            });

            this.customers.Add(new CustomerModel()
            {
                Name = "A Regular Customer",
                Address = "600 Galle Road, Colombo",
                Age = 23,
                Id = 3
            });
        }
    }
}
